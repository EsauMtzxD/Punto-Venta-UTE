using Eleventa.BusinessEntities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

        public static DataTable Productos(string CodigoBarras)
        {

            DataTable dt = new DataTable();

            using(EleventaDbContext dbCtx = new EleventaDbContext())
            {

                var resul = dbCtx.Products.Where(x => x.CodigoBarras == CodigoBarras).ToList();

                dt.Columns.AddRange(new DataColumn[]
                {

                    new DataColumn("Id", typeof(int)),
                    new DataColumn("Descripcion", typeof(string)),
                    new DataColumn("Codigo de Barras", typeof(string)),
                    new DataColumn("Unidad de Venta", typeof(string)),
                    new DataColumn("Departamento", typeof(int)),
                    new DataColumn("Cantidad", typeof(int)),
                    new DataColumn("Costo", typeof(decimal)),
                    new DataColumn("Precio", typeof(decimal)),
                    new DataColumn("Precio al Mayoreo", typeof(decimal)),
                    new DataColumn("Ganancia", typeof(decimal)),
                    new DataColumn("Uso de Inventario", typeof(bool)),
                    new DataColumn("Inventario Minimo", typeof(int)),
                    new DataColumn("Inventario Maximo", typeof(int))

                });

                resul.ToList().ForEach(x =>
                {

                    var row = dt.NewRow();

                    row["Id"] = x.Id;
                    row["Descripcion"] = x.Descripcion;
                    row["Codigo de Barras"] = x.CodigoBarras;
                    row["Unidad de Venta"] = x.Unidad_Venta;
                    row["Departamento"] = x.IdDepartamento;
                    row["Cantidad"] = x.Cantidad;
                    row["costo"] = x.Costo;
                    row["Precio"] = x.Precio;
                    row["Precio al Mayoreo"] = x.PrecioMayoreo;
                    row["Ganancia"] = x.Ganancia;

                    if(x.Use_Inventory == true)
                    {

                        row["Uso de Inventario"] = true;

                    }
                    else
                    {

                        row["Uso de Inventario"] = false;

                    }
                    row["Inventario Minimo"] = x.InvMinima;
                    row["Inventario Maximo"] = x.InvMaxima;

                    dt.Rows.Add(row);

                });

            }

            return dt;

        }

        public static bool EliminarProducto(string Bar)
        {

            bool isSaved = false;

            using(EleventaDbContext dbCtx = new EleventaDbContext())
            {

                var result = dbCtx.Products.Where(x => x.CodigoBarras == Bar).FirstOrDefault();

                dbCtx.Products.Remove(result);

                int rowsAffected = dbCtx.SaveChanges();

                if(rowsAffected > 0)
                {

                    isSaved = true;

                }

            }

            return isSaved;

        }

        public static bool Modificar_Producto(Product p)
        {

            bool isSaved = false;

            using (EleventaDbContext dbCtx = new EleventaDbContext())
            {

                dbCtx.Entry(p).State = System.Data.Entity.EntityState.Modified;

                int rowsAffected = dbCtx.SaveChanges();

                if(rowsAffected > 0)
                {

                    isSaved = true;

                }

            }

            return isSaved;

        }

    }
}
