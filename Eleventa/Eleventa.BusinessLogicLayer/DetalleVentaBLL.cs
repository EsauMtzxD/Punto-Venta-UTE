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
   
        public static bool insertDetalleVenta(DetalleVenta detalle)
        {

            return DataAccessLayer.DetalleVentaDAL.insertDetalleVenta(detalle);

        }
    
    }
}
