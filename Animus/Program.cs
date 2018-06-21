using Animus.BussinesRules;
using Animus.Common;
using Animus.DataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animus
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CoHome home = new BrHome().Exists();

            if (home != null)
            {
                Application.Run(new HomeAuthentication(home));
            }
            else
            {
                Application.Run(new HomeRegistry());
            }
            
        }
    }
}
