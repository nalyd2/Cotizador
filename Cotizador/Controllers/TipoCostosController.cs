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
    public class TipoCostosController : Controller
    {
        private CotizadorConext db = new CotizadorConext();

        // GET: TipoCostos
        public ActionResult Index()
        {
            return View(db.TipoCostos.ToList());
        }

        // GET: TipoCostos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCosto tipoCosto = db.TipoCostos.Find(id);
            if (tipoCosto == null)
            {
                return HttpNotFound();
            }
            return View(tipoCosto);
        }

        // GET: TipoCostos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoCostos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDTipoCosto,Codigo,Nombre,Activo,Descripcion")] TipoCosto tipoCosto)
        {
            if (ModelState.IsValid)
            {
                db.TipoCostos.Add(tipoCosto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoCosto);
        }

        // GET: TipoCostos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCosto tipoCosto = db.TipoCostos.Find(id);
            if (tipoCosto == null)
            {
                return HttpNotFound();
            }
            return View(tipoCosto);
        }

        // POST: TipoCostos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDTipoCosto,Codigo,Nombre,Activo,Descripcion")] TipoCosto tipoCosto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoCosto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoCosto);
        }

        // GET: TipoCostos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCosto tipoCosto = db.TipoCostos.Find(id);
            if (tipoCosto == null)
            {
                return HttpNotFound();
            }
            return View(tipoCosto);
        }

        // POST: TipoCostos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoCosto tipoCosto = db.TipoCostos.Find(id);
            db.TipoCostos.Remove(tipoCosto);
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
