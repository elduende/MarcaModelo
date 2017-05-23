using System.Web.Mvc;
using MarcaModelo.Web.Models;
using MarcaModelo.Data;
using System.ComponentModel;

namespace MarcaModelo.Web.Controllers
{
    public class MarcasController : Controller
    {

        // GET: Marca/MarcaTraer
        public ActionResult MarcasTraer()
        {
            IMarcaRepository marca = new Marca();
            BindingList<MarcasModel> marcas = new BindingList<MarcasModel>();
            foreach (Marca m in marca.GetMarcas())
            {
                marcas.Add(new MarcasModel(marca) { IDMarca = m.IDMarca, Descripcion = m.Descripcion, Estado = m.Estado });
            }
            return View(marcas);
        }
        // GET: Marca/MarcaAgregar
        public ActionResult MarcasAgregar()
        {
            return View();
        }
        // POST: Marca/MarcaAgregar
        [HttpPost]
        public ActionResult MarcasAgregar(MarcasModel marca)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IMarcaRepository marcaRepo = new Marca();
                    marcaRepo.Descripcion = marca.Descripcion;
                    marcaRepo.Persist((Marca)marcaRepo);
                    ViewBag.Message = "Marca agregada exitosamente.";
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        // GET: Bind controls to Update details
        public ActionResult MarcasModificar(int idMarca)
        {
            IMarcaRepository marca = new Marca();
            marca = marca.GetById(idMarca);
            return View(new MarcasModel(marca) { IDMarca = marca.IDMarca, Descripcion = marca.Descripcion, Estado = marca.Estado });
        }
        // POST:Update the details into database
        [HttpPost]
        public ActionResult MarcasModificar(int idMarca, MarcasModel marca)
        {
            try
            {
                IMarcaRepository marcaRepo = new Marca();
                marcaRepo.IDMarca = idMarca;
                marcaRepo.Descripcion = marca.Descripcion;
                marcaRepo.Persist((Marca)marcaRepo);
                return RedirectToAction("MarcasTraer");
            }
            catch
            {
                return View();
            }
        }
        // GET: Delete  Employee details by id
        public ActionResult MarcasEliminar(int idMarca)
        {
            try
            {
                Marca MarcaRepo = new Marca();
                MarcaRepo.Inactivate(idMarca);
                ViewBag.AlertMsg = "Marca eliminada exitosamente.";
                return RedirectToAction("MarcasTraer");
            }
            catch
            {
                return RedirectToAction("MarcasTraer");
            }
        }
























        // GET: Marca
        public ActionResult Index()
        {
            return View();
        }

        // GET: Marca/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Marca/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Marca/Create
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

        // GET: Marca/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Marca/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Marca/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Marca/Delete/5
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
