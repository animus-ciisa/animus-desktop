using Animus.Common;
using Animus.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animus.DataAccess
{
    class DaHabitant
    {
        public void Save(CoHabitant habitant)
        {
            var query = "SELECT * FROM Habitant WHERE id = ?;";
            DbParameter[] parametersSelect = {
                new DbParameter("id", habitant.id.ToString())
             };
            var result = DbContext.Select(query, parametersSelect);
            if (result.Count() > 0)
            {
                query = "UPDATE Habitant SET name = ?, lastname = ?, birthdate = ? WHERE  id = ?;";
                DbParameter[] parameters = {
                    new DbParameter("name", (habitant.name.ToString())),
                    new DbParameter("lastname", (habitant.lastname.ToString())),
                    new DbParameter("birthdate", habitant.birthdate.ToString("yyyy-MM-dd")),
                    new DbParameter("id", habitant.id.ToString())
                };
                DbContext.InsertOrUpdate(query, parameters);
            }
            else
            {
                query = "INSERT INTO Habitant VALUES(?, ? ,?, ?, ?, ?)";
                DbParameter[] parameters = {
                    new DbParameter("id", habitant.id.ToString()),
                    new DbParameter("type", habitant.typePerson.id.ToString()),
                    new DbParameter("name", habitant.name.ToString()),
                    new DbParameter("lastname", habitant.lastname),
                    new DbParameter("birthdate", habitant.birthdate.ToString("yyyy-MM-dd")),
                    new DbParameter("created", DateTime.Now.ToString(("yyyy-MM-dd")))
                };
                DbContext.InsertOrUpdate(query, parameters);
            }
        }
    }
}
