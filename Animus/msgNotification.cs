﻿using System;
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

            if (HomeRegistry.nameForm != null && HomeRegistry.nameForm != "")
            {
                this.pictureBox2.Location = new System.Drawing.Point(5, 47);
                picOK.Visible = false;
                if (HomeRegistry.msgForm != "" && HomeRegistry.msgForm != null)
                {
                    string msg = HomeRegistry.msgForm;
                    lblMsge.Text = msg;
                    HomeRegistry.nameForm = string.Empty;
                    HomeRegistry.nameForm = string.Empty;
                }

            }
            /*if (HomeAuthentication.nameForm != null && HomeAuthentication.nameForm != "")
            {


                if (HomeAuthentication.msgForm != "" && HomeAuthentication.msgForm != null)
                {
                    if (HomeAuthentication.correook == "OK")
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
                    string msg = HomeAuthentication.msgForm;
                    lblMsge.Text = msg;
                    HomeAuthentication.nameForm = string.Empty;
                    HomeAuthentication.msgForm = string.Empty;
                    HomeAuthentication.correook = string.Empty;
                }
            }*/
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
