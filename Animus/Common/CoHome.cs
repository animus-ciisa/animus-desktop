using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animus.Common
{
    [Serializable()]
    public class CoHome
    {
        private int _idHome;
        private string _nickHome;
        private string _mail;
        private string _password;
        private string _tookenHome;
        private string _pathImageHome;
        private string _imageHome;

        public int idHome
        {
            get { return this._idHome; }
            set { this._idHome = value; }
        }

        public string nickHome
        {
            get { return this._nickHome; }
            set { this._nickHome = value; }
        }

        public string mail
        {
            get { return this._mail; }
            set { this._mail = value; }
        }
        public string password
        {
            get { return this._password; }
            set { this._password = value; }
        }

        public string tookenHome
        {
            get { return this._tookenHome; }
            set { this._tookenHome = value; }
        }
        public string pathImageHome
        {
            get { return this._pathImageHome; }
            set { this._pathImageHome = value; }
        }
        public string imageHome
        {
            get { return this._imageHome; }
            set { this._imageHome = value; }
        }

    }
}
