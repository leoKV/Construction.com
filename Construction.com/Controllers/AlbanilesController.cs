using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Construction.com;

namespace Construction.com.Controllers
{
    public class AlbanilesController : Controller
    {
        private BD_CONSTRUCTIONEntities db = new BD_CONSTRUCTIONEntities();

        // GET: Albaniles
        public ActionResult Index()
        {
            return View(db.Albanils.ToList());
        }

        // GET: Albaniles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Albanil albanil = db.Albanils.Find(id);
            if (albanil == null)
            {
                return HttpNotFound();
            }
            return View(albanil);
        }

        // GET: Albaniles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Albaniles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigoAl,nombreCompleto,domicilio,aniosExpe,trabajosAnteriores,contactos,recomendaciones")] Albanil albanil)
        {
            if (ModelState.IsValid)
            {
                db.Albanils.Add(albanil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(albanil);
        }

        // GET: Albaniles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Albanil albanil = db.Albanils.Find(id);
            if (albanil == null)
            {
                return HttpNotFound();
            }
            return View(albanil);
        }

        // POST: Albaniles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigoAl,nombreCompleto,domicilio,aniosExpe,trabajosAnteriores,contactos,recomendaciones")] Albanil albanil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(albanil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(albanil);
        }

        // GET: Albaniles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Albanil albanil = db.Albanils.Find(id);
            if (albanil == null)
            {
                return HttpNotFound();
            }
            return View(albanil);
        }

        // POST: Albaniles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Albanil albanil = db.Albanils.Find(id);
            db.Albanils.Remove(albanil);
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
