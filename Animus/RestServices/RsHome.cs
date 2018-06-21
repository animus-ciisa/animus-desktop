using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Animus.Common;

namespace Animus.RestServices
{
    class RsHome : RsBase
    {

        public CoHome Authenticate(CoHome home, out string sessionToken, out Boolean internetStatus)
        {
            internetStatus = true;
            sessionToken = string.Empty;
            JObject request = new JObject();
            request.Add("email", home.mail);
            request.Add("password", home.password);
            //string requestParams = "{ \"email\": \"" + home.mail + "\", \"password\": \"" + home.password + "\" }";
            try
            {
                HttpWebRequest webRequest = this.CreatePost("auth", request.ToString(), out internetStatus, false);
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
                                home.id = Convert.ToInt32(parsedPresponse.data["id"].ToString());
                                home.nick = parsedPresponse.data["nick"].ToString();
                                home.mail = parsedPresponse.data["email"].ToString();
                                sessionToken = parsedPresponse.data["session"]["token"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                internetStatus = false;
            }
            return home;
        }

        public CoHome Save(CoHome home, out string sessionToken, out Boolean internetStatus)
        {
            internetStatus = true;
            sessionToken = string.Empty;
            JObject request = new JObject();
            request.Add("email", home.mail);
            request.Add("nick", home.nick);
            request.Add("password", home.password);
            //string requestParams = "{ \"email\": \"" + home.mail + "\", \"nick\": \"" + home.nick + "\", \"password\": \"" + home.password + "\" }";
            try
            {
                HttpWebRequest webRequest = this.CreatePost("home", request.ToString(), out internetStatus, false);
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
                                home.id = Convert.ToInt32(parsedPresponse.data["id"].ToString());
                                home.nick = parsedPresponse.data["nick"].ToString();
                                home.mail = parsedPresponse.data["email"].ToString();
                                sessionToken = parsedPresponse.data["session"]["token"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                internetStatus = false;
            }
            return home;
        }

        public Boolean EmailExists(string email, out Boolean internetStatus)
        {
            internetStatus = true;
            Boolean exists = false;
            JObject request = new JObject();
            request.Add("email", email);
            //string requestParams = "{\"email\": \"" + email + "\"}";
            try
            {
                HttpWebRequest webRequest = this.CreatePost("home/validate-password", request.ToString(), out internetStatus, false);
                if (internetStatus)
                {
                    using (WebResponse response = webRequest.GetResponse())
                    {
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            var rawJson = new StreamReader(response.GetResponseStream()).ReadToEnd();
                            CoRestResponse parsedPresponse = this.ParseResponse(rawJson);
                            if (parsedPresponse != null && parsedPresponse.data["exists"] != null)
                            {
                                exists = Convert.ToBoolean(parsedPresponse.data["exists"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                internetStatus = false;
            }
            return exists;
        }
    }
}
