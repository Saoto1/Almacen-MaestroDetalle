using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Models.Models
{
    public class Prestamo
    {
        public int Id { get; set; }
        public string Persona { get; set; }
        public int MarcaId { get; set; }
        public int EquipoId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; }

        // Relación con la entidad Marca
        public Marca? Marca { get; set; }

        // Relación con la entidad Equipo
        public Equipo? Equipo { get; set; }
    }
}
