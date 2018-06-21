using Animus.BussinesRules;
using Animus.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animus
{
    public partial class Password : MetroFramework.Forms.MetroForm
    {
        static string mailPassword = "";
        static string nickPassword = "";
        static string imageHomePath = "";
        static string nameArchiveHome = "";
        public static int idHome = 0;
        public static CoHome homeControl;
        public Password()
        {
            InitializeComponent();
        }

        public Boolean ValidatePassword(String pass)
        {

            Boolean resp = true;
            if (pass == "")
            {
                errorProvider1.SetError(txtPassword, "El campo contraseña es obligatorio.");
                resp = false;
            }
            else
            {
                errorProvider1.SetError(txtPassword, "");
            }
            return resp;
        }
        private void btnSaveHome_Click(object sender, EventArgs e)
        {

            try
            {
                if (ValidatePassword(txtPassword.Text) == false)
                    return;

                if (btnSaveHome.Text.ToUpper().Trim().Contains("HOGAR"))
                { // INSERT HOGAR.
                    //devuelde id select last_insert_rowid();
                    if (mailPassword != "" && nickPassword != "" && txtPassword.Text != "")
                    {
                        CoHome coHome = new CoHome();
                        coHome.nick = nickPassword;
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
                            MetroFramework.MetroMessageBox.Show(this, "No existe conexión con el servidor, vuelva a reintentarlo.", "Animus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        if (coHome.id != 0)
                        {
                            string response = string.Empty;
                            //insertamos home en base de datos
                            //new BrHome().InsertHome(coHome, out response);

                            //GUARDA ARCHIVO CON HOME,ID,MAIL,PASS
                            if (File.Exists(path) && response == "OK")
                            {

                                //remove text archive
                                //File.Delete(path);
                                //create archive
                                idHome = coHome.id;
                                string createText = coHome.id + ";" + coHome.mail + ";" + coHome.nick;
                                File.WriteAllText(path, createText);

                                homeControl = coHome;

                                //this.Close();
                                //DashBoardMenu dashBoard = new DashBoardMenu();
                                //dashBoard.ShowDialog();

                                this.Close();
                                //ControlCenter c = new ControlCenter();
                                //c.ShowDialog();
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
                            MetroFramework.MetroMessageBox.Show(this, "Usuario o Password Incorrecto.", "Animus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        if (status.ToUpper().Trim() != "OK" || code != "201")
                        {
                            MetroFramework.MetroMessageBox.Show(this, "No existe conexión con el servidor, vuelva a reintentarlo.", "Animus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        if (coHome.id != 0)
                        {
                            // mando a llamar al dashboard
                            //this.Hide();
                            //DashBoardMenu d = new DashBoardMenu();
                            //d.ShowDialog();
                            homeControl = coHome;
                            this.Hide();
                            //ControlCenter c = new ControlCenter();
                            //c.ShowDialog();
                        }
                        else
                        {
                            MetroFramework.MetroMessageBox.Show(this, "No se pudo rescatar los datos del usuario, favor reintentar.", "Animus", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            Login login = new Login();
            login.ShowDialog();


        }

        private void Password_Load(object sender, EventArgs e)
        {
            mailPassword = Login.mail;
            nickPassword = Login.nick;

            //int idHome = Program.idHome;
            if (idHome != 0)
            {
                /*DataTable dtHome = new BrHome().GetHomeId(idHome);
                if (dtHome.Rows.Count > 0)
                {
                    lblHogar.Visible = true;
                    string name = dtHome.Rows[0]["nickhome"].ToString();
                    lblHogar.Text = name;
                    btnSaveHome.Text = "Iniciar Sessión";
                    this.btnSaveHome.Location = new System.Drawing.Point(135, 300);
                    this.btnVolver.Visible = false;
                    metroLabel1.Visible = false;
                    this.linkPass.Location = new System.Drawing.Point(138, 356);
                    this.linkPass.Visible = true;
                    btnSaveHome.Enabled = false;
                    mailPassword = dtHome.Rows[0]["mail"].ToString();

                }
                else
                {
                    btnSaveHome.Text = "Registrar Hogar";
                    lblHogar.Visible = false;
                    this.btnSaveHome.Location = new System.Drawing.Point(212, 337);
                    metroLabel1.Visible = true;
                    this.linkPass.Visible = false;
                    btnSaveHome.Enabled = true;

                }*/
            }
            else
            {
                btnSaveHome.Text = "Registrar Hogar";
                lblHogar.Visible = false;
                this.btnSaveHome.Location = new System.Drawing.Point(212, 337);
                metroLabel1.Visible = true;
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
        private void linkPass_Click(object sender, EventArgs e)
        {
            if (mailPassword != "" && mailPassword.Contains("@"))
            {
                string status = string.Empty, code = string.Empty;
                Boolean boolPass = new BrAnimusRest().recoverPassword(mailPassword, out  status, out  code);
                if (boolPass == true)
                {
                    //mensaje ok
                }
                else
                {
                    //mensaje no se pudo
                }
            }
        }
    }
}
