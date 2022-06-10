using System;
using System.Linq;
using Newtonsoft.Json;
using OpenChargeMeteringFormat.Types;
using OpenChargeMeteringFormat.Util;

namespace OpenChargeMeteringFormat.Converters
{
    public class ReadingErrorFlagsConverter : JsonConverter<EReadingErrorFlag[]>
    {
        public override void WriteJson(JsonWriter writer, EReadingErrorFlag[] value, JsonSerializer serializer)
        {
            if (value == null)
            {
                return;
            }

            writer.WriteValue(string.Join("", value.Select(f => EnumExtensions.GetEnumMemberValue(f))));
        }

        public override EReadingErrorFlag[] ReadJson(
            JsonReader reader,
            Type objectType,
            EReadingErrorFlag[] existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            string input = (string)reader.Value;

            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            var readingErrorFlags = input.AsEnumerable()
                .Select(f => EnumExtensions.GetEnumByValue<EReadingErrorFlag>(f.ToString()))
                .ToArray();

            if (readingErrorFlags.Contains(null))
            {
                throw new JsonReaderException("The reading error flags contain invalid values.");
            }

            return readingErrorFlags
                .Cast<EReadingErrorFlag>()
                .ToArray();
        }
    }
}
