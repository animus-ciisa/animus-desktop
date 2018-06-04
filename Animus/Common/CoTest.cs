using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animus.Common
{
    [Serializable()]
    public class CoTest
    {
        private int _id;
        private String _name;


        public int id
        {
            get { return this._id; }
            set { this._id = value; }
        }
        public String name
        {
            get { return this._name; }
            set { this._name = value; }
        }
    }
}
