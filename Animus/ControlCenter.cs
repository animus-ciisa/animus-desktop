using Animus.BussinesRules;
using Animus.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animus
{
    public partial class ControlCenter : Form
    {
        public ControlCenter()
        {
            InitializeComponent();
            alarms1.BringToFront();



            Timer MyTimer = new Timer();
            MyTimer.Interval = Convert.ToInt32(ConfigurationManager.AppSettings["timerConsumeToken"]);//5000;
            MyTimer.Tick += new EventHandler(MyTimer_Tick);
            MyTimer.Start();
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("The form will now be closed.", "Time Elapsed");
            //this.Close();

            //  consume tooken 
            CoHome homeCo = Password.homeControl; // pasar objeto entero con tooken incluido
            string tooken = homeCo.tookenHome;
            BrAnimusRest brRest = new BrAnimusRest();
            string status = string.Empty, code = string.Empty;
            string tookenResponse = brRest.renewToken(tooken, out status, out code);
            if (tookenResponse != "")
            {

                //INSERTO EN BD Y AQUI VOY RENOVANDO
                Password.homeControl.tookenHome = tookenResponse;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            msgCloseSession msg = new msgCloseSession();
            msg.ShowDialog();
            
            //this.Close();
        }

        private void ControlCenter_Load(object sender, EventArgs e)
        {
            //  this.btnMenu.Location = new System.Drawing.Point(215, 0);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (panelMenu.Width == 50)
            {
                panelMenu.Visible = false;
                this.btnMenu.Location = new System.Drawing.Point(215, 0);
                panelMenu.Width = 265;
                panelAnimator.ShowSync(panelMenu);



            }
            else
            {

                panelMenu.Visible = false;
                this.btnMenu.Location = new System.Drawing.Point(0, 0);
                panelMenu.Width = 50;
                panelAnimator.ShowSync(panelMenu);
            }

        }

        private void btnAlarmas_Click(object sender, EventArgs e)
        {
            alarms1.Visible = false;
            alarms1.BringToFront();
            buninfuMenu.ShowSync(alarms1);
        }

        private void btnCamaras_Click(object sender, EventArgs e)
        {
            camerasAndMonitors1.Visible = false;
            camerasAndMonitors1.BringToFront(); // al hacer click muestrame camaras y monitores
            buninfuMenu.ShowSync(camerasAndMonitors1);
        }
    }
}
