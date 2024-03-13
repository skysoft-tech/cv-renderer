using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Utils.JsonHelpers;

namespace SkySoft.CvRenderer.Utils.Deserialization
{
    internal class DeserializeInput
    {
        private readonly ILogger _logger;
        private readonly string _cvJson;

        internal DeserializeInput(ILogger logger, string cvJson)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _cvJson = cvJson ?? throw new ArgumentNullException(nameof(cvJson));
        }

        public CvModel DeserializeJson()
        {
            var options = new JsonSerializerSettings();
            options.Converters.Add(new StringEnumConverter());
            options.Converters.Add(new MultiFormatDateConverter());

            var cv = JsonConvert.DeserializeObject<CvModel>(_cvJson, options);

            if (cv is null)
            {
                _logger.LogError("Failed to deserialize cv");

                throw new Exception();
            }

            return cv;
        }
    }
}
