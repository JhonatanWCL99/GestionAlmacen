using Microsoft.Build.Framework;
using System.Text.Json.Serialization;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;
namespace PruebaTecnicaSitec.Models
{
    public class Venta
    {
        /// <summary>
        /// Identificador de la Venta
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Fecha de Registro de Venta
        /// </summary>
        [Required]
        public DateTime fecha { get; set; }
        /// <summary>
        /// Total Vendido en Bs
        /// </summary>
        public float total { get; set; }
        [Required]
        public IList<DetalleVenta> detallesVenta{ get; set; } = new List<DetalleVenta>();
    }
}
