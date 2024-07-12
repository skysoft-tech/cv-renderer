using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SkySoft.CvRenderer.Utils.JsonHelpers;

namespace SkySoft.CvRenderer.Utils.Deserialization
{
    public interface ICvDeserializer
    {
        T DeserializeCv<T>(string cvJson);
    }

    public class CvDeserializer : ICvDeserializer
    {
        public T DeserializeCv<T>(string cvJson)
        {
            return (T)DeserializeCv(cvJson, typeof(T));
        }

        public object DeserializeCv(string cvJson, Type type)
        {
            if (string.IsNullOrEmpty(cvJson))
            {
                throw new ArgumentException("Input JSON string is null or empty", nameof(cvJson));
            }

            var options = new JsonSerializerSettings();

            options.Converters.Add(new StringEnumConverter());
            options.Converters.Add(new MultiFormatDateConverter());
            options.Converters.Add(new NullFilteringListConverter());

            var cv = JsonConvert.DeserializeObject(cvJson, type, options);
            if (cv == null)
            {
                throw new Exception("Failed to deserialize CV");
            }

            return cv;
        }
    }
}
