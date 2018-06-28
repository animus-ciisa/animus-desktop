using Animus.Common;
using Animus.DataAccess;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animus.BussinesRules
{
    class BrImage
    {
        BrDetection brDetection;
        DaImage daImage;

        public BrImage()
        {
            this.brDetection = new BrDetection();
            this.daImage = new DaImage();
        }

        public CoHabitant Recognize(CoFaceDetection detection)
        {
            if (detection.image == null)
            {
                detection.image = new Image<Bgr, byte>(detection.path + detection.name);
            }
            int label = this.brDetection.Recognize(detection);
            Console.WriteLine("Valor del label: " + label);
            if (label != 0)
            {
                detection = this.daImage.ById(label);
                if(detection.habitant != null)
                {
                    Console.WriteLine("Pertenece al habitante: " + detection.habitant.name);
                    return detection.habitant;
                }
                else
                {
                    Console.WriteLine("No pertenece a ningun habitante: ");
                }
            }
            else
            {
                Console.WriteLine("No se reconocio a nadiennn: ");
            }
            return null;
        }

        public List<CoFaceDetection> RecognizeFromImage(Image<Bgr, Byte> image)
        {
            List<CoFaceDetection> detections = this.brDetection.DetectFrontalFace(image);
            for (int i = 0; i < detections.Count; i++)
            {
                int label = this.brDetection.Recognize(detections[i]);
                if(label != 0)
                {
                    detections[i] = this.daImage.ById(label);
                }
            }
            return detections;
        }

        public void TrainRecognizer()
        {
            List<CoFaceDetection> detections = this.daImage.GetRecognizerDetections();
            if (detections.Count > 0)
            {
                this.brDetection.TrainRecognizer(detections);
            }
        }

        public CoFaceDetection Save(CoFaceDetection faceDetection)
        {
            faceDetection.path = @"..\..\Images\Habitant\";
            faceDetection.name = ((DateTime.Now - DateTime.MinValue).TotalMilliseconds).ToString() + ".bmp";
            Image<Bgr, byte> faceToSave = new Image<Bgr, byte>(faceDetection.image.Bitmap);
            faceToSave.ToBitmap().Save((faceDetection.path + faceDetection.name));
            faceDetection.id = this.daImage.Save(faceDetection);
            /*
             Introduzca el código para el servicio RESTful aqui !!
             */
            return faceDetection;
        }

        public CoFaceDetection DetectUniqueFrontalFace(Image<Bgr, Byte> image, out int countOfDetections)
        {
            List<CoFaceDetection> detections = this.brDetection.DetectFrontalFace(image);
            return this.OnlyOneDetection(detections, 1, out countOfDetections);
        }

        public CoFaceDetection DetectUniqueRightFace(Image<Bgr, Byte> image, out int countOfDetections)
        {
            List<CoFaceDetection> detections = this.brDetection.DetectRightSideFace(image);
            return this.OnlyOneDetection(detections, 2, out countOfDetections);
        }

        public CoFaceDetection DetectUniqueLeftFace(Image<Bgr, Byte> image, out int countOfDetections)
        {
            List<CoFaceDetection> detections = this.brDetection.DetectLeftSideFace(image);
            return this.OnlyOneDetection(detections, 3, out countOfDetections);
        }

        private CoFaceDetection OnlyOneDetection(List<CoFaceDetection> detections, int type, out int countOfDetections)
        {
            countOfDetections = detections.Count;
            if (countOfDetections == 1)
            {
                detections[0].type = type;
                return detections[0];
            }
            return null;
        }
    }
}
