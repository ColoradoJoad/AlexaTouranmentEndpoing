using Slight.Alexa.Framework.Models.Responses;
using System.Collections.Generic;

namespace AlexaNextTournamentEndpoint.Helpers
{
    public static class ResponseHelper
    {
        public static SkillResponse GetPlainTextOutputSpeech(string text, bool endSession)
        {
            var innerResponse = new PlainTextOutputSpeech();
            innerResponse.Text = text;

            var response = new Response();
            response.ShouldEndSession = endSession;
            response.OutputSpeech = innerResponse;

            var skillResponse = new SkillResponse();
            skillResponse.Response = response;
            skillResponse.Version = "1.0";
            skillResponse.SessionAttributes = new Dictionary<string, object>();

            return skillResponse;
        }

        public static SkillResponse GetSSMLOutput(string text, bool endSession = false)
        {
            var innerResponse = new PlainTextOutputSpeech();
            innerResponse.Text = text;

            var response = new Response();
            response.ShouldEndSession = endSession;
            response.OutputSpeech = innerResponse;

            var skillResponse = new SkillResponse();
            skillResponse.Response = response;
            skillResponse.Version = "1.0";
            skillResponse.SessionAttributes = new Dictionary<string, object>();

            return skillResponse;
        }

        public static SkillResponse StopOutput()
        {
            var response = new Response();
            response.ShouldEndSession = true;

            var skillResponse = new SkillResponse();
            skillResponse.Response = response;
            skillResponse.Version = "1.0";
            skillResponse.SessionAttributes = new Dictionary<string, object>();

            return skillResponse;
        }

        public static void AddCard(SkillResponse _response, string _title, string _text)
        {
            SimpleCard card = new SimpleCard()
            {
                Title = _title,
                Content = _text
            };

            _response.Response.Card = card;
        }
    }
}
