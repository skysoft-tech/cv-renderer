using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace SkySoft.CvRenderer.Cli
{
    internal class Executor
    {
        ILogger _logger;

        public Executor(ILogger logger)
        {
            _logger = logger;
        }

        public async Task Run(string input, string output)
        {
            _logger.LogInformation("Render [{input}] to [{output}]", input, output);

            var cvJson = await ReadInput(input);

            _logger.LogDebug("Json: {cvJson}", cvJson);

            var cv = DeserializeInput(cvJson);
            
            var renderer = new PdfRenderer(cv);
            renderer.Render();
        }

        private Task<string> ReadInput(string input)
        {
            return File.ReadAllTextAsync(input);
        }

        private CvModel? DeserializeInput(string cvJson)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return JsonSerializer.Deserialize<CvModel>(cvJson, options);
        }
    }
}
