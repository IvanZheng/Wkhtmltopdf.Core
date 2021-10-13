using Wkhtmltopdf.Core.Options.Interfaces;
using Wkhtmltopdf.Core.Attributes;

namespace Wkhtmltopdf.Core.Image.Options
{
    public class GeneralImageOptions : IOptions
    {
        [ConsoleLineParameter("--crop-h")]
        public int CropH { get; set; }

        [ConsoleLineParameter("--crop-w")]
        public int CropW { get; set; }

        [ConsoleLineParameter("--crop-x")]
        public int CropX { get; set; }

        [ConsoleLineParameter("--crop-y")]
        public int CropY { get; set; }
        
        [ConsoleLineParameter("--height")]
        public int Height { get; set; }

        [ConsoleLineParameter("--quality")]
        public int Quality { get; set; } = 96;

        [ConsoleLineParameter("--transparent")]
        public bool Transparent { get; set; }

        [ConsoleLineParameter("--width")]
        public int Width { get; set; } = 1024;

        [ConsoleLineParameter("--zoom")]
        public float Zoom { get; set; } = 1;

        [ConsoleLineParameter("--encoding")]
        public string Encoding { get; set; } = "utf8";
        /// <summary>
        ///  After timeout (milliseconds) process will be killed
        /// </summary>
        public int Timeout { get; set; }
    }
}