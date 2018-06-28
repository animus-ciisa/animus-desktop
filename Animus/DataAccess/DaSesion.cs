using Animus.Common;
using Animus.DataBase;
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
        public int Save(CoSesion session)
        {
            var query = "INSERT INTO sesion VALUES(null, ? , null , ?)";
            DbParameter[] parameters = {
                new DbParameter("start", session.start.ToString()),
                new DbParameter("token", session.token)
            };
            int sessionId = DbContext.InsertOrUpdate(query, parameters);
            return sessionId;
        }

        public void UpdateToken(CoSesion session)
        {
            var query = "update sesion set token = ? where id = ?";
            DbParameter[] parameters = {
                new DbParameter("id", session.id.ToString()),
                new DbParameter("token", session.token)
            };
            int sessionId = DbContext.InsertOrUpdate(query, parameters);
        }

        public void CloseSession(CoSesion session)
        {
            Console.WriteLine("Se cerrará session de id: " + session.id);
            var query = "UPDATE sesion SET end = ? WHERE id = ?";
            DbParameter[] parameters = {
                new DbParameter("end", DateTime.Now.ToString()),
                new DbParameter("id", session.id.ToString())
            };
            int sessionId = DbContext.InsertOrUpdate(query, parameters);
        }

        public CoSesion GetActiveSession()
        {
            var query = "SELECT id, token FROM Sesion " +
                        "WHERE (end is null) or (end = '') " +
                        "ORDER BY id DESC LIMIT 1";
            var result = DbContext.Select(query);
            if (result.Count() > 0)
            {
                CoSesion session = new CoSesion
                {
                    id = Convert.ToInt32(result[0]["id"].ToString()),
                    token = result[0]["token"].ToString()
                };
                return session;
            }
            else
            {
                return null;
            }
        }
    }
}
