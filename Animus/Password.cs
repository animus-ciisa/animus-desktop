﻿using Animus.BussinesRules;
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
                        MetroFramework.MetroMessageBox.Show(this, "No existe conexión con el servidor, vuelva a reintentarlo.", "Animus", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                            this.Close();
                            DashBoardMenu dashBoard = new DashBoardMenu();
                            dashBoard.ShowDialog();
                        }

                    }

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

                }
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
        }
    }
}