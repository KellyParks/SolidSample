using System;

namespace ArdalisRating
{
    public class RaterFactory
    {
        public Rater Create(Policy policy, RatingEngine engine)
        {
            try
            {
                return (Rater)Activator.CreateInstance(
                    Type.GetType($"ArdalisRating.{policy.Type}PolicyRater"),
                        new object[] { engine, engine.Logger });
            }
            catch
            {
                /*
                 Now, under no conditions would it return null. This lets the behaviour of
                 what to do if no match is found be encapsulated in the Factory if no match is found.
                 */
                return new UnknownPolicyRater(engine, engine.Logger);
            }
        }
    }
}
