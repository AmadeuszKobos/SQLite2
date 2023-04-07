using System;
using System.Data.SQLite;

namespace SQLite2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string BLUE = Console.IsOutputRedirected ? "" : "\x1b[94m";
            string NORMAL      = Console.IsOutputRedirected ? "" : "\x1b[39m";

            Database databaseObj = new Database();
            


            /* ADDING ROW TO DB */
            
            string query = "INSERT INTO 'Table' ('Name','Surname','Age') VALUES (@name, @surname, @age)";
            SQLiteCommand myInsert = new SQLiteCommand(query, databaseObj.conn);

            databaseObj.OpenConnection();//connect to db

            myInsert.Parameters.AddWithValue("@name", "Ronaldinho");
            myInsert.Parameters.AddWithValue("@surname", "Gaúcho");
            myInsert.Parameters.AddWithValue("@age", "18");

            var insertResult = myInsert.ExecuteNonQuery();
            Console.WriteLine("Rows added: {0}", insertResult);
            
            databaseObj.CloseConnection(); //end connection to db 

            /* ADDING ROW TO DB */



            /* TABLE SELECT */

            string query2 = "SELECT * FROM 'Table'";
            SQLiteCommand mySelect = new SQLiteCommand(query2, databaseObj.conn);


            databaseObj.OpenConnection(); //connect to db

            SQLiteDataReader selectResult = mySelect.ExecuteReader();


            if (selectResult.HasRows)
            {
                Console.WriteLine("Selected Rows");
                while (selectResult.Read())
                {
                    Console.Write($"  |  {BLUE}Name:{NORMAL} " + selectResult["Name"] + $"  |  {BLUE}Surname:{NORMAL}" + selectResult["Surname"] + $"  |  {BLUE}Age:{NORMAL} " + selectResult["Age"] + '\n');
                }
            }

            databaseObj.CloseConnection(); //end db connection

            /* TABLE SELECT */

            Console.ReadKey();


        }
    }
}