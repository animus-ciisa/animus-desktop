using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Data.SQLite;
using System.Configuration;
namespace Animus.DataAccess
{

    public class DaGenerateScript
    {

        SQLiteConnection sqliteConn;
        SQLiteCommand sqliteCmd;
        SQLiteDataReader sqliteDatareader;
        SQLiteTransaction sqliteTransaction;

        String connectionString = ConfigurationManager.AppSettings["connectionString"];
        String nameDataBase = ConfigurationManager.AppSettings["nameDataBase"];



        #region

        /*
         * 
         * 
// We use these three SQLite objects:
SQLiteConnection sqlite_conn;
SQLiteCommand sqlite_cmd;
SQLiteDataReader sqlite_datareader;

// create a new database connection:
sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");

// open the connection:
sqlite_conn.Open();

// create a new SQL command:
sqlite_cmd = sqlite_conn.CreateCommand();

// Let the SQLiteCommand object know our SQL-Query:
sqlite_cmd.CommandText = "CREATE TABLE test (id integer primary key, text varchar(100));";

// Now lets execute the SQL ;D
sqlite_cmd.ExecuteNonQuery();

// Lets insert something into our new table:
sqlite_cmd.CommandText = "INSERT INTO test (id, text) VALUES (1, 'Test Text 1');";

// And execute this again ;D
sqlite_cmd.ExecuteNonQuery();

// ...and inserting another line:
sqlite_cmd.CommandText = "INSERT INTO test (id, text) VALUES (2, 'Test Text 2');";

// And execute this again ;D
sqlite_cmd.ExecuteNonQuery();

// But how do we read something out of our table ?
// First lets build a SQL-Query again:
sqlite_cmd.CommandText = "SELECT * FROM test";

// Now the SQLiteCommand object can give us a DataReader-Object:
sqlite_datareader=sqlite_cmd.ExecuteReader();

// The SQLiteDataReader allows us to run through the result lines:
while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
{
// Print out the content of the text field:
System.Console.WriteLine( sqlite_datareader["text"] );
}

// We are ready, now lets cleanup and close our connection:
sqlite_conn.Close();*/
        #endregion




        public void CreateDatabase()
        {
            try
            {
                if (!File.Exists(nameDataBase))
                {
                    SQLiteConnection.CreateFile(nameDataBase);
                    CreateTables();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void CreateTables()
        {
            try
            {
                sqliteConn = new SQLiteConnection(connectionString);

                sqliteConn.Open();

                sqliteTransaction = sqliteConn.BeginTransaction();
                sqliteCmd = sqliteConn.CreateCommand();

                sqliteCmd.Transaction = sqliteTransaction;

                sqliteCmd.CommandText = "DROP TABLE IF EXISTS Home";
                sqliteCmd.ExecuteNonQuery();

                sqliteCmd.CommandText = @"CREATE TABLE Home(idhome INTEGER PRIMARY KEY, 
                                nickhome varchar(30) NOT NULL, mail varchar(50) NOT NULL,
                                tookenhome varchar(1000) NULL,imagehome varchar(100) NULL)";
                sqliteCmd.ExecuteNonQuery();

                sqliteTransaction.Commit();

            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

                if (sqliteTransaction != null)
                {
                    try
                    {
                        sqliteTransaction.Rollback();

                    }
                    catch (SQLiteException ex2)
                    {

                        Console.WriteLine("Transaction rollback failed.");
                        Console.WriteLine("Error: {0}", ex2.ToString());

                    }
                    finally
                    {
                        sqliteTransaction.Dispose();
                    }
                }
            }
            finally
            {
                if (sqliteCmd != null)
                {
                    sqliteCmd.Dispose();
                }

                if (sqliteTransaction != null)
                {
                    sqliteTransaction.Dispose();
                }

                if (sqliteConn != null)
                {
                    try
                    {
                        sqliteConn.Close();

                    }
                    catch (SQLiteException ex)
                    {

                        Console.WriteLine("Closing connection failed.");
                        Console.WriteLine("Error: {0}", ex.ToString());

                    }
                    finally
                    {
                        sqliteConn.Dispose();
                    }
                }
            }
        }//fin create tables

    }
}
