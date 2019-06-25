using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Controllers
{
    public class DefaultController : Controller
    {
        RepositorioPersonas repositorio = new RepositorioPersonas();

        // GET: Default
        public ActionResult Index()
        {
            return View(repositorio.ListarInclude());
        }

        // GET: Default/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Default/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Default/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //Diferentes formas de llenar un dropdowslist en MVC5: https://www.c-sharpcorner.com/article/different-ways-bind-the-value-to-razor-dropdownlist-in-aspnet-mvc5/
        // GET: Default/Edit/5
        public ActionResult Edit(int id)
        {
            // Creo un objeto temporal Ocupaciones con ViewBag para poder recuperarlo desde la vista Edit.
            ViewBag.Ocupaciones = new SelectList(repositorio.ObtenerOcupaciones(), "IdOcupacion", "Descripcion");

            return View(repositorio.ObtenerPersona(id));
        }

        // POST: Default/Edit/5
        [HttpPost]
        public ActionResult Edit(Personas p, FormCollection form)
        {
            try
            {
                // Mediante el parametro form puedo obtener puedo obtener cualquier elemento del HTML de la vista Edit
                // Obtengo el valor seleccionado del elemento DropDownList de la Vista Edit.
                string valorSeleccionadoCombo = form["dpOcupacion"].ToString();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Default/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Default/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
