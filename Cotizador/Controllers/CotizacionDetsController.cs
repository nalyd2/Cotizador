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
    public class CotizacionDetsController : Controller
    {
        private CotizadorConext db = new CotizadorConext();

        // GET: CotizacionDets
        public ActionResult Index()
        {
            var cotizacionDets = db.CotizacionDets.Include(c => c.Cotizacion);
            return View(cotizacionDets.ToList());
        }

        // GET: CotizacionDets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CotizacionDet cotizacionDet = db.CotizacionDets.Find(id);
            if (cotizacionDet == null)
            {
                return HttpNotFound();
            }
            return View(cotizacionDet);
        }

        // GET: CotizacionDets/Create
        public ActionResult Create()
        {
            ViewBag.IDCotizacion = new SelectList(db.Cotizacions, "IDCotizacion", "Cliente");
            return View();
        }

        // POST: CotizacionDets/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCotizacionDet,IDCotizacion,Linea,Componente,Precio,Descuento,Activo")] CotizacionDet cotizacionDet)
        {
            if (ModelState.IsValid)
            {
                db.CotizacionDets.Add(cotizacionDet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCotizacion = new SelectList(db.Cotizacions, "IDCotizacion", "Cliente", cotizacionDet.IDCotizacion);
            return View(cotizacionDet);
        }

        // GET: CotizacionDets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CotizacionDet cotizacionDet = db.CotizacionDets.Find(id);
            if (cotizacionDet == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCotizacion = new SelectList(db.Cotizacions, "IDCotizacion", "Cliente", cotizacionDet.IDCotizacion);
            return View(cotizacionDet);
        }

        // POST: CotizacionDets/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCotizacionDet,IDCotizacion,Linea,Componente,Precio,Descuento,Activo")] CotizacionDet cotizacionDet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cotizacionDet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCotizacion = new SelectList(db.Cotizacions, "IDCotizacion", "Cliente", cotizacionDet.IDCotizacion);
            return View(cotizacionDet);
        }

        // GET: CotizacionDets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CotizacionDet cotizacionDet = db.CotizacionDets.Find(id);
            if (cotizacionDet == null)
            {
                return HttpNotFound();
            }
            return View(cotizacionDet);
        }

        // POST: CotizacionDets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CotizacionDet cotizacionDet = db.CotizacionDets.Find(id);
            db.CotizacionDets.Remove(cotizacionDet);
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
