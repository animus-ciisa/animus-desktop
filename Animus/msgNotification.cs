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
    public partial class msgNotification : Form
    {
        public msgNotification()
        {
            InitializeComponent();

            if (LoginAnimus.nameForm != null && LoginAnimus.nameForm != "")
            {
                this.pictureBox2.Location = new System.Drawing.Point(5, 47);
                picOK.Visible = false;
                if (LoginAnimus.msgForm != "" && LoginAnimus.msgForm != null)
                {
                    string msg = LoginAnimus.msgForm;
                    lblMsge.Text = msg;
                    LoginAnimus.nameForm = string.Empty;
                    LoginAnimus.nameForm = string.Empty;
                }

            }
            if (PasswordAnimus.nameForm != null && PasswordAnimus.nameForm != "")
            {


                if (PasswordAnimus.msgForm != "" && PasswordAnimus.msgForm != null)
                {
                    if (PasswordAnimus.correook == "OK")
                    {
                        this.picOK.Location = new System.Drawing.Point(5, 47);
                        this.picOK.Visible = true;

                        pictureBox2.Visible = false;
                    }
                    else
                    {
                        this.pictureBox2.Location = new System.Drawing.Point(5, 47);
                        this.picOK.Visible = false;
                        pictureBox2.Visible = true;
                    }
                    string msg = PasswordAnimus.msgForm;
                    lblMsge.Text = msg;
                    PasswordAnimus.nameForm = string.Empty;
                    PasswordAnimus.msgForm = string.Empty;
                    PasswordAnimus.correook = string.Empty;
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
