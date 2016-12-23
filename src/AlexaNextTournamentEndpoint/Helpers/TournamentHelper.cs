using AlexaNextTournamentEndpoint.Objects;
using Amazon.Lambda.Core;
using Newtonsoft.Json;
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
            _logger.Log(json);

            List<Tournament> tournaments = JsonConvert.DeserializeObject<List<Tournament>>(json);
            return tournaments.Where(t => t.EventStart >= after).OrderBy(t => t.EventEnd).ToList();
        }
    }
}
