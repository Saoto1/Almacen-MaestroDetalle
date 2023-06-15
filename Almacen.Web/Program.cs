using Almacen.Logic.Interfacez;
using Almacen.Logic.Logic;
using Almacen.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Configuration;


var config = new ConfigurationBuilder()
  .AddJsonFile("appsettings.json", optional: false)
  .Build();

var DBConnection = config.GetConnectionString("MiConexionBD");




var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddTransient<IEquipo, Equipo_Logic>();
builder.Services.AddTransient<IPrestamo, Prestamo_Logic>();
builder.Services.AddTransient<IMarca, Marca_Logic>();

builder.Services.AddDbContextFactory<AlmacenContext>(options => options.UseSqlServer(DBConnection));

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Equipo}/{action=Index}");

app.Run();
