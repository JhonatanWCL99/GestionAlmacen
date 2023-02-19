using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace PruebaTecnicaSitec.Models
{
    public class DetalleVenta
    {
        /// <summary>
        /// Identificador del Detalle de Venta
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Cantidad del producto a Vender
        /// </summary>
        [Required]
        public float cantidad { get; set; }
        /// <summary>
        /// Precio del Producto
        /// </summary>
        [Required]
        public float precio { get; set; }
        /// <summary>
        /// Subtotal en Bs
        /// </summary>
        public float subtotal { get; set; }
        /// <summary>
        /// Identificador del Producto
        /// </summary>
        [Required]
        [ForeignKey("FK_Producto")]
        public int ProductoId { get; set; }
        /// <summary>
        /// Identificador de la Venta al que pertenece
        /// </summary>
        [ForeignKey("FK_Venta")]
        public int VentaId { get; set; }
    }
}
