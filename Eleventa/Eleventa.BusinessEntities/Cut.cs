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
        /// <summary>
        /// Llave primari del corte
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Saldo inicial de la caja
        /// </summary>
        [Required(ErrorMessage = "Ingrese el campo FondoInicial")]
        public double FondoInicial { get; set; }

        /// <summary>
        /// Cantidad final con la que quedo la caja
        /// </summary>
        [Required(ErrorMessage = "Ingrese el campo CantidadFinal")]
        public double CantidadFinal { get; set; }

        /// <summary>
        /// Diferencia entre el saldo inicial y el saldo final
        /// </summary>
        [Required(ErrorMessage = "Ingrese el campo Diferencia")]
        public double Diferencia { get; set; }

        /// <summary>
        /// Fecha del corte
        /// </summary>
        [Required(ErrorMessage = "Ingrese el campo Fecha")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [ForeignKey("Sale")]
        public int IdVenta { get; set; }
        public Sale Sale { get; set; }
    }
}
