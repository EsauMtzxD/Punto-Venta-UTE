using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleventa.BusinessEntities
{
    public class Sale
    {

        /// <summary>
        /// llave primaria de la venta
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Articulo de la venta
        /// </summary>
        [Required(ErrorMessage = "Ingrese el campo Articulo")]
        public String Articulo { get; set; }

        /// <summary>
        /// Precio del articulo
        /// </summary>
        [Required(ErrorMessage = "Ingrese el campo Precio")]
        public double Precio { get; set; }

        /// <summary>
        /// Cantidad de Articulos que se esta comprando
        /// </summary>
        [Required(ErrorMessage = "Ingrese el campo CantidadArticulos")]
        public int CantidadArticulos { get; set; }

        /// <summary>
        /// El subtotal que tiene la venta
        /// </summary>
        [Required(ErrorMessage = "Ingrese el campo Subtotal")]
        public double Subtotal { get; set; }

        /// <summary>
        /// Iva de la venta
        /// </summary>
        [Required(ErrorMessage = "Ingrese el campo Iva")]
        public double Iva { get; set; }

        /// <summary>
        /// Cantidad total a pagar de la venta con Iva
        /// </summary>
        [Required(ErrorMessage = "Ingrese el campo Total")]
        public double Total { get; set; }


        /// <summary>
        /// Cantidad que se esta pagando de la venta
        /// </summary>
        [Required(ErrorMessage = "Ingrese el campo Pago")]
        public double Pago { get; set; }

        /// <summary>
        /// Cantidad a regresar al cliente 
        /// </summary>
        [Required(ErrorMessage = "Ingrese el campo Cambio")]
        public double Cambio { get; set; }

        /// <summary>
        /// Nombre del empleado que realizo la venta
        /// </summary>
        [Required(ErrorMessage = "Ingrese el campo NombreEmpleado")]
        public String NombreEmpleado { get; set; }

        /// <summary>
        /// Fecha en que se realizo la venta
        /// </summary>
        [Required(ErrorMessage = "Ingrese el campo Fecha")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Productos que se vendieron
        /// </summary>
        [ForeignKey("Product")]
        [Required(ErrorMessage = "Ingrese el campo IdProducto")]
        public int IdProducto { get; set; }
        public Product Product { get; set; }

        public virtual ICollection<Cut> Cuts { get; set; }

    }
}
