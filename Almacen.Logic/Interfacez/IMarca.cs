using Almacen.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Logic.Interfacez
{
    public interface IMarca
    {

        public List<Marca>    GetAll();

        public Marca GetById(int Id);

        public int Delete(int ID);

        public Marca Create(Marca prestamo);

        public Marca Edit(Marca prestamo);

         Task<List<Marca>> SearchAnyParameter(Marca marca);

    }
}
