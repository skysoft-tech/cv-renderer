using SkySoft.CvRenderer.Models;

namespace SkySoft.CvRenderer.Utils.JsonHelpers
{
    internal class GetCvOptions
    {
        private readonly int _width;
        private readonly bool _hideLogo;

        internal GetCvOptions(int width, bool hideLogo)
        {
            _width = width;
            _hideLogo = hideLogo;
        }

        public CvOptions BuildOptions()
        {
            var DefaultWidthValue = 60;

            if (_width != 0)
            {
                DefaultWidthValue = _width;
            }

            return new CvOptions
            {
                WorkColumnWidth = DefaultWidthValue,
                HideLogo = _hideLogo,
            };
        }
    }
}
