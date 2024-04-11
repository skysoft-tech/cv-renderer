using Grpc.Core;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Utils.Deserialization;
using SkySoft.CvRenderer.Api.ModelsApi;
using SkySoft.CvRenderer.Models;
using Google.Protobuf;
using SkySoftCvRendererApi;

namespace SkySoft.CvRenderer.Api.Services
{
    public class GreeterService(ILogger<GreeterService> logger, Deserializer deserializer, CvCreator cvCreator) : GenerateCvService.GenerateCvServiceBase
    {
        private readonly ILogger<GreeterService> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        private readonly CvCreator _cvCreator = cvCreator ?? throw new ArgumentNullException(nameof(cvCreator));
        private readonly Deserializer _deserializer = deserializer ?? throw new ArgumentNullException(nameof(deserializer));

        private Int32 chunkSize;
        private byte[]? buffer;

        public override async Task DownloadCv(Request request, IServerStreamWriter<ChunkResponse> responseStream, ServerCallContext context)
        {
            _logger.LogInformation("Request [{request}]", request);

            var objectModel = RequestToObjectModel(request);
            using var pdfStream = _cvCreator.FromModel(objectModel.CvModel, null, objectModel.CvOptions);

            chunkSize = 250 * 1024;
            buffer = new byte[chunkSize];

            while (await pdfStream.ReadAsync(buffer, 0, buffer.Length) != 0)
            {
                await responseStream.WriteAsync(new ChunkResponse
                {
                    Chunk = ByteString.CopyFrom(buffer)
                });
            }
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