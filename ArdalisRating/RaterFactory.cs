/* Instantiating the appropriate type of rater is now only the responsibility of this factory. */
using System;

namespace ArdalisRating
{
    public class RaterFactory
    {
        public Rater Create(Policy policy, RatingEngine engine)
        {
            /*switch (policy.Type)
            {
                case PolicyType.Auto:
                    return new AutoPolicyRater(engine, engine.Logger);

                case PolicyType.Land:
                    return new LandPolicyRater(engine, engine.Logger);

                case PolicyType.Life:
                    return new LifePolicyRater(engine, engine.Logger);

                case PolicyType.Flood:
                    return new FloodPolicyRater(engine, engine.Logger);

                default:
                    return new UnknownPolicyRater(engine, engine.Logger);
            }*/

            /* Removing the switch statement altogether would be nice to do, as it still seems like we're just moving the OCP violation, because we'd still need
             * to add another case to the switch statement if we wanted to add a new policy type. A switch statement also still feels like an LSP violation as well.
             * 
             * To apply OCP further to the factory, we can harness the naming convention of the Rater classes and use reflection to get the correct instance.
             */
            try
            {
                //use the naming convention to create the appropriate instance
                return (Rater)Activator.CreateInstance(
                    Type.GetType($"ArdalisRating.{policy.Type}PolicyRater"), new object[] { engine, engine.Logger });
            }
            catch
            {
                return null;
            }
        }

    }
}
