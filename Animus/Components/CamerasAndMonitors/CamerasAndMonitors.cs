using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DirectShowLib;
using Emgu.CV;
using Emgu.CV.Structure;
using Bunifu.Framework.UI;
using Animus.BussinesRules;
using Animus.Common;

namespace Animus
{
    public partial class CamerasAndMonitors : UserControl
    {
        VideoCapture capture;
        int activeCamera = -1;
        BrCamera brCamera;
        List<CoCamera> systemCameras;

        public CamerasAndMonitors()
        {
            InitializeComponent();
            this.cameraPictureBox.Visible = false;
            this.addRemoveCamera.Visible = false;
            this.stopButton.Visible = false;
            this.cameraCard.Visible = false;

            this.brCamera = new BrCamera();
            this.systemCameras = this.brCamera.GetSystemCameras();
            this.RenderCameraButtons();
        }

        private void InitializeCamera(int index)
        {
            if(this.activeCamera != index)
            {
                this.activeCamera = index;
                this.capture = new VideoCapture(this.activeCamera);
                this.cameraPictureBox.Visible = true;
                this.addRemoveCamera.Visible = true;
                this.stopButton.Visible = true;
                this.cameraCard.Visible = true;
                this.RenderActionButtons(this.systemCameras[this.activeCamera].associate);
                Application.Idle += new EventHandler(ProcessFramer);
            }
        }

        private void ProcessFramer(object sender, EventArgs e)
        {
            Image<Bgr, Byte> image = this.capture.QueryFrame().ToImage<Bgr, Byte>();
            this.cameraPictureBox.Image = image.Resize(390, 290, Emgu.CV.CvEnum.Inter.Cubic).ToBitmap();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            Application.Idle -= ProcessFramer;
            this.capture.Stop();
            this.capture.Dispose();
            this.capture = null;
        }

        private void RenderCameraButtons()
        {
            int top = 0;
            this.camerasPanel.Controls.Clear();
            for (int i = 0; i < this.systemCameras.Count; i++)
            {
                int index = i;
                BunifuFlatButton cameraButton = this.CreateButton(this.systemCameras[i], top);
                top += cameraButton.Height;
                cameraButton.Click += (sender, args) => InitializeCamera(index);
                this.camerasPanel.Controls.Add(cameraButton);
            }
        }

        private BunifuFlatButton CreateButton(CoCamera camera, int top)
        {
            BunifuFlatButton button = new BunifuFlatButton();
            button.Normalcolor = Color.FromArgb(37, 46, 59);
            button.OnHovercolor = Color.FromArgb(58, 71, 92);
            button.BackColor = Color.FromArgb(58, 71, 92);
            button.Activecolor = Color.FromArgb(58, 71, 92);
            button.Iconimage = null;
            button.Text = camera.name + " (" + ((camera.associate) ? "Si" : "No") + ")";
            button.Top = top;
            return button;
        }

        private void addRemoveCamera_Click(object sender, EventArgs e)
        {
            this.systemCameras[this.activeCamera].associate = !this.systemCameras[this.activeCamera].associate;
            this.RenderActionButtons(this.systemCameras[this.activeCamera].associate);
            this.brCamera.Save(this.systemCameras[this.activeCamera]);
            this.RenderCameraButtons();
        }

        private void RenderActionButtons(Boolean status)
        {
            Color buttonColor = Color.FromArgb(0, 102, 204);
            string buttonText = "ASOCIAR";
            if (status)
            {
                buttonColor = Color.FromArgb(220, 0, 0);
                buttonText = "DESASOCIAR";
            }
            this.addRemoveCamera.ButtonText = buttonText;
            this.addRemoveCamera.ActiveFillColor = buttonColor;
            this.addRemoveCamera.ActiveLineColor = buttonColor;
            this.addRemoveCamera.ForeColor = buttonColor;
            this.addRemoveCamera.IdleForecolor = buttonColor;
            this.addRemoveCamera.IdleLineColor = buttonColor;
        }
    }
}
