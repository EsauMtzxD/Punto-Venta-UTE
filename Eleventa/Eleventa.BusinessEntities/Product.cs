using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleventa.BusinessEntities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public String Descripcion { get; set; }

        public int Cantidad { get; set; }

        public String CodigoBarras { get; set; }

        public double Precio { get; set; }

        public double PrecioMayoreo { get; set; }

        public double Costo { get; set; }

        public double Ganancia { get; set; }

        public int InvMinima { get; set; }

        public int InvMaxima { get; set; }

        //Falta la FK

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
