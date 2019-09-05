using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Wkhtmltopdf.Core.Converters.Interfaces;
using Wkhtmltopdf.Core.Enums;
using Wkhtmltopdf.Core.Options.Interfaces;
using Wkhtmltopdf.Core.Services;
using Wkhtmltopdf.Core.Services.Interfaces;
using Wkhtmltopdf.Core.Extensions;

namespace Wkhtmltopdf.Core.Converters
{
    public abstract class Converter<TOptions> : IConverter<TOptions> where TOptions: IOptions, new()
    {
        private static Dictionary<ConverterType, string> _executeFullPath = new Dictionary<ConverterType, string>();
        private readonly IProcessService _processService;

        protected ConverterType ConverterType;

        protected Converter()
        {
            _processService = new ProcessService();
        }

        public Converter(IProcessService processService)
        {
            this._processService = processService;
        }

        public async Task ConvertAsync(string html, string outputFile) =>
            await ConvertAsync(html, outputFile, new TOptions());

        public async Task ConvertAsync(string html, string outputFile, TOptions options) =>
            await ConvertAsync(new MemoryStream(Encoding.UTF8.GetBytes(html)), outputFile, options);

        public async Task ConvertAsync(Stream html, string outputFile) =>
            await ConvertAsync(html, outputFile, new TOptions());

        public async Task ConvertAsync(Stream html, string outputFile, TOptions options)
        {
            var inputFilePath = SaveFile(html);
            var arguments = $"{options.OptionsToCommandLineParameters()} {inputFilePath} {outputFile}";
            await _processService.StartAsync(GetExecutablePath(), arguments);
            File.Delete(inputFilePath);
        }
        


        private string GetExecutablePath()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                _executeFullPath.TryGetValue(ConverterType, out var path);
                if (string.IsNullOrEmpty(path))
                {
                    var fileName = GetExecutableName();
                    var is64 = IntPtr.Size == 8;
                    var baseUri = new Uri(Assembly.GetExecutingAssembly().GetName().EscapedCodeBase);
                    var baseDirectory = Path.GetDirectoryName(baseUri.LocalPath);
                    string dllDirectory;
                    path = Path.Combine(baseDirectory ?? throw new InvalidOperationException(), fileName);

                    if (!File.Exists(path))
                    {
                        dllDirectory = Path.Combine(baseDirectory,
                                                    is64
                                                        ? @"runtimes\win-x64\native"
                                                        : @"runtimes\win-x86\native");
                        path = Path.Combine(dllDirectory, fileName);
                    }

                    if (!File.Exists(path))
                    {
                        dllDirectory = Path.Combine(baseDirectory,
                                                    is64 ? "x64" : "x86");
                        path = Path.Combine(dllDirectory, fileName);
                    }
                    _executeFullPath[ConverterType] = path;
                }

                return path; //Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Executables", GetExecutableName());
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || 
                     RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                if (ConverterType == ConverterType.Image)
                {
                    return "wkhtmltoimage";
                }
                else
                {
                    return "wkhtmltopdf";
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private string GetExecutableName()
        {
            return ConverterType == ConverterType.Image ? "wkhtmltoimage.exe" : "wkhtmltopdf.exe";
        }

        private string SaveFile(Stream inputStream)
        {
            var temporaryFilePath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid():N}.html");
            using (var fileStream = new FileStream(temporaryFilePath, FileMode.CreateNew))
            {
                inputStream.CopyTo(fileStream);
            }
            return temporaryFilePath;
        }
    }
}