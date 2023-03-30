
using System.Globalization;

namespace BackEndApp.DTOs
{
    public class InternDto
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime InternshipStart { get; set; }
        public DateTime InternshipEnd { get; set; }

        public InternDto()
        {
            
        }

        public InternDto(string[] data)
        {
            Id = int.Parse(data[0]);
            Age = int.Parse(data[1]);
            Name = data[2];
            Email = data[3];
            InternshipStart = DateTime.ParseExact(data[4].TrimEnd('Z') ?? string.Empty, "yyyy-MM-dd'T'HH:mmzz", DateTimeFormatInfo.InvariantInfo);
            InternshipEnd = DateTime.ParseExact(data[5].TrimEnd('Z') ?? string.Empty, "yyyy-MM-dd'T'HH:mmzz", DateTimeFormatInfo.InvariantInfo);
        }
    }
}
