using Eleventa.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleventa.BusinessLogicLayer
{
    public class SaleBLL
    {

        public static string insertSale(Sale s)
        {

            string msgError = string.Empty;

            bool isCheked = DataAccessLayer.SaleDAL.inserSale(s);

            if(isCheked != true)
            {

                msgError = "No se puedo Insertar la venta";

            }

            return msgError;
        }

        public static int getLastRegister()
        {

            return DataAccessLayer.SaleDAL.getLastRegister();

        }

    }
}
