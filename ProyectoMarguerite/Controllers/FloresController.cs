using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoMarguerite.Services;
using ProyectoMarguerite.Models;
using ProyectoMarguerite.Models.ViewModels;

namespace ProyectoMarguerite.Controllers
{
    public class FloresController : Controller
    {
        // GET: FloresController
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        // GET: FloresController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FloresController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FloresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FloresViewModel flores)
        {
            if (ModelState.IsValid)
            {
                Services.Flores ServicioFlores = new Services.Flores();

                Models.Flores floresmodels = new Models.Flores();
                floresmodels.Nombre = flores.Nombre;
                floresmodels.Precio = flores.Precio;
                floresmodels.Id_especie = flores.Id_especie;
                floresmodels.Id_color = flores.Id_color;

                ServicioFlores.CargaUnaFlor(flores);

                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        // GET: FloresController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FloresController/Edit/5
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

        // GET: FloresController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FloresController/Delete/5
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
