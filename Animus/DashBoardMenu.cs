using Animus.BussinesRules;
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
    public partial class DashBoardMenu : Form
    {
        public static int idHomeDashBoard = 0;
        public DashBoardMenu()
        {
            InitializeComponent();
        }

        private void DashBoardMenu_Load(object sender, EventArgs e)
        {


            idHomeDashBoard = Password.idHome;

            /*DataTable dtHome = new BrHome().GetHomeId(idHomeDashBoard);
            if (dtHome.Rows.Count > 0)
            {
                string pathImage = dtHome.Rows[0]["imagehome"].ToString();
                if (pathImage != "")
                    pictureBox1.Image = Image.FromFile(pathImage);

            }*/


        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
