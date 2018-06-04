using Animus.Common;
using Animus.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animus.BussinesRules
{
    public class BrTest
    {
        public void insert_test(CoTest comtest)
        {
            DaTest da = new DaTest();
            da.insert_test(comtest);
        }

        public void Create_DataBase()
        {
            DaTest da = new DaTest();
            da.Create_DataBase();
        }

        internal void update_test(CoTest comtest)
        {
            DaTest da = new DaTest();
            da.update_test(comtest);
        }

        internal void delete_test(CoTest comtest)
        {
            DaTest da = new DaTest();
            da.delete_test(comtest);
        }

        internal DataTable trae_registro()
        {
            DaTest da = new DaTest();
            return da.trae_registro();
        }
    }
}
