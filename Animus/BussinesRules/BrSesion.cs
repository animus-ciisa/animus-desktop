using Animus.Common;
using Animus.DataAccess;
using Animus.RestServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animus.BussinesRules
{
    public class BrSesion
    {

        DaSesion daSession;
        RsSession rsSession;

        public BrSesion()
        {
            this.daSession = new DaSesion();
            this.rsSession = new RsSession();
        }

        public int Save(CoSesion coSession)
        {
            try
            {
                return this.daSession.Save(coSession);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public void CloseSession(CoSesion session)
        {
            try
            {
                this.daSession.CloseSession(session);
            }
            catch (Exception ex)
            {
                
            }
        }

        public Boolean UpdateToken(out Boolean internetStatus)
        {
            internetStatus = true;
            Boolean status = true;
            CoSesion session = this.daSession.GetActiveSession();
            if(session != null)
            {
                string newToken = this.rsSession.RenewToken(session.token, out internetStatus);
                if (newToken != null && newToken.Trim() != "")
                {
                    session.token = newToken;
                    this.daSession.UpdateToken(session);
                }
                else
                    status = false;
            }
            return status;
        }

        /*internal int insert(CoSesion coSession)
        {
            try
            {
                DaSesion da = new DaSesion();
                return da.insert(coSession);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }*/

        /*internal void update(CoSesion coSession)
        {
            try
            {
                this.daSession.update(coSession);
            }
            catch (Exception ex)
            {

            }
        }*/

        /*internal void getData(out string token, out int id)
        {
            token = string.Empty;
            id = 0;
            try
            {
                this.daSession.getData(out token, out id);
            }
            catch (Exception ex)
            {

            }
        }*/

        /*internal void updateUltimetoken(CoSesion coSession)
        {
            try
            {
                this.daSession.updateUltimetoken(coSession);
            }
            catch (Exception ex)
            {

            }
        }*/
    }
}
