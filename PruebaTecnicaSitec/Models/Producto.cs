using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace PruebaTecnicaSitec.Models
{
    public class Producto
    {
        /// <summary>
        /// Identificador del Producto
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nombre del Producto
        /// </summary>
        /// <example>Manzana</example>
        [Required]
        public string Nombre{ get; set;}
        /// <summary>
        /// Costo del Producto
        /// </summary>
        /// <example>2</example>
        [Required]
        public float Costo { get; set;}

    }
}
