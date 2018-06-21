using Animus.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Animus.RestServices
{
    class RsCamera : RsBase
    {
        public Boolean Update(List<CoCamera> cameras, out Boolean internetStatus)
        {
            internetStatus = true;
            Boolean status = true;
            try
            {
                JArray camerasArray = new JArray();
                for(int i = 0; i < cameras.Count; i++)
                {
                    JObject camera = new JObject();
                    camera.Add("name", cameras[i].name);
                    camera.Add("associate", cameras[i].associate);
                    camera.Add("status", cameras[i].status);
                    camerasArray.Add(camera);
                }
                JObject request = new JObject();
                request.Add("cameras", camerasArray);
                HttpWebRequest webRequest = this.CreatePost("camera", request.ToString(), out internetStatus);
                if (internetStatus)
                {
                    internetStatus = true;
                    using (WebResponse response = webRequest.GetResponse())
                    {
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            var rawJson = new StreamReader(response.GetResponseStream()).ReadToEnd();
                            CoRestResponse parsedPresponse = this.ParseResponse(rawJson);
                            status = parsedPresponse.status;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                status = false;
                internetStatus = false;
            }
            return status;
        }
    }
}
