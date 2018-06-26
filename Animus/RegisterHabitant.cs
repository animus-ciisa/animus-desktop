using Animus.BussinesRules;
using Animus.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        private CoHome coHome;
        private msgNotification notification;
        string nameForm = "RegisterHabitant";
        string msgForm = "";
        public RegisterHabitant(CoHome home)
        {
            coHome = home;
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


        public Boolean validate(out string msg)
        {
            Boolean resp = true;
            msg = "";


            if (txtNombre.Text == "" || txtFECHA.Value == null || txtApellidos.Text == "" || comboTIPOPERSONA.selectedValue == "" || comboTIPOPERSONA.selectedValue == null)
            {
                msg = "Debe llenar los datos del formulario para completar el registro.";
                resp = false;
                return resp;
            }

            DateTime fromDateValue;
            string s = txtFECHA.Value.ToString("yyyy-MM-dd");
            var formats = new[] { "dd/MM/yyyy", "yyyy-MM-dd" };
            if (!DateTime.TryParseExact(s, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out fromDateValue))
            {
                // do for valid date
                msg = "El formato fecha es incorrecto";
                resp = false;
            }
            return resp;
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            brhabitant = new BrHabitant();
            string msg = string.Empty;
            if (validate(out msg) == false)
            {
                msgNotification m = new msgNotification(nameForm, msg);
                m.ShowDialog();
                return;
            }

            string name = txtNombre.Text;
            string lastname = txtApellidos.Text;
            DateTime brithday = Convert.ToDateTime(txtFECHA.Value.ToString());
            int tipopersona = new BrTypePerson().getIntType(comboTIPOPERSONA.selectedValue); // rescato el tipo de persona


            cohabitant.name = name;
            cohabitant.lastname = lastname;
            cohabitant.birthdate = brithday.ToString("yyyy-MM-dd");
            cohabitant.idtypepeperson = tipopersona;


            cohabitant = brhabitant.Registry(cohabitant, out internetStatus);
            if (cohabitant != null && cohabitant.idhabitant != 0)
            {
                //insertar en bd local
                new BrHabitant().Save(cohabitant);
                cleanFields();

                msgForm = "OK- El habitante quedó registrado correctamente.";
                msgNotification ms = new msgNotification(nameForm, msgForm);
                ms.ShowDialog();
            }
            else
            {
                msgForm = "No se pudo crear el habitante, intente nuevamente.";
                msgNotification ms = new msgNotification(nameForm, msgForm);
                ms.ShowDialog();
            }

        }
        public void cleanFields()
        {
            txtApellidos.Text = string.Empty;
            txtNombre.Text = string.Empty;

        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
