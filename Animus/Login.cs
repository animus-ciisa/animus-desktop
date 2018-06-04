using Animus.BussinesRules;
using Animus.Common;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Animus
{
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        public static string mail = "", nick = "";
        public static int idHome = 0;
        public static string imagePath = "", nameArchive = "";
        public static string imageDefault = ConfigurationManager.AppSettings["imageDefault"];
        public static string pathImageDefault = ConfigurationManager.AppSettings["pathImage"];
        public Login()
        {
            InitializeComponent();
            GenerateDataBase();


            string path = System.IO.Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "");
            path = path + "\\" + "usr.txt";
            if (!File.Exists(path))
            {
                File.Create(path);
            }

            //Generar_Test();
        }
        public void GenerateDataBase()
        {
            try
            {
                BrHome br = new BrHome();
                br.GenerateDataBase();
            }
            catch (Exception ex)
            {

            }
        }
        public void Generar_Test()
        {
            CoTest comtest = new CoTest();
            BrTest br = new BrTest();

            br.Create_DataBase();
            br = new BrTest();

            comtest = new CoTest();
            comtest.id = 2;
            comtest.name = "Android";
            br.insert_test(comtest);

            comtest = new CoTest();
            comtest.id = 2;
            comtest.name = "Fedora";
            br.update_test(comtest);


            comtest = new CoTest();
            comtest.id = 2;
            br.delete_test(comtest);


            DataTable dt = br.trae_registro();
        }

        public Boolean ValidateFields()
        {
            Boolean validate = true;
            BrHome br = new BrHome();
            if (txtCorreo.Text == "")
            {
                errorProvider.SetError(txtCorreo, "El campo Correo Electrónico es obligatorio.");
                validate = false;
            }
            else
            {
                errorProvider.SetError(txtCorreo, "");

            }
            if (txtNick.Text == "")
            {
                errorProvider.SetError(txtNick, "El campo Nick del Hogar es obligatorio.");
                validate = false;
            }
            else
            {
                errorProvider.SetError(txtNick, "");
            }
            if (txtCorreo.Text != "")
            {
                if (br.validateMail(txtCorreo.Text) == false)
                {
                    errorProvider.SetError(txtCorreo, "El campo Correo Electrónico no tiene un formato correcto.");
                    validate = false;
                }
                else
                {
                    errorProvider.SetError(txtCorreo, "");
                }

            }
            return validate;
        }
        //Metodo encargado de registrar
        private void btnRegistro_Click(object sender, EventArgs e)
        {

            if (ValidateFields() == false)
            {
                return;
            }


            //si el email ya existe lo tengo que mandar a iniciar session
            string status = string.Empty, code = string.Empty;
            BrAnimusRest brAnimus = new BrAnimusRest();
            Boolean validateMail = brAnimus.validateMail(txtCorreo.Text, out status, out code);

            if (status.ToUpper().Trim() != "OK" || code != "200")
            {
                MetroFramework.MetroMessageBox.Show(this, "No existe conexión con el servidor, vuelva a reintentarlo.", "Animus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (validateMail == true)
            {
                txtCorreo.Text = string.Empty;
                txtNick.Text = string.Empty;
                MetroFramework.MetroMessageBox.Show(this, "La cuenta de correo existe, debe ingresar por la opción ya tengo una cuenta.", "Animus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //PASSING VARIABLES

            this.Hide();
            mail = txtCorreo.Text;
            nick = txtNick.Text;

            Password pass = new Password();
            pass.ShowDialog();


        }

        //METODO PARA EXAMINAR Y GUARDAR RUTA
        private void btnUpload_Click(object sender, EventArgs e)
        {

            this.openFileDialog1.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                if (openFileDialog1.FileName != "")
                {
                    if (openFileDialog1.FileName.Contains(".jpeg") || openFileDialog1.FileName.Contains(".jpg")
                        || openFileDialog1.FileName.Contains(".bmp") || openFileDialog1.FileName.Contains(".png"))
                    {
                        imagePath = openFileDialog1.FileName;
                        nameArchive = openFileDialog1.SafeFileName;

                        btnImageOk.Visible = true;

                        pictureBox1.Image = Image.FromFile(imagePath);

                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Debe seleccionar una imagen con formato .jpg/.bmp/.png", "Animus", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        btnImageOk.Visible = false;
                        pictureBox1.Image = Image.FromFile(pathImageDefault + imageDefault);
                    }
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Debe seleccionar una imagen.", "Animus", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnImageOk.Visible = false;
                    pictureBox1.Image = Image.FromFile(pathImageDefault + imageDefault);
                }
            }
            else
            {

                btnImageOk.Visible = false;
                pictureBox1.Image = Image.FromFile(pathImageDefault + imageDefault);
            }
        }

        private void btnUpload_MouseHover(object sender, EventArgs e)
        {
            this.metroToolTip1.SetToolTip(this.btnUpload, " Buscar una imagen de avatar para que sea cargada.");
        }

        private void btnImageOk_MouseHover(object sender, EventArgs e)
        {
            this.metroToolTip1.SetToolTip(this.btnImageOk, " Imagen cargada con éxito.");
        }


        public void validateMailPost(String correo)
        {
            try
            {
                string url = ConfigurationManager.AppSettings["urlEmailValidate"];
                HttpWebRequest webRequest;

                //  string requestParams = ("{email:" + correo + "}");

                string requestParams = "{ \"email\": \"" + correo + "\"}";

                //format information you need to pass into that string ('info={ "EmployeeID": [ "1234567", "7654321" ], "Salary": true, "BonusPercentage": 10}');

                // webRequest = (HttpWebRequest)WebRequest.Create("http://localhost:1111/animus-rest-test/?method=list");

                // webRequest = (HttpWebRequest)WebRequest.Create("http://localhost:1111/animus-rest-test/?method=home/validate-email&exists=true");


                webRequest = (HttpWebRequest)WebRequest.Create(url);


                webRequest.Method = "POST";
                webRequest.ContentType = "application/json";

                byte[] byteArray = Encoding.UTF8.GetBytes(requestParams);
                webRequest.ContentLength = byteArray.Length;
                using (Stream requestStream = webRequest.GetRequestStream())
                {
                    requestStream.Write(byteArray, 0, byteArray.Length);
                }

                // Get the response.
                using (WebResponse response = webRequest.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        StreamReader rdr = new StreamReader(responseStream, Encoding.UTF8);
                        var rawJson = new StreamReader(response.GetResponseStream()).ReadToEnd();
                        JObject json = JObject.Parse(rawJson);  //Turns your raw string into a key value lookup


                        //CUANDO NO ES ARRAY
                        string idhome = json["data"]["id"].ToString();



                        //CUANDO ES ARRAY
                        JArray array = (JArray)json["data"];

                        if (array.Count > 0)
                        {
                            foreach (JObject item in array)
                            {
                                string id_ = item.GetValue("id").ToString();
                                string image = item.GetValue("image").ToString();
                                string email = item.GetValue("email").ToString();
                                string nick = item.GetValue("nick").ToString();
                                string session = item.GetValue("sesion").ToString();
                            }
                        }
                        string id = (string)json["data"]["id"];


                        //CUANDO NO ES ARRAY



                        for (int i = 0; i < json["data"].ToArray().Count(); i++)
                        {

                        }

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if (txtCorreo.Text != "")
            {
                BrHome br = new BrHome();
                //vamos a validar que el correo sea valido
                if (br.validateMail(txtCorreo.Text) == true)
                {

                    //si el email ya existe lo tengo que mandar a iniciar session
                    string status = string.Empty, code = string.Empty;
                    BrAnimusRest brAnimus = new BrAnimusRest();
                    Boolean validateMail = brAnimus.validateMail(txtCorreo.Text, out status, out code);

                    if (status.ToUpper().Trim() != "OK" || code != "200")
                    {
                        MetroFramework.MetroMessageBox.Show(this, "No existe conexión con el servidor, vuelva a reintentarlo.", "Animus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (validateMail == true)
                    {
                        MetroFramework.MetroMessageBox.Show(this, "La cuenta de correo existe, debe ingresar por la opción ya tengo una cuenta.", "Animus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    //CoHome coHome = new CoHome();
                    //int homeIdRescue = 0;
                    //coHome.mail = txtCorreo.Text;
                    ////buscamos si el correo es valido para cargar la foto en el picture
                    //int countExist = new BrHome().HomeExits(coHome, out homeIdRescue);
                    //if (homeIdRescue != 0)
                    //{
                    //    DataTable dtHome = new BrHome().GetHomeId(homeIdRescue);
                    //    if (dtHome.Rows.Count > 0)
                    //    {
                    //        string pathImage = dtHome.Rows[0]["imagehome"].ToString();
                    //        if (pathImage != "")
                    //            pictureBox1.Image = Image.FromFile(pathImage);
                    //        else
                    //            pictureBox1.Image = Image.FromFile(pathImageDefault + imageDefault);
                    //        txtNick.Text = dtHome.Rows[0]["nickhome"].ToString();
                    //        errorProvider.SetError(txtCorreo, "");
                    //        errorProvider.SetError(txtNick, "");
                    //        idHome = Convert.ToInt32(dtHome.Rows[0]["idhome"].ToString());
                    //    }
                    //}
                    //else
                    //{
                    //    if (File.Exists(pathImageDefault + imageDefault))
                    //    {
                    //        pictureBox1.Image = Image.FromFile(pathImageDefault + imageDefault);
                    //        txtNick.Text = "";
                    //        errorProvider.SetError(txtCorreo, "");
                    //        errorProvider.SetError(txtNick, "");
                    //    }
                    //    idHome = 0;
                    //    mail = "";
                    //    nick = "";
                    //}
                }
                else
                {

                    MetroFramework.MetroMessageBox.Show(this, "El campo correo electrónico no tiene un formato correcto.", "Animus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCorreo.Text = string.Empty;
                    txtNick.Text = string.Empty;
                    //    if (File.Exists(pathImageDefault + imageDefault))
                    //    {
                    //        pictureBox1.Image = Image.FromFile(pathImageDefault + imageDefault);
                    //        txtNick.Text = "";
                    //        errorProvider.SetError(txtCorreo, "");
                    //        errorProvider.SetError(txtNick, "");
                    //    }
                    //    idHome = 0;
                    //    mail = "";
                    //    nick = "";
                }
            }
            else
            {
                //idHome = 0;
                //mail = "";
                //nick = "";
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {


            string path = System.IO.Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "");
            path = path + "\\" + "usr.txt";

            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (s.Contains(";"))
                        {
                            string id = s.Split(';')[0].ToString();
                            string correo = s.Split(';')[1].ToString();
                            string nick = s.Split(';')[2].ToString();



                            Password pass = new Password();
                            pass.ShowDialog();

                            this.Close();
                        }
                    }
                }
            }
        }


    }
}
