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

                //Linea que esta ingresando los datos a la Table de la BD
                dbCtx.Products.Add(p);

                // Linea que guarda las lineas afectadas cuando se guarda los cambios
                int rowsAffected = dbCtx.SaveChanges();

                // Si hay mas de 0 lineas afectadas entonces regresara un tru
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
                    new DataColumn("Departamento", typeof(int)),
                    new DataColumn("Unidad de Venta", typeof(string)),
                    new DataColumn("Costo", typeof(decimal)),
                    new DataColumn("Ganancia", typeof(decimal)),
                    new DataColumn("Precio", typeof(decimal)),
                    new DataColumn("Precio al Mayoreo", typeof(decimal)),
                    new DataColumn("Uso de Inventario", typeof(bool)),
                    new DataColumn("Cantidad", typeof(int)),
                    new DataColumn("Inventario Minimo", typeof(int)),
                    new DataColumn("Inventario Maximo", typeof(int))

                });

                resul.ToList().ForEach(x =>
                {

                    var row = dt.NewRow();

                    row["Id"] = x.Id;
                    row["Descripcion"] = x.Descripcion;
                    row["Codigo de Barras"] = x.CodigoBarras;
                    row["Departamento"] = x.IdDepartamento;
                    row["Unidad de Venta"] = x.Unidad_Venta;
                    row["costo"] = x.Costo;
                    row["Ganancia"] = x.Ganancia;
                    row["Precio"] = x.Precio;
                    row["Precio al Mayoreo"] = x.PrecioMayoreo;

                    if(x.Use_Inventory == true)
                    {

                        row["Uso de Inventario"] = true;

                    }
                    else
                    {

                        row["Uso de Inventario"] = false;

                    }
                    row["Cantidad"] = x.Cantidad;
                    row["Inventario Minimo"] = x.InvMinima;
                    row["Inventario Maximo"] = x.InvMaxima;

                    dt.Rows.Add(row);

                });

            }

            return dt;

        }

        public static Product Productos_Buscar(Product producto)
        {

            Product pp = new Product();

            using(EleventaDbContext dbCtx = new EleventaDbContext())
            {

                pp = dbCtx.Products.Where(x => x.CodigoBarras == producto.CodigoBarras).FirstOrDefault();

            }

            return pp;

        }

        /// <summary>
        /// Metodo el cual estara eliminando el Producto en por medio de LINQ
        /// </summary>
        /// <param name="Bar"></param>
        /// <returns></returns>
        public static bool EliminarProducto(string Bar)
        {

            // Variable bool el cual estara regresando el metodo
            bool isSaved = false;

            using(EleventaDbContext dbCtx = new EleventaDbContext())
            {

                // Colsulta el cual estara trayendo todo la fila de la tabla segun el codigo de baras
                var result = dbCtx.Products.Where(x => x.CodigoBarras == Bar).FirstOrDefault();

                // Linea el que estara eliminaod toda la fila antes traida 
                dbCtx.Products.Remove(result);

                // Guardar si hay filas afectadas al tiempo de guardar los cambios
                int rowsAffected = dbCtx.SaveChanges();

                // Si las lineas afectadas es mayor a cero entonces regresara un true
                if(rowsAffected > 0)
                {

                    // y pasar la variable bool antes declarada a true
                    isSaved = true;

                }

            }

            // y retornar la variable
            return isSaved;

        }

        /// <summary>
        /// Metodo que Modifica el producto
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool Modificar_Producto(Product p)
        {

            bool isSaved = false;

            using (EleventaDbContext dbCtx = new EleventaDbContext())
            {

                // Linea que esta guardando los datos traidos que antes guardamos
                dbCtx.Entry(p).State = System.Data.Entity.EntityState.Modified;

                // Guardar si hubo lineas afectadas al tiempo de estar guardando los datos
                int rowsAffected = dbCtx.SaveChanges();

                // Si las lineas afectadas es mayor a 0 entonces el metodo regresara un tru
                if(rowsAffected > 0)
                {

                    // Pasar la variable bool a true para que este lo pueda retornar
                    isSaved = true;

                }

            }

            return isSaved;

        }

        public static DataTable Select_Inventario(string BarCode)
        {

            DataTable dt = new DataTable();

            using(EleventaDbContext dbCtx = new EleventaDbContext())
            {

                var result = (from p in dbCtx.Products
                              where p.CodigoBarras == BarCode 
                              select new
                              {

                                  p.Descripcion,
                                  p.CodigoBarras,
                                  p.Costo,
                                  p.Precio,
                                  p.Cantidad,
                                  p.InvMinima,
                                  p.InvMaxima,

                              }).ToList();

                dt.Columns.AddRange(new DataColumn[]
                {

                    new DataColumn("Descripcion", typeof(string)),
                    new DataColumn("Codigo de Barras", typeof(string)),
                    new DataColumn("Costo", typeof(double)),
                    new DataColumn("Precio", typeof(double)),
                    new DataColumn("Cantidad", typeof(int)),
                    new DataColumn("Inventario Minimo", typeof(int)),
                    new DataColumn("Inventario Maximo", typeof(int))

                });

                result.ToList().ForEach(x =>
                {

                    var row = dt.NewRow();

                    row["Descripcion"] = x.Descripcion;
                    row["Codigo de Barras"] = x.CodigoBarras;
                    row["Costo"] = x.Costo;
                    row["Precio"] = x.Precio;
                    row["Cantidad"] = x.Cantidad;
                    row["Inventario Minimo"] = x.InvMinima;
                    row["Inventario Maximo"] = x.InvMaxima;

                    dt.Rows.Add(row);

                });

            }
            return dt;
        }

        /// <summary>
        /// Metodo para modificar el inventario
        /// </summary>
        /// <param name="p">Objeto con los datos a modificar</param>
        /// <returns>true si se pudo modificar, false si no se pudo modificar</returns>
        public static bool Modificar_Inventario(Product p)
        {

            //Variable a regresar
            bool isCheked = false;

            using(EleventaDbContext dbCtx = new EleventaDbContext())
            {

                // Linea para guardar los datos a modificar
                dbCtx.Entry(p).State = System.Data.Entity.EntityState.Modified;

                // Guardar las lineas afectadas a guardar los cambios
                int rowsAffected = dbCtx.SaveChanges();

                // Si las lineas afectadas es mayor a 0 entonces el metodo retornara un true
                // Pero si es 0 entonces retornara un false
                if(rowsAffected >0)
                {

                    isCheked = true;

                }

            }

            return isCheked;

        }

        public static DataTable Catalogo()
        {

            DataTable dt = new DataTable();

            using (EleventaDbContext dbCtx = new EleventaDbContext())
            {

                Product p = new Product();

                var result = (from product in dbCtx.Products
                             join dep in dbCtx.Departments on product.IdDepartamento equals dep.Id
                             select new
                             {

                                 product.Id,
                                 product.Descripcion,
                                 dep.Nombre,
                                 product.Precio

                             }).ToList();

                dt.Columns.AddRange(new DataColumn[]
                {

                    new DataColumn("Id", typeof(int)),
                    new DataColumn("Descripcion", typeof(string)),
                    new DataColumn("Departamento", typeof(string)),
                    new DataColumn("Precio $", typeof(double))

                });

                result.ToList().ForEach(x =>
                {

                    var row = dt.NewRow();

                    row["Id"] = x.Id;
                    row["Descripcion"] = x.Descripcion;
                    row["Departamento"] = x.Nombre;
                    row["Precio $"] = x.Precio;

                    dt.Rows.Add(row);

                });

            }

            return dt;

        }

        /// <summary>
        /// Metodo para encontrar el producto mediante el codigo de barras
        /// </summary>
        /// <param name="barCode">Codigo de barras a buscar el producto</param>
        /// <returns></returns>
        public static Product findProdoductByBarCode(string barCode)
        {

            Product p = null;

            using(EleventaDbContext dbCtx = new EleventaDbContext())
            {

                // Consulta para traer los datos del producto
                p = dbCtx.Products.Where(x => x.CodigoBarras == barCode).SingleOrDefault();

            }

            //Retornar el producto
            return p;
        }

        public static int getProductIdByCodeBar(string codBar)
        {

            int ProductId = 0;

            using(EleventaDbContext dbCtx = new EleventaDbContext())
            {

                ProductId = dbCtx.Products.Where(x => x.CodigoBarras == codBar).First().Id;

            }

            return ProductId;

        }

        public static void modifyQuantityOfItems(string codBar, int quantityOfItem)
        {

            using(EleventaDbContext dbCtx = new EleventaDbContext())
            {

                Product p = dbCtx.Products.Where(x => x.CodigoBarras == codBar).SingleOrDefault();

                int stock_actual = p.Cantidad - quantityOfItem;

                p.Cantidad = stock_actual;

                dbCtx.Entry(p).State = System.Data.Entity.EntityState.Modified;

                dbCtx.SaveChanges();

            }

        }

    }
}
