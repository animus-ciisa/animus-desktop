using Animus.Common;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animus.BussinesRules
{
    class BrDetection
    {
        private CascadeClassifier faceCascade;
        private CascadeClassifier sideCascade;
        private CascadeClassifier rightEyeCascade;
        private CascadeClassifier leftEyeCascade;
        private EigenFaceRecognizer eigenFaceRecognizer = null;
        private string cascadePath = @"..\..\Classifier\HaarCascades\";
        private string trainingPath = @"..\..\Classifier\Recognizer\";

        public BrDetection()
        {
            this.faceCascade = new CascadeClassifier(cascadePath + "haarcascade_frontalface_default.xml");
            this.sideCascade = new CascadeClassifier(cascadePath + "haarcascade_profileface.xml");
            this.leftEyeCascade = new CascadeClassifier(cascadePath + "haarcascade_lefteye_2splits.xml");
            this.rightEyeCascade = new CascadeClassifier(cascadePath + "haarcascade_righteye_2splits.xml");
        }

        public void TrainRecognizer(List<CoFaceDetection> detections)
        {
            if(eigenFaceRecognizer == null)
            {
                this.eigenFaceRecognizer = new EigenFaceRecognizer();
            }
            int count = detections.Count();
            Image<Gray, byte>[] images = new Image<Gray, byte>[count];
            int[] identifiersLabels = new int[count];
            for (int i = 0; i < count; i++)
            {
                Image<Gray, byte> detectionImage = new Image<Gray, byte>(detections[i].path + detections[i].name);
                detectionImage.ROI = detections[i].face;
                images[i] = detectionImage.Resize(100, 100, Inter.Cubic);
                identifiersLabels[i] = detections[i].localId;
            }
            this.eigenFaceRecognizer.Train(images, identifiersLabels);
            this.eigenFaceRecognizer.Write(trainingPath + "EigenFaceRecognizer");
        }

        public int Recognize(CoFaceDetection detection)
        {
            if(File.Exists(trainingPath + "EigenFaceRecognizer"))
            {
                if (this.eigenFaceRecognizer == null)
                {
                    this.eigenFaceRecognizer = new EigenFaceRecognizer();
                }
                Image<Gray, byte> detectionImage = new Image<Gray, byte>(detection.image.Bitmap);
                detectionImage.ROI = detection.face;
                this.eigenFaceRecognizer.Read(trainingPath + "EigenFaceRecognizer");
                var result = this.eigenFaceRecognizer.Predict(detectionImage.Resize(100, 100, Inter.Cubic));
                if (result.Distance < 1500)
                {
                    return result.Label;
                }
            }
            return 0;
        }

        public List<CoFaceDetection> DetectFrontalFace(Image<Bgr, Byte> image)
        {
            Image<Gray, byte> grayImage = image.Convert<Gray, byte>();
            Rectangle[] faces = faceCascade.DetectMultiScale(grayImage, 1.1, 10, Size.Empty);
            List<CoFaceDetection> facesOrderer = OrderRectangles(image, faces);
            return facesOrderer;
        }

        public List<CoFaceDetection> DetectRightSideFace(Image<Bgr, Byte> image)
        {
            Image<Gray, byte> grayImage = image.Convert<Gray, byte>();
            Rectangle[] faces = sideCascade.DetectMultiScale(grayImage, 1.1, 10, Size.Empty);
            Rectangle[] eyes = rightEyeCascade.DetectMultiScale(grayImage, 1.1, 10, Size.Empty);
            return OrderRectangles(image, faces, eyes, true);
        }

        public List<CoFaceDetection> DetectLeftSideFace(Image<Bgr, Byte> image)
        {
            Image<Gray, byte> grayImage = image.Convert<Gray, byte>();
            Rectangle[] faces = sideCascade.DetectMultiScale(grayImage, 1.1, 10, Size.Empty);
            Rectangle[] eyes = leftEyeCascade.DetectMultiScale(grayImage, 1.1, 10, Size.Empty);
            return OrderRectangles(image, faces, eyes, true);
        }

        private List<CoFaceDetection> OrderRectangles(Image<Bgr, Byte> image, Rectangle[] faces, Rectangle[] eyes = null, Boolean mustHaveEyes = false)
        {
            List<CoFaceDetection> detections = new List<CoFaceDetection>();
            foreach (var face in faces)
            {
                CoFaceDetection detection = new CoFaceDetection();
                List<Rectangle> faceEyes = new List<Rectangle>();
                detection.face = face;
                detection.image = image;
                if (eyes != null)
                {
                    foreach (var eye in eyes)
                    {
                        if (face.Contains(eye.Location))
                        {
                            faceEyes.Add(eye);
                        }
                    }
                    detection.eyes = faceEyes;
                    if (mustHaveEyes)
                    {
                        if (faceEyes.Count > 0)
                        {
                            detections.Add(detection);
                        }
                    }
                    else
                    {
                        detections.Add(detection);
                    }
                }
                else if (!mustHaveEyes)
                {
                    detections.Add(detection);
                }
            }
            return detections;
        }
    }
}
