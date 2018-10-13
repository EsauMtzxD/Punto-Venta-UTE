using Eleventa.BusinessEntities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleventa.DataAccessLayer
{
    public class ProductDAL
    {

        /// <summary>
        /// Metodo para insetar datos a la BD - Tabla Product
        /// Por medio de Linq
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool Nuevo_Producto(Product p)
        {

            bool isInserted = false;
            
            using(EleventaDbContext dbCtx = new EleventaDbContext())
            {

                dbCtx.Products.Add(p);

                int rowsAffected = dbCtx.SaveChanges();

                if(rowsAffected > 0)
                {

                    isInserted = true;

                }

            }

            return isInserted;
        }

    }
}
