using Animus.BussinesRules;
using Animus.Common;
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
    public partial class PasswordAnimus : Form
    {
        static string mailPassword = "";
        static string nickPassword = "";
        static string imageHomePath = "";
        static string nameArchiveHome = "";
        public static int idHome = 0;
        public static CoHome homeControl;
        public static string nameForm = "";
        public static string msgForm = "";
        public static int idSession = 0;
        public static string correook = "";

        BrHome homeBussinessRules = new BrHome();

        public PasswordAnimus()
        {
            InitializeComponent();

        }
        public Boolean ValidatePassword(String pass, out string msg)
        {
            msg = string.Empty;
            Boolean resp = true;
            if (pass == "")
            {
                msg = "El campo contraseña es obligatorio.";
                resp = false;
            }

            return resp;
        }
        private void btnSaveHome_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = string.Empty;
                if (ValidatePassword(txtPassword.Text, out msg) == false)
                {
                    nameForm = "PasswordAnimus";
                    msgForm = msg;

                    msgNotification ms = new msgNotification();
                    ms.ShowDialog();
                    return;
                }

                if (btnSaveHome.Text.ToUpper().Trim().Contains("HOGAR"))
                {
                    if (mailPassword != "" && nickPassword != "" && txtPassword.Text != "")
                    {
                        CoHome coHome = new CoHome();
                        coHome.nickHome = nickPassword;
                        coHome.password = txtPassword.Text;
                        coHome.mail = mailPassword;
                        
                        Boolean internetStatus = true;
                        string sessionToken = string.Empty;
                        coHome = this.homeBussinessRules.Save(coHome, out sessionToken, out internetStatus);
                        if (!internetStatus)
                        {
                            nameForm = "PasswordAnimus";
                            msgForm = "No existe conexión con el servidor, vuelva a reintentarlo.";
                            msgNotification ms = new msgNotification();
                            ms.ShowDialog();
                            return;
                        }
                        if (coHome != null && coHome.idHome != 0)
                        {
                            idHome = coHome.idHome;
                            homeControl = coHome;
                            CoSesion coSession = new CoSesion();
                            coSession.start = DateTime.Now;
                            coSession.token = sessionToken;
                            idSession = new BrSesion().insert(coSession);
                            if (idSession != 0)
                            {
                                this.Hide();
                                ControlCenter c = new ControlCenter();
                                c.ShowDialog();
                            }
                        }
                    }
                }
                else // validate auth
                {
                    if (mailPassword != "" && txtPassword.Text != "")
                    {
                        CoHome coHome = new CoHome();
                        coHome.mail = mailPassword;
                        coHome.password = txtPassword.Text;
                        Boolean internetStatus = true;
                        string sessionToken = string.Empty;
                        coHome = this.homeBussinessRules.Authenticate(coHome, out sessionToken, out internetStatus);
                        if (!internetStatus)
                        {
                            nameForm = "PasswordAnimus";
                            msgForm = "No existe conexión con el servidor, vuelva a reintentarlo.";
                            msgNotification ms = new msgNotification();
                            ms.ShowDialog();
                            return;
                        }
                        if (coHome != null && coHome.idHome != 0)
                        {
                            homeControl = coHome;
                            CoSesion coSession = new CoSesion();
                            coSession.start = DateTime.Now;
                            coSession.token = sessionToken;
                            idSession = new BrSesion().insert(coSession);
                            if (idSession != 0)
                            {
                                this.Hide();
                                ControlCenter c = new ControlCenter();
                                c.ShowDialog();
                            }
                        }
                        else
                        {
                            nameForm = "PasswordAnimus";
                            msgForm = "Usuario o Password Incorrecto.";
                            msgNotification ms = new msgNotification();
                            ms.ShowDialog();
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            // this.Close();
            LoginAnimus login = new LoginAnimus();
            login.ShowDialog();
        }

        private void PasswordAnimus_Load(object sender, EventArgs e)
        {
            mailPassword = LoginAnimus.mail;
            nickPassword = LoginAnimus.nick;


            int idHome = Program.idHome;
            if (idHome != 0)
            {
                DataTable dtHome = new BrHome().GetHomeId(idHome);
                if (dtHome.Rows.Count > 0)
                {
                    lblHogar.Visible = true;
                    string name = dtHome.Rows[0]["nickhome"].ToString();
                    lblHogar.Text = name;
                    btnSaveHome.Text = "Iniciar Sessión";
                    this.btnSaveHome.Location = new System.Drawing.Point(135, 300);
                    this.btnVolver.Visible = false;
                    bunifuCustomLabel2.Visible = false;
                    this.linkPass.Location = new System.Drawing.Point(146, 356);
                    this.linkPass.Visible = true;
                    btnSaveHome.Enabled = true;
                    mailPassword = dtHome.Rows[0]["mail"].ToString();

                }
                else
                {
                    btnSaveHome.Text = "Registrar Hogar";
                    lblHogar.Visible = false;
                    this.btnSaveHome.Location = new System.Drawing.Point(245, 334);
                    bunifuCustomLabel2.Visible = true;
                    this.linkPass.Visible = false;
                    btnSaveHome.Enabled = true;

                }
            }
            else
            {
                btnSaveHome.Text = "Registrar Hogar";
                lblHogar.Visible = false;
                this.btnSaveHome.Location = new System.Drawing.Point(245, 334);
                bunifuCustomLabel2.Visible = true;
                this.linkPass.Visible = false;
                btnSaveHome.Enabled = true;

            }

            #region
            //if (Login.imagePath != "")
            //    imageHomePath = Login.imagePath;
            //if (Login.nameArchive != "")
            //    nameArchiveHome = Login.nameArchive;
            //if (Login.idHome != 0)
            //{
            //    DataTable dtHome = new BrHome().GetHomeId(Login.idHome);
            //    if (dtHome.Rows.Count > 0)
            //    {



            //        //actualizo la imagen y nick
            //        CoHome coHome = new CoHome();
            //        coHome.idHome = Login.idHome;
            //        if (imageHomePath != "" && nameArchiveHome != "")
            //        {
            //            nameArchiveHome = ConfigurationManager.AppSettings["pathImage"] + nameArchiveHome;
            //            if (!File.Exists(nameArchiveHome))
            //                File.Copy(imageHomePath, nameArchiveHome);

            //            coHome.imageHome = nameArchiveHome;
            //        }
            //        else
            //        {
            //            coHome.imageHome = dtHome.Rows[0]["imagehome"].ToString();
            //        }

            //        if (Login.nick != dtHome.Rows[0]["nickhome"].ToString().ToLower())
            //        {
            //            coHome.nickHome = Login.nick;
            //        }
            //        else
            //        {
            //            coHome.nickHome = dtHome.Rows[0]["nickhome"].ToString();
            //        }

            //        new BrHome().UpdateHome(coHome);

            //        btnSaveHome.Text = "Iniciar Sesión";
            //        ////Mando A llamar menu
            //        //// this.Hide();
            //        //this.Close();

            //        //DashBoardMenu dashBoard = new DashBoardMenu();
            //        //dashBoard.ShowDialog();
            //    }
            //    else
            //    {
            //        btnSaveHome.Text = "Registrar Hogar";
            //    }
            //}
            //else { btnSaveHome.Text = "Registrar Hogar"; }
            #endregion
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtPassword.Text.Trim() != "")
                btnSaveHome.Enabled = true;
            else
                btnSaveHome.Enabled = false;
        }
        //METODO OLVIDE MI CONTRASEÑA
        //private void linkPass_Click(object sender, EventArgs e)
        //{
        //    txtPassword.isPassword = true;
        //    if (mailPassword != "" && mailPassword.Contains("@"))
        //    {
        //        string status = string.Empty, code = string.Empty;
        //        Boolean boolPass = new BrAnimusRest().recoverPassword(mailPassword, out  status, out  code);
        //        if (boolPass == true)
        //        {
        //            //mensaje ok
        //            if (status.ToUpper().Trim() == "OK")
        //            {
        //                string msg = "La contraseña fue enviada a su correo electrónico.";
        //                nameForm = "LoginAnimus";
        //                correook = "OK";
        //                msgForm = msg;

        //                msgNotification ms = new msgNotification();
        //                ms.ShowDialog();
        //                return;
        //            }
        //            else
        //            {
        //                string msg = "No se pudo enviar la contraseña al correo.";
        //                nameForm = "LoginAnimus";

        //                msgForm = msg;

        //                msgNotification ms = new msgNotification();
        //                ms.ShowDialog();
        //                return;
        //            }
        //        }
        //        else
        //        {
        //            //mensaje no se pudo
        //            nameForm = "LoginAnimus";
        //            msgForm = "No existe conexión con el servidor, vuelva a reintentarlo.";
        //            msgNotification ms = new msgNotification();
        //            ms.ShowDialog();
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        nameForm = "LoginAnimus";
        //        msgForm = "El campo contraseña es obligatorio.";
        //        msgNotification ms = new msgNotification();
        //        ms.ShowDialog();
        //        return;
        //    }

        //}

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }



        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {
            txtPassword.isPassword = true;
            if (mailPassword != "" && mailPassword.Contains("@"))
            {
                string status = string.Empty, code = string.Empty;
                Boolean boolPass = new BrAnimusRest().recoverPassword(mailPassword, out  status, out  code);
                if (boolPass == true)
                {
                    //mensaje ok
                    if (status.ToUpper().Trim() == "OK")
                    {
                        string msg = "La contraseña fue enviada a su correo electrónico.";
                        nameForm = "LoginAnimus";
                        correook = "OK";
                        msgForm = msg;

                        msgNotification ms = new msgNotification();
                        ms.ShowDialog();
                        return;
                    }
                    else
                    {
                        string msg = "No se pudo enviar la contraseña al correo.";
                        nameForm = "LoginAnimus";

                        msgForm = msg;

                        msgNotification ms = new msgNotification();
                        ms.ShowDialog();
                        return;
                    }
                }
                else
                {
                    //mensaje no se pudo
                    nameForm = "LoginAnimus";
                    msgForm = "No existe conexión con el servidor, vuelva a reintentarlo.";
                    msgNotification ms = new msgNotification();
                    ms.ShowDialog();
                    return;
                }
            }
            else
            {
                nameForm = "LoginAnimus";
                msgForm = "El campo contraseña es obligatorio.";
                msgNotification ms = new msgNotification();
                ms.ShowDialog();
                return;
            }
        }


    }
}
