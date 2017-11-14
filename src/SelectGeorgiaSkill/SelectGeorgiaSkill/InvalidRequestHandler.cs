using Amazon.Lambda.Core;
using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;

namespace SelectGeorgiaSkill
{
    public class InvalidRequestHandler : IntentHandler
    {
        public override SkillResponse HandleIntent(SkillRequest request, ILambdaContext context)
        {
            return new SkillResponse
            {
                Response = new Response
                {
                    OutputSpeech = new PlainTextOutputSpeech
                    {
                        Text = "I'm sorry, I didn't understand that."
                    }
                }
            };
        }
    }
}
