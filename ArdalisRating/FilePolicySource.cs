using System.IO;

/**
 * Instead of using low-level System.IO libraries throughout the code, just use it once in a simple class.
 * This helps facilitate the "tell, don't ask" delegation of SOLID design.
 */
namespace ArdalisRating
{
    public class FilePolicySource
    {
        public string GetPolicyFromSource()
        {
            return File.ReadAllText("policy.json");
        }
    }
}
