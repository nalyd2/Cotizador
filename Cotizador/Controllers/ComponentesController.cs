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
    public class ComponentesController : Controller
    {
        private CotizadorConext db = new CotizadorConext();

        // GET: Componentes
        public ActionResult Index()
        {
            var componentes = db.Componentes.Include(c => c.Sistema);
            return View(componentes.ToList());
        }

        // GET: Componentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Componente componente = db.Componentes.Find(id);
            if (componente == null)
            {
                return HttpNotFound();
            }
            return View(componente);
        }

        // GET: Componentes/Create
        public ActionResult Create()
        {
            ViewBag.IDSistema = new SelectList(db.Sistemas, "IDSistema", "Codigo");
            return View();
        }

        // POST: Componentes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDComponente,IDSistema,Codigo,Nombre,Activo,Descripcion")] Componente componente)
        {
            if (ModelState.IsValid)
            {
                db.Componentes.Add(componente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDSistema = new SelectList(db.Sistemas, "IDSistema", "Codigo", componente.IDSistema);
            return View(componente);
        }

        // GET: Componentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Componente componente = db.Componentes.Find(id);
            if (componente == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDSistema = new SelectList(db.Sistemas, "IDSistema", "Codigo", componente.IDSistema);
            return View(componente);
        }

        // POST: Componentes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDComponente,IDSistema,Codigo,Nombre,Activo,Descripcion")] Componente componente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(componente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDSistema = new SelectList(db.Sistemas, "IDSistema", "Codigo", componente.IDSistema);
            return View(componente);
        }

        // GET: Componentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Componente componente = db.Componentes.Find(id);
            if (componente == null)
            {
                return HttpNotFound();
            }
            return View(componente);
        }

        // POST: Componentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Componente componente = db.Componentes.Find(id);
            db.Componentes.Remove(componente);
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
