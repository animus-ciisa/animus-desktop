using Animus.BussinesRules;
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
    public partial class LoginAnimus : Form
    {

        public static string mail = "", nick = "";
        public static int idHome = 0;
        public static string imagePath = "", nameArchive = "";
        public static string imageDefault = ConfigurationManager.AppSettings["imageDefault"];
        public static string pathImageDefault = ConfigurationManager.AppSettings["pathImage"];
        public static string nameForm = "";
        public static string msgForm = "";

        public LoginAnimus()
        {
            InitializeComponent();
            GenerateDataBase();



            string path = System.IO.Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "");
            path = path + "\\" + "usr.txt";
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }

        }
        public void GenerateDataBase()
        {
            try
            {
                BrHome br = new BrHome();
                br.GenerateDataBase();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            // this.Close();
            this.Hide();
        }


        public Boolean ValidateFields(out string msg)
        {
            Boolean validate = true;
            BrHome br = new BrHome();
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
                if (br.validateMail(txtCorreo.Text) == false)
                {
                    msg = "El campo Correo Electrónico no tiene un formato correcto.";
                    validate = false;
                    txtCorreo.Focus();
                    return validate;
                }
            }
            return validate;
        }


        private void btnRegistro_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            if (ValidateFields(out msg) == false)
            {
                //MetroFramework.MetroMessageBox.Show(this, msg, "Animus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                nameForm = "LoginAnimus";
                msgForm = msg;

                msgNotification ms = new msgNotification();
                ms.ShowDialog();
                return;
            }


            //si el email ya existe lo tengo que mandar a iniciar session
            string status = string.Empty, code = string.Empty;
            BrAnimusRest brAnimus = new BrAnimusRest();
            Boolean validateMail = brAnimus.validateMail(txtCorreo.Text, out status, out code);

            if (status.ToUpper().Trim() != "OK" || code != "200")
            {
                //MetroFramework.MetroMessageBox.Show(this, "No existe conexión con el servidor, vuelva a reintentarlo.", "Animus", MessageBoxButtons.OK, MessageBoxIcon.Information);



                nameForm = "LoginAnimus";
                msgForm = "No existe conexión con el servidor, vuelva a reintentarlo.";

                msgNotification ms = new msgNotification();
                ms.ShowDialog();

                return;
            }

            if (validateMail == true)
            {
                txtCorreo.Text = string.Empty;
                txtNick.Text = string.Empty;
                //MetroFramework.MetroMessageBox.Show(this, "La cuenta de correo existe, debe ingresar por la opción ya tengo una cuenta.", "Animus", MessageBoxButtons.OK, MessageBoxIcon.Information);


                nameForm = "LoginAnimus";
                msgForm = "La cuenta de correo existe, debe ingresar por la opción ya tengo una cuenta.";

                msgNotification ms = new msgNotification();
                ms.ShowDialog();

                return;
            }

            //PASSING VARIABLES

            this.Hide();

            //this.Close();

            mail = txtCorreo.Text;
            nick = txtNick.Text;

            // Password pass = new Password();
            //pass.ShowDialog();

            PasswordAnimus pass = new PasswordAnimus();
            pass.ShowDialog();
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if (txtCorreo.Text != "")
            {
                BrHome br = new BrHome();
                //vamos a validar que el correo sea valido
                if (br.validateMail(txtCorreo.Text) == true)
                {

                    //si el email ya existe lo tengo que mandar a iniciar session
                    string status = string.Empty, code = string.Empty;
                    BrAnimusRest brAnimus = new BrAnimusRest();
                    Boolean validateMail = brAnimus.validateMail(txtCorreo.Text, out status, out code);

                    if (status.ToUpper().Trim() != "OK" || code != "200")
                    {

                        nameForm = "LoginAnimus";
                        msgForm = "No existe conexión con el servidor, vuelva a reintentarlo.";

                        msgNotification ms = new msgNotification();
                        ms.ShowDialog();

                        return;
                    }

                    if (validateMail == true)
                    {

                        nameForm = "LoginAnimus";
                        msgForm = "La cuenta de correo existe, debe ingresar por la opción ya tengo una cuenta.";

                        msgNotification ms = new msgNotification();
                        ms.ShowDialog();


                        //MetroFramework.MetroMessageBox.Show(this, "La cuenta de correo existe, debe ingresar por la opción ya tengo una cuenta.", "Animus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    #region
                    //CoHome coHome = new CoHome();
                    //int homeIdRescue = 0;
                    //coHome.mail = txtCorreo.Text;
                    ////buscamos si el correo es valido para cargar la foto en el picture
                    //int countExist = new BrHome().HomeExits(coHome, out homeIdRescue);
                    //if (homeIdRescue != 0)
                    //{
                    //    DataTable dtHome = new BrHome().GetHomeId(homeIdRescue);
                    //    if (dtHome.Rows.Count > 0)
                    //    {
                    //        string pathImage = dtHome.Rows[0]["imagehome"].ToString();
                    //        if (pathImage != "")
                    //            pictureBox1.Image = Image.FromFile(pathImage);
                    //        else
                    //            pictureBox1.Image = Image.FromFile(pathImageDefault + imageDefault);
                    //        txtNick.Text = dtHome.Rows[0]["nickhome"].ToString();
                    //        errorProvider.SetError(txtCorreo, "");
                    //        errorProvider.SetError(txtNick, "");
                    //        idHome = Convert.ToInt32(dtHome.Rows[0]["idhome"].ToString());
                    //    }
                    //}
                    //else
                    //{
                    //    if (File.Exists(pathImageDefault + imageDefault))
                    //    {
                    //        pictureBox1.Image = Image.FromFile(pathImageDefault + imageDefault);
                    //        txtNick.Text = "";
                    //        errorProvider.SetError(txtCorreo, "");
                    //        errorProvider.SetError(txtNick, "");
                    //    }
                    //    idHome = 0;
                    //    mail = "";
                    //    nick = "";
                    //}
                    #endregion
                }
                else
                {

                    //MetroFramework.MetroMessageBox.Show(this, "El campo correo electrónico no tiene un formato correcto.", "Animus", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtCorreo.Text = string.Empty;
                    txtNick.Text = string.Empty;


                    nameForm = "LoginAnimus";
                    msgForm = "El campo correo electrónico no tiene un formato correcto.";

                    msgNotification ms = new msgNotification();
                    ms.ShowDialog();


                    //    if (File.Exists(pathImageDefault + imageDefault))
                    //    {
                    //        pictureBox1.Image = Image.FromFile(pathImageDefault + imageDefault);
                    //        txtNick.Text = "";
                    //        errorProvider.SetError(txtCorreo, "");
                    //        errorProvider.SetError(txtNick, "");
                    //    }
                    //    idHome = 0;
                    //    mail = "";
                    //    nick = "";
                }
            }
            else
            {
                //idHome = 0;
                //mail = "";
                //nick = "";
            }
        }

        private void LoginAnimus_Load(object sender, EventArgs e)
        {


            string path = System.IO.Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "");
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



                                PasswordAnimus pass = new PasswordAnimus();
                                pass.ShowDialog();

                                // this.Close();
                                this.Hide();
                            }
                        }
                    }
                }
            }
        }

    }
}
