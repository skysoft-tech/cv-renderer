//namespace SkySoft.CvRenderer.Api.Deserialization
//{
//public class DeserializeInputFile
//{
//    private readonly ILogger<DeserializeInputFile> _logger;

//    public DeserializeInputFile(ILogger<DeserializeInputFile> logger)
//    {
//        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
//    }

//public async Task<Stream> DeserializationAsync(Stream stream)
//{
//    _logger.LogInformation("Render [{input}]", _fileUploadModel.FilePath);

//    var cvJson = await ReadInputAsync(_fileUploadModel.FilePath);

//    var cv = DeserializeInput(cvJson);

//    _logger.LogDebug("Json: {cvJson}", cvJson);

//    var isResolved = TryResolveAbsPhotoPath(cv.Basics?.Image, _fileUploadModel.FilePath, out var absPhotoPath);
//    if (isResolved)
//    {
//        cv.Basics!.Image = absPhotoPath;
//    }

//    var renderer = new PdfRenderer(_logger, cv);

//    var outputStream = new MemoryStream();
//    await renderer.Render(outputStream, new CvRenderer.Models.CvOptions());

//    return outputStream;
//}

//public async Task DeserializationAsync(MemoryStream stream)
//{

//    var getFileFromApi = new GetFileFromApi(_file);
//    var stringFile = await getFileFromApi.ReadAsStringAsync();

//    //_logger.LogInformation("Render [{input}]", _fileUploadModel.FilePath);

//    var cvJson = await ReadInputAsync(stringFile);

//    var cv = DeserializeInput(cvJson);

//    _logger.LogDebug("Json: {cvJson}", cvJson);

//    var isResolved = TryResolveAbsPhotoPath(cv.Basics?.Image, stringFile, out var absPhotoPath);
//    if (isResolved)
//    {
//        cv.Basics!.Image = absPhotoPath;
//    }

//    var renderer = new PdfRenderer(_logger, cv);

//    await renderer.Render(stream, _cvOptions);
//}

//private Task<string> ReadInputAsync(Stream input)
//{
//    return File.ReadAllTextAsync();
//}

//        private CvModel DeserializeInput(string cvJson)
//        {
//            var options = new JsonSerializerSettings();

//            options.Converters.Add(new StringEnumConverter());
//            options.Converters.Add(new MultiFormatDateConverter());

//            var cv = JsonConvert.DeserializeObject<CvModel>(cvJson, options);
//            if (cv is null)
//            {
//                _logger.LogError("Failed to deserialize cv");

//                throw new Exception();
//            }

//            return cv;
//        }

//        private bool TryResolveAbsPhotoPath(string? photoPath, string input, out string? absPhotoPath)
//        {
//            absPhotoPath = null;
//            if (photoPath == null)
//            {
//                return false;
//            }

//            if (File.Exists(photoPath))
//            {
//                absPhotoPath = Path.GetFullPath(photoPath);

//                return true;
//            }

//            var jsonLocation = Path.GetDirectoryName(input);
//            if (jsonLocation == null)
//            {
//                return false;
//            }

//            var probablePhotoLocation = Path.Combine(jsonLocation, photoPath);
//            if (File.Exists(probablePhotoLocation))
//            {
//                absPhotoPath = Path.GetFullPath(probablePhotoLocation);

//                return true;
//            }

//            return false;
//        }
//    }
//}
