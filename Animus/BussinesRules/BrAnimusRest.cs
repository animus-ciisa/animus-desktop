using Animus.Common;
using Animus.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animus.BussinesRules
{
    public class BrAnimusRest
    {

        public Boolean validateMail(String mail, out string status, out string code)
        {
            bool resp = true;
            status = string.Empty;
            code = string.Empty;
            try
            {
                DaAnimusRest da = new DaAnimusRest();
                resp = da.validateMail(mail, out status, out code);
            }
            catch (Exception ex)
            {
                resp = false;
            }
            return resp;
        }
        internal void validateAuth(out string status, out string code, CoHome coHome)
        {
            code = string.Empty;
            status = string.Empty;
            try
            {
                DaAnimusRest da = new DaAnimusRest();
                da.validateAuth(out status, out code, coHome);
            }
            catch (Exception ex)
            {
                coHome.idHome = 0;
            }
        }
        public CoHome registerHome(out string status, out string code, CoHome coHome)
        {
            code = string.Empty;
            status = string.Empty;
            try
            {
                DaAnimusRest da = new DaAnimusRest();
                return da.registerHome(out status, out code, coHome);
            }
            catch (Exception ex)
            {
                coHome.idHome = 0;
                return coHome;
            }
        }

        internal string renewToken(string tooken, out string status, out string code)
        {
            status = string.Empty;
            code = string.Empty;

            try
            {
                DaAnimusRest da = new DaAnimusRest();
                return da.renewToken(tooken, out status, out code);
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        internal bool recoverPassword(string mailPassword, out string status, out string code)
        {
            status = string.Empty;
            code = string.Empty;

            try
            {
                DaAnimusRest da = new DaAnimusRest();
                return da.recoverPassword(mailPassword, out status, out code);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
