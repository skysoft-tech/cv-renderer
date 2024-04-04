using Grpc.Core;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Utils.Deserialization;
using SkySoft.CvRenderer.Api.ModelsApi;
using SkySoft.CvRenderer.Models;
using Google.Protobuf;
using SkySoftCvRendererApi;

namespace SkySoft.CvRenderer.Api.Services
{
    public class GreeterService : GenerateCvService.GenerateCvServiceBase
    {
        private readonly ILogger<GreeterService> _logger;
        private readonly CvCreator _cvCreator;
        private readonly Deserializer _deserializer;

        public GreeterService(ILogger<GreeterService> logger, Deserializer deserializer, CvCreator cvCreator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _deserializer = deserializer ?? throw new ArgumentNullException(nameof(deserializer));
            _cvCreator = cvCreator ?? throw new ArgumentNullException(nameof(cvCreator));
        }

        public override async Task DownloadCv(Request request, IServerStreamWriter<ChunkResponse> responseStream, ServerCallContext context)
        {
            _logger.LogInformation("Request [{request}]", request);

            var objectModel = RequestToObjectModel(request);

            var pdfStream = _cvCreator.FromModel(objectModel.CvModel, null, objectModel.CvOptions);

            await responseStream.WriteAsync(new ChunkResponse
            {
                FileName = "file",
                Chunk = await ByteString.FromStreamAsync(pdfStream)
            });
        }

        private ObjectModel RequestToObjectModel(Request request)
        {
            var cvModel = _deserializer.DeserializeJson<CvModel>(request.CvModels.JsonCv);

            var cvOptions = new CvOptions
            {
                WorkColumnWidth = request.CvOptions.WorkColumnWidth,
                HideLogo = request.CvOptions.HideLogo,
            };

            return new ObjectModel
            {
                CvModel = cvModel,
                CvOptions = cvOptions
            };
        }
    }
}