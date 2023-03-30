using BackEndApp.FileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BackEndApp.Factory
{
    public class FactoryFileService
    {
        public static FileService Create(string[] args, string ageGt, string ageLt)
        {
            return args[1] switch
            {
                string s when s.Contains(".json") => new JsonFileService(args, ageGt, ageLt),
                string s when s.Contains(".csv") => new CsvFileService(args, ageGt, ageLt),
                string s when s.Contains(".zip") => new ZipFileService(args, ageGt, ageLt),
                _ => throw new Exception()
            };
        }
    }
}

