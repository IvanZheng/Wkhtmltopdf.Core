# Wkhtmltopdf.Core

Base on https://github.com/flopik3-5/WkHtmlWrapper and add linux support. 

On linux install wkhtmltopdf first as the following cmds
#
cd ~   
wget https://github.com/wkhtmltopdf/wkhtmltopdf/releases/download/0.12.3/wkhtmltox-0.12.3_linux-generic-amd64.tar.xz  
tar vxf wkhtmltox-0.12.3_linux-generic-amd64.tar.xz   
cp wkhtmltox/bin/wk* /usr/local/bin/  

#Sample Code  

         static async Task Main(string[] args)
         {
            var services = new ServiceCollection();
            services.AddWkHtml2ImageConverter();
            services.AddWkHtml2PdfConverter();
            using (var provider = services.BuildServiceProvider())
            {
                var html = "<html><body><h2>Hello World!</h2></body></html>";
                var imageConvertor = provider.GetService<IHtmlToImageConverter>();
                var pdfConvertor = provider.GetService<IHtmlToPdfConverter>();
                await pdfConvertor.ConvertAsync(html, "test.pdf", new GeneralPdfOptions{PageWidth = 750});
                await imageConvertor.ConvertAsync(html, "test.png", new GeneralImageOptions { Width = 750 });
            }
          }
