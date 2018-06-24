﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Animus.Common;

namespace Animus
{
    public partial class ListHabitant : UserControl
    {
        public CoHome coHome;

        public ListHabitant(CoHome home)
        {
            // TODO: Complete member initialization
            this.coHome = home;
            InitializeComponent();
        }

        public ListHabitant()
        { }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            RegisterHabitant register = new RegisterHabitant(coHome);
            register.Show();
        }
    }
}
