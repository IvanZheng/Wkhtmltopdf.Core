using System.Diagnostics;
using System.Threading.Tasks;
using Wkhtmltopdf.Core.Services.Interfaces;

namespace Wkhtmltopdf.Core.Services
{
    internal class ProcessService : IProcessService
    {
        public async Task StartAsync(string filename, string arguments)
        {
            await Task.Run(() =>
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo(filename, arguments)
                    {
                        CreateNoWindow = true,
                        WindowStyle = ProcessWindowStyle.Hidden
                    }
                };

                process.Start();
                process.WaitForExit();
            });
        }
    }
}