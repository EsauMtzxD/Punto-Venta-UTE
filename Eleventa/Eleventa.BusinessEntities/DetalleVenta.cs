using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleventa.BusinessEntities
{
    public class DetalleVenta
    {

        /// <summary>
        /// Llave primaria de la table
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Id de la table venta
        /// </summary>
        [ForeignKey("Sale")]
        public int IdVenta { get; set; }
        public Sale Sale { get; set; }

        /// <summary>
        /// Id del Producto que se compro
        /// </summary>
        [ForeignKey("Product")]
        public int IdProducto { get; set; }
        public Product Product { get; set; }

        /// <summary>
        /// Cantidad que se compro
        /// </summary>
        public int Cantidad { get; set; }

        /// <summary>
        /// Importe del arituclo segun la cantidad comprada
        /// </summary>
        public double Importe { get; set; }

    }
}
