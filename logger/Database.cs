using System;
using System.Data.SQLite;

namespace logger
{
    public class Database
    {
        String _databaseName;
        SQLiteConnection _connection;

        public Database(String databaseName)
        {
            this._databaseName = databaseName;
            this._connection = new SQLiteConnection("data source=" + _databaseName);
        }

        public void CreateDatabase()
        {
            String createTableQuery = @"CREATE TABLE IF NOT EXISTS [LoggerTable] (
                                    [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                    [Key] NVARCHAR(2048)  NULL,
                                    [Value] VARCHAR(2048)  NULL
                                    )";

            SQLiteConnection.CreateFile(this._databaseName);
            using (SQLiteCommand command = new SQLiteCommand(this._connection))
            {
                this._connection.Open();

                command.CommandText = createTableQuery;
                command.ExecuteNonQuery();
            }
        }

        public void WriteToDatabase(String key, String value, Boolean flag = false)
        {
            using (SQLiteCommand command = new SQLiteCommand(this._connection))
            {
                command.CommandText = "INSERT INTO LoggerTable (Key,Value) Values ('" + key + "','" + value + "')";
                command.ExecuteNonQuery();

                command.CommandText = "Select * FROM LoggerTable";

                if (flag)
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["Key"] + " : " + reader["Value"]);
                        }
                    }
                }
            }
        }

        public void ReadDatabase()
        {
            using (SQLiteCommand command = new SQLiteCommand(this._connection))
            {
                command.CommandText = "Select * FROM LoggerTable";

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["Key"] + " : " + reader["Value"]);
                    }
                }
            }
        }

        public void CloseDatabase()
        {
            using (SQLiteCommand command = new SQLiteCommand(this._connection))
            {
                this._connection.Close();
            }
        }
    }
}