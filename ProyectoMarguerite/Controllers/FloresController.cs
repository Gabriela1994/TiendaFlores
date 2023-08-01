using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoMarguerite.Services;
using ProyectoMarguerite.Models;
using ProyectoMarguerite.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

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

            Services.Flores servicioFlores = new Services.Flores();
            Models.Flores floresModel = servicioFlores.RecuperarFlor(id);

            FloresViewModel floresViewModel = new FloresViewModel();
            floresViewModel.Id = id;
            floresViewModel.Id_especie = floresModel.Id_especie;
            floresViewModel.Id_color = floresModel.Id_color;
            floresViewModel.Precio = floresModel.Precio;
            floresViewModel.Descripcion = floresModel.Descripcion;

            return View(floresViewModel);
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
                floresmodels.Descripcion = flores.Descripcion;
                floresmodels.Precio = flores.Precio;
                floresmodels.Id_especie = flores.Id_especie;
                floresmodels.Id_color = flores.Id_color;

                ServicioFlores.CargaUnaFlor(flores);

                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index", "Home");

            }
            else
                return View();
        }

        // GET: FloresController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FloresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FloresViewModel flores)
        {
            try
            {
                Services.Flores servicioFlores = new Services.Flores();
                Models.Flores floresModel = new Models.Flores();

                floresModel.Id = id;
                floresModel.Descripcion = flores.Descripcion;
                floresModel.Precio = flores.Precio;

                servicioFlores.EditarUnaFlor(floresModel);

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
        public ActionResult Delete(int id, FloresViewModel flores)
        {
            try
            {
                Services.Flores servicioFlores = new Services.Flores();
                Models.Flores floresModel = new Models.Flores();
                servicioFlores.RecuperarFlor(id);

                floresModel.Id = id;

                servicioFlores.EliminarFlor(id);

                return RedirectToAction(nameof(ListaFlores));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ListaFlores()
        {
            Services.Flores serviceFlores = new Services.Flores();
            List<Models.Flores> flor = serviceFlores.ListaFlores2();

            List<FloresViewModel> listaFlores = new List<FloresViewModel>();

            foreach (Models.Flores f in flor)
            {
                listaFlores.Add(new FloresViewModel()
                {
                    Id = f.Id,
                    Especie = f.Especie,
                    Color = f.Color,
                    Precio = f.Precio,
                    Descripcion = f.Descripcion
                });
            }
            return View(listaFlores);
        }
    }
}
