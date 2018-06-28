using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animus.Common
{
    public class CoFaceDetection
    {
        public int id { get; set; }
        public int localId { get; set; }
        public CoHabitant habitant { get; set; }
        public Rectangle face { get; set; }
        public List<Rectangle> eyes { get; set; }
        public Rectangle nose { get; set; }
        public Rectangle mounth { get; set; }
        public Rectangle smile { get; set; }
        public Image<Bgr, Byte> image { get; set; }
        public string path { get; set; }
        public string name { get; set; }
        public int type { get; set; }
    }
}
