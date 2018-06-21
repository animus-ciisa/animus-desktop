using Animus.Common;
using Animus.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animus.DataAccess
{
    class DaCamera
    {

        public List<CoCamera> All()
        {
            List<CoCamera> cameras = new List<CoCamera>();
            var query = "SELECT * FROM Camera;";
            var result = DbContext.Select(query);
            if (result.Count() > 0)
            {
                for(int i = 0; i < result.Count(); i++)
                {
                    cameras.Add(new CoCamera
                    {
                        name = result[i]["name"].ToString(),
                        status = Convert.ToInt32(result[i]["status"].ToString()) != 0,
                        associate = Convert.ToInt32(result[i]["associate"].ToString()) != 0,
                    });
                }
            }
            return cameras;
        }
            
        public void Save(CoCamera camera)
        {
            var query = "SELECT * FROM Camera WHERE name = ?;";
            DbParameter[] parametersSelect = {
                new DbParameter("name", camera.name.ToString())
            };
            var result = DbContext.Select(query, parametersSelect);
            if (result.Count() > 0)
            {
                query = "UPDATE Camera SET status = ?, associate = ? WHERE name = ?;";
                DbParameter[] parameters = {
                    new DbParameter("status", ((camera.status) ? 1 : 0).ToString()),
                    new DbParameter("associate", ((camera.associate) ? 1 : 0).ToString()),
                    new DbParameter("name", camera.name.ToString())
                };
                DbContext.InsertOrUpdate(query, parameters);
            }
            else
            {
                query = "INSERT INTO Camera VALUES(?, ? , ?)";
                DbParameter[] parameters = {
                    new DbParameter("name", camera.name.ToString()),
                    new DbParameter("status", ((camera.status) ? 1 : 0).ToString()),
                    new DbParameter("associate", ((camera.associate) ? 1 : 0).ToString())
                };
                DbContext.InsertOrUpdate(query, parameters);
            }
        }
    }
}
