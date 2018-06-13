using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animus.Common
{
    [Serializable()]
    public class CoSesion
    {
        private int _id;
        private DateTime _start;
        private DateTime _end;
        private string _token;


        public int id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public DateTime end
        {
            get { return this._end; }
            set { this._end = value; }
        }


        public DateTime start
        {
            get { return this._start; }
            set { this._start = value; }
        }

        public string token
        {
            get { return this._token; }
            set { this._token = value; }
        }

    }
}
