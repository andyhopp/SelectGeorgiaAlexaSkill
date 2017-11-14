using Amazon.Lambda.Core;
using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;

namespace SelectGeorgiaSkill
{
    public class WelcomeHandler : IntentHandler
    {
        public override SkillResponse HandleIntent(SkillRequest request, ILambdaContext context)
        {
            var greetings = new[] {
                "Hi! How can I help you learn about why Georgia is the best place to locate your company?",
                "Hello! What can I tell you about economic development in Georgia?",
                "Welcome! Let's get started. What questions do you have for me?",
            };

            var rng = new System.Random();
            var selectedGreeting = greetings[rng.Next(greetings.Length)];
            return new SkillResponse
            {
                Response = new Response()
                {
                    OutputSpeech = new PlainTextOutputSpeech
                    {
                        Text = selectedGreeting
                    }
                }
            };
        }
    }
}
