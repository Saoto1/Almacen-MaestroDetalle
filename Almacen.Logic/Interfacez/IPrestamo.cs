using Almacen.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Logic.Interfacez
{
    public interface IPrestamo
    {
        public List<Prestamo> GetAll();

        public Prestamo GetById(int Id);

        public int Delete(int ID);

        public Prestamo Create(Prestamo prestamo);

        public Prestamo Edit (Prestamo prestamo);

        Task<List<Prestamo>> SearchAnyParameter(Prestamo prestamo);
    }
}
