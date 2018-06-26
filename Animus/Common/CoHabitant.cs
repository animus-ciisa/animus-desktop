using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animus.Common
{
    public class CoHabitant
    {
        private int _idhabitant;
        private int _idhome;
        private int _idtypepeperson;
        private string _name;
        private string _lastname;
        private string _birthdate;
        private string _registrationdate;


        public int idhabitant
        {
            get { return this._idhabitant; }
            set { this._idhabitant = value; }
        }

        public int idhome
        {
            get { return this._idhome; }
            set { this._idhome = value; }
        }
        public int idtypepeperson
        {
            get { return this._idtypepeperson; }
            set { this._idtypepeperson = value; }
        }

        public string name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public string lastname
        {
            get { return this._lastname; }
            set { this._lastname = value; }
        }
        public string birthdate
        {
            get { return this._birthdate; }
            set { this._birthdate = value; }
        }

        public string registrationdate
        {
            get { return this._registrationdate; }
            set { this._registrationdate = value; }
        }

    }
}
