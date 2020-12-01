using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;
using Wkhtmltopdf.Core.Image.Converters.Interfaces;
using Wkhtmltopdf.Core.Converters;
using Wkhtmltopdf.Core.Enums;
using Wkhtmltopdf.Core.Services.Interfaces;
using Wkhtmltopdf.Core.Image.Options;

[assembly: InternalsVisibleTo("WkHtmlWrapper")]
[assembly: InternalsVisibleTo("WkHtmlWrapper.UnitTests")]
namespace Wkhtmltopdf.Core.Image.Converters
{
    public class HtmlToImageConverter : Converter<GeneralImageOptions>, IHtmlToImageConverter
    {

        internal HtmlToImageConverter(IProcessService processService, ILogger<HtmlToImageConverter> logger) : base(processService, logger)
        {
            ConverterType = ConverterType.Image;
        }
    }
}
