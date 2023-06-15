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
    public class AlmacenContext : DbContext
    {
        //private readonly IConfiguration _configuration;

        //public AlmacenContext (IConfiguration config)
        //{
        //    _configuration = config;
        //}

        public DbSet<Equipo> Equipo { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Prestamo> Prestamo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var config = new ConfigurationBuilder()
          .AddJsonFile("appsettings.json", optional: false)
          .Build();

            var DBConnection = config.GetConnectionString("MiConexionBD");


            optionsBuilder.UseSqlServer(DBConnection);
        }


    }
}
