using Animus.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Animus.RestServices
{
    class RsSession : RsBase
    {

        public string RenewToken(string lastToken, out Boolean internetStatus)
        {
            internetStatus = true;
            string newToken = null;
            try
            {
                HttpWebRequest webRequest = this.CreatePost("auth/renew", "", out internetStatus);
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
                                newToken = parsedPresponse.data["token"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                internetStatus = false;
            }
            return newToken;
        }

    }
}
