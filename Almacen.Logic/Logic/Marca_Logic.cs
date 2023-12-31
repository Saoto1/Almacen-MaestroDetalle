﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Almacen.Logic.Interfacez;
using Almacen.Models;
using Almacen.Models.Models;
using Microsoft.Extensions.Logging;

namespace Almacen.Logic.Logic
{
    public class Marca_Logic : IMarca
    {
        private readonly ILogger<Prestamo_Logic> _logger;
        private readonly AlmacenContext _dbcontext;

        public Marca_Logic(ILogger<Prestamo_Logic> logger, AlmacenContext dbcontext)
        {
            _logger = logger;
            _dbcontext = dbcontext;
        }

        public List<Marca> GetAll()
        {
            try
            {
                _logger.LogWarning("Inica metodo GetAll");
                var ListOfMarca = _dbcontext.Marca.ToList();

                _logger.LogWarning("Finalizo exitosamente metodo GetAll");
                return ListOfMarca;
            }
            catch (Exception e)
            {
                _logger.LogError($"Ocurrio en el metodo: GetAll  Clase: Marca_Logic  Mensaje:{e.Message} InnerException:{e.InnerException}");
                return new List<Marca>() { };
            }
        }

        public Marca GetById(int Id)
        {
            try
            {
                _logger.LogWarning("Inica metodo GetById");
                var Prestamo = _dbcontext.Marca.FirstOrDefault(s => s.Id == Id);

                _logger.LogWarning("Finalizo exitosamente metodo GetById");
                return Prestamo;
            }
            catch (Exception e)
            {
                _logger.LogError($"Ocurrio en el metodo: GetById  Clase: Marca_Logic  Mensaje:{e.Message} InnerException:{e.InnerException}");

                return new Marca() { };
            }
        }

        public int Delete(int Id)
        {
            try
            {
                _logger.LogWarning("Inica metodo GetAll");
                var pMarca = _dbcontext.Marca.FirstOrDefault(s => s.Id == Id);

                _dbcontext.Marca.Remove(pMarca);
                var result = _dbcontext.SaveChanges();

                _logger.LogWarning("Finalizo exitosamente metodo GetAll");
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError($"Ocurrio en el metodo: Delete  Clase: Marca_Logic  Mensaje:{e.Message} InnerException:{e.InnerException}");
                return 0;
            }
        }


        public Marca Create(Marca marca)
        {
            try
            {
                _logger.LogWarning("Inica metodo Create");

                _dbcontext.Marca.Add(marca);
                _dbcontext.SaveChanges();

                _logger.LogWarning("Finalizo exitosamente metodo Create");
                return marca;
            }
            catch (Exception e)
            {
                _logger.LogError($"Ocurrio en el metodo: Create  Clase: Marca_Logic  Mensaje:{e.Message} InnerException:{e.InnerException}");
                return new Marca() { };
            }
        }



        public Marca Edit(Marca marca)
        {
            try
            {
                _logger.LogWarning("Inica metodo Edit");
                var pMarca = _dbcontext.Marca.FirstOrDefault(s => s.Id == marca.Id);

                pMarca.Nombre = marca.Nombre;
                pMarca.Descripcion = marca.Descripcion;
                pMarca.TipoHerramienta = marca.TipoHerramienta;
                pMarca.Exactitud = marca.Exactitud;

                _dbcontext.Marca.Update(pMarca);
                _dbcontext.SaveChanges();

                _logger.LogWarning("Finalizo exitosamente metodo Edit");
                return pMarca;
            }
            catch (Exception e)
            {
                _logger.LogError($"Ocurrio en el metodo: Edit  Clase: Marca_Logic  Mensaje:{e.Message} InnerException:{e.InnerException}");

                return new Marca() { };
            }
        }


        public async Task<List<Marca>> SearchAnyParameter(Marca marca)
        {
            try
            {
                _logger.LogWarning("Inica metodo SearchAnyParameter");

                var result = await Search(marca);

                _logger.LogWarning("Finalizo exitosamente metodo GetAll");

                return result;
            }
            catch (Exception e)
            {
                _logger.LogError($"Ocurrio en el metodo: SearchAnyParameter  Clase: Marca_Logic  Mensaje:{e.Message} InnerException:{e.InnerException}");
                return new List<Marca>() { };
            }
        }


        public async Task<List<Marca>> Search(Marca marca)
        {
            var query = _dbcontext.Marca.AsQueryable();


            if (marca.Id > 0) query = query.Where(s => s.Id == marca.Id);

            if (!string.IsNullOrWhiteSpace(marca.Nombre)) query = query.Where(s => s.Nombre == marca.Nombre);

            if (!string.IsNullOrWhiteSpace(marca.Descripcion)) query = query.Where(s => s.Descripcion == marca.Descripcion);

            if (!string.IsNullOrWhiteSpace(marca.TipoHerramienta)) query = query.Where(s => s.TipoHerramienta == marca.TipoHerramienta);

            if (marca.Exactitud > 0) query = query.Where(s => s.Exactitud == marca.Exactitud);

            return query.ToList();
        }
    }
}
