using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleventa.BusinessLogicLayer
{
    public class DepartmentBLL
    {

        public static DataTable Departamentos()
        {

            DataTable dt = new DataTable();

            dt = DataAccessLayer.DepartmentDAL.Search_Departments();

            return dt;

        }

    }
}
