using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleventa.BusinessEntities
{
    public class Employee
    {

        /// <summary>
        /// Llave primaria de la clase
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nombre del empleado
        /// </summary>
        [Required(ErrorMessage = "El nombre del empleado es obligatorio")]
        public string Nombre { get; set; }

        /// <summary>
        /// puesto que tiene el empleado
        /// </summary>
        public string Puesto { get; set; }

        /// <summary>
        /// Caja en la que esta cobrando
        /// </summary>
        public string Caja { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }

    }
}
