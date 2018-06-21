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
        private int _id;
        private string _nick;
        private string _mail;
        private string _password;
        private string _tookenHome;
        private string _pathImageHome;
        private string _image;

        public int id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public string nick
        {
            get { return this._nick; }
            set { this._nick = value; }
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
        public string image
        {
            get { return this._image; }
            set { this._image = value; }
        }

    }
}
