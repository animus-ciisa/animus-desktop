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
    class RsHabitant : RsBase
    {
        public CoHabitant Save(CoHabitant habitant, out Boolean internetStatus)
        {
            internetStatus = true;

            JObject request = new JObject();
            request.Add("name", habitant.name);
            request.Add("lastname", habitant.lastname);
            request.Add("brithday", habitant.birthdate.ToString("yyyy-MM-dd"));
            request.Add("type", habitant.idtypepeperson);//tipo de persona
            Console.WriteLine("JSON: " + request.ToString());
            //string requestParams = "{ \"email\": \"" + home.mail + "\", \"password\": \"" + home.password + "\" }";
            try
            {
                HttpWebRequest webRequest = this.CreatePost("habitant", request.ToString(), out internetStatus);
                if (internetStatus)
                {
                    internetStatus = true;
                    using (WebResponse response = webRequest.GetResponse())
                    {
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            var rawJson = new StreamReader(response.GetResponseStream()).ReadToEnd();
                            CoRestResponse parsedPresponse = this.ParseResponse(rawJson);
                            if (parsedPresponse != null && parsedPresponse.status)
                            {
                                habitant.idhabitant = Convert.ToInt32(parsedPresponse.data["Id"].ToString());

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                internetStatus = false;
            }
            return habitant;

        }
    }
}
