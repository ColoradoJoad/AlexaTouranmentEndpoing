using AlexaNextTournamentEndpoint.Interfaces;
using Amazon.Lambda.Core;
using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;
using AlexaNextTournamentEndpoint.Helpers;

namespace AlexaNextTournamentEndpoint.Handlers
{
    public class StopHandler : IAlexaHandler
    {
        public SkillResponse HandleRequest(SkillRequest _request, ILambdaLogger _log)
        {
            return ResponseHelper.StopOutput();
        }
    }
}
