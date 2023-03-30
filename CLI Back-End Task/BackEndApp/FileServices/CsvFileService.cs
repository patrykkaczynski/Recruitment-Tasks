
using BackEndApp.DTOs;
using BackEndApp.NewtonsoftConverter;
using Newtonsoft.Json;

namespace BackEndApp.FileServices
{
    public sealed class CsvFileService : FileService
    {
        public CsvFileService(string[] args, string ageGt, string ageLt) : base(args, ageGt, ageLt)
        {

        }


    }
}
