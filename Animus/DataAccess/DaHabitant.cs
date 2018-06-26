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


        public List<CoHabitant> GetAll()
        {
            List<CoHabitant> habitant = new List<CoHabitant>();
            var query = "SELECT * FROM Habitant;";
            var result = DbContext.Select(query);
            if (result.Count() > 0)
            {
                for (int i = 0; i < result.Count(); i++)
                {

                    habitant.Add(new CoHabitant
                    {
                        idhabitant = Convert.ToInt32(result[i]["idhabitant"].ToString()),
                        idhome = Convert.ToInt32(result[i]["idhome"].ToString()),
                        idtypepeperson = Convert.ToInt32(result[i]["idtypeperson"].ToString()),
                        name = result[i]["name"].ToString(),
                        lastname = result[i]["lastname"].ToString(),
                        birthdate = result[i]["birthdate"].ToString(),
                        registrationdate = result[i]["registrationdate"].ToString()
                    });
                }
            }
            return habitant;
        }


        public void Delete(int id)
        {
            var query = "DELETE FROM Habitant WHERE idhabitant = ?;";
            DbParameter[] parameters = {
                    new DbParameter("idhabitant", id.ToString())
                };
            DbContext.Delete(query, parameters);
        }

        public CoHabitant GetId(int id)
        {
            CoHabitant habitant = new CoHabitant();

            var query = "SELECT * FROM Habitant WHERE idhabitant = ?;";
            DbParameter[] parametersSelect = {
                new DbParameter("idhabitant", id.ToString())
             };
            var result = DbContext.Select(query, parametersSelect);

            if (result.Count() > 0)
            {
                habitant.idhabitant = Convert.ToInt32(result[0]["idhabitant"].ToString());
                habitant.idhome = Convert.ToInt32(result[0]["idhome"].ToString());
                habitant.idtypepeperson = Convert.ToInt32(result[0]["idtypeperson"].ToString());
                habitant.name = result[0]["name"].ToString();
                habitant.lastname = result[0]["lastname"].ToString();
                habitant.birthdate = result[0]["birthdate"].ToString();
                habitant.registrationdate = result[0]["registrationdate"].ToString();
            }
            return habitant;
        }


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
                    new DbParameter("birthdate", habitant.birthdate),
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
                    new DbParameter("birthdate", habitant.birthdate),
                    new DbParameter("registrationdate", DateTime.Now.ToString(("yyyy-MM-dd")))
                };
                DbContext.InsertOrUpdate(query, parameters);
            }
        }
    }
}
