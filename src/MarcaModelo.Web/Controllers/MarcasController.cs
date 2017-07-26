using System.Web.Mvc;
using MarcaModelo.Web.Models;
using MarcaModelo.Data;
using System.ComponentModel;

namespace MarcaModelo.Web.Controllers
{
    public class MarcasController : Controller
    {
        // GET: Marca/Index
        public ActionResult Index(string pActivas = "A")
        {
            ViewData["Activas"] = pActivas;
            IMarcaRepository marca = new Marca();
            BindingList<MarcasModel> marcas = new BindingList<MarcasModel>();
            foreach (Marca m in pActivas == "A" ? marca.GetMarcas() : marca.GetMarcasInactivas())
            {
                marcas.Add(new MarcasModel(marca) { IdMarca = m.IdMarca, Descripcion = m.Descripcion, Estado = m.Estado });
            }
            return View(marcas);
        }
        
        // GET: Marca/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Marca/Create
        [HttpPost]
        public ActionResult Create(MarcasModel marca)
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
                //return RedirectToAction("Index");
                return RedirectToAction("Index", new { pActivas = "A" });
            }
            catch
            {
                return View();
            }
        }

        // GET: Marca/Edit/5
        public ActionResult Edit(int idMarca)
        {
            IMarcaRepository marca = new Marca();
            marca = marca.GetById(idMarca);
            return View(new MarcasModel(marca) { IdMarca = marca.IdMarca, Descripcion = marca.Descripcion, Estado = marca.Estado });
        }

        // POST: Marca/Edit/5
        [HttpPost]
        public ActionResult Edit(int idMarca, MarcasModel marca)
        {
            try
            {
                IMarcaRepository marcaRepo = new Marca();
                marcaRepo.IdMarca = idMarca;
                marcaRepo.Descripcion = marca.Descripcion;
                marcaRepo.Persist((Marca)marcaRepo);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        // GET: Marca/Delete/5
        public ActionResult Delete(int IdMarca)
        {
            try
            {
                Marca marcaRepo = new Marca();
                marcaRepo.Inactivate(IdMarca);
                ViewBag.AlertMsg = "Marca desactivada exitosamente.";
                return RedirectToAction("Index", new { pActivas = "A" });
            }
            catch
            {
                return Index("A");
            }
        }
        
        // GET: Marca/Reactivar/5
        public ActionResult Reactivar(int IdMarca)
        {
            try
            {
                Marca marcaRepo = new Marca();
                marcaRepo.Activate(IdMarca);
                ViewBag.AlertMsg = "Marca reactivada exitosamente.";
                return RedirectToAction("Index", new { pActivas = "B" });
            }
            catch
            {
                return Index("B");
            }
        }
        
        // GET: Marca/Details/5
        public ActionResult Details(int idMarca)
        {
            IMarcaRepository marca = new Marca();
            marca = marca.GetById(idMarca);
            return View(new MarcasModel(marca) { IdMarca = marca.IdMarca, Descripcion = marca.Descripcion, Estado = marca.Estado });
        }

        public ActionResult Excel()
        {
            return Index();
        }

        public ActionResult Imprimir()
        {
            return Index();
        }
    }
}
