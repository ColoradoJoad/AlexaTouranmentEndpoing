using AlexaNextTournamentEndpoint.Constants;
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

                return TournamentHelper.GetTournamentResponse(t);
            }
            else
            {
                int nowMonth = m_ColoradoNow.Month;

                if (nowMonth > 4 && nowMonth < 8)
                {
                    _log.Log("No tournaments found (not in season).");
                    return ResponseHelper.GetPlainTextOutputSpeech(SpeechConstants.NoNextTournamentOutOfSeaon, true);
                }
                else
                {
                    _log.Log("No tournaments found.");
                    return ResponseHelper.GetPlainTextOutputSpeech(SpeechConstants.NoNextTournamentInSeason, true);
                }
            }
        }
    }
}
