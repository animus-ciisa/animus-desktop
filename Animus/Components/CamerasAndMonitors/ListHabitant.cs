using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Animus.Common;
using Animus.BussinesRules;

namespace Animus
{
    public partial class ListHabitant : UserControl
    {
        public CoHome coHome;
        private BrHome brHome;
        private BrHabitant brHabitant;
        private CoHabitant coHabitant;


        public ListHabitant()
        {
            brHabitant = new BrHabitant();
            brHome = new BrHome();
            coHome = new BrHome().Exists();
            // TODO: Complete m
            InitializeComponent();
            DrawDynamic();//dibuja usuarios registrados
        }
        public void DrawDynamic()
        {
            //path configurada
            //   string pathImageDefault = ConfigurationManager.AppSettings["pathImage"];



            string path = System.IO.Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "");
            path = path + "\\" + "Images\\Application\\";


            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListHabitant));

            IList<CoHabitant> listHabitant = brHabitant.GetAll();
            if (listHabitant.Count > 0) //dibuja usuarios
            {
                int poscheck = 75;
                int posimg = 27;
                int posname = 75;
                int posedit = 75;
                int posdelete = 75;
                int idtab = 2;
                foreach (CoHabitant coHabitante in listHabitant)
                {

                    //CHECKBOX EDITAR
                    Bunifu.Framework.UI.BunifuCheckbox bunifuCheckbox11 = new Bunifu.Framework.UI.BunifuCheckbox();
                    bunifuCheckbox11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
                    bunifuCheckbox11.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(100)))), ((int)(((byte)(254)))));
                    bunifuCheckbox11.Checked = false;
                    bunifuCheckbox11.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
                    bunifuCheckbox11.ForeColor = System.Drawing.Color.White;
                    bunifuCheckbox11.Location = new System.Drawing.Point(48, poscheck);
                    bunifuCheckbox11.Name = coHabitante.idhabitant.ToString() + "-check";
                    bunifuCheckbox11.Size = new System.Drawing.Size(20, 20);
                    bunifuCheckbox11.TabIndex = idtab;
                    idtab += 1;

                    poscheck += 168;


                    this.panelCenter.Controls.Add(bunifuCheckbox11);


                    //IMAGEN DEL HABITANTE
                    PictureBox picturebox11 = new PictureBox();
                    picturebox11.Image = ((System.Drawing.Image)(resources.GetObject("picturebox11.Image")));
                    picturebox11.Location = new System.Drawing.Point(130, posimg);
                    picturebox11.Name = coHabitante.idhabitant.ToString() + "-img";//"picturebox11";
                    picturebox11.Size = new System.Drawing.Size(143, 110);
                    picturebox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    picturebox11.TabIndex = idtab;
                    picturebox11.TabStop = false;
                    picturebox11.Image = Image.FromFile(path + "user.png");
                    idtab += 1;

                    posimg += 168;

                    this.panelCenter.Controls.Add(picturebox11);


                    //NOMBRE DEL HABITANTE
                    Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel4 = new Bunifu.Framework.UI.BunifuCustomLabel();
                    bunifuCustomLabel4.AutoSize = true;
                    bunifuCustomLabel4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    bunifuCustomLabel4.ForeColor = System.Drawing.Color.Silver;
                    bunifuCustomLabel4.Location = new System.Drawing.Point(303, posname);
                    bunifuCustomLabel4.Name = coHabitante.idhabitant.ToString() + "-name";//"bunifuCustomLabel4";
                    bunifuCustomLabel4.Size = new System.Drawing.Size(151, 17);
                    bunifuCustomLabel4.TabIndex = idtab;
                    bunifuCustomLabel4.Text = coHabitante.name + " " + coHabitante.lastname;
                    idtab += 1;

                    posname += 168;

                    this.panelCenter.Controls.Add(bunifuCustomLabel4);


                    //IMAGEN EDITAR
                    PictureBox picturebox12 = new PictureBox();
                    picturebox12.Image = ((System.Drawing.Image)(resources.GetObject("picturebox12.Image")));
                    picturebox12.Location = new System.Drawing.Point(502, posedit);
                    picturebox12.Name = coHabitante.idhabitant.ToString() + "-imgedit";//"picturebox12";
                    picturebox12.Size = new System.Drawing.Size(23, 20);
                    picturebox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    picturebox12.TabIndex = idtab;
                    picturebox12.TabStop = false;
                    picturebox12.Image = Image.FromFile(path + "edit.png");
                    picturebox12.Click += new EventHandler(PictureBoxEdit_Click);
                    idtab += 1;

                    posedit += 168;

                    this.panelCenter.Controls.Add(picturebox12);


                    //IMAGEN ELIMINAR
                    PictureBox picturebox13 = new PictureBox();
                    picturebox13.Image = ((System.Drawing.Image)(resources.GetObject("picturebox13.Image")));
                    picturebox13.Location = new System.Drawing.Point(539, posdelete);
                    picturebox13.Name = coHabitante.idhabitant.ToString() + "-imgdelete";//"picturebox13";
                    picturebox13.Size = new System.Drawing.Size(28, 20);
                    picturebox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    picturebox13.TabIndex = 18;
                    picturebox13.TabStop = false;
                    picturebox13.Image = Image.FromFile(path + "delete.png");
                    picturebox13.Click += new EventHandler(PictureBoxDelete_Click);

                    posdelete += 168;

                    this.panelCenter.Controls.Add(picturebox13);
                }
            }






        }

        protected void PictureBoxDelete_Click(object sender, EventArgs e)
        {
            PictureBox button = sender as PictureBox;
            string name = button.Name;
            if (name.Contains("-"))
            {
                int id = Convert.ToInt32(name.Split('-')[0].ToString());

                coHabitant = brHabitant.GetId(id);
                if (coHabitant != null)
                {
                    DeleteHabitant m = new DeleteHabitant(coHabitant);
                    m.ShowDialog();
                    return;
                }
            }
        }
        protected void PictureBoxEdit_Click(object sender, EventArgs e)
        {
            PictureBox button = sender as PictureBox;
            string name = button.Name;
            if (name.Contains("-"))
            {
                int id = Convert.ToInt32(name.Split('-')[0].ToString());
                coHabitant = brHabitant.GetId(id);
                if (coHabitant != null)
                {
                    ModifyHabitant m = new ModifyHabitant(coHabitant);
                    m.ShowDialog();
                    return;
                }

            }
            // identify which button was clicked and perform necessary actions
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (coHome != null)
            {
                RegisterHabitant register = new RegisterHabitant(coHome);
                register.Show();
            }
        }

    }
}
