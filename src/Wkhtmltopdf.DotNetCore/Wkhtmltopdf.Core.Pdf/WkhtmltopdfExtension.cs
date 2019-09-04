

using Microsoft.Extensions.DependencyInjection;
using Wkhtmltopdf.Core.Extensions;
using Wkhtmltopdf.Core.Pdf.Converters;
using Wkhtmltopdf.Core.Pdf.Converters.Interfaces;
using Wkhtmltopdf.Core.Services.Interfaces;

namespace Wkhtmltopdf.Core.Pdf
{
    public static class WkhtmltopdfExtension
    {
        public static IServiceCollection AddWkHtml2PdfConverter(this IServiceCollection services)
        {
            services.AddProcessService();
            services.AddScoped<IHtmlToPdfConverter, HtmlToPdfConverter>();
            return services;
        }
    }
    
}
