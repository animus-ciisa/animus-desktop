using Animus.Common;
using Animus.DataBase;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animus.DataAccess
{
    class DaImage
    {
        public CoFaceDetection ById(int id)
        {
            var query = "   SELECT      Image.localId, Image.localPath, Image.name, Image.rectangleX, Image.rectangleY, Image.rectangleWidth, Image.rectangleHeight," +
                        "               Habitant.id, Habitant.type, Habitant.name AS habitantName, Habitant.lastname" +
                        "   FROM        Image " +
                        "   LEFT JOIN   Habitant ON Habitant.id = habitantId" +
                        "   WHERE       localId = ?";

            DbParameter[] parameters = { new DbParameter("localId", id.ToString()) };
            var result = DbContext.Select(query, parameters);
            if (result.Count() > 0)
            {
                return new CoFaceDetection
                {
                    localId = Convert.ToInt32(result[0]["localId"].ToString()),
                    path = result[0]["localPath"].ToString(),
                    name = result[0]["name"].ToString(),
                    habitant = new CoHabitant
                    {
                        id = Convert.ToInt32(result[0]["id"].ToString()),
                        name = result[0]["habitantName"].ToString(),
                        lastname = result[0]["lastname"].ToString(),
                        typePerson = new CoTypePerson
                        {
                            id = Convert.ToInt32(result[0]["type"].ToString())
                        }  
                    },
                    face = new Rectangle(
                            Convert.ToInt32(result[0]["rectangleX"].ToString()),
                            Convert.ToInt32(result[0]["rectangleY"].ToString()),
                            Convert.ToInt32(result[0]["rectangleWidth"].ToString()),
                            Convert.ToInt32(result[0]["rectangleHeight"].ToString())
                        )
                };
            }
            return null;
        }

        public List<CoFaceDetection> GetRecognizerDetections()
        {
            List<CoFaceDetection> detections = new List<CoFaceDetection>();
            var query = "   SELECT  * " +
                        "   FROM    Image " +
                        "   WHERE   type = 1 OR type = 2 OR type = 3;";
            var result = DbContext.Select(query);
            if (result.Count() > 0)
            {
                for (int i = 0; i < result.Count(); i++)
                {
                    detections.Add(new CoFaceDetection
                    {
                        localId = Convert.ToInt32(result[i]["localId"].ToString()),
                        path = result[i]["localPath"].ToString(),
                        name = result[i]["name"].ToString(),
                        face = new Rectangle(
                            Convert.ToInt32(result[i]["rectangleX"].ToString()),
                            Convert.ToInt32(result[i]["rectangleY"].ToString()),
                            Convert.ToInt32(result[i]["rectangleWidth"].ToString()),
                            Convert.ToInt32(result[i]["rectangleHeight"].ToString())
                        )
                    });
                }
            }
            return detections;
        }

        public int Save(CoFaceDetection detection)
        {
            var query = "INSERT INTO Image (localPath, name, habitantId, rectangleX, rectangleY, rectangleWidth, rectangleHeight, type) VALUES (?, ?, ?, ?, ?, ?, ?, ?)";
            DbParameter[] parameters = {
                new DbParameter("localPath", detection.path),
                new DbParameter("name", detection.name),
                new DbParameter("habitantId", detection.habitant.id.ToString()),
                new DbParameter("rectangleX", detection.face.Y.ToString()),
                new DbParameter("rectangleY", detection.face.X.ToString()),
                new DbParameter("rectangleWidth", detection.face.Width.ToString()),
                new DbParameter("rectangleHeight", detection.face.Height.ToString()),
                new DbParameter("type", detection.type.ToString())
            };
            int id = DbContext.InsertOrUpdate(query, parameters);
            return id;
        }
    }
}
