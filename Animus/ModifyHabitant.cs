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
    public partial class ModifyHabitant : Form
    {
        private CoHabitant habitant;
        private BrHabitant brhabitant;
        string nameForm = "RegisterHabitant";
        string msgForm = "";

        public ModifyHabitant(CoHabitant cohabitant)
        {
            brhabitant = new BrHabitant();
            habitant = new CoHabitant();
            habitant = cohabitant;
            InitializeComponent();
            FillTipoPerson();
            getHabitant();
        }
        public void FillTipoPerson()
        {

            IList<CoTypePerson> listPerson = new BrTypePerson().All();
            if (listPerson.Count > 0)
            {
                foreach (CoTypePerson item in listPerson)
                {
                    comboPersona.AddItem(item.name);
                    //comboBox1.Items.Add(item.name);
                }
            }
        }
        public void getHabitant()
        {
            if (habitant != null)
            {
                txtNombre.Text = habitant.name;
                txtApellidos.Text = habitant.lastname;
                DateTime temp;
                if (DateTime.TryParse(habitant.birthdate, out temp))
                    txtFECHA.Value = temp;// Convert.ToDateTime(temp.ToString("yyyy-MM-dd"));

                getImageHabitant();
            }

        }
        public void getImageHabitant()
        {

            int x = 8;


            //cambiar la ruta y hacer la llamada a la tabla con las rutas.
            string path = System.IO.Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "");
            path = path + "\\" + "Images\\Application\\";

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListHabitant));
            for (int i = 0; i < 7; i++)
            {
                PictureBox picture = new PictureBox();
                picture.Image = ((System.Drawing.Image)(resources.GetObject("picture.Image")));
                picture.Location = new System.Drawing.Point(x, 13);
                picture.Name = i.ToString();
                picture.Size = new System.Drawing.Size(125, 119);
                picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                picture.TabIndex = 0;
                picture.TabStop = false;
                picture.Image = Image.FromFile(path + "iconhapy.png");
                this.panelImagen.Controls.Add(picture);
                //position hacia al lado
                x += 140;
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public Boolean validate(out string msg)
        {
            Boolean resp = true;
            msg = "";


            if (txtNombre.Text == "" || txtFECHA.Value == null || txtApellidos.Text == "")
            {
                msg = "Debe llenar los datos del formulario para completar el registro.";
                resp = false;
                return resp;
            }

            if (comboPersona.selectedValue == null || comboPersona.selectedValue == "" || comboPersona.selectedIndex == 0)
            {
                if (habitant.idtypepeperson == 0)
                {
                    msg = "Debe llenar los datos del formulario para completar el registro.";
                    resp = false;
                    return resp;
                }
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


        private void btnFinalizar_Click(object sender, EventArgs e)
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
            int tipopersona = 0;
            if (comboPersona.selectedValue != null && comboPersona.selectedValue != "" && comboPersona.selectedIndex != 0)
                tipopersona = new BrTypePerson().getIntType(comboPersona.selectedValue); // rescato el tipo de persona


            habitant.name = name;
            habitant.lastname = lastname;
            habitant.birthdate = brithday.ToString("yyyy-MM-dd");
            if (tipopersona != 0)
                habitant.idtypepeperson = tipopersona;


            //cohabitant = brhabitant.Registry(cohabitant, out internetStatus); hacer la llamada al update en la nube
            if (1 == 1)//(cohabitant != null && cohabitant.idhabitant != 0)
            {
                //insertar en bd local
                new BrHabitant().Save(habitant);


                msgForm = "OK- habitante actualizado correctamente.";
                msgNotification ms = new msgNotification(nameForm, msgForm);
                ms.ShowDialog();
            }
            else
            {
                msgForm = "No se pudo actualizar el habitante, intente nuevamente.";
                msgNotification ms = new msgNotification(nameForm, msgForm);
                ms.ShowDialog();
            }
        }



    }
}
