﻿using Almacen.Logic.Interfacez;
using Almacen.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Almacen.Web.Controllers
{
    public class MarcaController : Controller
    {
        private readonly IMarca _Marca;

        public MarcaController(IMarca marca )
        {
            _Marca = marca;
        }

        // GET: MarcaController
        // GET: EquipoController
        public ActionResult Index()
        {
            var all = _Marca.GetAll();

            return View(all);
        }

        // GET: EquipoController/Details/5
        public ActionResult Details(int id)
        {
            var record = _Marca.GetById(id);

            return View(record);
        }

        // GET: EquipoController/Create
        public ActionResult Create()
        {
            ViewBag.Marcas = _Marca.GetAll();
            return View();
        }

        // POST: EquipoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Marca equipo)
        {
            try
            {
                var equipocreate = _Marca.Create(equipo);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.Marcas = _Marca.GetAll();
                return View(equipo);
            }
        }

        // GET: EquipoController/Edit/5
        public ActionResult Edit(int id)
        {
            var record = _Marca.GetById(id);

            return View(record);
        }

        // POST: EquipoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Marca equipo)
        {
            try
            {

                var d = _Marca.Edit(equipo);

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
            var record = _Marca.GetById(id);

            return View(record);
        }

        // POST: EquipoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Marca equipo)
        {
            try
            {


                _Marca.Delete(equipo.Id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



    }
}
