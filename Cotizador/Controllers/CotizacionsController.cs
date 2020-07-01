using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cotizador.DAL;
using Cotizador.Models;

namespace Cotizador.Controllers
{
    public class CotizacionsController : Controller
    {
        private CotizadorConext db = new CotizadorConext();

        // GET: Cotizacions
        public ActionResult Index()
        {
            var cotizacions = db.Cotizacions.Include(c => c.Producto);
            return View(cotizacions.ToList());
        }

        public ActionResult IndexDetalle(int? id)
        {
            var cotizacionDets = db.CotizacionDets.Where(cd => cd.IDCotizacionDet == id);
            return View("~/Views/CotizacionDets/Index.cshtml", cotizacionDets.ToList());
        }
        public ActionResult CreateDetalle()
        {
            ViewBag.IDCotizacion = new SelectList(db.Cotizacions, "IDCotizacion", "Cliente");
            return View("~/Views/CotizacionDets/Create.cshtml");
        }

        // GET: Cotizacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotizacion cotizacion = db.Cotizacions.Find(id);
            if (cotizacion == null)
            {
                return HttpNotFound();
            }
            return View(cotizacion);
        }

        // GET: Cotizacions/Create
        public ActionResult Create()
        {
            ViewBag.IDProducto = new SelectList(db.Productos, "IDProducto", "Codigo");
            return View();
        }

        // POST: Cotizacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCotizacion,Numero,Cliente,Direccion,CodigoPostal,IDProducto,Precio,Descuento,Creada,Modificada,Vigencia,Activo")] Cotizacion cotizacion)
        {
            if (ModelState.IsValid)
            {
                db.Cotizacions.Add(cotizacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDProducto = new SelectList(db.Productos, "IDProducto", "Codigo", cotizacion.IDProducto);
            return View(cotizacion);
        }
       
        // GET: Cotizacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotizacion cotizacion = db.Cotizacions.Find(id);
            if (cotizacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDProducto = new SelectList(db.Productos, "IDProducto", "Codigo", cotizacion.IDProducto);
            return View(cotizacion);
        }

        // POST: Cotizacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCotizacion,Numero,Cliente,Direccion,CodigoPostal,IDProducto,Precio,Descuento,Creada,Modificada,Vigencia,Activo")] Cotizacion cotizacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cotizacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDProducto = new SelectList(db.Productos, "IDProducto", "Codigo", cotizacion.IDProducto);
            return View(cotizacion);
        }

        // GET: Cotizacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotizacion cotizacion = db.Cotizacions.Find(id);
            if (cotizacion == null)
            {
                return HttpNotFound();
            }
            return View(cotizacion);
        }

        // POST: Cotizacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cotizacion cotizacion = db.Cotizacions.Find(id);
            db.Cotizacions.Remove(cotizacion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
