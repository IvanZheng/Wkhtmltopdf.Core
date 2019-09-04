using System;
using System.Runtime.CompilerServices;


namespace Wkhtmltopdf.Core.Attributes
{
    public class ConsoleLineParameterAttribute : Attribute
    {
        public string ParameterName { get; }

        public ConsoleLineParameterAttribute(string parameterName)
        {
            ParameterName = parameterName;
        }
    }
}