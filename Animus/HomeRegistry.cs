using Animus.BussinesRules;
using Animus.Common;
using Animus.RestServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animus
{
    public partial class HomeRegistry : Form
    {

        public static string mail = "", nick = "";
        public static int idHome = 0;
        public static string imagePath = "", nameArchive = "";
        public static string imageDefault = ConfigurationManager.AppSettings["imageDefault"];
        public static string pathImageDefault = ConfigurationManager.AppSettings["pathImage"];
        public string nameForm = "";
        public static string msgForm = "";


        BrHome brHome = new BrHome();

        public HomeRegistry()
        {
            nameForm = "HomeRegister";
            InitializeComponent();
            this.ChechInternet();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        public Boolean ValidateFields(out string msg)
        {
            Boolean validate = true;
            msg = string.Empty;
            if (txtCorreo.Text == "")
            {
                msg = "El campo Correo Electrónico es obligatorio.";
                validate = false;
                txtCorreo.Focus();
                return validate;
            }

            if (txtNick.Text == "")
            {
                msg = "El campo Nick del Hogar es obligatorio.";
                validate = false;
                txtNick.Focus();
                return validate;
            }
            if (txtCorreo.Text != "")
            {
                if (this.brHome.ValidateEmailFormat(txtCorreo.Text) == false)
                {
                    msg = "El campo Correo Electrónico no tiene un formato correcto.";
                    validate = false;
                    txtCorreo.Focus();
                    return validate;
                }
            }
            if (txtPassword.Text == "")
            {
                msg = "El campo Contraseña del Hogar es obligatorio.";
                validate = false;
                txtNick.Focus();
                return validate;
            }
            return validate;
        }


        private void btnRegistro_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            if (ValidateFields(out msg) == false)
            {
                nameForm = "LoginAnimus";
                msgForm = msg;
                msgNotification ms = new msgNotification(nameForm, msg);
                ms.ShowDialog();
                return;
            }
            //si el email ya existe lo tengo que mandar a iniciar session
            Boolean exists = this.ValidateExistsEmail();
            if (exists == true)
            {
                txtCorreo.Text = string.Empty;
                txtNick.Text = string.Empty;
                msgForm = "La cuenta de correo existe, debe ingresar por la opción ya tengo una cuenta.";
                msgNotification ms = new msgNotification(nameForm, msgForm);
                ms.ShowDialog();
                return;
            }

            CoHome home = new CoHome();
            home.nick = txtNick.Text;
            home.mail = txtCorreo.Text;
            home.password = txtPassword.Text;

            Boolean internetStatus = true;
            CoSesion session = null;
            home = this.brHome.Registry(home, out session, out internetStatus);
            if (!internetStatus)
            {
                this.InternetStatus(internetStatus);
                return;
            }
            else
            {
                this.Hide();
                ControlCenter controlCenter = new ControlCenter(home, session);
                controlCenter.ShowDialog();
            }
        }

        private void btnCuenta_Click(object sender, EventArgs e)
        {

        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if (txtCorreo.Text != "")
            {
                if (this.brHome.ValidateEmailFormat(txtCorreo.Text) == true)
                {
                    Boolean exists = this.ValidateExistsEmail();
                    if (exists == true)
                    {

                        msgForm = "La cuenta de correo existe, debe ingresar por la opción ya tengo una cuenta.";
                        msgNotification ms = new msgNotification(nameForm, msgForm);
                        ms.ShowDialog();
                        return;
                    }
                }
                else
                {
                    txtCorreo.Text = string.Empty;
                    txtNick.Text = string.Empty;
              
                    msgForm = "El campo correo electrónico no tiene un formato correcto.";
                    msgNotification ms = new msgNotification(nameForm, msgForm);
                    ms.ShowDialog();
                }
            }
        }

        private void LoginAnimus_Load(object sender, EventArgs e)
        {
            /*string path = System.IO.Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "");
            path = path + "\\" + "usr.txt";

            if (File.Exists(path))
            {

                byte[] archivo = System.IO.File.ReadAllBytes(path);
                int tamaño = archivo.Length;
                if (tamaño > 0)
                {
                    using (StreamReader sr = File.OpenText(path))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            if (s.Contains(";"))
                            {
                                string id = s.Split(';')[0].ToString();
                                string correo = s.Split(';')[1].ToString();
                                string nick = s.Split(';')[2].ToString();

                                // this.Close();
                                this.Hide();
                            }
                        }
                    }
                }
            }*/
        }

        private void btnCheckInternet_Click(object sender, EventArgs e)
        {
            this.ChechInternet();
        }

        private Boolean ValidateExistsEmail()
        {
            Boolean internetStatus = true;
            Boolean exists = this.brHome.EmailExists(txtCorreo.Text, out internetStatus);
            if (!internetStatus)
            {
                this.InternetStatus(internetStatus);
                return internetStatus;
            }
            return exists;
        }

        private void ChechInternet()
        {
            Boolean internetStatus = RsBase.CheckForInternetConnection();
            this.InternetStatus(internetStatus);
        }

        private void InternetStatus(Boolean status)
        {
            txtCorreo.Enabled = status;
            txtNick.Enabled = status;
            btnCuenta.Enabled = status;
            btnRegistro.Enabled = status;
            btnCheckInternet.Visible = !status;
        }
    }
}
