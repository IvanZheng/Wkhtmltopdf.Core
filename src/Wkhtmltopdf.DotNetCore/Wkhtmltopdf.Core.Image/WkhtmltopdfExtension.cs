using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Wkhtmltopdf.Core.Extensions;
using Wkhtmltopdf.Core.Image.Converters;
using Wkhtmltopdf.Core.Image.Converters.Interfaces;

namespace Wkhtmltopdf.Core.Image
{
    public static class WkhtmltopdfExtension
    {
        public static IServiceCollection AddWkHtml2ImageConverter(this IServiceCollection services)
        {
            services.AddProcessService();
            services.AddScoped<IHtmlToImageConverter, HtmlToImageConverter>();
            return services;
        }
    }
    
}
