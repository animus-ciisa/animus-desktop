using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animus.Common
{
    class CoCamera
    {
        private string _name;
        private Boolean _status;
        private Boolean _associate;

        public string name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public Boolean status
        {
            get { return this._status; }
            set { this._status = value; }
        }

        public Boolean associate
        {
            get { return this._associate; }
            set { this._associate = value; }
        }
    }
}
