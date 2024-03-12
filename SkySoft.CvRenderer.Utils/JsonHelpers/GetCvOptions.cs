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
            return new CvOptions
            {
                WorkColumnWidth = _width,
                HideLogo = _hideLogo,
            };
        }
    }
}
