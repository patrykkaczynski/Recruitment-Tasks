
using System.IO.Compression;

namespace BackEndApp.FileServices
{
    public sealed class ZipFileService : FileService
    {
        public ZipFileService(string[] args, string ageGt, string ageLt) : base(args, ageGt, ageLt)
        {
        }

        private protected async override Task ParseAsync()
        {
            ZipFile.ExtractToDirectory(_fullPath, CreateDirectory(), true);
            _fullPath = Path.Combine(CreateDirectory(), "interns.csv");
            await base.ParseAsync();
        }
    }
}
