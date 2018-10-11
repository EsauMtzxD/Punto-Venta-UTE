using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleventa.BusinessEntities
{
    public class Product
    {
        [Key]
        [Required(ErrorMessage = "Ingrese el campo Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese el campo Descripcion")]
        public String Descripcion { get; set; }

        [Required(ErrorMessage = "Ingrese el campo Cantidad")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Ingrese el campo CodigoBarras")]
        public String CodigoBarras { get; set; }

        [Required(ErrorMessage = "Ingrese el campo Precio")]
        public double Precio { get; set; }

        [Required(ErrorMessage = "Ingrese el campo PrecioMayoreo")]
        public double PrecioMayoreo { get; set; }

        [Required(ErrorMessage = "Ingrese el campo Costo")]
        public double Costo { get; set; }

        [Required(ErrorMessage = "Ingrese el campo Ganancia")]
        public double Ganancia { get; set; }

        [Required(ErrorMessage = "Ingrese el campo InvMinima")]
        public int InvMinima { get; set; }

        [Required(ErrorMessage = "Ingrese el campo InvMaxima")]
        public int InvMaxima { get; set; }

        [ForeignKey ("Department")]
        [Required(ErrorMessage = "Ingrese el campo IdDepartamento")]
        public int IdDepartamento { get; set; }
        public Department Department { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
