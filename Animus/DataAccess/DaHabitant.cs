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



            var query = "SELECT * FROM Habitant WHERE idhabitant = ?;";
            DbParameter[] parametersSelect = {
                new DbParameter("idhabitant", habitant.idhabitant.ToString())
             };
            var result = DbContext.Select(query, parametersSelect);
            if (result.Count() > 0)
            {
                query = "UPDATE Habitant SET name = ?, lastname = ?,birthdate = ? WHERE  idhabitant = ?;";
                DbParameter[] parameters = {
                    new DbParameter("name", (habitant.name.ToString())),
                    new DbParameter("lastname", (habitant.lastname.ToString())),
                    new DbParameter("birthdate", habitant.birthdate.ToString("yyyy-MM-dd")),
                    new DbParameter("idhabitant", habitant.idhabitant.ToString())
                };
                DbContext.InsertOrUpdate(query, parameters);
            }
            else
            {
                query = "INSERT INTO Habitant VALUES(?, ? , ?,?,?,?,?)";
                DbParameter[] parameters = {
                    new DbParameter("idhabitant", habitant.idhabitant.ToString()),
                    new DbParameter("idhome", habitant.idhome.ToString()),
                    new DbParameter("idtypepeperson", habitant.idtypepeperson.ToString()),
                    new DbParameter("name", habitant.name.ToString()),
                    new DbParameter("lastname", habitant.lastname),
                    new DbParameter("birthdate", habitant.birthdate.ToString("yyyy-MM-dd")),
                    new DbParameter("registrationdate", DateTime.Now.ToString(("yyyy-MM-dd")))
                };
                DbContext.InsertOrUpdate(query, parameters);
            }
        }
    }
}
