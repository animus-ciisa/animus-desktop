using Animus.Common;
using Animus.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animus.DataAccess
{
    class DaTypePerson
    {
        public List<CoTypePerson> All()
        {
            List<CoTypePerson> typeperson = new List<CoTypePerson>();
            var query = "SELECT * FROM TypePerson;";
            var result = DbContext.Select(query);
            if (result.Count() > 0)
            {
                for (int i = 0; i < result.Count(); i++)
                {
                    typeperson.Add(new CoTypePerson
                    {
                        name = result[i]["name"].ToString(),
                        id = Convert.ToInt32(result[i]["id"].ToString()),

                    });
                }
            }
            return typeperson;
        }
    }
}
