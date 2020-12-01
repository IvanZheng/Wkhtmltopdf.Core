using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;
using Wkhtmltopdf.Core.Pdf.Converters.Interfaces;
using Wkhtmltopdf.Core.Pdf.Options;
using Wkhtmltopdf.Core.Converters;
using Wkhtmltopdf.Core.Enums;
using Wkhtmltopdf.Core.Services.Interfaces;

namespace Wkhtmltopdf.Core.Pdf.Converters
{
    public class HtmlToPdfConverter : Converter<GeneralPdfOptions>, IHtmlToPdfConverter
    {
        internal HtmlToPdfConverter(IProcessService processService, ILogger<HtmlToPdfConverter> logger) : base(processService, logger)
        {
            ConverterType = ConverterType.Pdf;
        }
    }
}
