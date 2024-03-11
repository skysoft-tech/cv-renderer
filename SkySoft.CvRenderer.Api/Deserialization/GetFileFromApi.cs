//namespace SkySoft.CvRenderer.Api.Deserialization
//{
//    internal class GetFileFromApi
//    {
//        private readonly IFormFile _file;

//        public GetFileFromApi(IFormFile file)
//        {
//            _file = file;
//        }

//        public async Task<string> ReadAsStringAsync()
//        {
//            var result = new StringBuilder();
//            using (var reader = new StreamReader(_file.OpenReadStream()))
//            {
//                while (reader.Peek() >= 0)
//                    result.AppendLine(await reader.ReadLineAsync());
//            }
//            return result.ToString();
//        }
//    }
//}
