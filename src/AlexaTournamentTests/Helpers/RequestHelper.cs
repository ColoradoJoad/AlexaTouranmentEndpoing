using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Requests.RequestTypes;

namespace AlexaTournamentTests.Helpers
{
    public static class RequestHelper
    {
        public static SkillRequest GetRequest(string _intent)
        {
            SkillRequest request = new SkillRequest();
            request.Request = new RequestBundle();
            request.Request.Intent = new Intent();
            request.Request.Intent.Name = _intent;

            return request;
        }
    }
}
