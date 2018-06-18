using Animus.Common;
using Animus.DataAccess;
using Animus.RestServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Animus.BussinesRules
{
    public class BrHome
    {
        internal void GenerateDataBase()
        {
            try
            {
                DaHome da = new DaHome();
                da.GenerateDataBase();
            }
            catch (Exception ex)
            {

            }
        }

        internal bool ValidateEmailFormat(string mail)
        {
            try
            {
                if (new EmailAddressAttribute().IsValid(mail))
                    return true;
                else
                    return false;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        internal int HomeExits(CoHome home, out int idHome)
        {
            idHome = 0;
            try
            {
                DaHome da = new DaHome();
                return da.HomeExits(home, out idHome);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /*internal int InsertHome(CoHome coHome,out string response)
        {
            response = string.Empty;
            try
            {
                DaHome da = new DaHome();
                return da.InsertHome(coHome,out response);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }*/

        internal DataTable GetHomeId(int homeIdRescue)
        {
            DataTable dt = new DataTable();
            try
            {
                DaHome da = new DaHome();
                dt = da.GetHomeId(homeIdRescue);
                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
        }

        internal void UpdateHome(CoHome coHome)
        {
            try
            {
                DaHome da = new DaHome();
                da.UpdateHome(coHome);
            }
            catch (Exception ex)
            {

            }
        }

        internal bool ValidatePassword(CoHome coHome)
        {
            try
            {
                DaHome da = new DaHome();
                return da.validatePassword(coHome);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Boolean EmailExists(string email, out Boolean internetStatus)
        {
            RsHome restService = new RsHome();
            return restService.EmailExists(email, out internetStatus);
        }

        public CoHome Save(CoHome home, out string sessionToken, out Boolean internetStatus)
        {
            internetStatus = true;
            sessionToken = string.Empty;
            RsHome restService = new RsHome();
            home = restService.Save(home, out sessionToken, out internetStatus);
            if (home.idHome != 0)
            {
                try
                {
                    DaHome da = new DaHome();
                    da.InsertHome(home);
                }catch (Exception ex)
                {
                    home = null;
                }
            }
            else
            {
                home = null;
            }
            return home;
        }

        public CoHome Authenticate(CoHome home, out string sessionToken, out Boolean internetStatus)
        {
            RsHome restService = new RsHome();
            home = restService.Authenticate(home, out sessionToken, out internetStatus);
            if (home.idHome == 0)
            {
                home = null;
            }
            return home;
        }
    }
}
