using Almacen.Logic.Interfacez;
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

    public class Prestamo_Logic : IPrestamo
    {

        private readonly ILogger<Prestamo_Logic> _logger;
        private readonly AlmacenContext _dbcontext;

        public Prestamo_Logic(ILogger<Prestamo_Logic> logger, AlmacenContext dbcontext)
        {
            _logger = logger;
            _dbcontext = dbcontext;
        }

        public List<Prestamo> GetAll()
        {
            try
            {

                _logger.LogWarning("Inica metodo GetAll");
                var ListOfPrestamo = _dbcontext.Prestamo.ToList();

                _logger.LogWarning("Finalizo exitosamente metodo GetAll");
                return ListOfPrestamo;
            }
            catch (Exception e)
            {
                _logger.LogError($"Ocurrio en el metodo: GetAll  Clase: Marc_Logic  Mensaje:{e.Message} InnerException:{e.InnerException}");
                return new List<Prestamo>() { };
            }
        }

        public Prestamo GetById(int Id)
        {
            try
            {
                _logger.LogWarning("Inica metodo GetById");
                var Prestamo = _dbcontext.Prestamo.FirstOrDefault(s => s.Id == Id);

                _logger.LogWarning("Finalizo exitosamente metodo GetById");
                return Prestamo;
            }
            catch (Exception e)
            {
                _logger.LogError($"Ocurrio en el metodo: GetById  Clase: Prestamo_Logic  Mensaje:{e.Message} InnerException:{e.InnerException}");

                return new Prestamo() { };
            }
        }

        public int Delete(int Id)
        {
            try
            {
                _logger.LogWarning("Inica metodo GetAll");
                var pPrestamo = _dbcontext.Prestamo.FirstOrDefault(s => s.Id == Id);

                _dbcontext.Prestamo.Remove(pPrestamo);
                var result = _dbcontext.SaveChanges();

                _logger.LogWarning("Finalizo exitosamente metodo GetAll");
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError($"Ocurrio en el metodo: Delete  Clase: Prestamo_Logic  Mensaje:{e.Message} InnerException:{e.InnerException}");
                return 0;
            }
        }



        public Prestamo Create(Prestamo prestamo)
        {
            try
            {
                _logger.LogWarning("Inica metodo Create");

                _dbcontext.Prestamo.Add(prestamo);
                _dbcontext.SaveChanges();

                _logger.LogWarning("Finalizo exitosamente metodo Create");
                return prestamo;
            }
            catch (Exception e)
            {
                _logger.LogError($"Ocurrio en el metodo: Create  Clase: Prestamo_Logic  Mensaje:{e.Message} InnerException:{e.InnerException}");
                return new Prestamo() { };
            }
        }


        public Prestamo Edit(Prestamo prestamo)
        {
            try
            {
                _logger.LogWarning("Inica metodo Edit");
                var pPrestamo = _dbcontext.Prestamo.FirstOrDefault(s => s.Id == prestamo.Id);

                pPrestamo.Estado = prestamo.Estado;
                pPrestamo.Persona = prestamo.Persona;
                pPrestamo.MarcaId = prestamo.MarcaId;
                pPrestamo.EquipoId = prestamo.EquipoId;
                pPrestamo.FechaInicio = prestamo.FechaInicio;
                pPrestamo.FechaFin = prestamo.FechaFin;

                _dbcontext.Prestamo.Update(pPrestamo);
                _dbcontext.SaveChanges();

                _logger.LogWarning("Finalizo exitosamente metodo Edit");
                return pPrestamo;
            }
            catch (Exception e)
            {
                _logger.LogError($"Ocurrio en el metodo: Edit  Clase: Prestamo_Logic  Mensaje:{e.Message} InnerException:{e.InnerException}");
                return new Prestamo() { };
            }
        }

        public async Task<List<Prestamo>> SearchAnyParameter(Prestamo prestamo)
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
                return new List<Prestamo>() { };
            }
        }

        public async Task<List<Prestamo>> Search(Prestamo prestamo)
        {
            var query = _dbcontext.Prestamo.AsQueryable();


            if (prestamo.Id > 0) query = query.Where(s => s.Id == prestamo.Id);

            if (!string.IsNullOrWhiteSpace(prestamo.Persona)) query = query.Where(s => s.Persona == prestamo.Persona);

            if (!string.IsNullOrWhiteSpace(prestamo.Estado)) query = query.Where(s => s.Estado == prestamo.Estado);

            if (prestamo.FechaFin.Year > 1000) query = query.Where(s => s.FechaFin == prestamo.FechaFin);

            if (prestamo.FechaInicio.Year > 1000) query = query.Where(s => s.FechaInicio == prestamo.FechaInicio);

            return query.ToList();
        }


    }
}
