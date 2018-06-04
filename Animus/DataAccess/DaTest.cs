using Animus.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animus.DataAccess
{
    public class DaTest
    {

        String connectionString = "Data Source=C:\\inetpub\\wwwroot\\tesis\\Animus\\Animus\\DataBase\\Dbanimus.db;Version=3;";

        SQLiteConnection sqliteConn;// = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
        SQLiteCommand sqliteCmd;

        SQLiteDataAdapter sqliteadapter;
        SQLiteTransaction sqliteTransaction;

        public void insert_test(CoTest comtest)
        {

            try
            {
                sqliteConn = new SQLiteConnection(connectionString);
                sqliteConn.Open();


                sqliteTransaction = sqliteConn.BeginTransaction();

                sqliteCmd = new SQLiteCommand("INSERT INTO usuario(id,name) VALUES(?,?)", sqliteConn);

                sqliteCmd.Parameters.Add(new SQLiteParameter("@id") { Value = comtest.id });
                sqliteCmd.Parameters.Add(new SQLiteParameter("@name") { Value = comtest.name });

                sqliteCmd.Transaction = sqliteTransaction;
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



        }

        internal void Create_DataBase()
        {
            DaGenerateScript da = new DaGenerateScript();
            da.CreateDatabase();
        }

        internal void update_test(CoTest comtest)
        {
            try
            {
                sqliteConn = new SQLiteConnection(connectionString);
                sqliteConn.Open();


                sqliteTransaction = sqliteConn.BeginTransaction();
                sqliteCmd = new SQLiteCommand(sqliteConn);
                sqliteCmd.CommandText = "update usuario set name = @name where id=@id";
                sqliteCmd.Parameters.Add(new SQLiteParameter("@id") { Value = comtest.id });
                sqliteCmd.Parameters.Add(new SQLiteParameter("@name") { Value = comtest.name });

                sqliteCmd.Transaction = sqliteTransaction;
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
        }

        internal void delete_test(CoTest comtest)
        {
            try
            {
                sqliteConn = new SQLiteConnection(connectionString);
                sqliteConn.Open();


                sqliteTransaction = sqliteConn.BeginTransaction();
                sqliteCmd = new SQLiteCommand(sqliteConn);
                sqliteCmd.CommandText = "delete from usuario where id=@id";
                sqliteCmd.Parameters.Add(new SQLiteParameter("@id") { Value = comtest.id });

                sqliteCmd.Transaction = sqliteTransaction;
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
        }

        internal DataTable trae_registro()
        {

            DataSet ds = new DataSet();
            try
            {
                sqliteConn = new SQLiteConnection(connectionString);
                sqliteConn.Open();


                sqliteTransaction = sqliteConn.BeginTransaction();
                sqliteCmd = new SQLiteCommand(sqliteConn);
                sqliteCmd.CommandText = "select * from usuario";

                sqliteadapter = new SQLiteDataAdapter(sqliteCmd);
                ds = new DataSet();
                sqliteadapter.Fill(ds);

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
            return ds.Tables[0];
        }
    }
}
