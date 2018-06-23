using Animus.Common;
using Animus.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animus.BussinesRules
{
    class BrTypePerson
    {
        DaTypePerson daTypePerson;

        public BrTypePerson()
        {
            this.daTypePerson = new DaTypePerson();
        }

        internal IList<Common.CoTypePerson> All()
        {
            List<CoTypePerson> typePerson = this.daTypePerson.All();
            return typePerson;

        }
    }
}
