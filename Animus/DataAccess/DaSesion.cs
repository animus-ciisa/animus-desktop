using Animus.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animus.DataAccess
{
    public class DaSesion
    {
        SQLiteConnection sqliteConn;
        SQLiteCommand sqliteCmd;
        SQLiteDataReader sqliteDatareader;
        SQLiteTransaction sqliteTransaction;
        SQLiteDataAdapter sqliteAdapter;

        String connectionString = ConfigurationManager.AppSettings["connectionString"];
        String nameDataBase = ConfigurationManager.AppSettings["nameDataBase"];
        String pathImage = ConfigurationManager.AppSettings["pathImage"];

        internal int insert(CoSesion coSession)
        {
            int idSesion = 0;

            try
            {
                sqliteConn = new SQLiteConnection(connectionString);
                sqliteConn.Open();


                sqliteTransaction = sqliteConn.BeginTransaction();

                sqliteCmd = new SQLiteCommand("INSERT INTO sesion VALUES(null,?,null,?)", sqliteConn);


                sqliteCmd.Parameters.Add(new SQLiteParameter("@start") { Value = coSession.start });
                sqliteCmd.Parameters.Add(new SQLiteParameter("@token") { Value = coSession.token });

                sqliteCmd.Transaction = sqliteTransaction;
                sqliteCmd.ExecuteNonQuery();


                sqliteTransaction.Commit();

                sqliteCmd.CommandText = "select last_insert_rowid()";
                sqliteAdapter = new SQLiteDataAdapter(sqliteCmd);
                DataSet ds = new DataSet();
                sqliteAdapter.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        idSesion = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                    }
                }



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
            return idSesion;
        }


        internal void updateUltimetoken(CoSesion coSession)
        {
            try
            {
                sqliteConn = new SQLiteConnection(connectionString);
                sqliteConn.Open();


                sqliteTransaction = sqliteConn.BeginTransaction();
                sqliteCmd = new SQLiteCommand(sqliteConn);


                sqliteCmd.CommandText = "update sesion set token = @token where id=@id";
                sqliteCmd.Parameters.Add(new SQLiteParameter("@id") { Value = coSession.id });
                sqliteCmd.Parameters.Add(new SQLiteParameter("@token") { Value = coSession.token });


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

        internal void update(CoSesion coSession)
        {
            try
            {
                sqliteConn = new SQLiteConnection(connectionString);
                sqliteConn.Open();


                sqliteTransaction = sqliteConn.BeginTransaction();
                sqliteCmd = new SQLiteCommand(sqliteConn);


                sqliteCmd.CommandText = "update sesion set end = @end where id=@id";
                sqliteCmd.Parameters.Add(new SQLiteParameter("@id") { Value = coSession.id });
                sqliteCmd.Parameters.Add(new SQLiteParameter("@end") { Value = coSession.end });


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

        internal void getData(out string token, out int id)
        {
            DataSet ds = new DataSet();
            token = string.Empty;
            id = 0;
            try
            {
                sqliteConn = new SQLiteConnection(connectionString);
                sqliteConn.Open();


                sqliteTransaction = sqliteConn.BeginTransaction();
                sqliteCmd = new SQLiteCommand(sqliteConn);


                sqliteCmd.CommandText = "select id,token from Sesion where (end is null) or (end = '') order by start desc limit 1";

                sqliteAdapter = new SQLiteDataAdapter(sqliteCmd);
                ds = new DataSet();
                sqliteAdapter.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString());
                        token = ds.Tables[0].Rows[0]["token"].ToString();
                    }
                }

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
    }
}
