using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Wkhtmltopdf.Core.Attributes;
using Wkhtmltopdf.Core.Image;
using Wkhtmltopdf.Core.Image.Converters.Interfaces;
using Wkhtmltopdf.Core.Image.Options;
using Wkhtmltopdf.Core.Pdf;
using Wkhtmltopdf.Core.Pdf.Converters.Interfaces;
using Wkhtmltopdf.Core.Pdf.Options;

namespace Tests
{
    public class ExtendGeneralImageOptions : GeneralImageOptions
    {
        [ConsoleLineParameter("--window-status")]
        public string WindowStatus { get; set; } = "ready_to_print";
    }
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddWkHtml2ImageConverter();
            services.AddWkHtml2PdfConverter();
            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var provider = scope.ServiceProvider;
                var html = await File.ReadAllTextAsync("demo.html");
                var imageConvertor = provider.GetService<IHtmlToImageConverter>();
                var pdfConvertor = provider.GetService<IHtmlToPdfConverter>();
                //await pdfConvertor.ConvertAsync(html, "test.pdf", new GeneralPdfOptions{PageWidth = 750});
                await imageConvertor.ConvertAsync(html, "test.png", new ExtendGeneralImageOptions { Width = 1020, Height = 1275, Timeout = 5000});
            }
        }
    }
}
