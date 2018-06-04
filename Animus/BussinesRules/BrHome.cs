using Animus.Common;
using Animus.DataAccess;
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

        internal bool validateMail(string mail)
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

        internal int InsertHome(CoHome coHome,out string response)
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
        }

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

        internal bool validatePassword(CoHome coHome)
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
    }
}
