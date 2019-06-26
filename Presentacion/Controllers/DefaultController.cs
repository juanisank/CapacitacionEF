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
            List<Personas> lstPersonas = repositorio.ListarInclude();

            return View(lstPersonas);
        }
        [HttpPost]
        public ActionResult Index(string iptSearch)
        {
            List<Personas> lstPersonas = repositorio.Listar(iptSearch);

            return View(lstPersonas);
        }

        // GET: Default/Details/5
        public ActionResult Details(int id)
        {
            Personas objPersona = repositorio.ObtenerPersona(id);
            return View(objPersona);
        }

        // GET: Default/Create
        public ActionResult Create()
        {
            List<Ocupaciones> lstOcupaciones = repositorio.ObtenerOcupaciones();
            // Creo un objeto temporal Ocupaciones con ViewBag para poder recuperarlo desde la vista Edit.
            ViewBag.Ocupaciones = new SelectList(lstOcupaciones, "IdOcupacion", "Descripcion");

            return View();
        }

        // POST: Default/Create
        [HttpPost]
        public ActionResult Create(Personas p, FormCollection form)
        {
            try
            {
                int valorSeleccionadoCombo = Convert.ToInt32(form["dpOcupacion"].ToString());
                p.IdOcupacion = valorSeleccionadoCombo;

                repositorio.Agregar(p);

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
            Personas objPersona = repositorio.ObtenerPersona(id);
            List<Ocupaciones> lstOcupaciones = repositorio.ObtenerOcupaciones();

            // Creo un objeto temporal Ocupaciones con ViewBag para poder recuperarlo desde la vista Edit.
            ViewBag.Ocupaciones = new SelectList(lstOcupaciones, "IdOcupacion", "Descripcion");

            return View(objPersona);
        }

        // POST: Default/Edit/5
        [HttpPost]
        public ActionResult Edit(Personas p, FormCollection form)
        {
            try
            {
                // Mediante el parametro form puedo obtener puedo obtener cualquier elemento del HTML de la vista Edit
                // Obtengo el valor seleccionado del elemento DropDownList de la Vista Edit.
                int valorSeleccionadoCombo = Convert.ToInt32(form["dpOcupacion"].ToString());

                p.IdOcupacion = valorSeleccionadoCombo;
                repositorio.Actualizar(p);

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
            repositorio.Eliminar(repositorio.ObtenerPersona(id));
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
