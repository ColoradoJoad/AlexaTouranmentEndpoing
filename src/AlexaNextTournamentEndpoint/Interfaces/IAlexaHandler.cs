using Amazon.Lambda.Core;
using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;

namespace AlexaNextTournamentEndpoint.Interfaces
{
    interface IAlexaHandler
    {
        SkillResponse HandleRequest(SkillRequest _request, ILambdaLogger _log);
    }
}
