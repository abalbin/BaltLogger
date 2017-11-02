using BaltLogger.Interface;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Composition.Convention;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace BaltLogger.ConsoleApp
{
    public class Program
    {
        //For unloading or loading dll's at runtime
        internal class CustomLoadContext : AssemblyLoadContext
        {
            protected override Assembly Load(AssemblyName assemblyName)
            {
                return Assembly.Load(assemblyName);
            }
        }

        [ImportMany]
        public IEnumerable<IBaltLogger> Loggers { get; set; }
        private void Compose()
        {
            var context = new CustomLoadContext();
            var assemblies = new List<Assembly>();
            var files = Directory.EnumerateFiles(@"plugins", "*.dll", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read);
                using (stream)
                {
                    byte[] data = new byte[stream.Length];
                    stream.Read(data, 0, data.Length);
                    var assembly = context.LoadFromStream(new MemoryStream(data));
                    assemblies.Add(assembly);
                }
            }

            var conventions = new ConventionBuilder();
            conventions
                .ForTypesDerivedFrom<IBaltLogger>()
                .Export<IBaltLogger>()
                .Shared();
            var configuration = new ContainerConfiguration()
                .WithAssemblies(assemblies, conventions);
            using (var container = configuration.CreateContainer())
            {
                Loggers = container.GetExports<IBaltLogger>();
            }
        }

        public void Run()
        {
            bool keepLoop = true;
            while (keepLoop)
            {
                Compose();
                Console.WriteLine("Plugged in loggers:");
                Console.WriteLine("===================");
                foreach (var logger in Loggers)
                {
                    Console.WriteLine($"- {logger.LoggerName}");
                }
                Console.WriteLine("Enter a message:");
                var message = Console.ReadLine();
                Console.WriteLine("Select type of message: (A: all, E: error, W: warning, S: success");
                var type = Console.ReadLine();
                foreach (var logger in Loggers)
                {
                    switch (type)
                    {
                        case "A":
                            LogError(logger, message);
                            break;

                    }
                }
                Console.WriteLine("");
                Console.WriteLine("End of the routine. Do you want to repeat one more time? (Y/N):");
                keepLoop = Console.ReadLine() == "Y";
            }

        }

        private void LogError(IBaltLogger logger, string message)
        {
            var result = logger.Error(message);
            Console.WriteLine($"Error log for {logger.LoggerName} - Status: {(result ? "Completed" : "Not Completed")}");
        }

        private void LogWarning(IBaltLogger logger, string message)
        {
            var result = logger.Warning(message);
            Console.WriteLine($"Warning log for {logger.LoggerName} - Status: {(result ? "Completed" : "Not Completed")}");
        }

        private void LogSuccess(IBaltLogger logger, string message)
        {
            var result = logger.Success(message);
            Console.WriteLine($"Success log for {logger.LoggerName} - Status: {(result ? "Completed" : "Not Completed")}");
        }

        static void Main(string[] args)
        {
            var program = new Program();
            program.Run();
        }
    }
}
