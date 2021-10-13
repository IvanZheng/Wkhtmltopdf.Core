namespace Wkhtmltopdf.Core.Options.Interfaces
{
    public interface IOptions
    {
        /// <summary>
        /// After timeout (milliseconds) process will be killed
        /// </summary>
        int Timeout { get; set; }
    }
}