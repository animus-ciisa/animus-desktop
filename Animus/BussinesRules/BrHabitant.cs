using Animus.Common;
using Animus.DataAccess;
using Animus.RestServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animus.BussinesRules
{
    class BrHabitant
    {
        private RsHabitant rs;
        DaHabitant daHabitant;

        public BrHabitant()
        {
            rs = new RsHabitant();
            daHabitant = new DaHabitant();
        }
        public CoHabitant Registry(CoHabitant habitant, out Boolean internetStatus)
        {

            internetStatus = true;

            habitant = rs.Save(habitant, out internetStatus);
            if (habitant == null || habitant.idhabitant == 0)
                return null;
            else
                return habitant;

        }
        public List<CoHabitant> GetAll()
        {
            List<CoHabitant> habitan = this.daHabitant.GetAll();
            return habitan;
        }
        public void Save(CoHabitant habitant)
        {
            this.daHabitant.Save(habitant);
        }

        public void Delete(int id)
        {
            this.daHabitant.Delete(id);
        }

        public CoHabitant GetId(int id)
        {
            return this.daHabitant.GetId(id);
        }
    }
}
