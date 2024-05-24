using Newtonsoft.Json;
using System.Globalization;

namespace SkySoft.CvRenderer.Utils.JsonHelpers
{
    // source: https://stackoverflow.com/a/51319347
    public class MultiFormatDateConverter : JsonConverter
    {
        public List<string> DateTimeFormats { get; set; } = new List<string>
        {
            "yyyy", "MM/yyyy", "DD/MM/yyyy", "dd-MM-yyyy"
        };

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime) || objectType == typeof(DateTime?);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var dateString = reader.Value as string;
            if (string.IsNullOrWhiteSpace(dateString))
            {
                if (objectType == typeof(DateTime?))
                    return null;

                throw new JsonException("Unable to parse null as a date.");
            }

            DateTime date;

            if (DateTime.TryParse(dateString, out date))
            {
                return date;
            }

            foreach (string format in DateTimeFormats)
            {
                // adjust this as necessary to fit your needs
                if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    return date;
                }
            }

            throw new JsonException("Unable to parse \"" + dateString + "\" as a date.");
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
