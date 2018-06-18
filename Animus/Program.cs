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
        public static int idHome = 0;
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DaHome daHome = new DaHome();
            CoHome home = daHome.Exists();
            if (home != null)
            {
                idHome = home.idHome;
                Application.Run(new PasswordAnimus());
            }
            else
            {
                Application.Run(new LoginAnimus());
            }
            /*string path = System.IO.Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "");
            path = path + "\\" + "usr.txt";

            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string status = "";
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (s.Contains(";"))
                        {
                            idHome = Convert.ToInt32(s.Split(';')[0].ToString());
                            status = "ok";
                        }
                    }
                    if (status == "ok")
                    {
                        Application.Run(new PasswordAnimus());

                    }
                    else
                    {
                        Application.Run(new LoginAnimus());
                    }
                }
            }
            else
            {

                Application.Run(new LoginAnimus());
            }*/
        }
    }
}
