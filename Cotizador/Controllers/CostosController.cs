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
    public class CostosController : Controller
    {
        private CotizadorConext db = new CotizadorConext();

        // GET: Costos
        public ActionResult Index()
        {
            var costos = db.Costos.Include(c => c.Componente).Include(c => c.Producto);
            return View(costos.ToList());
        }

        // GET: Costos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Costos costos = db.Costos.Find(id);
            if (costos == null)
            {
                return HttpNotFound();
            }
            return View(costos);
        }

        // GET: Costos/Create
        public ActionResult Create()
        {
            ViewBag.IDComponente = new SelectList(db.Componentes, "IDComponente", "Codigo");
            ViewBag.IDProducto = new SelectList(db.Productos, "IDProducto", "Codigo");
            return View();
        }

        // POST: Costos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCosto,TipoCosto,IDProducto,IDComponente,Costo,InicioVigencia,FinVigencia,Activo")] Costos costos)
        {
            if (ModelState.IsValid)
            {
                db.Costos.Add(costos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDComponente = new SelectList(db.Componentes, "IDComponente", "Codigo", costos.IDComponente);
            ViewBag.IDProducto = new SelectList(db.Productos, "IDProducto", "Codigo", costos.IDProducto);
            return View(costos);
        }

        // GET: Costos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Costos costos = db.Costos.Find(id);
            if (costos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDComponente = new SelectList(db.Componentes, "IDComponente", "Codigo", costos.IDComponente);
            ViewBag.IDProducto = new SelectList(db.Productos, "IDProducto", "Codigo", costos.IDProducto);
            return View(costos);
        }

        // POST: Costos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCosto,TipoCosto,IDProducto,IDComponente,Costo,InicioVigencia,FinVigencia,Activo")] Costos costos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(costos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDComponente = new SelectList(db.Componentes, "IDComponente", "Codigo", costos.IDComponente);
            ViewBag.IDProducto = new SelectList(db.Productos, "IDProducto", "Codigo", costos.IDProducto);
            return View(costos);
        }

        // GET: Costos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Costos costos = db.Costos.Find(id);
            if (costos == null)
            {
                return HttpNotFound();
            }
            return View(costos);
        }

        // POST: Costos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Costos costos = db.Costos.Find(id);
            db.Costos.Remove(costos);
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
