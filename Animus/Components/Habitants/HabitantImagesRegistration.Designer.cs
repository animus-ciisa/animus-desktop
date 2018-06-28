namespace Animus.Components.Habitants
{
    partial class HabitantImagesRegistration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HabitantImagesRegistration));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnCerrar = new Bunifu.Framework.UI.BunifuImageButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.cameraDropdown = new Bunifu.Framework.UI.BunifuDropdown();
            this.cameraPictureBox = new System.Windows.Forms.PictureBox();
            this.selectCameraBtn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.startDetectionBtn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.captureTypeLbl = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.frontalStatusLbl = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.leftStatusLbl = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.rightStatusLbl = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.panelHeader.Controls.Add(this.btnCerrar);
            this.panelHeader.Controls.Add(this.pictureBox1);
            this.panelHeader.Controls.Add(this.bunifuCustomLabel1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(501, 46);
            this.panelHeader.TabIndex = 4;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.ImageActive = null;
            this.btnCerrar.Location = new System.Drawing.Point(464, 11);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(25, 25);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Zoom = 20;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Animus.Properties.Resources.home_white;
            this.pictureBox1.Location = new System.Drawing.Point(12, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(216)))), ((int)(((byte)(255)))));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(38, 15);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(67, 21);
            this.bunifuCustomLabel1.TabIndex = 0;
            this.bunifuCustomLabel1.Text = "Animus";
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel3.ForeColor = System.Drawing.Color.Silver;
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(12, 65);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(285, 17);
            this.bunifuCustomLabel3.TabIndex = 16;
            this.bunifuCustomLabel3.Text = "Seleccione una de las cámaras del sistema";
            // 
            // cameraDropdown
            // 
            this.cameraDropdown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.cameraDropdown.BorderRadius = 3;
            this.cameraDropdown.ForeColor = System.Drawing.Color.White;
            this.cameraDropdown.Items = new string[0];
            this.cameraDropdown.Location = new System.Drawing.Point(15, 98);
            this.cameraDropdown.Name = "cameraDropdown";
            this.cameraDropdown.NomalColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.cameraDropdown.onHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(100)))), ((int)(((byte)(254)))));
            this.cameraDropdown.selectedIndex = -1;
            this.cameraDropdown.Size = new System.Drawing.Size(206, 35);
            this.cameraDropdown.TabIndex = 18;
            // 
            // cameraPictureBox
            // 
            this.cameraPictureBox.Location = new System.Drawing.Point(15, 205);
            this.cameraPictureBox.Name = "cameraPictureBox";
            this.cameraPictureBox.Size = new System.Drawing.Size(280, 280);
            this.cameraPictureBox.TabIndex = 19;
            this.cameraPictureBox.TabStop = false;
            // 
            // selectCameraBtn
            // 
            this.selectCameraBtn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.selectCameraBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.selectCameraBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.selectCameraBtn.BorderRadius = 0;
            this.selectCameraBtn.ButtonText = "Seleccionar";
            this.selectCameraBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectCameraBtn.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.selectCameraBtn.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectCameraBtn.Iconcolor = System.Drawing.Color.Transparent;
            this.selectCameraBtn.Iconimage = null;
            this.selectCameraBtn.Iconimage_right = null;
            this.selectCameraBtn.Iconimage_right_Selected = null;
            this.selectCameraBtn.Iconimage_Selected = null;
            this.selectCameraBtn.IconMarginLeft = 0;
            this.selectCameraBtn.IconMarginRight = 0;
            this.selectCameraBtn.IconRightVisible = true;
            this.selectCameraBtn.IconRightZoom = 0D;
            this.selectCameraBtn.IconVisible = true;
            this.selectCameraBtn.IconZoom = 90D;
            this.selectCameraBtn.IsTab = false;
            this.selectCameraBtn.Location = new System.Drawing.Point(240, 98);
            this.selectCameraBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.selectCameraBtn.Name = "selectCameraBtn";
            this.selectCameraBtn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.selectCameraBtn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(100)))), ((int)(((byte)(254)))));
            this.selectCameraBtn.OnHoverTextColor = System.Drawing.Color.White;
            this.selectCameraBtn.selected = false;
            this.selectCameraBtn.Size = new System.Drawing.Size(136, 37);
            this.selectCameraBtn.TabIndex = 20;
            this.selectCameraBtn.Text = "Seleccionar";
            this.selectCameraBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.selectCameraBtn.Textcolor = System.Drawing.Color.White;
            this.selectCameraBtn.TextFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectCameraBtn.Click += new System.EventHandler(this.selectCameraBtn_Click);
            // 
            // startDetectionBtn
            // 
            this.startDetectionBtn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.startDetectionBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.startDetectionBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.startDetectionBtn.BorderRadius = 0;
            this.startDetectionBtn.ButtonText = "Comenzar detecciones";
            this.startDetectionBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startDetectionBtn.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.startDetectionBtn.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDetectionBtn.Iconcolor = System.Drawing.Color.Transparent;
            this.startDetectionBtn.Iconimage = null;
            this.startDetectionBtn.Iconimage_right = null;
            this.startDetectionBtn.Iconimage_right_Selected = null;
            this.startDetectionBtn.Iconimage_Selected = null;
            this.startDetectionBtn.IconMarginLeft = 0;
            this.startDetectionBtn.IconMarginRight = 0;
            this.startDetectionBtn.IconRightVisible = true;
            this.startDetectionBtn.IconRightZoom = 0D;
            this.startDetectionBtn.IconVisible = true;
            this.startDetectionBtn.IconZoom = 90D;
            this.startDetectionBtn.IsTab = false;
            this.startDetectionBtn.Location = new System.Drawing.Point(15, 505);
            this.startDetectionBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.startDetectionBtn.Name = "startDetectionBtn";
            this.startDetectionBtn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.startDetectionBtn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(100)))), ((int)(((byte)(254)))));
            this.startDetectionBtn.OnHoverTextColor = System.Drawing.Color.White;
            this.startDetectionBtn.selected = false;
            this.startDetectionBtn.Size = new System.Drawing.Size(280, 37);
            this.startDetectionBtn.TabIndex = 21;
            this.startDetectionBtn.Text = "Comenzar detecciones";
            this.startDetectionBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.startDetectionBtn.Textcolor = System.Drawing.Color.White;
            this.startDetectionBtn.TextFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDetectionBtn.Click += new System.EventHandler(this.startDetectionBtn_Click);
            // 
            // captureTypeLbl
            // 
            this.captureTypeLbl.AutoSize = true;
            this.captureTypeLbl.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.captureTypeLbl.ForeColor = System.Drawing.Color.Silver;
            this.captureTypeLbl.Location = new System.Drawing.Point(12, 171);
            this.captureTypeLbl.Name = "captureTypeLbl";
            this.captureTypeLbl.Size = new System.Drawing.Size(105, 17);
            this.captureTypeLbl.TabIndex = 22;
            this.captureTypeLbl.Text = "captureTypeLbl";
            // 
            // frontalStatusLbl
            // 
            this.frontalStatusLbl.AutoSize = true;
            this.frontalStatusLbl.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frontalStatusLbl.ForeColor = System.Drawing.Color.Silver;
            this.frontalStatusLbl.Location = new System.Drawing.Point(301, 205);
            this.frontalStatusLbl.Name = "frontalStatusLbl";
            this.frontalStatusLbl.Size = new System.Drawing.Size(141, 17);
            this.frontalStatusLbl.TabIndex = 23;
            this.frontalStatusLbl.Text = "bunifuCustomLabel2";
            // 
            // leftStatusLbl
            // 
            this.leftStatusLbl.AutoSize = true;
            this.leftStatusLbl.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftStatusLbl.ForeColor = System.Drawing.Color.Silver;
            this.leftStatusLbl.Location = new System.Drawing.Point(301, 232);
            this.leftStatusLbl.Name = "leftStatusLbl";
            this.leftStatusLbl.Size = new System.Drawing.Size(141, 17);
            this.leftStatusLbl.TabIndex = 24;
            this.leftStatusLbl.Text = "bunifuCustomLabel4";
            // 
            // rightStatusLbl
            // 
            this.rightStatusLbl.AutoSize = true;
            this.rightStatusLbl.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightStatusLbl.ForeColor = System.Drawing.Color.Silver;
            this.rightStatusLbl.Location = new System.Drawing.Point(301, 262);
            this.rightStatusLbl.Name = "rightStatusLbl";
            this.rightStatusLbl.Size = new System.Drawing.Size(141, 17);
            this.rightStatusLbl.TabIndex = 25;
            this.rightStatusLbl.Text = "bunifuCustomLabel5";
            // 
            // HabitantImagesRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(501, 555);
            this.Controls.Add(this.rightStatusLbl);
            this.Controls.Add(this.leftStatusLbl);
            this.Controls.Add(this.frontalStatusLbl);
            this.Controls.Add(this.captureTypeLbl);
            this.Controls.Add(this.startDetectionBtn);
            this.Controls.Add(this.selectCameraBtn);
            this.Controls.Add(this.cameraPictureBox);
            this.Controls.Add(this.cameraDropdown);
            this.Controls.Add(this.bunifuCustomLabel3);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HabitantImagesRegistration";
            this.Text = "HabitantImagesRegistration";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panelHeader;
        private Bunifu.Framework.UI.BunifuImageButton btnCerrar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private Bunifu.Framework.UI.BunifuDropdown cameraDropdown;
        private System.Windows.Forms.PictureBox cameraPictureBox;
        private Bunifu.Framework.UI.BunifuFlatButton selectCameraBtn;
        private Bunifu.Framework.UI.BunifuFlatButton startDetectionBtn;
        private Bunifu.Framework.UI.BunifuCustomLabel captureTypeLbl;
        private Bunifu.Framework.UI.BunifuCustomLabel rightStatusLbl;
        private Bunifu.Framework.UI.BunifuCustomLabel leftStatusLbl;
        private Bunifu.Framework.UI.BunifuCustomLabel frontalStatusLbl;
    }
}