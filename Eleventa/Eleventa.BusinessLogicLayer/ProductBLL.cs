using Eleventa.BusinessEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleventa.BusinessLogicLayer
{
    public class ProductBLL
    {

        /// <summary>
        /// Metodo que sirve para Validar los DataAnnotations
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="results"></param>
        /// <returns></returns>
        public static bool Validate<T>(T obj, out ICollection<ValidationResult> results)
        {
            results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
        }

        /// <summary>
        /// Metodo para validar la Insercion de los datos a la table de la BD
        /// </summary>
        /// <param name="p">Objeto con los datos a ingresar</param>
        /// <returns>Mensaje de error</returns>
        public static string NuevoProducto(Product p)
        {

            string msgError = string.Empty;

            // Linea que valida los DATAANNOTATIONS y mostrar los mensajes de Error
            ICollection<ValidationResult> results = null;

            if(!Validate(p, out results))
            {

                msgError = String.Join("\n", results.Select(o => o.ErrorMessage));

            }
            else
            {

                try
                {

                    // Llamar el metodo de PRODUCTDALL e ingresar el objeto que mandamos antes
                    bool isInserted = DataAccessLayer.ProductDAL.Nuevo_Producto(p);

                    if (isInserted != true)
                    {

                        msgError = "No se Puedo Registrar el Producto";

                    }

                }
                catch(Exception e)
                {

                    msgError = e.Message.ToString();

                }

            }
            return msgError;
        }

        public static DataTable Productos(string CodigoBarras)
        {

            DataTable dt = new DataTable();

            dt = DataAccessLayer.ProductDAL.Productos(CodigoBarras);

            return dt;

        }

        public static Product Productos_Buscar(Product p)
        {

            Product pp = new Product();

            pp = DataAccessLayer.ProductDAL.Productos_Buscar(p);

            return pp;

        }

        /// <summary>
        /// Metodo para validar la logica de negocio
        /// Mandando el Codigo de barras del producto para poder eliminarlo
        /// </summary>
        /// <param name="Bar">Codigo de barras a buscar y eliminar</param>
        /// <returns>Mensaje de Error</returns>
        public static string Eliminar_Producto(string Bar)
        {

            string msgError = string.Empty;

            // Guardar en una varia bool si el metodo de eliminar el la clase PRODUCTDALL si
            // Logro eliminar el producto Correctamento
            bool isSaved = DataAccessLayer.ProductDAL.EliminarProducto(Bar);

            // Si el metodo regreso algo diferente de verdadero entonces mandara un mensaje de error
            // El cual dija que no se pudo eliminar el producto
            if(isSaved != true)
            {

                msgError = "No se puedo Eliminar el Producto";

            }

            return msgError;

        }

        /// <summary>
        /// Metodo que validara si se puedo modificar el producto
        /// </summary>
        /// <param name="p">Objeto donde guardamos los datos a Modificar</param>
        /// <returns>Mensaje de Error</returns>
        public static string Modificar_Producto(Product p)
        {

            string msgError = string.Empty;

            // guardar lo que el metodo regreso en una variable bool
            bool isSaved = DataAccessLayer.ProductDAL.Modificar_Producto(p);

            // Si es diferente de tru
            if(isSaved != true)
            {

                //Entonces madara un mensaje de error
                msgError = "No se puedo Modificar el Producto";

            }

            return msgError;

        }

        public static DataTable Select_Inventario(string BarCode)
        {

            DataTable dt = new DataTable();

            dt = DataAccessLayer.ProductDAL.Select_Inventario(BarCode);

            return dt;

        }

        /// <summary>
        /// Metodo para validar si se pudo modificar el inventario
        /// </summary>
        /// <param name="p">Objeto con los datos que vamos a modificar</param>
        /// <returns>Mensaje de Error</returns>
        public static string Modificar_Inventario(Product p)
        {

            string msgError = string.Empty;

            bool isSaved = DataAccessLayer.ProductDAL.Modificar_Inventario(p);

            if(isSaved != true)
            {

                msgError = "\n \tEl Inventario no se Pudo Modificar";

            }

            return msgError;

        }

        public static DataTable Catalogo()
        {

            DataTable dt = new DataTable();

            dt = DataAccessLayer.ProductDAL.Catalogo();

            return dt;

        }

        /// <summary>
        /// Metodo que retornara los datos del producto a vender
        /// </summary>
        /// <param name="CodBar">Codigo de Barras a buscar el producto</param>
        /// <returns></returns>
        public static Product findProdoductByBarCode(string CodBar)
        {

            Product p = null;

            // Retornar el producto 
            return p = DataAccessLayer.ProductDAL.findProdoductByBarCode(CodBar);

        }

        public static int getProductIdByCodeBar(string codBar)
        {

            return DataAccessLayer.ProductDAL.getProductIdByCodeBar(codBar);

        }

        public static void modifyQuantityOfItems(string codBar, int quantityOfItem)
        {

            DataAccessLayer.ProductDAL.modifyQuantityOfItems(codBar, quantityOfItem);

        }



    }
}
