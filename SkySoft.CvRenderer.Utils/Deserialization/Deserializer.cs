using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SkySoft.CvRenderer.Utils.JsonHelpers;

namespace SkySoft.CvRenderer.Utils.Deserialization
{
    public class Deserializer
    {
        private readonly ILogger<Deserializer> _logger;

        public Deserializer(ILogger<Deserializer> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public T DeserializeJson<T>(string cvJson)
        {
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
