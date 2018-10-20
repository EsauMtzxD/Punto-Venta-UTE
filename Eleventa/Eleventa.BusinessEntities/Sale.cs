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
        /// Sucursal en la que se realizo la venta
        /// </summary>  
        [Required(ErrorMessage = "El campo Sucursal es obligatorio")]
        public string Sucursal { get; set; }

        /// <summary>
        /// Fecha en que se realizo la venta
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Importe total del la venta
        /// </summary>
        [Required(ErrorMessage = "El campo Importe es obligatorio")]
        public double Importe { get; set; }

        /// <summary>
        /// Cantidad de articulos comprados
        /// </summary>
        public int QuantityOfItems { get; set; }

        /// <summary>
        /// La caja en que se combre la venta
        /// </summary>
        public string Caja { get; set; }

        public virtual ICollection<DetalleVenta> DetalleVentas { get; set; }

        public virtual ICollection<Cut> Cuts { get; set; }

    }
}
