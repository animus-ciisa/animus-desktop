using Animus.BussinesRules;
using Animus.Common;
using Animus.Components.Habitants;
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
    public partial class HabitantDataRegistration : Form
    {
        private BrTypePerson brtype;
        private BrHabitant brhabitant;
        private Boolean internetStatus;
        private CoHome coHome;
        private msgNotification notification;
        string nameForm = "RegisterHabitant";
        string msgForm = "";

        public HabitantDataRegistration(CoHome home)
        {
            coHome = home;
            brtype = new BrTypePerson();
            brhabitant = new BrHabitant();
            //this.finishBtn.Enabled = false;
            InitializeComponent();
            FillTipoPerson();
        }
        public void FillTipoPerson()
        {

            IList<CoTypePerson> listPerson = this.brtype.All();
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

            CoHabitant cohabitant = new CoHabitant();
            cohabitant.name = txtNombre.Text;
            cohabitant.lastname = txtApellidos.Text;
            cohabitant.birthdate = Convert.ToDateTime(txtFECHA.Value.ToString());
            cohabitant.typePerson = brtype.ByName(comboTIPOPERSONA.selectedValue);

            cohabitant = brhabitant.Registry(cohabitant, out internetStatus);
            if (cohabitant == null || cohabitant.id == 0)
            {
                msgForm = "No se pudo crear el habitante, intente nuevamente.";
                msgNotification ms = new msgNotification(nameForm, msgForm);
                ms.ShowDialog();
            }
            else
            {
                HabitantImagesRegistration habitantImages = new HabitantImagesRegistration(cohabitant);
                habitantImages.Show();
                habitantImages.detectionsReady += (object s, CoRecognitionImages recognitions) =>
                {
                    this.RenderCaptures(recognitions);
                    habitantImages.Close();
                };
            }
        }

        private void RenderCaptures(CoRecognitionImages recognitions)
        {
            recognitions.frontalDetections[0].image.ROI = recognitions.frontalDetections[0].face;

            this.frontalPictureBox.Image = recognitions.frontalDetections[0].image.Resize(112, 112, Emgu.CV.CvEnum.Inter.Cubic).ToBitmap();
            this.leftPictureBox.Image = recognitions.leftDetections[0].image.Resize(112, 112, Emgu.CV.CvEnum.Inter.Cubic).ToBitmap();
            this.rightPictureBox.Image = recognitions.rightDetections[0].image.Resize(112, 112, Emgu.CV.CvEnum.Inter.Cubic).ToBitmap();
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

        private void finishBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
