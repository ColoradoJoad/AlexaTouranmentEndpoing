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
    public class SpecificMonthHandler : IAlexaHandler
    {
        private DateTime m_ColoradoNow;

        /// <summary>
        /// Normal Constructor
        /// </summary>
        public SpecificMonthHandler()
        {
            m_ColoradoNow = DateTime.UtcNow.AddHours(-7);
        }

        /// <summary>
        /// Used for testing
        /// </summary>
        /// <param name="_specificDate"></param>
        public SpecificMonthHandler(DateTime _specificDate)
        {
            m_ColoradoNow = _specificDate;
        }

        public SkillResponse HandleRequest(SkillRequest _request, ILambdaLogger _log)
        {
            _log.Log("Spectific Month Tournament Requested");

            if (_request != null
                && _request.Request != null
                && _request.Request.Intent != null)
            {
                string month = _request.Request.Intent.Slots["MonthSlot"].Value;

                _log.Log($"{month} requested");

                if (!string.IsNullOrEmpty(month))
                {
                    int monthInt = DateHelper.GetMonth(month);

                    if (monthInt > 0)
                    {
                        List<Tournament> remaining = TournamentHelper.GetTournaments(m_ColoradoNow.Date, _log);

                        if (remaining != null)
                        {
                            Tournament tournament = remaining.Where(t => t.EventStart.Month == monthInt).FirstOrDefault();

                            if (tournament != null)
                            {
                                return TournamentHelper.GetTournamentResponse(tournament, month);
                            }
                        }

                        if (monthInt >= 5 && monthInt <= 9)
                        {
                            return ResponseHelper.GetPlainTextOutputSpeech($"No summer outdoor tournaments are currently scheduled.", true);
                        }
                        else
                        {
                            return ResponseHelper.GetPlainTextOutputSpeech($"The next {month} indoor tournament has not been posted yet.", true);
                        }
                    }
                }
            }

            return ResponseHelper.GetPlainTextOutputSpeech(SpeechConstants.NotSure, false);
        }
    }
}
