using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Models.Models
{
    public class Equipo
    {

        public int Id { get; set; }

        [Required]
        public int MarcaId { get; set; }
        [Required]
        public string NombreEquipo { get; set; }
        [Required]
        public string NumeroSerie { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public bool Activo { get; set; }

        // Relación con la entidad Marca
        public Marca Marca { get; set; }

    }
}
