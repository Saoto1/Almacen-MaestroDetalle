using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Almacen.Logic.Interfacez;
using Almacen.Models.Models;

namespace Almacen.Web.Controllers
{
    public class PrestamoController : Controller
    {
        private readonly ILogger<PrestamoController> _logger;
        private readonly IPrestamo _prestamo;
        private readonly IEquipo _Equipo;
        private readonly IMarca _marca;

        public PrestamoController(IPrestamo prestamo, ILogger<PrestamoController> logger,IEquipo equipo,IMarca marca)
        {
            _prestamo = prestamo;
            _logger = logger;
            _Equipo = equipo;
            _marca = marca; 
        }



        public async Task<ActionResult> Buscar(Prestamo prestamo)
        {
            try
            {
                var record = await _prestamo.SearchAnyParameter(prestamo);
                return View("Index", record);

            }
            catch (Exception e)
            {
                return View("Index");
            }
        }

        public ActionResult Index()
        {
            var all = _prestamo.GetAll();

            return View(all);
        }

        // GET: EquipoController/Details/5
        public ActionResult Details(int id)
        {
            var record = _prestamo.GetById(id);

            return View(record);
        }

        // GET: EquipoController/Create
        public ActionResult Create()
        {
            ViewBag.Marcas = _marca.GetAll();
            ViewBag.Equipo = _Equipo.GetAll();
            return View();
        }

        // POST: EquipoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Prestamo equipo)
        {
            try
            {
                var equipocreate = _prestamo.Create(equipo);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.Marcas = _marca.GetAll();
                return View(equipo);
            }
        }

        // GET: EquipoController/Edit/5
        public ActionResult Edit(int id)
        {
            var record = _prestamo.GetById(id);

            return View(record);
        }

        // POST: EquipoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Prestamo equipo)
        {
            try
            {

                var d = _prestamo.Edit(equipo);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EquipoController/Delete/5
        public ActionResult Delete(int id, int test)
        {
            var record = _prestamo.GetById(id);

            return View(record);
        }

        // POST: EquipoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Equipo equipo)
        {
            try
            {


                _prestamo.Delete(equipo.Id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
