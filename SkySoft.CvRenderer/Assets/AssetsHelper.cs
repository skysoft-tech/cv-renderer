using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SkySoft.CvRenderer.Assets
{
    public static class AssetsHelper
    { 
        public static Stream? ReadResourceStream(string fileName)
        {
            var namespaceName = fileName
                .Replace("/", ".")
                .Replace("/", ".");

            var assembly = typeof(AssetsHelper).Assembly;

            return ReadResource(assembly, namespaceName);
        }

        public static byte[] ReadResourceBytes(string fileName)
        {
            using var stream = ReadResourceStream(fileName);
            using var memoryStream = new MemoryStream();

            if (stream is null)
            {
                throw new FileNotFoundException($"Resource [{fileName}] not found");
            }

            stream.CopyTo(memoryStream);

            return memoryStream.ToArray();
        }

        /// <summary>
        /// Read embedded resource as Stream.
        /// </summary>
        private static Stream? ReadResource(Assembly assembly, string fileName)
        {
            var assemblyName = assembly.GetName().Name;

            var resourcePath = $"{assemblyName}.{fileName}";

            return assembly.GetManifestResourceStream(resourcePath);
        }
    }
}
