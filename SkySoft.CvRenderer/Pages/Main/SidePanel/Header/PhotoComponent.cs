﻿using Microsoft.Extensions.Logging;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkiaSharp;

namespace SkySoft.CvRenderer.Pages.Main.SidePanel
{
    internal class PhotoComponent : IComponent
    {
        private readonly ILogger _logger;
        private readonly IFileResolver _fileResolver;
        private readonly string? _photo;

        public PhotoComponent(ILogger logger, IFileResolver fileResolver, string? photo)
        {
            _logger = logger;
            _fileResolver = fileResolver;
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
                using var fileStream = _fileResolver.ResolveFile(photo);

                bitmap = SKBitmap.Decode(fileStream);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to load photo file [{photo}]", photo);

                return false;
            }
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
