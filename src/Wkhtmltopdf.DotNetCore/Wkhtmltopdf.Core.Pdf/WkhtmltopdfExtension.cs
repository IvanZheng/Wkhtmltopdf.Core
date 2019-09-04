

using Microsoft.Extensions.DependencyInjection;
using Wkhtmltopdf.Core.Pdf.Converters;
using Wkhtmltopdf.Core.Pdf.Converters.Interfaces;

namespace Wkhtmltopdf.Core.Pdf
{
    public static class WkhtmltopdfExtension
    {
        public static IServiceCollection AddWkHtml2PdfConverter(this IServiceCollection services)
        {
            services.AddScoped<IHtmlToPdfConverter, HtmlToPdfConverter>();
            return services;
        }
    }
    
}
