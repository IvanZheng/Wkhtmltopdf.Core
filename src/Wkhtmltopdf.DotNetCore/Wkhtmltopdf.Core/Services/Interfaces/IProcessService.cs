using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Wkhtmltopdf.Core.Services.Interfaces
{
    public interface IProcessService
    {
        Task StartAsync(string filename, string arguments, int? milliseconds = null);
    }
}