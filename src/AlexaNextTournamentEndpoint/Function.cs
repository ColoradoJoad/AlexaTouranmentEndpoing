using Amazon.Lambda.Core;
using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;
using AlexaNextTournamentEndpoint.Helpers;
using AlexaNextTournamentEndpoint.Interfaces;
using AlexaNextTournamentEndpoint.Handlers;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializerAttribute(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AlexaNextTournamentEndpoint
{
    public class Function
    {        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="_input"></param>
        /// <param name="_context"></param>
        /// <returns></returns>
        public SkillResponse FunctionHandler(SkillRequest _input, ILambdaContext _context)
        {
            var logger = _context.Logger;
            IAlexaHandler handler = null;

            if (_input.GetRequestType() == typeof(Slight.Alexa.Framework.Models.Requests.RequestTypes.ILaunchRequest))
            {
                logger.LogLine($"LaunchRequest made");
                handler = new WelcomeHandler();
            }
            else if (_input.GetRequestType() == typeof(Slight.Alexa.Framework.Models.Requests.RequestTypes.IIntentRequest))
            {
                string intentName = _input.Request.Intent.Name.ToLower();

                logger.LogLine($"Intent Requested {intentName}");

                switch (intentName)
                {
                    case "nexttournamentintent":
                        handler = new NextTournamentHandler();
                        break;
                    case "monthintent":
                        handler = new SpecificMonthHandler();
                        break;
                    case "amazon.helpintent":
                        handler = new HelpHandler();
                        break;
                    case "amazon.stopintent":
                        handler = new StopHandler();
                        break;
                }
            }

            if (handler == null)
            {
                handler = new UnknownHandler();
            }

            return handler.HandleRequest(_input, logger);
        }
    }
}
