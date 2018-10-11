using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleventa.BusinessEntities
{
    public class Cut
    {
        [Key]
        public int Id { get; set; }

        public double FondoInicial { get; set; }

        public double CantidadFinal { get; set; }

        public double Diferencia { get; set; }

        public DateTime Fecha { get; set; }

        //Falta la FK 
    }
}
