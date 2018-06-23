using Animus.BussinesRules;
using Animus.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animus
{
    public partial class RegisterHabitant : Form
    {
        private BrTypePerson brtype;
        private BrHabitant brhabitant;
        private CoHabitant cohabitant;
        private Boolean internetStatus;
        public RegisterHabitant()
        {
            brtype = new BrTypePerson();
            brhabitant = new BrHabitant();
            cohabitant = new CoHabitant();
            InitializeComponent();
            FillTipoPerson();
        }
        public void FillTipoPerson()
        {

            IList<CoTypePerson> listPerson = new BrTypePerson().All();
            if (listPerson.Count > 0)
            {


                foreach (CoTypePerson item in listPerson)
                {
                    comboTIPOPERSONA.AddItem(item.name);
                }


            }
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            string name = txtNombre.Text;
            string lastname = txtApellidos.Text;
            DateTime brithday = Convert.ToDateTime(txtFECHA.Value.ToString());
            int tipopersona = 1;

            cohabitant.name = name;
            cohabitant.lastname = lastname;
            cohabitant.birthdate = brithday;
            cohabitant.idtypepeperson = tipopersona;

            cohabitant = brhabitant.Registry(cohabitant, out internetStatus);
            if (cohabitant != null && cohabitant.idhabitant != 0)
            {
                //insertar en bd local
                Console.WriteLine(cohabitant.idhabitant);
            }

        }
    }
}
