using System.Text.Json.Serialization;
using System.Text.Json;

namespace JetStreamBackend.Models
{
    public class JsonDateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string dateString = reader.GetString();

            if (string.IsNullOrEmpty(dateString))
            {
                // Gib das aktuelle Datum zurück, wenn kein gültiges Datum bereitgestellt wird
                return DateTime.Now;
            }

            return DateTime.Parse(dateString, null, System.Globalization.DateTimeStyles.RoundtripKind);
        }


        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("o")); // "o" für das Rundreiseformat
        }
    }

}
