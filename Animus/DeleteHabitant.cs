using Animus.BussinesRules;
using Animus.Common;
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
    public partial class DeleteHabitant : Form
    {
        private CoHabitant habitant;
        private BrHabitant brHabitant;
        string nameform = "RegisterHabitant", msg = "";
        public DeleteHabitant(CoHabitant coHabitant)
        {
            habitant = new CoHabitant();
            brHabitant = new BrHabitant();
            habitant = coHabitant;
            //Falta cargar la foto del habitante
            InitializeComponent();

            lblResponsable.Text = "¿Está seguro que desea eliminar al habitante " + habitant.name + "?";

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //ELIMINAR rest

            //ELIMINAR BD LOCAL
            brHabitant.Delete(habitant.idhabitant);
            msg = "OK- Habitante eliminado con éxito.";
            msgNotification ms = new msgNotification(nameform, msg);
            ms.ShowDialog();






        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
