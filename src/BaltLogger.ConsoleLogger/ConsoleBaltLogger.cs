using BaltLogger.Interface;
using System;
using System.Composition;

namespace BaltLogger.ConsoleLogger
{
    [Export(typeof(IBaltLogger))]
    public class ConsoleBaltLogger : IBaltLogger
    {
        public string LoggerName => "Balt Console Logger";
        public bool Error(string message)
        {
            Console.WriteLine($"Error: {message}");
            return true;
        }

        public bool Success(string message)
        {
            Console.WriteLine($"Success: {message}");
            return true;
        }

        public bool Warning(string message)
        {
            Console.WriteLine($"Warning: {message}");
            return true;
        }
    }
}
