using System;

namespace logger
{
    public class Logger : ILogger
    {
        String _databaseName;
        Database _db = null;

        public Logger(String databaseName)
        {
            this._databaseName = databaseName;
            OpenLog();
        }

        public void OpenLog()
        {
            this._db = new Database(this._databaseName);
            this._db.CreateDatabase();
        }

        public void CloseLog()
        {
            this._db.CloseDatabase();
        }

        public void Log(String logMessage)
        {
            DateTime utcTime = DateTime.UtcNow;
            this._db.WriteToDatabase(utcTime.ToString(), logMessage);
        }
    }
}