using Wkhtmltopdf.Core.Pdf.Options;
using Wkhtmltopdf.Core.Converters.Interfaces;

namespace Wkhtmltopdf.Core.Pdf.Converters.Interfaces
{
    public interface IHtmlToPdfConverter : IConverter<GeneralPdfOptions>
    {
    }
}