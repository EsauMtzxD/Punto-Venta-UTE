using Eleventa.BusinessEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        /// <param name="p"></param>
        /// <returns></returns>
        public static string NuevoProducto(Product p)
        {

            string msgError = string.Empty;

            ICollection<ValidationResult> results = null;

            if(!Validate(p, out results))
            {

                msgError = String.Join("\n", results.Select(o => o.ErrorMessage));

            }
            else
            {

                try
                {

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

    }
}
