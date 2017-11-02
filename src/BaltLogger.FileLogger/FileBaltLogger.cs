using BaltLogger.Interface;
using System;
using System.Composition;
using System.IO;

namespace BaltLogger.FileLogger
{
    [Export(typeof(IBaltLogger))]
    public class FileBaltLogger : IBaltLogger
    {
        private string _path;

        public FileBaltLogger()
        {
            _path = @"logs";
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
        }

        public string LoggerName => "Balt File System Logger";
        public bool Error(string message)
        {
            try
            {
                using (var file = new StreamWriter(Path.Combine(_path, "log.txt"), true))
                {
                    file.WriteLine($"Error: {message}");
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public bool Success(string message)
        {
            try
            {
                using (var file = new StreamWriter(Path.Combine(_path, "log.txt"), true))
                {
                    file.WriteLine($"Success: {message}");
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public bool Warning(string message)
        {
            try
            {
                using (var file = new StreamWriter(Path.Combine(_path, "log.txt"), true))
                {
                    file.WriteLine($"Warning: {message}");
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
