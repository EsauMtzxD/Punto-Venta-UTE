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

        /// <summary>
        /// Metodo para validar la insercion de datos en la table venta
        /// </summary>
        /// <param name="s">Objeto de la clase Venta con los datos a guardar</param>
        /// <returns></returns>
        public static string insertSale(Sale s)
        {

            string msgError = string.Empty;

            // Metodo de la clase DAL para guardar los datos en la clase SALE
            bool isCheked = DataAccessLayer.SaleDAL.inserSale(s);

            // SI el metodo no regresa un true entonces retornara el mensaje de error
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
