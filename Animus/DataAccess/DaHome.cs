using Animus.Common;
using Animus.DataBase;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Animus.DataAccess
{
    public class DaHome
    {

        /*SQLiteConnection sqliteConn;
        SQLiteCommand sqliteCmd;
        SQLiteDataReader sqliteDatareader;
        SQLiteTransaction sqliteTransaction;
        SQLiteDataAdapter sqliteAdapter;

        String connectionString = ConfigurationManager.AppSettings["connectionString"];
        String nameDataBase = ConfigurationManager.AppSettings["nameDataBase"];
        String pathImage = ConfigurationManager.AppSettings["pathImage"];
        internal void GenerateDataBase()
        {
            try
            {
                DaGenerateScript da = new DaGenerateScript();
                da.CreateDatabase();
            }
            catch (Exception ex)
            {

            }
        }*/

        /*
         query = "INSERT INTO Camera VALUES(?, ? , ?)";
                DbParameter[] parameters = {
                    new DbParameter("name", camera.name.ToString()),
                    new DbParameter("status", ((camera.status) ? 1 : 0).ToString()),
                    new DbParameter("associate", ((camera.associate) ? 1 : 0).ToString())
                };
                DbContext.InsertOrUpdate(query, parameters);
             */

        public CoHome Save(CoHome home)
        {
            var query = "INSERT INTO Home VALUES(?, ? , ?, ?)";
            DbParameter[] parameters = {
                new DbParameter("id", home.id.ToString()),
                new DbParameter("nick", home.nick),
                new DbParameter("mail", home.mail),
                new DbParameter("image", home.image)
            };
            int id = DbContext.InsertOrUpdate(query, parameters);
            home.id = id;
            return home;
        }

        public CoHome Exists()
        {
            var query = "SELECT * FROM Home LIMIT 1;";
            var result = DbContext.Select(query);
            if (result.Count() > 0)
            {
                CoHome home = new CoHome {
                    id = Convert.ToInt32(result[0]["id"].ToString()),
                    nick = result[0]["nick"].ToString(),
                    mail = result[0]["mail"].ToString(),
                    image = result[0]["image"].ToString()
                };
                return home;
            }
            else
            {
                return null;
            }
        }

        /*public int HomeExits(CoHome home, out int idHome)
        {
            DataSet ds = new DataSet();
            int userExits = 0;
            idHome = 0;
            try
            {
                sqliteConn = new SQLiteConnection(connectionString);
                sqliteConn.Open();


                sqliteTransaction = sqliteConn.BeginTransaction();
                sqliteCmd = new SQLiteCommand(sqliteConn);


                sqliteCmd.CommandText = "select count(*),idhome from Home where lower(mail)=@mail";
                //sqliteCmd.Parameters.Add(new SQLiteParameter("@nickhome") { Value = home.nickHome.ToLower() });
                sqliteCmd.Parameters.Add(new SQLiteParameter("@mail") { Value = home.mail.ToLower() });

                sqliteAdapter = new SQLiteDataAdapter(sqliteCmd);
                ds = new DataSet();
                sqliteAdapter.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        userExits = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                        if (userExits != 0)
                            idHome = Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());
                    }
                }

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
            return userExits;
        }

        /// Encripta una cadena
        //public string Encriptar(string _cadenaAencriptar)
        //{
        //    string result = string.Empty;
        //    byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
        //    result = Convert.ToBase64String(encryted);
        //    return result;
        //}
        //public string DesEncriptar(string _cadenaAdesencriptar)
        //{
        //    string result = string.Empty;
        //    byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
        //    //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
        //    result = System.Text.Encoding.Unicode.GetString(decryted);
        //    return result;
        //}

        public static string GetSHA1(string str)
        {
            SHA1 sha1 = SHA1Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha1.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);

            string pass = string.Empty;
            if (sb.Length > 49)
            {
                pass = sb.ToString(0, 45);
                return pass;
            }
            else
            {
                return sb.ToString();
            }
        }


        internal int InsertHome(CoHome coHome)
        {
            string response = string.Empty;
            int cHome = 0;
            DataSet ds = new DataSet();
            try
            {
                sqliteConn = new SQLiteConnection(connectionString);
                sqliteConn.Open();


                sqliteTransaction = sqliteConn.BeginTransaction();

                sqliteCmd = new SQLiteCommand("INSERT INTO Home VALUES(?,?,?,?,null)", sqliteConn);

                sqliteCmd.Parameters.Add(new SQLiteParameter("@idhome") { Value = coHome.id });
                sqliteCmd.Parameters.Add(new SQLiteParameter("@nickhome") { Value = coHome.nick });
                sqliteCmd.Parameters.Add(new SQLiteParameter("@mail") { Value = coHome.mail });
                sqliteCmd.Parameters.Add(new SQLiteParameter("@tookenhome") { Value = coHome.tookenHome });

                sqliteCmd.Transaction = sqliteTransaction;
                sqliteCmd.ExecuteNonQuery();

                cHome = coHome.id;

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
            return cHome;

        }

        internal DataTable GetHomeId(int homeIdRescue)
        {
            DataSet ds = new DataSet();
            try
            {
                sqliteConn = new SQLiteConnection(connectionString);
                sqliteConn.Open();


                sqliteTransaction = sqliteConn.BeginTransaction();
                sqliteCmd = new SQLiteCommand(sqliteConn);

                sqliteCmd.CommandText = "select * from home where idhome=@idhome";
                sqliteCmd.Parameters.Add(new SQLiteParameter("@idhome") { Value = homeIdRescue });

                sqliteAdapter = new SQLiteDataAdapter(sqliteCmd);
                ds = new DataSet();
                sqliteAdapter.Fill(ds);

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

        internal void UpdateHome(CoHome coHome)
        {
            try
            {
                sqliteConn = new SQLiteConnection(connectionString);
                sqliteConn.Open();


                sqliteTransaction = sqliteConn.BeginTransaction();
                sqliteCmd = new SQLiteCommand(sqliteConn);


                sqliteCmd.CommandText = "update home set nickhome = @nickhome,imagehome=@imagehome where idhome=@idhome";
                sqliteCmd.Parameters.Add(new SQLiteParameter("@idhome") { Value = coHome.id });
                sqliteCmd.Parameters.Add(new SQLiteParameter("@nickhome") { Value = coHome.nick });
                sqliteCmd.Parameters.Add(new SQLiteParameter("@imagehome") { Value = coHome.image });

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

        internal Boolean validatePassword(CoHome coHome)
        {
            Boolean response = false;
            try
            {

                DataTable dt = GetHomeId(coHome.id);

                if (dt.Rows.Count > 0)
                {
                    string passBd = dt.Rows[0]["password"].ToString();
                    string passVar = GetSHA1(coHome.password);
                    if (passBd == passVar)
                        response = true;
                }
            }
            catch (Exception ex)
            {

            }
            return response;
        }*/
    }
}
