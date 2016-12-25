using AlexaNextTournamentEndpoint.Objects;
using Amazon.Lambda.Core;
using Newtonsoft.Json;
using Slight.Alexa.Framework.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlexaNextTournamentEndpoint.Helpers
{
    public static class TournamentHelper
    {
        public static List<Tournament> GetTournaments(DateTime after, ILambdaLogger _logger)
        {
            string bucket = Environment.GetEnvironmentVariable("S3Bucket");
            string key = Environment.GetEnvironmentVariable("TournamentFileKey");
            string regionName = Environment.GetEnvironmentVariable("S3Region");

            _logger.Log($"{bucket}{key}@{regionName}");

            var task = S3Helper.ReadDocument(bucket, key, regionName);
            Task.WaitAll(task);

            string json = task.Result;
            _logger.Log("Tournaments loaded from S3");

            List<Tournament> tournaments = JsonConvert.DeserializeObject<List<Tournament>>(json);
            return tournaments.Where(t => t.EventStart >= after).OrderBy(t => t.EventEnd).ToList();
        }

        public static SkillResponse GetTournamentResponse(Tournament _tournament)
        {
            SkillResponse response = null;
            string cardTitle = $"{_tournament.EventStart:MMMM} Tournament";
            string content = null;

            if (_tournament.EventStart.Equals(_tournament.EventEnd))
            {
                content = $"Host - {_tournament.Host}\nLocation - {_tournament.Location}\nDate - {_tournament.EventStart:MM/dd/yyyy}";
                response = ResponseHelper.GetPlainTextOutputSpeech($"The next tournament is hosted by {_tournament.Host} in {_tournament.Location}.  It will be on {_tournament.EventStart:m}.", true);
            }
            else
            {
                content = $"Host - {_tournament.Host}\nLocation - {_tournament.Location}\nStart - {_tournament.EventStart:MM/dd/yyyy}\nEnd - {_tournament.EventEnd:MM/dd/yyyy}";
                response = ResponseHelper.GetPlainTextOutputSpeech($"The next tournament is hosted by {_tournament.Host} in {_tournament.Location}.  It will start on {_tournament.EventStart:m} and end on {_tournament.EventEnd:m}.", true);
            }

            ResponseHelper.AddCard(response, cardTitle, content);

            return response;
        }

        public static SkillResponse GetTournamentResponse(Tournament _tournament, string _month)
        {
            SkillResponse response = null;
            string cardTitle = $"{_tournament.EventStart:MMMM} Tournament";
            string content = null;

            if (_tournament.EventStart.Equals(_tournament.EventEnd))
            {
                content = $"Host - {_tournament.Host}\nLocation - {_tournament.Location}\nDate - {_tournament.EventStart:MM/dd/yyyy}";
                response = ResponseHelper.GetPlainTextOutputSpeech($"The next {_month} tournament is hosted by {_tournament.Host} in {_tournament.Location}.  It will be on {_tournament.EventStart:m}.", true);
            }
            else
            {
                content = $"Host - {_tournament.Host}\nLocation - {_tournament.Location}\nStart - {_tournament.EventStart:MM/dd/yyyy}\nEnd - {_tournament.EventEnd:MM/dd/yyyy}";
                response = ResponseHelper.GetPlainTextOutputSpeech($"The next {_month} tournament is hosted by {_tournament.Host} in {_tournament.Location}.  It will start on {_tournament.EventStart:m} and end on {_tournament.EventEnd:m}.", true);
            }

            ResponseHelper.AddCard(response, cardTitle, content);

            return response;
        }
    }
}
