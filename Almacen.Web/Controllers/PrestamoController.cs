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

        public PrestamoController(IPrestamo prestamo, ILogger<PrestamoController> logger)
        {
            _prestamo = prestamo;
            _logger = logger;
        }

        // GET: PrestamoController
        public ActionResult Index()
        {
            var all = _prestamo.GetAll();
            return View(all);
        }

        // GET: PrestamoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PrestamoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PrestamoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PrestamoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PrestamoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PrestamoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PrestamoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
