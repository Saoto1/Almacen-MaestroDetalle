using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Models.Models
{
    public class Prestamo
    {
        public int Id { get; set; }
        [Required]
        public string Persona { get; set; }
        [Required]
        public int MarcaId { get; set; }
        [Required]
        public int EquipoId { get; set; }
        [Required]
        public DateTime FechaInicio { get; set; }
        [Required]
        public DateTime FechaFin { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]

        public bool Activo { get; set; }

        // Relación con la entidad Marca
        public Marca? Marca { get; set; }

        // Relación con la entidad Equipo
        public Equipo? Equipo { get; set; }
    }
}
