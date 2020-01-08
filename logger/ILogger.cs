using System;

namespace logger
{
    public interface ILogger
    {
        void OpenLog();
        void CloseLog();
        void Log(String logMessage);
    }
}