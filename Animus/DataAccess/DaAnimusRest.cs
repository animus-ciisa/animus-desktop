using Animus.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Animus.DataAccess
{
    public class DaAnimusRest
    {


        public CoHome registerHome(out string status, out string code, CoHome coHome)
        {
            status = string.Empty;
            code = string.Empty;
            try
            {

                string requestParams = "{ \"email\": \"" + coHome.mail + "\", \"nick\": \"" + coHome.nickHome + "\", \"password\": \"" + coHome.password + "\" }";
                //string requestParams = ""; //format information you need to pass into that string ('info={ "EmployeeID": [ "1234567", "7654321" ], "Salary": true, 
                HttpWebRequest webRequest;
                string urlHome = ConfigurationManager.AppSettings["urlRegisterHome"];
                webRequest = (HttpWebRequest)WebRequest.Create(urlHome);

                webRequest.Method = "POST";
                webRequest.ContentType = "application/json";

                byte[] byteArray = Encoding.UTF8.GetBytes(requestParams);
                webRequest.ContentLength = byteArray.Length;
                using (Stream requestStream = webRequest.GetRequestStream())
                {
                    requestStream.Write(byteArray, 0, byteArray.Length);
                }


                // Get the response.
                using (WebResponse response = webRequest.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        StreamReader rdr = new StreamReader(responseStream, Encoding.UTF8);
                        var rawJson = new StreamReader(response.GetResponseStream()).ReadToEnd();
                        JObject json = JObject.Parse(rawJson);


                        status = json["status"].ToString();
                        code = json["code"].ToString();


                        //aqui debo insertar en bd local
                        string id = json["data"]["id"].ToString();
                        // string image = json["data"]["image"].ToString();
                        string email = json["data"]["email"].ToString();
                        string nick = json["data"]["nick"].ToString();
                        string tooken = json["data"]["session"]["token"].ToString();
                        //string session = json["data"]["sesion"].ToString();
                        coHome.idHome = Convert.ToInt32(id);
                        coHome.nickHome = nick;
                        coHome.mail = email;
                        coHome.tookenHome = tooken;


                    }
                }
                return coHome;
            }
            catch (Exception ex)
            {
                coHome.idHome = 0;
                return coHome;
            }
        }
        //example method array de objetos
        public void exampleList()
        {
            try
            {
                HttpWebRequest webRequest;

                string requestParams = ""; //format information you need to pass into that string ('info={ "EmployeeID": [ "1234567", "7654321" ], "Salary": true, "BonusPercentage": 10}');

                webRequest = (HttpWebRequest)WebRequest.Create("http://localhost:1111/animus-rest-test/?method=list");

                // webRequest = (HttpWebRequest)WebRequest.Create("http://localhost:1111/animus-rest-test/?method=home/validate-email&exists=true");


                //webRequest = (HttpWebRequest)WebRequest.Create(urlEmail);//("http://localhost:1111/animus-rest-test/?method=home");


                webRequest.Method = "POST";
                webRequest.ContentType = "application/json";

                byte[] byteArray = Encoding.UTF8.GetBytes(requestParams);
                webRequest.ContentLength = byteArray.Length;
                using (Stream requestStream = webRequest.GetRequestStream())
                {
                    requestStream.Write(byteArray, 0, byteArray.Length);
                }

                // Get the response.
                using (WebResponse response = webRequest.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        StreamReader rdr = new StreamReader(responseStream, Encoding.UTF8);
                        var rawJson = new StreamReader(response.GetResponseStream()).ReadToEnd();
                        JObject json = JObject.Parse(rawJson);  //Turns your raw string into a key value lookup


                        string status = json["status"].ToString();
                        string code = json["code"].ToString();


                        //CUANDO ES ARRAY
                        JArray array = (JArray)json["data"];

                        if (array.Count > 0)
                        {
                            foreach (JObject item in array)
                            {
                                string id_ = item.GetValue("id").ToString();
                                string image = item.GetValue("image").ToString();
                                string email = item.GetValue("email").ToString();
                                string nick = item.GetValue("nick").ToString();
                                string session = item.GetValue("sesion").ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }


        internal void validateAuth(out string status, out string code, CoHome coHome)
        {

            status = string.Empty;
            code = string.Empty;
            try
            {

                string requestParams = "{ \"email\": \"" + coHome.mail + "\", \"password\": \"" + coHome.password + "\" }";
                //string requestParams = ""; //format information you need to pass into that string ('info={ "EmployeeID": [ "1234567", "7654321" ], "Salary": true, 
                HttpWebRequest webRequest;
                string urlAuth = ConfigurationManager.AppSettings["urlValidateAuth"];
                webRequest = (HttpWebRequest)WebRequest.Create(urlAuth);

                webRequest.Method = "POST";
                webRequest.ContentType = "application/json";

                byte[] byteArray = Encoding.UTF8.GetBytes(requestParams);
                webRequest.ContentLength = byteArray.Length;
                using (Stream requestStream = webRequest.GetRequestStream())
                {
                    requestStream.Write(byteArray, 0, byteArray.Length);
                }


                // Get the response.
                using (WebResponse response = webRequest.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        StreamReader rdr = new StreamReader(responseStream, Encoding.UTF8);
                        var rawJson = new StreamReader(response.GetResponseStream()).ReadToEnd();
                        JObject json = JObject.Parse(rawJson);


                        status = json["status"].ToString();
                        code = json["code"].ToString();


                        //aqui debo insertar en bd local
                        string id = json["data"]["id"].ToString();
                        // string image = json["data"]["image"].ToString();
                        string email = json["data"]["email"].ToString();
                        string nick = json["data"]["nick"].ToString();
                        string tooken = json["data"]["session"]["token"].ToString();
                        //string session = json["data"]["sesion"].ToString();
                        coHome.idHome = Convert.ToInt32(id);
                        coHome.nickHome = nick;
                        coHome.mail = email;
                        coHome.tookenHome = tooken;
                    }
                }

            }
            catch (Exception ex)
            {
                coHome.idHome = 0;

            }
        }

        internal bool validateMail(string mail, out string status, out string code)
        {
            status = string.Empty;
            code = string.Empty;
            Boolean responseMethod = false;

            try
            {
                HttpWebRequest webRequest;
                string urlEmail = ConfigurationManager.AppSettings["urlEmailValidate"];
                string requestParams = "{ \"email\": \"" + mail + "\"}";
                webRequest = (HttpWebRequest)WebRequest.Create(urlEmail);
                webRequest.Method = "POST";
                webRequest.ContentType = "application/json";
                byte[] byteArray = Encoding.UTF8.GetBytes(requestParams);
                webRequest.ContentLength = byteArray.Length;
                using (Stream requestStream = webRequest.GetRequestStream())
                {
                    requestStream.Write(byteArray, 0, byteArray.Length);
                }

                // Get the response.
                using (WebResponse response = webRequest.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        StreamReader rdr = new StreamReader(responseStream, Encoding.UTF8);
                        var rawJson = new StreamReader(response.GetResponseStream()).ReadToEnd();
                        JObject json = JObject.Parse(rawJson);  //Turns your raw string into a key value lookup
                        //CUANDO NO ES ARRAY
                        string msg = json["data"]["exists"].ToString();
                        if (msg.ToUpper().Trim() == "TRUE")
                            responseMethod = true;

                        status = json["status"].ToString();
                        code = json["code"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                responseMethod = false;
            }

            return responseMethod;
        }


        internal string renewToken(string tooken, out string status, out string code)
        {
            status = string.Empty;
            code = string.Empty;
            string token = string.Empty;
            try
            {
                HttpWebRequest webRequest;
                string urlEmail = ConfigurationManager.AppSettings["urlRenewToken"];

                webRequest = (HttpWebRequest)WebRequest.Create(urlEmail);
                string requestParams = "";

                webRequest.Method = "POST";
                webRequest.ContentType = "application/json";
                webRequest.Headers.Add("Authorization", "bearer " + tooken);

                byte[] byteArray = Encoding.UTF8.GetBytes(requestParams);
                webRequest.ContentLength = byteArray.Length;
                using (Stream requestStream = webRequest.GetRequestStream())
                {
                    requestStream.Write(byteArray, 0, byteArray.Length);
                }

                // Get the response.
                using (WebResponse response = webRequest.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        StreamReader rdr = new StreamReader(responseStream, Encoding.UTF8);
                        var rawJson = new StreamReader(response.GetResponseStream()).ReadToEnd();
                        JObject json = JObject.Parse(rawJson);  //Turns your raw string into a key value lookup


                        token = json["data"]["token"].ToString();
                        status = json["status"].ToString();
                        code = json["code"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return token;
        }

        internal bool recoverPassword(string mailPassword, out string status, out string code)
        {
            status = string.Empty;
            code = string.Empty;
            Boolean responseMethod = false;
            try
            {
                HttpWebRequest webRequest;
                string urlEmail = ConfigurationManager.AppSettings["urlRecoverPass"];

                string requestParams = "{ \"email\": \"" + mailPassword + "\"}";

                webRequest = (HttpWebRequest)WebRequest.Create(urlEmail);

                webRequest.Method = "POST";
                webRequest.ContentType = "application/json";

                byte[] byteArray = Encoding.UTF8.GetBytes(requestParams);
                webRequest.ContentLength = byteArray.Length;
                using (Stream requestStream = webRequest.GetRequestStream())
                {
                    requestStream.Write(byteArray, 0, byteArray.Length);
                }

                // Get the response.
                using (WebResponse response = webRequest.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        StreamReader rdr = new StreamReader(responseStream, Encoding.UTF8);
                        var rawJson = new StreamReader(response.GetResponseStream()).ReadToEnd();
                        JObject json = JObject.Parse(rawJson);  //Turns your raw string into a key value lookup


                        //CUANDO NO ES ARRAY
                        //string msg = json["data"]["exists"].ToString();
                        //if (msg.ToUpper().Trim() == "TRUE")
                        //    responseMethod = true;

                        status = json["status"].ToString();
                        code = json["code"].ToString();
                        responseMethod = true;

                    }
                }
            }
            catch (Exception ex)
            {
                responseMethod = false;
            }

            return responseMethod;
        }
    }
}
