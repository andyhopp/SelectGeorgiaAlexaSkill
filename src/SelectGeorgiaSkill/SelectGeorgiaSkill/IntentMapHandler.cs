using Amazon.Lambda.Core;
using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelectGeorgiaSkill
{
    public class IntentMapHandler : IntentHandler
    {
        static readonly IDictionary<string, string> intentMap = new Dictionary<string, string> {
            { "WhyGeorgia", "The more you explore Georgia, the more you'll see why we've continuously ranked the top state for business. Global access via the world's most-traveled airport, the largest single-container port in the country, top-ranked workforce training programs and high-quality technical schools and universities are just a few reasons. Our competitive tax rates and business incentives, diverse talent pool and innovative spirit bring new businesses in, and help existing ones keep growing. The fact that there's a landscape for everyone - mountains to beaches and small towns to bustling cities - doesn't hurt, either." },
            { "AboutSchools", "In Georgia, you'll be close to some of the brightest minds in the world. Universities like Georgia Tech are internationally known for producing top tech and engineering talent. Georgia Tech also supports the innovation ecosystem by working with students and startups through their world-renowned incubator and accelerator programs. Companies can tap into this dynamic concentration of talent through partnership initiatives or direct hiring. Universities with incredible programs supporting our state's innovation ecosystem include the Georgia Institute of Technology, Emory University, Georgia State University, and Kennesaw State University." },
            { "Transportation", "Georgia's transportation infrastructure is one of our state's strongest competitive advantages. The world converges here through a network of air, land, and sea transport, and Georgia businesses experience growth through the power of accessibility. The most extensive rail system in the Southeast, the busiest airport in the world and the fastest-growing port in the nation provide direct connections to your people, your suppliers and your customers." },
            { "AboutGrid", "If your company needs a reliable source of energy that helps with your bottom line, you can count on Georgia Power to deliver. With almost 15,300 MW of generating capacity, representing a diverse mix of fuel sources, we’ll help your business stay ahead of the competition by connecting you to an abundant network of affordable power." },
            { "EnergyCost", "Adding to the already-low operating costs in Georgia, we offer rates below the national average with pricing programs to meet the changing needs of your business as it grows, such as marginally priced rates and real-time pricing options" },
            { "RenewableEnergy", "Georgia Power is on the forefront of cutting-edge research related to renewable energy. We stay focused on balancing environmental efficiency with our commitment to meeting the changing energy needs of our customers and offer energy solutions that stay clean, safe, reliable and affordable.  Our current mix of fuel sources includes hydro, solar and wind. Some of our recent developments in solar include, three 30 MW solar plants at Fort Benning, Stewart and Gordon, our first wholesale solar generation project in Dalton, Georgia, and nearly 500 new solar projects through our Advanced Solar Initiative." },
            { "AboutGeorgiaPower", "Georgia Power is our state’s largest utility, proudly serving more than 2.4 million fellow Georgians with safe, clean, affordable and reliable electricity every day. The Georgia Power corporate headquarters is located in the heart of downtown Atlanta, but our reach goes well beyond the city limits. We power more than 310,000 businesses and industries in 157 of Georgia’s 159 counties. The Georgia Power team is 9,000 employees strong, living and working in communities all over Georgia. Our goal as a company is to take care of those communities - because every town is our hometown." },
            { "SouthernCompanyTicker", "The Southern Company is listed in the New York Stock Exchange under the ticker symbol S.O." },
            { "SiteSelection", "You know your business better than anyone. So when it’s time for a new location or an expansion, you know what you’re looking for. Our experienced business recruitment experts are here to help you find it. We’ll use our deep knowledge of Georgia and relationships with statewide and local organizations to help you find a place where your company can reach its full potential. Working with our business recruitment team gives you confidential, streamlined access to a team of local site selection experts, including the Georgia Department of Economic Development. " },
            { "RecruitmentTeam", "The business recruitment team are resources that turn your vision for success into reality. They can give customized, research-based insights on workforce and local market evaluations, connections to local leaders and Georgia-based executives in your industry, find potential land or buildings that meet your requirements, and help with planning and coordination of a unique itinerary for your on-the-ground evaluations of Georgia." },
            { "RecruitmentTeamExperience", "Our business recruitment team has industry-specific knowledge and relationships in areas including automotive and aerospace manufacturing, data centers, corporate headquarters, and information technology." },
            { "Startups", "Atlanta's vibrant startup community is backed by sheer volume of talent and an unmatched entrepreneurial and collaborative spirit. Startups have unique opportunities to work alongside Georgia's high concentration of Fortune 1000 companies to develop technologies and products of the future. Signature startups like MailChimp and Kabbage continue to grow from their strong roots in Atlanta, while incubators and co-working spaces usher in the new crop, such as the Advanced Technology Development Center at Georgia Tech, TechStars Atlanta, Tech Square Labs, and the Center for Civic Innovation." },
            { "ATDC", "The Advanced Technology Development Center (ATDC) at Georgia Tech is Georgia’s technology incubator. Founded in 1980, ATDC has developed a global reputation for fostering technological entrepreneurship. Forbes named ATDC to its list of Incubators Changing the World in 2010 and 2013, alongside Y Combinator and the Palo Alto Research Center. You can learn more at their website at www. a.t.d.c .org." },
            { "TechStars", "Techstars Atlanta, in partnership with Cox Enterprises, is located in the epicenter of startup activity in the Southeast, providing entrepreneurs with the resources and network to build meaningful enterprise technology companies and enduring consumer brands. You can learn more at their website at www.techstarsatlanta.com." },
            { "TechSquare", "TechSquare Labs is a coworking space, a venture fund and a community. They are driven to work with tech entrepreneurs to build something from nothing. You can learn more at their website at www.techsquare.co." },
            { "CenterForCivicInnovation", "The Center for Civic Innovation is a community-driven space with a mission to inform, engage, connect, and empower people to shape the future of their city. Over the past two years, they have held over 50 programs and workshops with over 1,500 entrepreneurs and have helped facilitate over $100,000 in early stage investments to local social entrepreneurs. You can learn more at their website at www.civicatlanta.org." }
        };

        public override SkillResponse HandleIntent(SkillRequest request, ILambdaContext context)
        {
            var intentName = request.Request.Intent.Name;
            if (Environment.GetEnvironmentVariable("DEBUG") != default(string))
            {
                context.Logger.LogLine($"{nameof(IntentMapHandler)} - requested intent: {intentName}.");
            }
            string responseText = null;
            if (intentMap.TryGetValue(intentName, out responseText)) {
                return new SkillResponse
                {
                    Response = new Response()
                    {
                        OutputSpeech = new PlainTextOutputSpeech
                        {
                            Text = responseText
                        }
                    }
                };
            } else {
                context.Logger.LogLine($"Unrecognized intent: {intentName}");
                return new InvalidRequestHandler().HandleIntent(request, context);
            }
        }
    }
}
