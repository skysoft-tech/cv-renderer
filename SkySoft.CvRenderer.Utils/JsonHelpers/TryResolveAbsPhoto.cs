using SkySoft.CvRenderer.Core.Models;

namespace SkySoft.CvRenderer.Utils.JsonHelpers
{
    internal class TryResolveAbsPhoto
    {
        private readonly CvModel _cvModel;
        private readonly string _input;

        internal TryResolveAbsPhoto(CvModel cvModel, string input)
        {
            _cvModel = cvModel ?? throw new ArgumentNullException(nameof(cvModel));
            _input = input ?? throw new ArgumentNullException(nameof(cvModel));
        }

        public string TryResolvePhoto()
        {
            var isResolved = TryResolveAbsPhotoPath(_cvModel.Basics?.Image, _input, out var absPhotoPath);
            if (isResolved)
            {
                return absPhotoPath;
            }

            return _cvModel.Basics?.Image;
        }

        private bool TryResolveAbsPhotoPath(string? photoPath, string input, out string? absPhotoPath)
        {
            absPhotoPath = null;
            if (photoPath == null)
            {
                return false;
            }

            if (File.Exists(photoPath))
            {
                absPhotoPath = Path.GetFullPath(photoPath);

                return true;
            }

            var jsonLocation = Path.GetDirectoryName(input);
            if (jsonLocation == null)
            {
                return false;
            }

            var probablePhotoLocation = Path.Combine(jsonLocation, photoPath);
            if (File.Exists(probablePhotoLocation))
            {
                absPhotoPath = Path.GetFullPath(probablePhotoLocation);

                return true;
            }

            return false;
        }
    }
}
