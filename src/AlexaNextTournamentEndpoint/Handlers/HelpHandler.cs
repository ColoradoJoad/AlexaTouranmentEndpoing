using AlexaNextTournamentEndpoint.Interfaces;
using Amazon.Lambda.Core;
using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;
using AlexaNextTournamentEndpoint.Helpers;
using AlexaNextTournamentEndpoint.Constants;

namespace AlexaNextTournamentEndpoint.Handlers
{
    public class HelpHandler : IAlexaHandler
    {
        public SkillResponse HandleRequest(SkillRequest _request, ILambdaLogger _log)
        {
            return ResponseHelper.GetPlainTextOutputSpeech(SpeechConstants.HelpText, false);
        }
    }
}
