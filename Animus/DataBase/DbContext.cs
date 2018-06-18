using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animus.DataBase
{
    class DbParameter
    {
        public DbParameter() { }

        public DbParameter(string field, string value)
        {
            this.field = field;
            this.value = value;
        }

        public string field { get; set; }
        public string value { get; set; }
    }

    class DbContext
    {

        public static String connectionString = ConfigurationManager.AppSettings["connectionString"];

        public static SQLiteConnection GetInstance()
        {
            var db = new SQLiteConnection(DbContext.connectionString);
            db.Open();
            return db;
        }

        public static int Insert(string query, DbParameter[] parameters)
        {
            int insertId;
            using (var ctx = DbContext.GetInstance())
            {
                using (var command = new SQLiteCommand(query, ctx))
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        command.Parameters.Add(new SQLiteParameter(parameters[i].field, parameters[i].value));
                    }
                    command.ExecuteNonQuery();
                    command.CommandText = "select last_insert_rowid()";
                    insertId = Convert.ToInt32(command.ExecuteScalar());
                    command.Dispose();
                }
                ctx.Close();
            }
            return insertId;
        }

        public static List<Dictionary<string, string>> Select(string query, DbParameter[] parameters = null)
        {
            List<Dictionary<string, string>> resulset = new List<Dictionary<string, string>>();
            using (var ctx = DbContext.GetInstance())
            {
                using (var command = new SQLiteCommand(query, ctx))
                {
                    if (parameters != null)
                    {
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            command.Parameters.Add(new SQLiteParameter(parameters[i].field, parameters[i].value));
                        }
                    }

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Dictionary<string, string> row = new Dictionary<string, string>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row[reader.GetName(i)] = reader[i].ToString();
                            }
                            resulset.Add(row);
                        }
                        reader.Close();
                    }
                    command.Dispose();
                }
                ctx.Close();
            }
            return resulset;
        }
    }
}
