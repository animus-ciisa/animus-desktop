using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animus
{
    public partial class msgCloseSession : Form
    {
        public static string nameFormSession = "";
        public msgCloseSession()
        {
            InitializeComponent();
            Timer MyTimer = new Timer();
            MyTimer.Interval = 4000;
            MyTimer.Tick += new EventHandler(MyTimer_Tick);
            MyTimer.Start();
        }
        private void MyTimer_Tick(object sender, EventArgs e)
        {
            nameFormSession = "CloseSesion";
            //System.Windows.Forms.Application.Exit();
            Environment.Exit(0);
        }
        private void msgCloseSession_Load(object sender, EventArgs e)
        {
            //bunifuFormFadeTransition1.ShowAsyc(this);
            buninfuPop.ShowSync(this);
        }
    }
}
