using Amazon.Lambda.Core;
using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;

namespace SelectGeorgiaSkill
{
    public abstract class IntentHandler
    {
        public abstract SkillResponse HandleIntent(SkillRequest request, ILambdaContext context);
    }
}
