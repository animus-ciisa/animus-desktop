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

        RsHome rsHome;
        DaHome daHome;

        public BrHome()
        {
            this.rsHome = new RsHome();
            this.daHome = new DaHome();
        }

        public Boolean ValidateEmailFormat(string mail)
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

        public CoHome Exists()
        {
            return this.daHome.Exists();
        }

        public Boolean EmailExists(string email, out Boolean internetStatus)
        {
            return this.rsHome.EmailExists(email, out internetStatus);
        }

        public CoHome Registry(CoHome home, out CoSesion session, out Boolean internetStatus)
        {
            session = new CoSesion();
            internetStatus = true;
            string sessionToken = string.Empty;
            home = this.rsHome.Save(home, out sessionToken, out internetStatus);
            if (home.id != 0)
            {
                try
                {
                    this.daHome.Save(home);
                    session.start = DateTime.Now;
                    session.token = sessionToken;
                    int idSession = new BrSesion().Save(session);
                }
                catch (Exception ex)
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
            home = this.rsHome.Authenticate(home, out sessionToken, out internetStatus);
            if (home.id == 0)
            {
                home = null;
            }
            return home;
        }
    }
}
