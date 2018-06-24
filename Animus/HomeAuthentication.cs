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
    public partial class HomeAuthentication : Form
    {
        private CoHome activeHome;
        BrHome brHome = new BrHome();
        string msg = string.Empty;

        public HomeAuthentication(CoHome home)
        {
            InitializeComponent();
            this.activeHome = home;
            lblHogar.Text = activeHome.nick.ToUpper();
            homeCover.Load(activeHome.image);
        }

        private void btnSaveHome_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != "")
            {
                this.activeHome.password = txtPassword.Text;
                Boolean internetStatus = true;
                string sessionToken = string.Empty;
                this.activeHome = this.brHome.Authenticate(this.activeHome, out sessionToken, out internetStatus);

                if (!internetStatus)
                {
                    //MessageBox.Show("No existe conexión a internet, intentelo más tarde");

                    msg = "No existe conexión a internet, intentelo más tarde.";
                    msgNotification c = new msgNotification("homeAuthentication", msg);
                    c.ShowDialog();
                    return;
                }

                if (this.activeHome != null && this.activeHome.id != 0)
                {
                    CoSesion session = new CoSesion();
                    session.start = DateTime.Now;
                    session.token = sessionToken;
                    int idSession = new BrSesion().Save(session);
                    if (idSession != 0)
                    {
                        session.id = idSession;
                        this.Hide();
                        ControlCenter c = new ControlCenter(this.activeHome, session);
                        c.ShowDialog();
                    }
                }
                else
                {
                    //MessageBox.Show("Usuario o Password Incorrecto");
                    msg = "Usuario o Password Incorrecto";
                    msgNotification c = new msgNotification("homeAuthentication", msg);
                    c.ShowDialog();
                    return;
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomeRegistry login = new HomeRegistry();
            login.ShowDialog();
        }

        private void PasswordAnimus_Load(object sender, EventArgs e)
        {

        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtPassword.Text.Trim() != "")
            {

                btnSaveHome.Enabled = true;
                if (e.KeyChar == (char)Keys.Enter)//si preciona el enter llamar al metodo del boton inciar session
                    btnSaveHome_Click(null, null);

            }
            else
            { btnSaveHome.Enabled = false; }
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }



        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {

        }
    }
}
