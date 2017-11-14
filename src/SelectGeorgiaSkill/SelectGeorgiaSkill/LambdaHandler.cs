using System;
using Amazon.Lambda.Core;
using Slight.Alexa.Framework.Models.Responses;
using Slight.Alexa.Framework.Models.Requests;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace SelectGeorgiaSkill
{
    public class LambdaHandler
    {
        /// <summary>
        /// The entry point for the Lambda function
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public SkillResponse FunctionHandler(SkillRequest input, ILambdaContext context)
        {
            var serializer = new Newtonsoft.Json.JsonSerializer();

            if (Environment.GetEnvironmentVariable("DEBUG") != default(string))
            {
                context.Logger.LogLine("Received Request:");
                serializer.Serialize(Console.Out, input);
            }

            IntentHandler handler;
            if (input.Request.Type == "LaunchRequest")
            {
                handler = new WelcomeHandler();
            }
            else if (input.Request.Type == "SessionEndedRequest")
            {
                return null;
            }
            else
            {
                handler = new IntentMapHandler();
            }
            return handler?.HandleIntent(input, context);
        }
    }
}
