namespace Animus
{
    partial class CamerasAndMonitors
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CamerasAndMonitors));
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.cameraPictureBox = new System.Windows.Forms.PictureBox();
            this.addRemoveCamera = new Bunifu.Framework.UI.BunifuThinButton2();
            this.stopButton = new Bunifu.Framework.UI.BunifuThinButton2();
            this.camerasPanel = new System.Windows.Forms.Panel();
            this.cameraCard = new Bunifu.Framework.UI.BunifuCards();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraPictureBox)).BeginInit();
            this.cameraCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(17, 82);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(357, 22);
            this.bunifuCustomLabel2.TabIndex = 2;
            this.bunifuCustomLabel2.Text = "Selecciona una cámara para asociar:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.panel1.Controls.Add(this.bunifuCustomLabel1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(915, 59);
            this.panel1.TabIndex = 3;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(16, 11);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(281, 30);
            this.bunifuCustomLabel1.TabIndex = 4;
            this.bunifuCustomLabel1.Text = "CÁMARAS ASOCIADAS";
            // 
            // cameraPictureBox
            // 
            this.cameraPictureBox.Location = new System.Drawing.Point(3, 60);
            this.cameraPictureBox.Name = "cameraPictureBox";
            this.cameraPictureBox.Size = new System.Drawing.Size(372, 271);
            this.cameraPictureBox.TabIndex = 5;
            this.cameraPictureBox.TabStop = false;
            // 
            // addRemoveCamera
            // 
            this.addRemoveCamera.ActiveBorderThickness = 1;
            this.addRemoveCamera.ActiveCornerRadius = 20;
            this.addRemoveCamera.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.addRemoveCamera.ActiveForecolor = System.Drawing.Color.White;
            this.addRemoveCamera.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.addRemoveCamera.BackColor = System.Drawing.Color.White;
            this.addRemoveCamera.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addRemoveCamera.BackgroundImage")));
            this.addRemoveCamera.ButtonText = "ASOCIAR";
            this.addRemoveCamera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addRemoveCamera.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addRemoveCamera.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.addRemoveCamera.IdleBorderThickness = 1;
            this.addRemoveCamera.IdleCornerRadius = 20;
            this.addRemoveCamera.IdleFillColor = System.Drawing.Color.White;
            this.addRemoveCamera.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.addRemoveCamera.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.addRemoveCamera.Location = new System.Drawing.Point(194, 11);
            this.addRemoveCamera.Margin = new System.Windows.Forms.Padding(5);
            this.addRemoveCamera.Name = "addRemoveCamera";
            this.addRemoveCamera.Size = new System.Drawing.Size(181, 41);
            this.addRemoveCamera.TabIndex = 6;
            this.addRemoveCamera.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.addRemoveCamera.Click += new System.EventHandler(this.addRemoveCamera_Click);
            // 
            // stopButton
            // 
            this.stopButton.ActiveBorderThickness = 1;
            this.stopButton.ActiveCornerRadius = 20;
            this.stopButton.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.stopButton.ActiveForecolor = System.Drawing.Color.White;
            this.stopButton.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.stopButton.BackColor = System.Drawing.Color.White;
            this.stopButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("stopButton.BackgroundImage")));
            this.stopButton.ButtonText = "DETENER";
            this.stopButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stopButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.stopButton.IdleBorderThickness = 1;
            this.stopButton.IdleCornerRadius = 20;
            this.stopButton.IdleFillColor = System.Drawing.Color.White;
            this.stopButton.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.stopButton.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.stopButton.Location = new System.Drawing.Point(3, 11);
            this.stopButton.Margin = new System.Windows.Forms.Padding(5);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(181, 41);
            this.stopButton.TabIndex = 7;
            this.stopButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // camerasPanel
            // 
            this.camerasPanel.Location = new System.Drawing.Point(21, 109);
            this.camerasPanel.Name = "camerasPanel";
            this.camerasPanel.Size = new System.Drawing.Size(192, 339);
            this.camerasPanel.TabIndex = 8;
            // 
            // cameraCard
            // 
            this.cameraCard.BackColor = System.Drawing.Color.White;
            this.cameraCard.BorderRadius = 5;
            this.cameraCard.BottomSahddow = true;
            this.cameraCard.color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.cameraCard.Controls.Add(this.cameraPictureBox);
            this.cameraCard.Controls.Add(this.stopButton);
            this.cameraCard.Controls.Add(this.addRemoveCamera);
            this.cameraCard.LeftSahddow = false;
            this.cameraCard.Location = new System.Drawing.Point(219, 109);
            this.cameraCard.Name = "cameraCard";
            this.cameraCard.RightSahddow = true;
            this.cameraCard.ShadowDepth = 20;
            this.cameraCard.Size = new System.Drawing.Size(381, 341);
            this.cameraCard.TabIndex = 9;
            // 
            // CamerasAndMonitors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.Controls.Add(this.cameraCard);
            this.Controls.Add(this.camerasPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bunifuCustomLabel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CamerasAndMonitors";
            this.Size = new System.Drawing.Size(891, 606);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraPictureBox)).EndInit();
            this.cameraCard.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private System.Windows.Forms.PictureBox cameraPictureBox;
        private Bunifu.Framework.UI.BunifuThinButton2 addRemoveCamera;
        private Bunifu.Framework.UI.BunifuThinButton2 stopButton;
        private System.Windows.Forms.Panel camerasPanel;
        private Bunifu.Framework.UI.BunifuCards cameraCard;
    }
}
