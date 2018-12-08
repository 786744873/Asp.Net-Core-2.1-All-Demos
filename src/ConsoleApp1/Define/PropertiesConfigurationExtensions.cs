using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Define
{
    public static class PropertiesConfigurationExtensions
    {
        public static IConfigurationBuilder AddPropertiesFile(this IConfigurationBuilder builder, string path)
        {
            builder.Add(new PropertiesConfigurationSource(path));
            return builder;
        }
    }
}
