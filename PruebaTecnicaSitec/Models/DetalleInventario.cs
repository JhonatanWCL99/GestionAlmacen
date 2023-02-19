using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace PruebaTecnicaSitec.Models
{
    public class DetalleInventario
    {
        /// <summary>
        /// Identificador del Detalle de Inventario
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Stock del Producto
        /// </summary>
        [Required]
        public float cantidad { get; set; }
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
        /// Identificador del Inventario al que pertenece
        /// </summary>
        [ForeignKey("FK_Inventario")]
        public int InventarioId { get; set; }

    }
}
