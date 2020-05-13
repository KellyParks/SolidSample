using System;

namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        public ConsoleLogger Logger { get; set; } = new ConsoleLogger();
        public FilePolicySource PolicySource { get; set; } = new FilePolicySource();
        public JsonPolicySerializer PolicySerializer { get; set; } = new JsonPolicySerializer();
        public decimal Rating { get; set; }
        public void Rate()
        {
            Logger.Log("Starting rate.");

            Logger.Log("Loading policy.");

            string policyJson = PolicySource.GetPolicyFromSource();

            var policy = PolicySerializer.GetPolicyFromJsonString(policyJson);

            var factory = new RaterFactory();

            var rater = factory.Create(policy, this);

            /*
             * This isn't exactly the original behaviour. The original behaviour was to output a log message if the policy type was unknown.
             * To log a message if it's not a known policy type, we could create an if statement for that...
            */

            //rater?.Rate(policy);


            /*
             * ...But type checking, even null checks, violates LSP.
             * To fix this, we can apply the Null Object Pattern, meaning we can create an 'Unknown' policy rater type.
             * The RaterFactory then returns this unknown policy type every time we don't find a matching policy type.
             */

            /*if (rater == null)
            {
                Logger.Log("Unknown policy type.");
            }
            else
            {
                rater.Rate(policy);
            }*/


            /*
             * Correct solution: Avoid type checking, and delegate (tell, don't ask) the unknown type error to the factory, which handles all the other types.
             * This reduces the complexity of Rate(), so it doesn't need to worry about nulls or other edge cases.
             */

            rater.Rate(policy);

            Logger.Log("Rating completed.");
        }
    }
}
