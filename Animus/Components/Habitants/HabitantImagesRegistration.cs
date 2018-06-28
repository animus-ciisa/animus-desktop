using Animus.BussinesRules;
using Animus.Common;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animus.Components.Habitants
{
    public partial class HabitantImagesRegistration : Form
    {
        public event EventHandler<CoRecognitionImages> detectionsReady;

        static Timer takePictureTimer = new Timer();
        CoHabitant coHabitant;
        VideoCapture capture;
        BrCamera brCamera;
        BrImage brImage;
        List<CoCamera> coCameras;
        Boolean detecting = false;
        Boolean takeImage = true;

        List<CoFaceDetection> frontalDetections = new List<CoFaceDetection>();
        List<CoFaceDetection> leftDetections = new List<CoFaceDetection>();
        List<CoFaceDetection> rightDetections = new List<CoFaceDetection>();

        int coutOfImages = 7;

        public HabitantImagesRegistration(CoHabitant habitant)
        {
            InitializeComponent();
            this.RenderLabels();
            this.coHabitant = habitant;
            this.brCamera = new BrCamera();
            this.brImage = new BrImage();
            this.coCameras = this.brCamera.GetSystemCameras();
            this.RenderCamerasDropdown();
            takePictureTimer.Tick += new EventHandler((Object myObject, EventArgs myEventArgs) => {
                this.takeImage = true;
            });
            takePictureTimer.Interval = 3000;
            takePictureTimer.Start();
        }

        private void RenderLabels()
        {
            this.startDetectionBtn.Visible = false;
            this.captureTypeLbl.Visible = false;
            this.frontalStatusLbl.Visible = false;
            this.leftStatusLbl.Visible = false;
            this.rightStatusLbl.Visible = false;
        }

        private void RenderCamerasDropdown()
        {
            for(int i = 0; i < this.coCameras.Count; i++)
            {
                this.cameraDropdown.AddItem(this.coCameras[i].name);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if(this.capture != null)
            {
                Application.Idle -= ProcessFramer;
                this.capture.Stop();
                this.capture.Dispose();
                this.capture = null;
            }
            this.Close();
        }

        private void selectCameraBtn_Click(object sender, EventArgs e)
        {
            this.capture = new VideoCapture(this.cameraDropdown.selectedIndex);
            this.startDetectionBtn.Visible = true;
            Application.Idle += new EventHandler(ProcessFramer);
        }

        private void ProcessFramer(object sender, EventArgs e)
        {
            if (this.rightDetections.Count == this.coutOfImages && this.leftDetections.Count == this.coutOfImages && this.rightDetections.Count == this.coutOfImages)
            {
                CoRecognitionImages coRecognitionImages = new CoRecognitionImages
                {
                    frontalDetections = this.frontalDetections,
                    leftDetections = this.leftDetections,
                    rightDetections = this.rightDetections
                };
                this.brImage.TrainRecognizer();
                if (this.detectionsReady != null)
                {
                    Console.WriteLine("this.detectionsReady");
                    detectionsReady(this, coRecognitionImages);
                }
                Application.Idle -= ProcessFramer;
                this.capture.Stop();
                this.capture.Dispose();
                this.capture = null;
            }
            else
            {
                Image<Bgr, Byte> image = this.capture.QueryFrame().ToImage<Bgr, Byte>();
                if (this.detecting && this.takeImage)
                {
                    image = this.DetectFace(image);
                }
                this.cameraPictureBox.Image = image.Resize(280, 280, Emgu.CV.CvEnum.Inter.Cubic).ToBitmap();
            }
        }

        private Image<Bgr, Byte> DetectFace(Image<Bgr, Byte> image)
        {
            CoFaceDetection detection = new CoFaceDetection();
            int countOfDetections = 0;
            if (this.frontalDetections.Count < this.coutOfImages)
            {
                this.captureTypeLbl.Text = "Mira a la cámara frontalmente";
                detection = this.brImage.DetectUniqueFrontalFace(image, out countOfDetections);
                if (detection != null)
                {
                    CoHabitant habitantRecognized = this.brImage.Recognize(detection);
                    if (habitantRecognized == null)
                    {
                        detection.habitant = coHabitant;
                        detection = this.brImage.Save(detection);
                        this.frontalDetections.Add(detection);
                        this.takeImage = false;
                        image.Draw(detection.face, new Bgr(Color.Blue), 2);
                    }
                }
                this.frontalStatusLbl.Text = "Capturas frontales: " + ((this.frontalDetections.Count * 100) / this.coutOfImages) + "%";
                this.frontalStatusLbl.Visible = true;
            }
            else if (this.leftDetections.Count < this.coutOfImages)
            {
                this.captureTypeLbl.Text = "Gira tu cabeza hacia la derecha";
                detection = this.brImage.DetectUniqueLeftFace(image, out countOfDetections);
                if (detection != null)
                {
                    detection.habitant = coHabitant;
                    detection = this.brImage.Save(detection);
                    this.leftDetections.Add(detection);
                    this.takeImage = false;
                    image.Draw(detection.face, new Bgr(Color.Blue), 2);
                    if (detection.eyes.Count > 0)
                    {
                        for (int i = 0; i < detection.eyes.Count; i++)
                        {
                            image.Draw(detection.eyes[i], new Bgr(Color.Red), 2);
                        }
                    }
                }
                this.leftStatusLbl.Text = "Capturas lado izquierdo: " + ((this.leftDetections.Count * 100) / this.coutOfImages) + "%";
                this.leftStatusLbl.Visible = true;
            }
            else if(this.rightDetections.Count < this.coutOfImages)
            {
                this.captureTypeLbl.Text = "Gira tu cabeza hacia la izquierda";
                detection = this.brImage.DetectUniqueRightFace(image, out countOfDetections);
                if (detection != null)
                {
                    detection.habitant = coHabitant;
                    detection = this.brImage.Save(detection);
                    this.rightDetections.Add(detection);
                    this.takeImage = false;
                    image.Draw(detection.face, new Bgr(Color.Blue), 2);
                    if (detection.eyes.Count > 0)
                    {
                        for (int i = 0; i < detection.eyes.Count; i++)
                        {
                            image.Draw(detection.eyes[i], new Bgr(Color.Red), 2);
                        }
                    }
                }
                this.rightStatusLbl.Text = "Capturas lado derecho: " + ((this.rightDetections.Count * 100) / this.coutOfImages) + "%";
                this.rightStatusLbl.Visible = true;
            }
            this.captureTypeLbl.Visible = true;
            return image;
        }

        private void startDetectionBtn_Click(object sender, EventArgs e)
        {
            this.detecting = true;
        }
    }
}
