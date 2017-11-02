using Autofac;
using BaltLogger.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading.Tasks;

namespace BaltLogger.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadInstalledModules(this IServiceCollection services, string contentRootPath)
        {
            var plugins = new List<PluginInfo>();
            var pluginsRootFolder = new DirectoryInfo(Path.Combine(contentRootPath, "Plugins"));
            var pluginsFolders = pluginsRootFolder.GetDirectories();

            foreach (var pluginFolder in pluginsFolders)
            {
                var binFolder = new DirectoryInfo(Path.Combine(pluginFolder.FullName, "bin"));
                if (!binFolder.Exists)
                {
                    continue;
                }

                foreach (var file in binFolder.GetFileSystemInfos("*.dll", SearchOption.AllDirectories))
                {
                    Assembly assembly;
                    try
                    {
                        assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(file.FullName);
                    }
                    catch (FileLoadException)
                    {
                        // Get loaded assembly
                        assembly = Assembly.Load(new AssemblyName(Path.GetFileNameWithoutExtension(file.Name)));

                        if (assembly == null)
                        {
                            throw;
                        }
                    }

                    if (assembly.FullName.Contains(pluginFolder.Name))
                    {
                        plugins.Add(new PluginInfo
                        {
                            Name = pluginFolder.Name,
                            Assembly = assembly,
                            Path = pluginFolder.FullName
                        });
                    }
                }
            }

            GlobalConfiguration.Plugins = plugins;
            return services;
        }
    }
}
