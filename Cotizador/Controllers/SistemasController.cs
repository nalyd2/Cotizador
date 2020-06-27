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
    public class SistemasController : Controller
    {
        private CotizadorConext db = new CotizadorConext();

        // GET: Sistemas
        public ActionResult Index()
        {
            var sistemas = db.Sistemas.Include(s => s.Modelo);
            return View(sistemas.ToList());
        }

        // GET: Sistemas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sistema sistema = db.Sistemas.Find(id);
            if (sistema == null)
            {
                return HttpNotFound();
            }
            return View(sistema);
        }

        // GET: Sistemas/Create
        public ActionResult Create()
        {
            ViewBag.IDModelo = new SelectList(db.Modelos, "IDModelo", "Codigo");
            return View();
        }

        // POST: Sistemas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDSistema,IDModelo,Codigo,Nombre,Activo,Descripcion")] Sistema sistema)
        {
            if (ModelState.IsValid)
            {
                db.Sistemas.Add(sistema);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDModelo = new SelectList(db.Modelos, "IDModelo", "Codigo", sistema.IDModelo);
            return View(sistema);
        }

        // GET: Sistemas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sistema sistema = db.Sistemas.Find(id);
            if (sistema == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDModelo = new SelectList(db.Modelos, "IDModelo", "Codigo", sistema.IDModelo);
            return View(sistema);
        }

        // POST: Sistemas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDSistema,IDModelo,Codigo,Nombre,Activo,Descripcion")] Sistema sistema)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sistema).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDModelo = new SelectList(db.Modelos, "IDModelo", "Codigo", sistema.IDModelo);
            return View(sistema);
        }

        // GET: Sistemas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sistema sistema = db.Sistemas.Find(id);
            if (sistema == null)
            {
                return HttpNotFound();
            }
            return View(sistema);
        }

        // POST: Sistemas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sistema sistema = db.Sistemas.Find(id);
            db.Sistemas.Remove(sistema);
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
