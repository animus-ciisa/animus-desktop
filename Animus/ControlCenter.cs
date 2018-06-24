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
        public CoHome activeHome;
        private CoSesion activeSession;
        private BrBatch brBatch;
        //   public static CoHome homecontrol;

        public ControlCenter(CoHome home, CoSesion session)
        {
            this.activeHome = home;

            InitializeComponent();


            alarms1.BringToFront();
            this.brBatch = new BrBatch();
            this.brBatch.StartProcess();

            this.activeSession = session;
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            new BrSesion().CloseSession(this.activeSession);
            msgCloseSession msg = new msgCloseSession();
            msg.ShowDialog();
            this.Hide();
        }

        private void ControlCenter_Load(object sender, EventArgs e)
        {
            //  this.btnMenu.Location = new System.Drawing.Point(215, 0);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            /*if (panelMenu.Width == 50)
            {
                panelMenu.Visible = false;
                this.btnMenu.Location = new System.Drawing.Point(215, 0);
                panelMenu.Width = 265;
            }
            else
            {
                panelMenu.Visible = false;
                this.btnMenu.Location = new System.Drawing.Point(0, 0);
                panelMenu.Width = 50;    
            }*/
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

        private void btnHabitantes_Click(object sender, EventArgs e)
        {
            listHabitant1.Visible = false;
            listHabitant1.BringToFront();
            buninfuMenu.ShowSync(listHabitant1);
        }
    }
}
