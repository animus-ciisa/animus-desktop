using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animus.Common
{
    public class CoTypePerson
    {

        private int _id;
        private string _name;
        public string name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public int id
        {
            get { return this._id; }
            set { this._id = value; }
        }
    }
}
