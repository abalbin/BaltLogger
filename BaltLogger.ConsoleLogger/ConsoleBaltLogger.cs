using BaltLogger.Interface;
using System;

namespace BaltLogger.ConsoleLogger
{
    public class ConsoleBaltLogger : IBaltLogger
    {
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
