using Animus.Common;
using Animus.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animus.BussinesRules
{
    public class BrSesion
    {
        internal int insert(CoSesion coSession)
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
        }

        internal void update(CoSesion coSession)
        {
            try
            {
                DaSesion da = new DaSesion();
                da.update(coSession);
            }
            catch (Exception ex)
            {

            }
        }

        internal void getData(out string token, out int id)
        {
            token = string.Empty;
            id = 0;

            try
            {
                DaSesion da = new DaSesion();
                da.getData(out token, out id);
            }
            catch (Exception ex)
            {

            }
        }

        internal void updateUltimetoken(CoSesion coSession)
        {
            try
            {
                DaSesion da = new DaSesion();
                da.updateUltimetoken(coSession);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
