using System.Data;
using System.Data.SQLite;
using System.IO;

namespace SQLite2
{
    internal class Database
    {
        public SQLiteConnection conn; //connection to database

        public Database()
        {
            conn = new SQLiteConnection("Data Source=database.sqlite3");

            if (!File.Exists("./database.sqlite3"))
            {
                SQLiteConnection.CreateFile("database.sqlite3"); //if file named database.sqlite3 doesn't exist, we create one
                Console.WriteLine("Created database file");
            }
        }

        public void OpenConnection()
        {
            if(conn.State != ConnectionState.Open)
            { 
                conn.Open();
            }

        }
        public void CloseConnection()
        {
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }

    }
}
