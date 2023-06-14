using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Models.Models
{
    public class Equipo
    {

        public int Id { get; set; }
        public int MarcaId { get; set; }
        public string NombreEquipo { get; set; }
        public string NumeroSerie { get; set; }
        public string Descripcion { get; set; }

        // Relación con la entidad Marca
        public Marca Marca { get; set; }

    }
}
