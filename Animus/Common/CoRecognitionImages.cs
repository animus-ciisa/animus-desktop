using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animus.Common
{
    public class CoRecognitionImages
    {
        public List<CoFaceDetection> frontalDetections { get; set; }
        public List<CoFaceDetection> leftDetections { get; set; }
        public List<CoFaceDetection> rightDetections { get; set; }
    }
}
