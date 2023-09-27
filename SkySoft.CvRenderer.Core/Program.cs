using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using SkySoft.CvRenderer.Core.Models;
using System.ComponentModel;
using System.Text.Json;
using WebApplicationPdf.Pages;

namespace SkySoft.CvRenderer.Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var fileContent = File.ReadAllText("C:\\WebApplicationPdf\\WebApplicationPdf\\SorseCV.json");
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            CvModel? cvModel = JsonSerializer.Deserialize<CvModel>(fileContent, options);

            Statement statement = new Statement(cvModel);
            statement.PageContainer();

        }
    }
}

