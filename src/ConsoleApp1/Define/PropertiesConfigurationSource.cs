using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Define
{
    public class PropertiesConfigurationSource : IConfigurationSource
    {

        string _path = string.Empty;
        public PropertiesConfigurationSource(string path)
        {
            this._path = path;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new PropertiesConfigurationProvider(_path);
        }
    }
}
