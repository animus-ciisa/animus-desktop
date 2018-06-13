namespace Animus
{
    partial class Password
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Password));
            this.btnSaveHome = new MetroFramework.Controls.MetroTile();
            this.btnVolver = new MetroFramework.Controls.MetroTile();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtPassword = new MetroFramework.Controls.MetroTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblHogar = new MetroFramework.Controls.MetroLabel();
            this.linkPass = new MetroFramework.Controls.MetroLink();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveHome
            // 
            this.btnSaveHome.ActiveControl = null;
            this.btnSaveHome.Location = new System.Drawing.Point(212, 337);
            this.btnSaveHome.Name = "btnSaveHome";
            this.btnSaveHome.Size = new System.Drawing.Size(149, 43);
            this.btnSaveHome.TabIndex = 18;
            this.btnSaveHome.Text = "Registrar Hogar";
            this.btnSaveHome.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSaveHome.UseSelectable = true;
            this.btnSaveHome.Click += new System.EventHandler(this.btnSaveHome_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.ActiveControl = null;
            this.btnVolver.Location = new System.Drawing.Point(39, 337);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(141, 43);
            this.btnVolver.TabIndex = 17;
            this.btnVolver.Text = "Volver al Inicio";
            this.btnVolver.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVolver.UseSelectable = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(15, 302);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(389, 19);
            this.metroLabel1.TabIndex = 16;
            this.metroLabel1.Text = "Asegurese de que el correo sea la persona a cargo del aplicativo";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // txtPassword
            // 
            // 
            // 
            // 
            this.txtPassword.CustomButton.Image = null;
            this.txtPassword.CustomButton.Location = new System.Drawing.Point(229, 1);
            this.txtPassword.CustomButton.Name = "";
            this.txtPassword.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPassword.CustomButton.TabIndex = 1;
            this.txtPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPassword.CustomButton.UseSelectable = true;
            this.txtPassword.CustomButton.Visible = false;
            this.txtPassword.DisplayIcon = true;
            this.txtPassword.Icon = global::Animus.Properties.Resources.llave;
            this.txtPassword.Lines = new string[0];
            this.txtPassword.Location = new System.Drawing.Point(85, 248);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.PromptText = "Ingrese la Contraseña";
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.ShortcutsEnabled = true;
            this.txtPassword.Size = new System.Drawing.Size(251, 23);
            this.txtPassword.TabIndex = 12;
            this.txtPassword.UseSelectable = true;
            this.txtPassword.WaterMark = "Ingrese la Contraseña";
            this.txtPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Animus.Properties.Resources.house;
            this.pictureBox1.Location = new System.Drawing.Point(120, 75);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 132);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // lblHogar
            // 
            this.lblHogar.AutoSize = true;
            this.lblHogar.Location = new System.Drawing.Point(179, 210);
            this.lblHogar.Name = "lblHogar";
            this.lblHogar.Size = new System.Drawing.Size(60, 19);
            this.lblHogar.TabIndex = 19;
            this.lblHogar.Text = "lblHogar";
            this.lblHogar.Visible = false;
            // 
            // linkPass
            // 
            this.linkPass.Location = new System.Drawing.Point(138, 386);
            this.linkPass.Name = "linkPass";
            this.linkPass.Size = new System.Drawing.Size(136, 23);
            this.linkPass.TabIndex = 20;
            this.linkPass.Text = "olvidé mi contraseña";
            this.linkPass.UseSelectable = true;
            this.linkPass.Visible = false;
            this.linkPass.Click += new System.EventHandler(this.linkPass_Click);
            // 
            // Password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 415);
            this.Controls.Add(this.linkPass);
            this.Controls.Add(this.lblHogar);
            this.Controls.Add(this.btnSaveHome);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Password";
            this.Text = "Bienvenido a Animus";
            this.Load += new System.EventHandler(this.Password_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroTextBox txtPassword;
        private MetroFramework.Controls.MetroTile btnSaveHome;
        private MetroFramework.Controls.MetroTile btnVolver;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private MetroFramework.Controls.MetroLabel lblHogar;
        private MetroFramework.Controls.MetroLink linkPass;
    }
}