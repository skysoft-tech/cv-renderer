using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SkySoft.CvRenderer.Utils.JsonHelpers;

namespace SkySoft.CvRenderer.Utils.Deserialization
{
    public class Deserializer
    {
        private readonly ILogger _logger;

        public Deserializer(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public T DeserializeJson<T>(string cvJson)
        {
            if (string.IsNullOrEmpty(cvJson))
            {
                _logger.LogError("Input JSON string is null or empty");
                throw new ArgumentException("Input JSON string is null or empty", nameof(cvJson));
            }

            var options = new JsonSerializerSettings();

            options.Converters.Add(new StringEnumConverter());
            options.Converters.Add(new MultiFormatDateConverter());

            var cv = JsonConvert.DeserializeObject<T>(cvJson, options);

            if (cv is null)
            {
                _logger.LogError("Failed to deserialize cv");

                throw new Exception();
            }

            return cv;
        }
    }
}
