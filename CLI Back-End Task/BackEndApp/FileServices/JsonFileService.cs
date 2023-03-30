using BackEndApp.DTOs;
using BackEndApp.NewtonsoftConverter;
using Newtonsoft.Json;

namespace BackEndApp.FileServices
{
    public sealed class JsonFileService : FileService
    {
        public JsonFileService(string[] args, string ageGt, string ageLt) : base(args, ageGt, ageLt)
        {

        }

        private protected async override Task ParseAsync()
        {
            try
            {
                string content = await File.ReadAllTextAsync(_fullPath);

                _listInterns = JsonConvert.DeserializeObject<InternData>(content, new GeneralDateTimeNewtonsoftConverter()).Interns;

            }
            catch (Exception)
            { 
                Console.WriteLine("Error: Cannot process the file.");
            }

        }
    }
}
