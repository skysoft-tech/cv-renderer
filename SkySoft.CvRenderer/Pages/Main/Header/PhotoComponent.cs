using Microsoft.Extensions.Logging;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkiaSharp;
using System.Net;

namespace SkySoft.CvRenderer.Pages.Main.Header
{
    internal class PhotoComponent : IComponent
    {
        private readonly ILogger _logger;
        private readonly string _photo;

        public PhotoComponent(ILogger logger, string? photo)
        {
            _logger = logger;
            _photo = photo;
        }

        public void Compose(IContainer container)
        {
            container.Canvas(DrawPhoto);
        }

        private void DrawPhoto(SKCanvas canvas, Size availableSpace)
        {
            var clippingPath = new SKPath();
            clippingPath.AddCircle(availableSpace.Width / 2, availableSpace.Height / 2, availableSpace.Height / 2);

            // note: canvas.Restore doesn't work
            using (new SKAutoCanvasRestore(canvas))
            {
                canvas.ClipPath(clippingPath, antialias: true);

                var isPhotoLoaded = TryLoadPhoto(_photo, out var image);
                if (isPhotoLoaded)
                {
                    var destination = new SKRect(0, 0, availableSpace.Width, availableSpace.Height);

                    canvas.DrawBitmap(image, destination);
                }
                else
                {
                    DrawImagePlaceholder(canvas, availableSpace);
                }
            }
        }

        private bool TryLoadPhoto(string? photo, out SKBitmap? bitmap)
        {
            bitmap = default;
            
            if (string.IsNullOrWhiteSpace(photo))
            {
                _logger.LogError("Photo isn't provided");

                return false;
            }

            try
            {
                if (IsUrl(photo))
                {
                    bitmap = GetImageFromUrl(photo);
                }
                else
                {
                    bitmap = GetImageFromFile(photo);
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to load photo file [{photo}]", photo);

                return false;
            }
        }

        private SKBitmap? GetImageFromFile(string? photo)
        {
            if (!File.Exists(photo))
            {
                throw new FileNotFoundException();
            }

            using var stream = File.OpenRead(photo);

            return SKBitmap.Decode(stream);
        }


        private SKBitmap GetImageFromUrl(string photo)
        {
            using var client = new WebClient();
            using Stream stream = client.OpenRead(photo);

            return SKBitmap.Decode(stream);
        }

        private bool IsUrl(string? photo)
        {
            if (photo == null)
            {
                return false;
            }

            bool result = Uri.TryCreate(photo, UriKind.Absolute, out var uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            return result;
        }


        private void DrawImagePlaceholder(SKCanvas canvas, Size availableSpace)
        {
            var paint = new SKPaint();
            paint.Color = SKColors.LightGray;
            paint.Style = SKPaintStyle.Fill;

            canvas.DrawRect(0, 0, availableSpace.Width, availableSpace.Height, paint);
        }
    }
}
