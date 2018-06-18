using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Configuration;
using Animus.Common;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Animus.RestServices
{
    class RsBase
    {
        string backendUrl = ConfigurationManager.AppSettings["backendUri"];

        public HttpWebRequest CreatePost(string resource, string jsonParams, out Boolean internetStatus, Boolean useToken = true)
        {
            HttpWebRequest webRequest = null;
            internetStatus = RsBase.CheckForInternetConnection();
            if (internetStatus)
            {
                webRequest = (HttpWebRequest)WebRequest.Create(backendUrl + resource);
                webRequest.Method = "POST";
                webRequest.ContentType = "application/json";
                byte[] byteArray = Encoding.UTF8.GetBytes(jsonParams);
                webRequest.ContentLength = byteArray.Length;
                using (Stream requestStream = webRequest.GetRequestStream())
                {
                    requestStream.Write(byteArray, 0, byteArray.Length);
                }
            }
            return webRequest;
        }

        public CoRestResponse ParseResponse(string rawJson)
        {
            CoRestResponse response = new CoRestResponse();
            JObject json = JObject.Parse(rawJson);
            if (json["code"] == null || json["status"] == null || json["data"] == null)
            {
                return null;
            }
            response.status = (json["status"].ToString() == "ok") ? true : false;
            response.code = Int32.Parse(json["code"].ToString());
            response.data = JObject.Parse(json["data"].ToString());
            return response;
        }

        public static bool CheckForInternetConnection()
        {
            string checkInternetUri = ConfigurationManager.AppSettings["checkInternetUri"];
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead(checkInternetUri))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
