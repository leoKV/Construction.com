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
    public class ArquitectosController : Controller
    {
        private BD_CONSTRUCTIONEntities db = new BD_CONSTRUCTIONEntities();

        // GET: Arquitectos
        public ActionResult Index()
        {
            return View(db.Arquitectoes.ToList());
        }

        // GET: Arquitectos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arquitecto arquitecto = db.Arquitectoes.Find(id);
            if (arquitecto == null)
            {
                return HttpNotFound();
            }
            return View(arquitecto);
        }

        // GET: Arquitectos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Arquitectos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigoAr,nombreCompleto,domicilio,aniosExpe,contactos,recomendaciones")] Arquitecto arquitecto)
        {
            if (ModelState.IsValid)
            {
                db.Arquitectoes.Add(arquitecto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(arquitecto);
        }

        // GET: Arquitectos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arquitecto arquitecto = db.Arquitectoes.Find(id);
            if (arquitecto == null)
            {
                return HttpNotFound();
            }
            return View(arquitecto);
        }

        // POST: Arquitectos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigoAr,nombreCompleto,domicilio,aniosExpe,contactos,recomendaciones")] Arquitecto arquitecto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arquitecto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(arquitecto);
        }

        // GET: Arquitectos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arquitecto arquitecto = db.Arquitectoes.Find(id);
            if (arquitecto == null)
            {
                return HttpNotFound();
            }
            return View(arquitecto);
        }

        // POST: Arquitectos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Arquitecto arquitecto = db.Arquitectoes.Find(id);
            db.Arquitectoes.Remove(arquitecto);
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
