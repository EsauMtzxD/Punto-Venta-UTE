using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleventa.BusinessEntities
{
    public class Cut
    {
        [Key]
        [Required(ErrorMessage = "Ingrese el campo Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese el campo FondoInicial")]
        public double FondoInicial { get; set; }

        [Required(ErrorMessage = "Ingrese el campo CantidadFinal")]
        public double CantidadFinal { get; set; }

        [Required(ErrorMessage = "Ingrese el campo Diferencia")]
        public double Diferencia { get; set; }

        [Required(ErrorMessage = "Ingrese el campo Fecha")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [ForeignKey ("Sale")]
        public int IdVenta { get; set; }
        public Sale Sale { get; set; }
    }
}
