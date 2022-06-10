using System;
using Newtonsoft.Json;
using OpenChargeMeteringFormat.Types;
using OpenChargeMeteringFormat.Util;

namespace OpenChargeMeteringFormat.Converters
{
    public class TimeWithSynchronizationStateConverter : JsonConverter<TimeWithSynchronizationState>
    {
        private const string DATE_TIME_FORMAT = "yyyy-MM-dd'T'HH:mm:ss,fffzzz";

        public override void WriteJson(JsonWriter writer, TimeWithSynchronizationState value, JsonSerializer serializer)
        {
            writer.WriteValue($"{value.Timestamp.ToString(DATE_TIME_FORMAT)} {EnumExtensions.GetEnumMemberValue(value.SynchronizationState)}");
        }

        public override TimeWithSynchronizationState ReadJson(
            JsonReader reader,
            Type objectType,
            TimeWithSynchronizationState existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            string input = (string)reader.Value;

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new JsonReaderException("The time with synchronization state may not be null or white space.");
            }

            var parts = input.Split(' ');
            if (parts.Length != 2)
            {
                throw new JsonReaderException("The format of the time with synchronization state is invalid.");
            }

            if (!DateTimeOffset.TryParseExact(parts[0], DATE_TIME_FORMAT, null, System.Globalization.DateTimeStyles.None, out var time))
            {
                throw new JsonReaderException("The date time format is invalid.");
            }

            var synchronizationState = EnumExtensions.GetEnumByValue<ETimeSynchronizationState>(parts[1]);
            if (synchronizationState == null)
            {
                throw new JsonReaderException("The time synchronization state is not supported.");
            }

            return new TimeWithSynchronizationState
            {
                Timestamp = time,
                SynchronizationState = synchronizationState.Value,
            };
        }
    }
}
