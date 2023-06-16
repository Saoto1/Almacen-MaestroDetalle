using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Models.Models
{
    public class Marca
    {
      
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public int? TipoHerramientaId { get; set; }
        [Required]
        public decimal Exactitud { get; set; }
        [Required]
        public bool Activo { get; set; }
    }
}
