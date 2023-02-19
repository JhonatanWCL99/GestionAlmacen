using Microsoft.Build.Framework;
using System.Text.Json.Serialization;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace PruebaTecnicaSitec.Models
{
    public class Inventario
    {
        /// <summary>
        /// Identificador del Inventario
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Fecha de Registro de Inventario
        /// </summary>
        [Required]
        public DateTime fecha { get; set; }
        /// <summary>
        /// Total del Inventario en Bs
        /// </summary>
        public float total { get; set; }
        /// <summary>
        /// Detalle del Inventario
        /// </summary>
        /// <example>[
        /// { 
        /// "cantidad":2,
        /// "ProductoId":1 
        /// }
        /// ]</example>
        [Required]
        public IList<DetalleInventario> detallesInventario { get; set; } = new List<DetalleInventario>();
    }
}
