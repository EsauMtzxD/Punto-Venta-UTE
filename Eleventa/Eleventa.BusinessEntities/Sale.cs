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
        public int Id { get; set; }

        public String Articulo { get; set; }

        public double Precio { get; set; }

        public int CantidadArticulos { get; set; }

        public double Pago { get; set; }

        public double Subtotal { get; set; }

        public double Total { get; set; }

        public double Iva { get; set; }

        public double Cambio { get; set; }

        public String NombreEmpleado { get; set; }

        public DateTime Fecha { get; set; }

        [ForeignKey ("Product")]
        public int IdProducto { get; set; }
        public Product Product { get; set; }
    }
}
