using AlexaNextTournamentEndpoint.Helpers;
using AlexaNextTournamentEndpoint.Interfaces;
using AlexaNextTournamentEndpoint.Objects;
using Amazon.Lambda.Core;
using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlexaNextTournamentEndpoint.Handlers
{
    public class NextTournamentHandler : IAlexaHandler
    {
        private DateTime m_ColoradoNow;

        /// <summary>
        /// Normal Constructor
        /// </summary>
        public NextTournamentHandler()
        {
            m_ColoradoNow = DateTime.UtcNow.AddHours(-7);
        }

        /// <summary>
        /// Used for testing
        /// </summary>
        /// <param name="_specificDate"></param>
        public NextTournamentHandler(DateTime _specificDate)
        {
            m_ColoradoNow = _specificDate;
        }

        public SkillResponse HandleRequest(SkillRequest _request, ILambdaLogger _log)
        {
            _log.Log("Next Tournament Requested");

            List<Tournament> remaining = TournamentHelper.GetTournaments(m_ColoradoNow.Date, _log);

            if (remaining.Any())
            {
                _log.Log("Tournament Found");

                Tournament t = remaining.First();

                SkillResponse response = null;
                string cardTitle = $"{t.EventStart:MMMM} Tournament";
                string content = null;

                if (t.EventStart.Equals(t.EventEnd))
                {
                    content = $"Host - {t.Host}\nLocation - {t.Location}\nDate - {t.EventStart:MM/dd/yyyy}";
                    response = ResponseHelper.GetPlainTextOutputSpeech($"The next tournament is hosted by {t.Host} in {t.Location}.  It will be on {t.EventStart:m}.", true);
                }
                else
                {
                    content = $"Host - {t.Host}\nLocation - {t.Location}\nStart - {t.EventStart:MM/dd/yyyy}\nEnd - {t.EventEnd:MM/dd/yyyy}";
                    response = ResponseHelper.GetPlainTextOutputSpeech($"The next tournament is hosted by {t.Host} in {t.Location}.  It will start on {t.EventStart:m} and end on {t.EventEnd:m}.", true);
                }

                ResponseHelper.AddCard(response, cardTitle, content);
                return response;
            }
            else
            {
                int nowMonth = m_ColoradoNow.Month;

                if (nowMonth > 4 && nowMonth < 8)
                {
                    _log.Log("No tournaments found (not in season).");
                    return ResponseHelper.GetPlainTextOutputSpeech("The indoor season has ended.  Check back in August.");
                }
                else
                {
                    _log.Log("No tournaments found.");
                    return ResponseHelper.GetPlainTextOutputSpeech("I am not aware of any tournaments that have been scheduled.");
                }
            }
        }
    }
}
