using Eleventa.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleventa.DataAccessLayer
{
    public class DetalleVentaDAL
    {

        public static bool insertDetalleVenta(DetalleVenta detalle)
        {

            bool isInsert = false;

            using(EleventaDbContext dbCtx = new EleventaDbContext())
            {

                dbCtx.DetalleVentas.Add(detalle);

                int rowsAffected = dbCtx.SaveChanges();

                if(rowsAffected > 0)
                {

                    isInsert = true;

                }

            }

            return isInsert;

        }

    }
}
