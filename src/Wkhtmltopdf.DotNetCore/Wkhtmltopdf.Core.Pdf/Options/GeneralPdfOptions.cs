using Wkhtmltopdf.Core.Pdf.Enums;
using Wkhtmltopdf.Core.Attributes;
using Wkhtmltopdf.Core.Options.Interfaces;

namespace Wkhtmltopdf.Core.Pdf.Options
{
    public class GeneralPdfOptions : IOptions
    {
        [ConsoleLineParameter("--dpi")]
        public int Dpi { get; set; } = 96;

        [ConsoleLineParameter("--grayscale")]
        public bool Grayscale { get; set; }

        [ConsoleLineParameter("--image-dpi")]
        public int ImageDpi { get; set; } = 600;

        [ConsoleLineParameter("--image-quality")]
        public int ImageQuality { get; set; } = 94;

        [ConsoleLineParameter("--lowquality")]
        public bool LowQuality { get; set; }

        [ConsoleLineParameter("--margin-bottom")]
        public int MarginBottom { get; set; }

        [ConsoleLineParameter("--margin-left")]
        public int MarginLeft { get; set; } = 10;

        [ConsoleLineParameter("--margin-right")]
        public int MarginRight { get; set; } = 10;

        [ConsoleLineParameter("--margin-top")]
        public int MarginTop { get; set; }

        [ConsoleLineParameter("--orientation")]
        public PageOrientation Orientation { get; set; } = PageOrientation.Portrait;

        [ConsoleLineParameter("--page-height")]
        public int PageHeight { get; set; }

        [ConsoleLineParameter("--page-size")]
        public PageSize PageSize { get; set; } = PageSize.A4;

        [ConsoleLineParameter("--page-width")]
        public int PageWidth { get; set; }

        [ConsoleLineParameter("--title")]
        public string Title { get; set; }

        [ConsoleLineParameter("--encoding")]
        public string Encoding { get; set; } = "utf8";
        /// <summary>
        ///  After timeout (milliseconds) process will be killed
        /// </summary>
        public int Timeout { get; set; }
    }
}