using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1.Define
{
    public class PropertiesConfigurationProvider:ConfigurationProvider
    {
        string _path = string.Empty;
        public PropertiesConfigurationProvider(string path)
        {
            this._path = path;
        }

        /// <summary>
        /// 用于解析1.properties
        /// </summary>
        public override void Load()
        {
            var lines = File.ReadAllLines(this._path);

            var dict = new Dictionary<string, string>();

            foreach (var line in lines)
            {
                var items = line.Split('=');
                dict.Add(items[0], items[1]);
            }

            this.Data = dict;
        }
    }
}
