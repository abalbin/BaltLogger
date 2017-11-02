using System;

namespace BaltLogger.Interface
{
    public interface IBaltLogger
    {
        string LoggerName { get; }
        bool Error(string message);
        bool Warning(string message);
        bool Success(string message);
    }
}
