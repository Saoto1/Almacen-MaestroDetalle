using Almacen.Models;
using Almacen.Models.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Logic.Logic
{
    public class Equipo_Logic
    {
        private readonly ILogger<Equipo_Logic> _logger;
        private readonly AlmacenContext _dbcontext;

        public Equipo_Logic (ILogger<Equipo_Logic> logger, AlmacenContext context)
        {
            _logger = logger;
            _dbcontext = context;
        }

        public List<Equipo> GetAll()
        {
            try
            {
                _logger.LogWarning("Inica metodo GetAll");
                var ListOfPrestamo = _dbcontext._Equipo.ToList();

                _logger.LogWarning("Finalizo exitosamente metodo GetAll");
                return ListOfPrestamo;
            }
            catch (Exception e)
            {
                _logger.LogError($"Ocurrio en el metodo: GetAll  Clase: Equipo_Logic  Mensaje:{e.Message} InnerException:{e.InnerException}");
                return new List<Equipo>() { };
            }
        }
    
        public Equipo GetById(int Id)
        {
            try
            {
                _logger.LogWarning("Inica metodo GetById");

                Equipo equipo = _dbcontext._Equipo.FirstOrDefault(x => x.Id == Id);

                _logger.LogWarning("Finalizo exitosamente metodo GetById");
                return equipo;
            }
            catch (Exception e)
            {
                _logger.LogError($"Ocurrio en el metodo: GetById  Clase: Equipo_Logic  Mensaje:{e.Message} InnerException:{e.InnerException}");
                return new Equipo() { };
            }
        }


        public int Delete(int Id)
        {
            try
            {
                _logger.LogWarning("Inica metodo Delete");
                var pPrestamo = _dbcontext._Equipo.FirstOrDefault(s => s.Id == Id);

                _dbcontext._Equipo.Remove(pPrestamo);
                var result = _dbcontext.SaveChanges();

                _logger.LogWarning("Finalizo exitosamente metodo Delete");
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError($"Ocurrio en el metodo: Delete  Clase: Prestamo_Logic  Mensaje:{e.Message} InnerException:{e.InnerException}");
                return 0;
            }
        }



        public Equipo Create(Equipo equipo)
        {
            try
            {
                _logger.LogWarning("Inica metodo Create");

                _dbcontext._Equipo.Add(equipo);
                _dbcontext.SaveChanges();

                _logger.LogWarning("Finalizo exitosamente metodo Create");
                return equipo;
            }
            catch (Exception e)
            {
                _logger.LogError($"Ocurrio en el metodo: Create  Clase: Prestamo_Logic  Mensaje:{e.Message} InnerException:{e.InnerException}");
                return new Equipo() { };
            }
        }


        public Equipo Edit(Equipo prestamo)
        {
            try
            {
                _logger.LogWarning("Inica metodo Edit");
                var pPrestamo = _dbcontext._Equipo.FirstOrDefault(s => s.Id == prestamo.Id);

                pPrestamo.Marca = prestamo.Marca;
                pPrestamo.NombreEquipo = prestamo.NombreEquipo;
                pPrestamo.NumeroSerie = prestamo.NumeroSerie;
                pPrestamo.Descripcion = prestamo.Descripcion;

                _dbcontext._Equipo.Update(pPrestamo);
                _dbcontext.SaveChanges();

                _logger.LogWarning("Finalizo exitosamente metodo Edit");
                return pPrestamo;
            }
            catch (Exception e)
            {
                _logger.LogError($"Ocurrio en el metodo: Edit  Clase: Prestamo_Logic  Mensaje:{e.Message} InnerException:{e.InnerException}");
                return new Equipo() { };
            }
        }



        public async Task<List<Equipo>> SearchAnyParameter(Equipo prestamo)
        {
            try
            {
                _logger.LogWarning("Inica metodo SearchAnyParameter");

                var result = await Search(prestamo);

                _logger.LogWarning("Finalizo exitosamente metodo GetAll");

                return result;
            }
            catch (Exception e)
            {
                _logger.LogError($"Ocurrio en el metodo: SearchAnyParameter  Clase: Prestamo_Logic  Mensaje:{e.Message} InnerException:{e.InnerException}");
                return new List<Equipo>() { };
            }
        }



        public async Task<List<Equipo>> Search(Equipo prestamo)
        {
            var query = _dbcontext._Equipo.AsQueryable();

            if (prestamo.Id > 0) query = query.Where(s => s.Id == prestamo.Id);

            if (prestamo.Id > 0) query = query.Where(s => s.MarcaId == prestamo.MarcaId);

            if (!string.IsNullOrWhiteSpace(prestamo.NumeroSerie)) query = query.Where(s => s.NumeroSerie == prestamo.NumeroSerie);

            if (!string.IsNullOrWhiteSpace(prestamo.NombreEquipo)) query = query.Where(s => s.NombreEquipo == prestamo.NombreEquipo);

            if (!string.IsNullOrWhiteSpace(prestamo.Descripcion)) query = query.Where(s => s.Descripcion == prestamo.Descripcion);

            return query.ToList();
        }




    }
}
