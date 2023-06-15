using Almacen.Logic.Interfacez;
using Almacen.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Almacen.Web.Controllers
{
    public class EquipoController : Controller
    {
        private readonly ILogger<EquipoController> _logger;
        private readonly IEquipo Equipo;
        private readonly  IMarca _marca;


        public EquipoController(IEquipo equipo, ILogger<EquipoController> logger, IMarca marca)
        {
            Equipo = equipo;
            _logger = logger;
            _marca = marca;
        }

        public async Task<ActionResult> Buscar(Equipo equipo)
        {
            try
            {
                var record = await Equipo.SearchAnyParameter(equipo);

                ViewBag.Marca = _marca.GetAll();

                return View("Index", record);

            }
            catch (Exception e)
            {
                return View("Index");
            }
        }

        // GET: EquipoController
        public ActionResult Index()
        {
            var all = Equipo.GetAll();

            ViewBag.Marca  = _marca.GetAll();

            return View(all);
        }

        // GET: EquipoController/Details/5
        public ActionResult Details(int id)
        {
            var record  =  Equipo.GetById(id);

            return View(record);
        }

        // GET: EquipoController/Create
        public ActionResult Create( )
        {
            ViewBag.Marcas = _marca.GetAll();
            return View();
        }

        // POST: EquipoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Equipo equipo)
        {
            try
            {
                var equipocreate = Equipo.Create(equipo);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                ViewBag.Marcas = _marca.GetAll();
                return View(equipo);
            }
        }

        // GET: EquipoController/Edit/5
        public ActionResult Edit(int id)
        {
            var record = Equipo.GetById(id);

            ViewBag.Marca = _marca.GetAll();

            return View(record);
        }

        // POST: EquipoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Equipo equipo)
        {
            try
            {

             var d = Equipo.Edit(equipo);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EquipoController/Delete/5
        public ActionResult Delete(int id,int test)
        {
           var record = Equipo.GetById(id);

            return View(record);
        }

        // POST: EquipoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Equipo equipo)
        {
            try
            {


                Equipo.Delete(equipo.Id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
