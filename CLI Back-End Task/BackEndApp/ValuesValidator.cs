
namespace BackEndApp
{
    public class ValuesValidator
    {

        public static bool ValidateEnteredValues(string[] args, string? ageGt, string? ageLt)
        {
            if (args.Length < 2 || args.Length > 2)
            {
                Console.WriteLine("Error: Invalid command.");
                return false;
            }

            if (args.Length == 2 && args[0] != "count" && args[0] != "max-age")
            {
                Console.WriteLine("Error: Invalid command.");
                return false;
            }

            if (args.Length == 2
                && args[1] != @"https://fortedigital.github.io/Back-End-Internship-Task/interns.json"
                && args[1] != @"https://fortedigital.github.io/Back-End-Internship-Task/interns.csv"
                && args[1] != @"https://fortedigital.github.io/Back-End-Internship-Task/interns.zip"
                )
            {
                Console.WriteLine("Error: Invalid command.");
                return false;
            }

            if (args[0] == "max-age" && (ageGt != null || ageLt != null))
            {
                Console.WriteLine("Error: Invalid command.");
                return false;
            }

            if (!string.IsNullOrWhiteSpace(ageGt) && (!(int.TryParse(ageGt, out int result1)) || result1 < 0))
            {
                Console.WriteLine($"Error: Invalid command.");
                return false;
            }

            if (!string.IsNullOrWhiteSpace(ageLt) && (!(int.TryParse(ageLt, out int result2)) || result2 < 0))
            {
                Console.WriteLine($"Error: Invalid command.");
                return false;
            }

            if (!string.IsNullOrWhiteSpace(ageGt) && !string.IsNullOrWhiteSpace(ageLt))
            {
                Console.WriteLine($"Error: Invalid command.");
                return false;
            }

            return true;
        }
    }
}
