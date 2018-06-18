using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Animus.Common
{
    class CoRestResponse
    {
        private Boolean _status;
        private int _code;
        private JObject _data;

        public Boolean status
        {
            get { return this._status; }
            set { this._status = value; }
        }

        public int code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        public JObject data
        {
            get { return this._data; }
            set { this._data = value; }
        }
    }
}
