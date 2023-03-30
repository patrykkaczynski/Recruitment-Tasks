using BackEndApp;
using BackEndApp.Factory;
using BackEndApp.FileServices;

class Program
{
    /// <summary>
    /// Command-line interface (CLI) application written in C# which downloads a file from a given URL using HTTP,&#xA;parses it and writes to standard output result of one of two commands: count or max-age.
    /// </summary>
    /// <example>fdfssfsfsfsfsfsdfsfsfsfsdfsdfsfsdf</example>
    /// <param name="args">1st argument: &#60;count&#62; or &#60;max-age&#62;&#xA;&#60;count&#62; - this command counts number of interns satisifing condition and writes it to standard output.&#xA;&#60;max-age&#62; - this command writes a maximum age of an intern to standard output. &#xA;2nd argument: &#60;url&#62;&#xA;For instance: https://fortedigital.github.io/Back-End-Internship-Task/interns.json</param>
    /// <param name="ageGt">Counts interns where age is greater than &#60;age&#62;, where &#60;age&#62; is an integer</param>
    /// <param name="ageLt">Counts interns where age is less than &#60;age&#62;, where &#60;age&#62; is an integer</param>

    static async Task Main(string[] args, string? ageGt = null, string? ageLt = null)
    {
        var result = ValuesValidator.ValidateEnteredValues(args, ageGt, ageLt);

        if(result == false)
        {
            return;
        }

        FileService file = FactoryFileService.Create(args, ageGt, ageLt);

        await file.WriteOutputResultAsync();

    }
}

