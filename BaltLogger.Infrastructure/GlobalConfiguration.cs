using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BaltLogger.Infrastructure
{
    public static class GlobalConfiguration
    {
        static GlobalConfiguration()
        {
            Plugins = new List<PluginInfo>();
        }

        public static IList<PluginInfo> Plugins { get; set; }

        public static string WebRootPath { get; set; }

        public static string ContentRootPath { get; set; }
    }

    public class PluginInfo
    {
        public string Name { get; set; }

        public Assembly Assembly { get; set; }

        public string ShortName
        {
            get
            {
                return Name.Split('.').Last();
            }
        }

        public string Path { get; set; }
    }
}
