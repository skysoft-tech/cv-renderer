﻿using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using System.Text.Json.Serialization;

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

            var outputFileName = GetPdfName(input, output);
            var outputFile = File.OpenWrite(outputFileName);

            var renderer = new PdfRenderer(_logger, cv);
            await renderer.Render(outputFile);

            _logger.LogInformation("Created file: {outputFileName}", outputFileName);
        }

        private Task<string> ReadInput(string input)
        {
            return File.ReadAllTextAsync(input);
        }

        private CvModel DeserializeInput(string cvJson)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            options.Converters.Add(new JsonStringEnumConverter());

            var cv = JsonSerializer.Deserialize<CvModel>(cvJson, options);
            if (cv is null)
            {
                _logger.LogError("Failed to deserialize cv");

                throw new Exception();
            }

            return cv;
        }

        private string GetPdfName(string input, string output)
        {
            return output ?? input.Replace(".json", ".pdf");
        }
    }
}
