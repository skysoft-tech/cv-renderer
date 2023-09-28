// See https://aka.ms/new-console-template for more information
using System.CommandLine;
using System.Text.Json;
using System.Diagnostics;
using SkySoft.CvRenderer.Core.Models;
using WebApplicationPdf.Pages;
namespace SkySoft.CvRenderer.Cli
{
    class Program
    {
        static  async Task<int> Main(string[] args)
        {
            var fileOption = new Option<string>(
                name: "--file",
                description: "Add a json file for deserialize");

            var directoryOption = new Option<string>(
                name: "--directory",
                description: "The way to save CV");

            var rootCommand = new RootCommand("JSON deserialize");
            rootCommand.AddOption(fileOption);
            rootCommand.AddOption(directoryOption);

            rootCommand.SetHandler(async (filePath, directoryPath) =>
            {
                var fileContent = await File.ReadAllTextAsync(/*filePath*/"C:\\WebApplicationPdf\\WebApplicationPdf\\SorseCV.json");
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                CvModel? cvModel = JsonSerializer.Deserialize<CvModel>(fileContent, options);
                PdfRenderer statement = new PdfRenderer(cvModel);
                statement.Render();

                Console.WriteLine($"Message = {await DisplayIntAndString(directoryPath)}");

                Process.Start("explorer.exe", filePath);

            }, fileOption, directoryOption);

            return await rootCommand.InvokeAsync(args);
        }

        public static async Task<string> DisplayIntAndString(string messageOptionValue)
        {
            var par = messageOptionValue;
            return par;
        }
    }
}

