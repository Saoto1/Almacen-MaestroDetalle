using Almacen.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Models
{
    public class AlmacenContext: DbContext
    {
        private readonly IConfiguration _configuration;
        
        public AlmacenContext (IConfiguration config)
        {
            _configuration = config;
        }

        public DbSet<Equipo> _Equipo { get; set; }
        public DbSet<Marca> _Marca { get; set; }
        public DbSet<Prestamo> _Prestamo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string ConnectionString = _configuration.GetConnectionString("MiConexionBD");

            optionsBuilder.UseSqlServer(ConnectionString);
        }


    }
}
