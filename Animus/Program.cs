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



            string path = System.IO.Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "");
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
                            status = "ok";
                    }
                    if (status == "ok")
                        Application.Run(new Password());
                    else
                        Application.Run(new Login());
                }
            }
            else
            {

                Application.Run(new Login());
            }

        }
    }
}
