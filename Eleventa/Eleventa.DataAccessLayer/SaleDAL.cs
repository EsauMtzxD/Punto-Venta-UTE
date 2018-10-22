using Eleventa.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleventa.DataAccessLayer
{
    public class SaleDAL
    {

        /// <summary>
        /// Metodo para insertar los datos en la tabla SALE de la BD
        /// </summary>
        /// <param name="s">Objeto del tipo SALE con los datos a guardar</param>
        /// <returns></returns>
        public static bool inserSale(Sale s)
        {

            //Variable a retornar
            bool isInsert = false;

            using(EleventaDbContext dbCtx = new EleventaDbContext())
            {

                // Linea para insertar los datos en la BD
                dbCtx.Sales.Add(s);

                //Validar las lineas afectadas al tiempo de guardar los cambios
                int rowsAffected = dbCtx.SaveChanges();
                
                // Si las lineas afectadas son mayor a 0 entonces retornara un true
                if(rowsAffected > 0)
                {

                    isInsert = true;

                }

            }

            return isInsert;

        }

        public static int getLastRegister()
        {

            int saleId;

            using(EleventaDbContext dbCtx = new EleventaDbContext())
            {

                saleId = dbCtx.Sales.OrderByDescending(x => x.Id).First().Id;

            }

            return saleId;

        }

    }
}
