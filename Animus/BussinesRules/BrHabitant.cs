using Animus.Common;
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

        public BrHabitant()
        {
            rs = new RsHabitant();
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
    }
}
