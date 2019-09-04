using System.Runtime.CompilerServices;
using Wkhtmltopdf.Core.Pdf.Converters.Interfaces;
using Wkhtmltopdf.Core.Pdf.Options;
using Wkhtmltopdf.Core.Converters;
using Wkhtmltopdf.Core.Enums;
using Wkhtmltopdf.Core.Services.Interfaces;

namespace Wkhtmltopdf.Core.Pdf.Converters
{
    public class HtmlToPdfConverter : Converter<GeneralPdfOptions>, IHtmlToPdfConverter
    {
        public HtmlToPdfConverter()
        {
            ConverterType = ConverterType.Pdf;
        }

        internal HtmlToPdfConverter(IProcessService processService) : base(processService)
        {
            ConverterType = ConverterType.Pdf;
        }
    }
}
