using BackEndApp.DTOs;

namespace BackEndApp.FileServices
{
    public abstract class FileService
    {
        private static readonly HttpClient _httpClient = new();
        private string _url;
        protected List<InternDto> _listInterns;
        private protected string _fullPath;

        private protected string _selectedCommand;
        private protected int _ageGt;
        private protected int _ageLt;

        public FileService(string[] args, string ageGt, string ageLt)
        {
            _selectedCommand = args[0];
            _url = args[1];
            _fullPath = Path.Combine(CreateDirectory(), Path.GetFileName(_url));
            _ageGt = ParseToNumber(ageGt);
            _ageLt = ParseToNumber(ageLt);
            _listInterns = new();
        }

        private protected string CreateDirectory()
        {
            var directoryForDownloadedFiles = Path.Combine(Directory.GetCurrentDirectory(), "DownloadedFiles");

            if (!Directory.Exists(directoryForDownloadedFiles))
                Directory.CreateDirectory(directoryForDownloadedFiles);

            return directoryForDownloadedFiles;
        }

        private int ParseToNumber(string ageText)
        {
            int ageNumber;
            if(string.IsNullOrEmpty(ageText))
            {
                return 0;
            }

            ageNumber = int.Parse(ageText);

            return ageNumber;
        }

        public async Task WriteOutputResultAsync()
        {
            await DownloadAsync();

            await ParseAsync();

            var result = WriteOutputByCommand();

            Console.WriteLine(result);
        }

        private async Task DownloadAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(_url, HttpCompletionOption.ResponseHeadersRead);

                response.EnsureSuccessStatusCode();

                var stream = await response.Content.ReadAsStreamAsync();

                await using (var filestream = new FileStream(Path.Combine(_fullPath), FileMode.Create))
                {
                    await stream.CopyToAsync(filestream);
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Error: Cannot get file.");
            }
        }

        private protected async virtual Task ParseAsync()
        {
            try
            {
                string[] content = await File.ReadAllLinesAsync(_fullPath);

                for (int i = 1; i < content.Length; i++)
                {
                    var intern = new InternDto(content[i].Split(","));

                    _listInterns.Add(intern);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Cannot process the file.");
            }
        }

        private int WriteOutputByCommand()
        {
            int result = 0;

            if(_selectedCommand == "max-age")
            {
                result = _listInterns.Max(x => x.Age);
            }

            if(_selectedCommand == "count" && _ageGt > 0)
            {
                result = _listInterns.Where(x => x.Age > _ageGt).Count();
            }

            if(_selectedCommand == "count" && _ageLt > 0)
            {
                result = _listInterns.Where(x => x.Age < _ageLt).Count();
            }

            if (_selectedCommand == "count")
            {
                result = _listInterns.Count();
            }

            return result;
        }
   
    }
}
