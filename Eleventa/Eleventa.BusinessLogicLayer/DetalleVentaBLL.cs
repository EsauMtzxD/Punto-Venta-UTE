using Eleventa.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleventa.BusinessLogicLayer
{
    public class DetalleVentaBLL
    {
   
        /// <summary>
        /// Metodo para validar la insercion de los datos en la tabla DetalleVentas
        /// </summary>
        /// <param name="detalle">Objeto con los datos a guardar</param>
        /// <returns></returns>
        public static bool insertDetalleVenta(DetalleVenta detalle)
        {

            return DataAccessLayer.DetalleVentaDAL.insertDetalleVenta(detalle);

        }
    
    }
}
