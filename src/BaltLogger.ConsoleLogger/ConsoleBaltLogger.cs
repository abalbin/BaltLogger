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
            try
            {
                Console.WriteLine($"Error: {message}");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Success(string message)
        {
            try
            {
                Console.WriteLine($"Success: {message}");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Warning(string message)
        {
            try
            {
                Console.WriteLine($"Warning: {message}");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
