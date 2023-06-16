using Almacen.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Logic.Interfacez
{
    public interface IEquipo
    {
        public List<Equipo> GetAll();

       

        public Equipo GetById(int Id);

        public int Delete(int ID);

        public Equipo Create(Equipo equipo);

        public Equipo Edit(Equipo pEquipo);

        public Task<List<Equipo>> SearchAnyParameter(Equipo prestamo);

    }
}
