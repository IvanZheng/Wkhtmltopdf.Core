using System.Runtime.CompilerServices;
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
        public HtmlToImageConverter()
        {
            ConverterType = ConverterType.Image;
        }

        internal HtmlToImageConverter(IProcessService processService) : base(processService)
        {
            ConverterType = ConverterType.Image;
        }
    }
}
