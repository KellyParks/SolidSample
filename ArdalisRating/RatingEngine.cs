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

            /* If we wanted to add another policy type, like flood, we would need to 
             * add another case to this switch statement. That breaks the 'open/closed principle'
             * because then we are modifying the source code (closed = closed to modification). 
             * 
             * If we abstract the policy types away into their own classes, we can instantiate the 
             * appropriate rater based on the type. That still violates OCP, but it breaks the code
             * up enough that it's easier to work with (SRP). Then, to reach OCP, we need to further refactor
             * the RatingEngine class so that we've eliminated the need for the switch statement to be inside
             * RatingEngine. To do this, we can create a Factory, and put the switch statement inside
             * that factory.
             * 
             * Then we can apply OCP to the Factory itself by using reflection. This will mean we can remove
             * the switch statement altogether. 
             */

            var factory = new RaterFactory();
            var rater = factory.Create(policy, this);
            /* The Rate method is now closed to modification, but open to extension. We no longer need to change Rate() 
            in order to add support for new policy types. */
            rater?.Rate(policy);

            Logger.Log("Rating completed.");
        }
    }
}
