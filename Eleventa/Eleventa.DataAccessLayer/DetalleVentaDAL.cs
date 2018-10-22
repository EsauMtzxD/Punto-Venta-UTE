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

        /// <summary>
        /// Metodo para insertar los datos en la BD
        /// </summary>
        /// <param name="detalle">Objeto con los datos a guardar</param>
        /// <returns></returns>
        public static bool insertDetalleVenta(DetalleVenta detalle)
        {

            bool isInsert = false;

            using(EleventaDbContext dbCtx = new EleventaDbContext())
            {

                // Linea para guardar los datos
                dbCtx.DetalleVentas.Add(detalle);

                // Validar las lineas afectadas al guardar los cambios
                int rowsAffected = dbCtx.SaveChanges();

                // Si las lineas afectadas son mayor a 0 entonces el metodo retornara un true;
                if(rowsAffected > 0)
                {

                    isInsert = true;

                }

            }

            return isInsert;

        }

    }
}
