using Animus.BussinesRules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animus
{
    public partial class RecuperarContrasena : Form
    {
        public static string nameForm = "";
        public static string msgForm = "";
        public static int idSession = 0;
        public static string correook = "";
        public RecuperarContrasena()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            PasswordAnimus ms = new PasswordAnimus();
            ms.ShowDialog();
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            txtCorreo_Leave(null, null);

        }
        public string RecuperarCorreoArchivo()
        {
            string correo = "";
            try
            {
                string path = System.IO.Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "");
                path = path + "\\" + "usr.txt";

                if (File.Exists(path))
                {
                    using (StreamReader sr = File.OpenText(path))
                    {
                        string status = "";
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            if (s.Contains(";"))
                            {
                                correo = s.Split(';')[1].ToString();

                            }
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return correo;
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

                        nameForm = "RecuperarContrasena";
                        msgForm = "No existe conexión con el servidor, vuelva a reintentarlo.";

                        msgNotification ms = new msgNotification();
                        ms.ShowDialog();

                        return;
                    }

                    if (validateMail == false)
                    {

                        nameForm = "RecuperarContrasena";
                        msgForm = "La cuenta de correo no existe, debe registrarse para ingresar a animus.";

                        msgNotification ms = new msgNotification();
                        ms.ShowDialog();
                        return;
                    }
                    else
                    {

                        if (RecuperarCorreoArchivo().ToString().ToUpper().Trim() != txtCorreo.Text.Trim().ToUpper())
                        {
                            nameForm = "RecuperarContrasena";
                            msgForm = "La cuenta de correo no corresponde a la que está registrada para el hogar.";

                            msgNotification ms = new msgNotification();
                            ms.ShowDialog();
                            return;
                        }
                        else
                        {

                            status = string.Empty;
                            code = string.Empty;
                            Boolean boolPass = new BrAnimusRest().recoverPassword(txtCorreo.Text, out  status, out  code);
                            if (boolPass == true)
                            {
                                //mensaje ok
                                if (status.ToUpper().Trim() == "OK")
                                {
                                    string msg = "La contraseña fue enviada a su correo electrónico.";
                                    nameForm = "RecuperarContrasena";
                                    correook = "OK";
                                    msgForm = msg;

                                    msgNotification ms = new msgNotification();
                                    ms.ShowDialog();
                                    return;
                                }
                                else
                                {
                                    string msg = "No se pudo enviar la contraseña al correo.";
                                    nameForm = "RecuperarContrasena";

                                    msgForm = msg;

                                    msgNotification ms = new msgNotification();
                                    ms.ShowDialog();
                                    return;
                                }
                            }
                        }
                    }

                }
                else
                {

                    nameForm = "RecuperarContrasena";
                    msgForm = "El campo correo electrónico no tiene un formato correcto.";

                    msgNotification ms = new msgNotification();
                    ms.ShowDialog();
                    return;

                }
            }
            else
            {
                nameForm = "RecuperarContrasena";
                msgForm = "El campo correo electrónico es obligatorio.";

                msgNotification ms = new msgNotification();
                ms.ShowDialog();
                return;

            }
        }


    }
}
