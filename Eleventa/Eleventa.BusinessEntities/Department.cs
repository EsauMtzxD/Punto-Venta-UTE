using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleventa.BusinessEntities
{
    public class Department
    {
        [Key]
        [Required(ErrorMessage = "Ingrese el campo Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese el campo Nombre")]
        public String Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese el campo Descripcion")]
        public String Descripcion { get; set; }


        public virtual ICollection<Product> Products { get; set; }
    }
}
