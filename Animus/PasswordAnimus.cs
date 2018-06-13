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
                { // INSERT HOGAR.
                    //devuelde id select last_insert_rowid();
                    if (mailPassword != "" && nickPassword != "" && txtPassword.Text != "")
                    {
                        CoHome coHome = new CoHome();
                        coHome.nickHome = nickPassword;
                        coHome.password = txtPassword.Text;
                        coHome.mail = mailPassword;
                        string status = string.Empty;
                        string code = string.Empty;

                        string fullimagepath = Path.Combine(Application.StartupPath);

                        string path = System.IO.Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "");
                        path = path + "\\" + "usr.txt";

                        //Consumir post al insert casa
                        coHome = new BrAnimusRest().registerHome(out status, out code, coHome);

                        if (status.ToUpper().Trim() != "OK" || code != "201")
                        {
                            //   MetroFramework.MetroMessageBox.Show(this, "No existe conexión con el servidor, vuelva a reintentarlo.", "Animus", MessageBoxButtons.OK, MessageBoxIcon.Information);


                            nameForm = "PasswordAnimus";
                            msgForm = "No existe conexión con el servidor, vuelva a reintentarlo.";

                            msgNotification ms = new msgNotification();
                            ms.ShowDialog();

                            return;
                        }

                        if (coHome.idHome != 0)
                        {
                            string response = string.Empty;
                            //insertamos home en base de datos
                            new BrHome().InsertHome(coHome, out response);

                            //GUARDA ARCHIVO CON HOME,ID,MAIL,PASS
                            if (File.Exists(path) && response == "OK")
                            {

                                //remove text archive
                                //File.Delete(path);
                                //create archive
                                idHome = coHome.idHome;
                                string createText = coHome.idHome + ";" + coHome.mail + ";" + coHome.nickHome;
                                File.WriteAllText(path, createText);

                                homeControl = coHome;

                                //this.Close();
                                //DashBoardMenu dashBoard = new DashBoardMenu();
                                //dashBoard.ShowDialog();

                                //INSERTO EN BD
                                CoSesion coSession = new CoSesion();
                                coSession.start = DateTime.Now;
                                coSession.token = coHome.tookenHome;

                                idSession = new BrSesion().insert(coSession);

                                if (idSession != 0)
                                {
                                    // this.Close();
                                    this.Hide();
                                    ControlCenter c = new ControlCenter();
                                    c.ShowDialog();
                                }
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
                        string status = string.Empty;
                        string code = string.Empty;

                        //consume validate password
                        new BrAnimusRest().validateAuth(out status, out code, coHome);

                        if (status.ToUpper().Trim() != "OK" || code == "402")
                        {
                            //  MetroFramework.MetroMessageBox.Show(this, "Usuario o Password Incorrecto.", "Animus", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            nameForm = "PasswordAnimus";
                            msgForm = "Usuario o Password Incorrecto.";

                            msgNotification ms = new msgNotification();
                            ms.ShowDialog();
                            return;
                        }

                        if (status.ToUpper().Trim() != "OK" || code != "201")
                        {
                            // MetroFramework.MetroMessageBox.Show(this, "No existe conexión con el servidor, vuelva a reintentarlo.", "Animus", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            nameForm = "PasswordAnimus";
                            msgForm = "No existe conexión con el servidor, vuelva a reintentarlo.";

                            msgNotification ms = new msgNotification();
                            ms.ShowDialog();
                            return;

                        }

                        if (coHome.idHome != 0)
                        {
                            // mando a llamar al dashboard
                            //this.Hide();
                            //DashBoardMenu d = new DashBoardMenu();
                            //d.ShowDialog();
                            homeControl = coHome;


                            //aqui inserto cuando inicio
                            BrAnimusRest brRest = new BrAnimusRest();
                            string status_ = string.Empty, code_ = string.Empty;

                            //INSERTO EN BD
                            CoSesion coSession = new CoSesion();
                            coSession.start = DateTime.Now;
                            coSession.token = coHome.tookenHome;


                            idSession = new BrSesion().insert(coSession);



                            //string tookenResponse = brRest.renewToken(tooken, out status_, out code_);
                            //if (tookenResponse != "")
                            //{

                            //    //INSERTO EN BD Y AQUI VOY RENOVANDO AGREGAR LLAMADA BD
                            //    PasswordAnimus.homeControl.tookenHome = tookenResponse;
                            //}


                            if (idSession != 0)
                            {
                                this.Hide();
                                //this.Close();
                                ControlCenter c = new ControlCenter();
                                c.ShowDialog();

                            }
                        }
                        else
                        {
                            // MetroFramework.MetroMessageBox.Show(this, "No se pudo rescatar los datos del usuario, favor reintentar.", "Animus", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            nameForm = "PasswordAnimus";
                            msgForm = "No se pudo rescatar los datos del usuario, favor reintentar.";

                            msgNotification ms = new msgNotification();
                            ms.ShowDialog();
                            return;
                        }
                    }
                }

                #region
                //CoHome coHome = new CoHome();
                //coHome.nickHome = nickPassword;
                //coHome.password = txtPassword.Text;
                //coHome.mail = mailPassword;

                //if (imageHomePath != "")
                //    coHome.pathImageHome = imageHomePath;

                //if (nameArchiveHome != "")
                //    coHome.imageHome = nameArchiveHome;

                //int homeIdRescue = 0;
                ////vamos a validar si existe el home con el correo y nick
                //int countExist = new BrHome().HomeExits(coHome, out homeIdRescue);
                //if (countExist == 0)
                //{
                //    //inserto home
                //    idHome = new BrHome().InsertHome(coHome);
                //    if (idHome > 0)
                //    {
                //        //Mando A llamar menu
                //        this.Hide();

                //        DashBoardMenu dashBoard = new DashBoardMenu();
                //        dashBoard.ShowDialog();
                //    }
                //    else
                //    {
                //        MetroFramework.MetroMessageBox.Show(this, "No se pudo registrar el Hogar, pongase en contacto con el administrador.", "Animus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //}
                //else
                //{
                //    if (countExist == 1 && homeIdRescue != 0)
                //    {
                //        coHome.idHome = homeIdRescue;
                //        //validar password
                //        Boolean validatePass = new BrHome().validatePassword(coHome);

                //        if (validatePass == false)
                //        {
                //            MetroFramework.MetroMessageBox.Show(this, "La contraseña es incorrecta.", "Animus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //            return;
                //        }



                //        idHome = homeIdRescue;
                //        //Mando A llamar menu
                //        this.Hide();

                //        DashBoardMenu dashBoard = new DashBoardMenu();
                //        dashBoard.ShowDialog();
                //    }
                //    else
                //    {
                //        MetroFramework.MetroMessageBox.Show(this, "No se pudieron rescatar los datos del Hogar, pongase en contacto con el administrador.", "Animus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //}
                #endregion


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
