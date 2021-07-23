using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Modulo_Matricula;

namespace Modulo_Matricula.Controllers
{
    public class ResponsableLegalsController : Controller
    {
        private bdsistemaEntities db = new bdsistemaEntities();

        // GET: ResponsableLegals
        public ActionResult Index()
        {
            var responsableLegal = db.ResponsableLegal.Include(r => r.Alumnos);
            return View(responsableLegal.ToList());
        }

        // GET: ResponsableLegals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResponsableLegal responsableLegal = db.ResponsableLegal.Find(id);
            if (responsableLegal == null)
            {
                return HttpNotFound();
            }
            return View(responsableLegal);
        }

        // GET: ResponsableLegals/Create
        public ActionResult Create()
        {
            ViewBag.IdAlumno = new SelectList(db.Alumnos, "IdAlumno", "Nombre");
            return View();
        }

        // POST: ResponsableLegals/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdResponsable,IdAlumno,Nombre,Parentesco,NumeroDeCedula,Ocupacion,LugarDeTrabajo,Telefono,CorreoElectronico,DireccionDelResponsable")] ResponsableLegal responsableLegal)
        {
            if (ModelState.IsValid)
            {
                db.ResponsableLegal.Add(responsableLegal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAlumno = new SelectList(db.Alumnos, "IdAlumno", "Nombre", responsableLegal.IdAlumno);
            return View(responsableLegal);
        }

        // GET: ResponsableLegals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResponsableLegal responsableLegal = db.ResponsableLegal.Find(id);
            if (responsableLegal == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAlumno = new SelectList(db.Alumnos, "IdAlumno", "Nombre", responsableLegal.IdAlumno);
            return View(responsableLegal);
        }

        // POST: ResponsableLegals/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdResponsable,IdAlumno,Nombre,Parentesco,NumeroDeCedula,Ocupacion,LugarDeTrabajo,Telefono,CorreoElectronico,DireccionDelResponsable")] ResponsableLegal responsableLegal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(responsableLegal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAlumno = new SelectList(db.Alumnos, "IdAlumno", "Nombre", responsableLegal.IdAlumno);
            return View(responsableLegal);
        }

        // GET: ResponsableLegals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResponsableLegal responsableLegal = db.ResponsableLegal.Find(id);
            if (responsableLegal == null)
            {
                return HttpNotFound();
            }
            return View(responsableLegal);
        }

        // POST: ResponsableLegals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResponsableLegal responsableLegal = db.ResponsableLegal.Find(id);
            db.ResponsableLegal.Remove(responsableLegal);
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
