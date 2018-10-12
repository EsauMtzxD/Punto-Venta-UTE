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

        /// <summary>
        /// llave primaria del Departamento
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nombre del Departamento
        /// </summary>
        [Required(ErrorMessage = "Ingrese el campo Nombre")]
        public String Nombre { get; set; }

        /// <summary>
        /// Descripcion del Departamento
        /// </summary>
        [Required(ErrorMessage = "Ingrese el campo Descripcion")]
        public String Descripcion { get; set; }


        public virtual ICollection<Product> Products { get; set; }

    }
}
