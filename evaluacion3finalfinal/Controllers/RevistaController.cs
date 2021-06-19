using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using evaluacion3finalfinal;

namespace evaluacion3finalfinal.Controllers
{
    public class RevistaController : Controller
    {
        private EmpresaEntities db = new EmpresaEntities();

        // GET: Revista
        public ActionResult Index()
        {
            return View(db.Revistas.ToList());
        }

        // GET: Revista/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revista revista = db.Revistas.Find(id);
            if (revista == null)
            {
                return HttpNotFound();
            }
            return View(revista);
        }

        // GET: Revista/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Revista/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Volumen,Titulo,Precio,Cantidad,Descripcion")] Revista revista)
        {
            if (ModelState.IsValid)
            {
                db.Revistas.Add(revista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(revista);
        }

        // GET: Revista/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revista revista = db.Revistas.Find(id);
            if (revista == null)
            {
                return HttpNotFound();
            }
            return View(revista);
        }

        // POST: Revista/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Volumen,Titulo,Precio,Cantidad,Descripcion")] Revista revista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(revista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(revista);
        }

        // GET: Revista/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revista revista = db.Revistas.Find(id);
            if (revista == null)
            {
                return HttpNotFound();
            }
            return View(revista);
        }

        // POST: Revista/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Revista revista = db.Revistas.Find(id);
            db.Revistas.Remove(revista);
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
