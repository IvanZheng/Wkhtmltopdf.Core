using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Wkhtmltopdf.Core.Attributes;
using Wkhtmltopdf.Core.Options.Interfaces;
using Wkhtmltopdf.Core.Services;
using Wkhtmltopdf.Core.Services.Interfaces;

namespace Wkhtmltopdf.Core.Extensions
{
    public static class OptionsExtensions
    {
        public static IServiceCollection AddProcessService(this IServiceCollection services)
        {
            services.AddSingleton<IProcessService, ProcessService>();
            return services;
        }

        public static string OptionsToCommandLineParameters(this IOptions options)
        {
            var parameters = options.GetType().GetProperties()
                .Select(p => OptionsPropertyToCommandLineParameter(options, p));

            return string.Join(" ", parameters);
        }

        private static string OptionsPropertyToCommandLineParameter(IOptions options, PropertyInfo property)
        {
            var propertyName = property.GetCustomAttribute<ConsoleLineParameterAttribute>()?.ParameterName;
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                return string.Empty;
            }
            var (propertyValue, skipProperty) = OptionsPropertyValueToString(options, property);
            return skipProperty 
                ? string.Empty
                : $"{propertyName}{(string.IsNullOrEmpty(propertyValue) ? string.Empty : $" {propertyValue}")}";
        }

        private static (string val, bool skip) OptionsPropertyValueToString(IOptions options, PropertyInfo property)
        {
            switch (property.GetValue(options))
            {
                case int value:
                    return value == default ? (string.Empty, true) : (value.ToString(), false);
                case bool value:
                    return (string.Empty, !value);
                case object value:
                    return string.IsNullOrWhiteSpace(value.ToString())
                        ? (string.Empty, true)
                        : (value.ToString(), false);
            }
            return (string.Empty, true);
        }
    }
}