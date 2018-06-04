namespace Animus
{
    partial class Login
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnCuenta = new MetroFramework.Controls.MetroTile();
            this.btnRegistro = new MetroFramework.Controls.MetroTile();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.btnImageOk = new System.Windows.Forms.PictureBox();
            this.btnUpload = new System.Windows.Forms.PictureBox();
            this.txtNick = new MetroFramework.Controls.MetroTextBox();
            this.txtCorreo = new MetroFramework.Controls.MetroTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnImageOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 314);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(389, 19);
            this.metroLabel1.TabIndex = 13;
            this.metroLabel1.Text = "Asegurese de que el correo sea la persona a cargo del aplicativo";
            // 
            // btnCuenta
            // 
            this.btnCuenta.ActiveControl = null;
            this.btnCuenta.Location = new System.Drawing.Point(47, 349);
            this.btnCuenta.Name = "btnCuenta";
            this.btnCuenta.Size = new System.Drawing.Size(141, 43);
            this.btnCuenta.TabIndex = 14;
            this.btnCuenta.Text = "Ya tengo una cuenta";
            this.btnCuenta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCuenta.UseSelectable = true;
            // 
            // btnRegistro
            // 
            this.btnRegistro.ActiveControl = null;
            this.btnRegistro.Location = new System.Drawing.Point(220, 349);
            this.btnRegistro.Name = "btnRegistro";
            this.btnRegistro.Size = new System.Drawing.Size(149, 43);
            this.btnRegistro.TabIndex = 15;
            this.btnRegistro.Text = "Continuar Registro";
            this.btnRegistro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRegistro.UseSelectable = true;
            this.btnRegistro.Click += new System.EventHandler(this.btnRegistro_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            this.errorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider.Icon")));
            // 
            // metroToolTip1
            // 
            this.metroToolTip1.AutomaticDelay = 300;
            this.metroToolTip1.Style = MetroFramework.MetroColorStyle.Default;
            this.metroToolTip1.StyleManager = null;
            this.metroToolTip1.Theme = MetroFramework.MetroThemeStyle.Default;
            // 
            // btnImageOk
            // 
            this.btnImageOk.Image = global::Animus.Properties.Resources.icox;
            this.btnImageOk.Location = new System.Drawing.Point(320, 205);
            this.btnImageOk.Name = "btnImageOk";
            this.btnImageOk.Size = new System.Drawing.Size(28, 24);
            this.btnImageOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnImageOk.TabIndex = 17;
            this.btnImageOk.TabStop = false;
            this.btnImageOk.Visible = false;
            this.btnImageOk.MouseHover += new System.EventHandler(this.btnImageOk_MouseHover);
            // 
            // btnUpload
            // 
            this.btnUpload.Image = global::Animus.Properties.Resources.upload32;
            this.btnUpload.Location = new System.Drawing.Point(275, 206);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(26, 21);
            this.btnUpload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnUpload.TabIndex = 16;
            this.btnUpload.TabStop = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            this.btnUpload.MouseHover += new System.EventHandler(this.btnUpload_MouseHover);
            // 
            // txtNick
            // 
            // 
            // 
            // 
            this.txtNick.CustomButton.Image = null;
            this.txtNick.CustomButton.Location = new System.Drawing.Point(247, 1);
            this.txtNick.CustomButton.Name = "";
            this.txtNick.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtNick.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtNick.CustomButton.TabIndex = 1;
            this.txtNick.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtNick.CustomButton.UseSelectable = true;
            this.txtNick.CustomButton.Visible = false;
            this.txtNick.DisplayIcon = true;
            this.txtNick.Icon = global::Animus.Properties.Resources.metrouser;
            this.txtNick.Lines = new string[0];
            this.txtNick.Location = new System.Drawing.Point(78, 273);
            this.txtNick.MaxLength = 32767;
            this.txtNick.Name = "txtNick";
            this.txtNick.PasswordChar = '\0';
            this.txtNick.PromptText = "Nick del Hogar";
            this.txtNick.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNick.SelectedText = "";
            this.txtNick.SelectionLength = 0;
            this.txtNick.SelectionStart = 0;
            this.txtNick.ShortcutsEnabled = true;
            this.txtNick.Size = new System.Drawing.Size(269, 23);
            this.txtNick.TabIndex = 12;
            this.txtNick.UseSelectable = true;
            this.txtNick.WaterMark = "Nick del Hogar";
            this.txtNick.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNick.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtCorreo
            // 
            // 
            // 
            // 
            this.txtCorreo.CustomButton.Image = null;
            this.txtCorreo.CustomButton.Location = new System.Drawing.Point(247, 1);
            this.txtCorreo.CustomButton.Name = "";
            this.txtCorreo.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtCorreo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCorreo.CustomButton.TabIndex = 1;
            this.txtCorreo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCorreo.CustomButton.UseSelectable = true;
            this.txtCorreo.CustomButton.Visible = false;
            this.txtCorreo.DisplayIcon = true;
            this.txtCorreo.Icon = global::Animus.Properties.Resources.mail;
            this.txtCorreo.Lines = new string[0];
            this.txtCorreo.Location = new System.Drawing.Point(78, 233);
            this.txtCorreo.MaxLength = 32767;
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.PasswordChar = '\0';
            this.txtCorreo.PromptText = "Correo Electrónico";
            this.txtCorreo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCorreo.SelectedText = "";
            this.txtCorreo.SelectionLength = 0;
            this.txtCorreo.SelectionStart = 0;
            this.txtCorreo.ShortcutsEnabled = true;
            this.txtCorreo.Size = new System.Drawing.Size(269, 23);
            this.txtCorreo.TabIndex = 11;
            this.txtCorreo.UseSelectable = true;
            this.txtCorreo.WaterMark = "Correo Electrónico";
            this.txtCorreo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCorreo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtCorreo.Leave += new System.EventHandler(this.txtCorreo_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Animus.Properties.Resources.house;
            this.pictureBox1.Location = new System.Drawing.Point(121, 74);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 132);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 415);
            this.Controls.Add(this.btnImageOk);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnRegistro);
            this.Controls.Add(this.btnCuenta);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtNick);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Login";
            this.Text = "Bienvenido a Animus";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnImageOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroTextBox txtNick;
        private MetroFramework.Controls.MetroTextBox txtCorreo;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTile btnCuenta;
        private MetroFramework.Controls.MetroTile btnRegistro;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox btnUpload;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private System.Windows.Forms.PictureBox btnImageOk;

    }
}

