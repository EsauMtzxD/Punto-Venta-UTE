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
        [Key]
        [Required(ErrorMessage = "Ingrese el campo Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese el campo Articulo")]
        public String Articulo { get; set; }

        [Required(ErrorMessage = "Ingrese el campo Precio")]
        public double Precio { get; set; }

        [Required(ErrorMessage = "Ingrese el campo CantidadArticulos")]
        public int CantidadArticulos { get; set; }

        [Required(ErrorMessage = "Ingrese el campo Pago")]
        public double Pago { get; set; }

        [Required(ErrorMessage = "Ingrese el campo Subtotal")]
        public double Subtotal { get; set; }

        [Required(ErrorMessage = "Ingrese el campo Total")]
        public double Total { get; set; }

        [Required(ErrorMessage = "Ingrese el campo Iva")]
        public double Iva { get; set; }

        [Required(ErrorMessage = "Ingrese el campo Cambio")]
        public double Cambio { get; set; }

        [Required(ErrorMessage = "Ingrese el campo NombreEmpleado")]
        public String NombreEmpleado { get; set; }

        [Required(ErrorMessage = "Ingrese el campo Fecha")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [ForeignKey ("Product")]
        [Required(ErrorMessage = "Ingrese el campo IdProducto")]
        public int IdProducto { get; set; }
        public Product Product { get; set; }

        public virtual ICollection<Cut> Cuts { get; set; }
    }
}
