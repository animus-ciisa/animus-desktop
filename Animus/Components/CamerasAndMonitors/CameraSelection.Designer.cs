namespace Animus.Components.CamerasAndMonitors
{
    partial class CameraSelection
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraSelection));
            this.enableDisabledButton = new Bunifu.Framework.UI.BunifuThinButton2();
            this.cameraPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cameraPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // enableDisabledButton
            // 
            this.enableDisabledButton.ActiveBorderThickness = 1;
            this.enableDisabledButton.ActiveCornerRadius = 20;
            this.enableDisabledButton.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.enableDisabledButton.ActiveForecolor = System.Drawing.Color.White;
            this.enableDisabledButton.ActiveLineColor = System.Drawing.Color.White;
            this.enableDisabledButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.enableDisabledButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("enableDisabledButton.BackgroundImage")));
            this.enableDisabledButton.ButtonText = "ASOCIAR";
            this.enableDisabledButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.enableDisabledButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enableDisabledButton.ForeColor = System.Drawing.Color.White;
            this.enableDisabledButton.IdleBorderThickness = 1;
            this.enableDisabledButton.IdleCornerRadius = 20;
            this.enableDisabledButton.IdleFillColor = System.Drawing.Color.White;
            this.enableDisabledButton.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.enableDisabledButton.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.enableDisabledButton.Location = new System.Drawing.Point(126, 379);
            this.enableDisabledButton.Margin = new System.Windows.Forms.Padding(5);
            this.enableDisabledButton.Name = "enableDisabledButton";
            this.enableDisabledButton.Size = new System.Drawing.Size(181, 41);
            this.enableDisabledButton.TabIndex = 1;
            this.enableDisabledButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cameraPictureBox
            // 
            this.cameraPictureBox.Location = new System.Drawing.Point(3, 3);
            this.cameraPictureBox.Name = "cameraPictureBox";
            this.cameraPictureBox.Size = new System.Drawing.Size(446, 359);
            this.cameraPictureBox.TabIndex = 0;
            this.cameraPictureBox.TabStop = false;
            // 
            // CameraSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.Controls.Add(this.enableDisabledButton);
            this.Controls.Add(this.cameraPictureBox);
            this.Name = "CameraSelection";
            this.Size = new System.Drawing.Size(451, 440);
            ((System.ComponentModel.ISupportInitialize)(this.cameraPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox cameraPictureBox;
        private Bunifu.Framework.UI.BunifuThinButton2 enableDisabledButton;
    }
}
