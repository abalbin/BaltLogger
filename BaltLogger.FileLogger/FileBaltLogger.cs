using BaltLogger.Interface;
using System;
using System.IO;

namespace BaltLogger.FileLogger
{
    public class FileBaltLogger : IBaltLogger
    {
        private string _path;
        private StreamWriter _file;

        public FileBaltLogger()
        {
            _path = @"logs";
            if(!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
            _file = new StreamWriter(Path.Combine(_path,"log.txt"), true);
        }

        public bool Error(string message)
        {
            using (_file)
            {
                _file.WriteLine($"Error: {message}");
            }
            return true;
        }

        public bool Success(string message)
        {
            throw new NotImplementedException();
        }

        public bool Warning(string message)
        {
            throw new NotImplementedException();
        }
    }
}
