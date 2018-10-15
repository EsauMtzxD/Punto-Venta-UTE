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
        public int Id { get; set; }

        /// <summary>
        /// Nombre o Descripcion del Producto
        /// </summary>
        [Required(ErrorMessage = "Ingrese el campo Descripcion")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Codigo de Barras del producto
        /// </summary>
        [Required(ErrorMessage = "Ingrese el campo CodigoBarras")]
        [StringLength(12, ErrorMessage = "Longitud maxima de 12 Digitos en el campo")]
        public string CodigoBarras { get; set; }

        /// <summary>
        /// Departamento al que pertenece el producto
        /// </summary>
        [ForeignKey("Department")]
        [Required(ErrorMessage = "Ingrese el campo IdDepartamento")]
        public int IdDepartamento { get; set; }
        public Department Department { get; set; }

        /// <summary>
        /// Unidad de la venta, el como se vende.
        /// </summary>
        [Required(ErrorMessage = "El campo Unidad_Venta es Obligatorio")]
        [StringLength(50, ErrorMessage = "La longitud maxima es de 50 caracteres")]
        public string Unidad_Venta { get; set; }

        /// <summary>
        /// precio de la compra del producto a un provedor
        /// </summary>
        [Required(ErrorMessage = "Ingrese el campo Costo")]
        public double Costo { get; set; }

        /// <summary>
        /// Ganancia del producto
        /// </summary>
        [Required(ErrorMessage = "Ingrese el campo Ganancia")]
        public double Ganancia { get; set; }

        /// <summary>
        /// Precio del producto a como lo vendes 
        /// </summary>
        [Required(ErrorMessage = "Ingrese el campo Precio")]
        public double Precio { get; set; }

        /// <summary>
        /// Precio del producto al mayoreo
        /// </summary>
        [Required(ErrorMessage = "Ingrese el campo PrecioMayoreo")]
        public double PrecioMayoreo { get; set; }

        /// <summary>
        /// Campo para saber si el producto usa inventario o no
        /// </summary>
        [Required(ErrorMessage = "El campo Use_Inventory es obligatorio")]
        public bool Use_Inventory { get; set; }

        /// <summary>
        /// Cantidad actual del producto
        /// </summary>
        [Required(ErrorMessage = "Ingrese el campo Cantidad")]
        public int Cantidad { get; set; }

        /// <summary>
        /// Campo para saber la cantidad minima que se puede tener de este producto
        /// </summary>
        [Required(ErrorMessage = "Ingrese el campo InvMinima")]
        public int InvMinima { get; set; }

        /// <summary>
        /// Campo para saber la cantidad maxima que se puede tener de este producto
        /// </summary>
        [Required(ErrorMessage = "Ingrese el campo InvMaxima")]
        public int InvMaxima { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }

    }
}
