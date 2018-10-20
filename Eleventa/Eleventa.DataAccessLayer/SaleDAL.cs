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

        public static bool inserSale(Sale s)
        {

            bool isInsert = false;

            using(EleventaDbContext dbCtx = new EleventaDbContext())
            {

                dbCtx.Sales.Add(s);

                int rowsAffected = dbCtx.SaveChanges();

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
