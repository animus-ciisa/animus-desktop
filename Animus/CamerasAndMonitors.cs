using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animus
{
    public partial class CamerasAndMonitors : UserControl
    {
        public CamerasAndMonitors()
        {
            InitializeComponent();
            Button button1 = new Button();
            Button button2 = new Button();

            button1.Text = "Boton 1";
            button2.Text = "Boton 2";

            //button1.Width = this.tableLayoutPanel1.Width;
            //button2.Width = this.tableLayoutPanel1.Width;

            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.Controls.Add(button1);
            this.tableLayoutPanel1.Controls.Add(button2);
        }


    }
}
