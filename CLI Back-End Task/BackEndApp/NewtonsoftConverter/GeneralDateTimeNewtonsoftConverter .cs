using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndApp.NewtonsoftConverter
{
    internal class GeneralDateTimeNewtonsoftConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var dataString = reader.Value as string;
            return DateTime.ParseExact(dataString.TrimEnd('Z') ?? string.Empty, "yyyy-MM-dd'T'HH:mmzz", DateTimeFormatInfo.InvariantInfo);
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
