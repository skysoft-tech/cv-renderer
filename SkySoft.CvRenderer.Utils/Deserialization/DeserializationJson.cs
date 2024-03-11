namespace SkySoft.CvRenderer.Utils.Deserialization
{
    public class DeserializationJson
    {
        private CvModel DeserializeInput(string cvJson)
        {
            var options = new JsonSerializerSettings();

            options.Converters.Add(new StringEnumConverter());
            options.Converters.Add(new MultiFormatDateConverter());

            var cv = JsonConvert.DeserializeObject<CvModel>(cvJson, options);
            if (cv is null)
            {
                _logger.LogError("Failed to deserialize cv");

                throw new Exception();
            }

            return cv;
        }
    }
}
