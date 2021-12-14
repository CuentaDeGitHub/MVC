using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelosControladores.Models;

namespace ModelosControladores.Controllers
{
    public class PublicidadsController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: Publicidads
        public ActionResult Index()
        {
            var publicidads = db.Publicidads.Include(p => p.TipoDePublicidad).Include(p => p.Usuario).Include(p => p.Usuario1);
            return View(publicidads.ToList());
        }

        // GET: Publicidads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publicidad publicidad = db.Publicidads.Find(id);
            if (publicidad == null)
            {
                return HttpNotFound();
            }
            return View(publicidad);
        }

        // GET: Publicidads/Create
        public ActionResult Create()
        {
            ViewBag.idTipoDePublicidad = new SelectList(db.TipoDePublicidads, "idTipoDePublicidad", "tipo");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: Publicidads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPublicidad,escala,costo,idTipoDePublicidad,fechaInicio,fechaTermino,idOficina,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Publicidad publicidad)
        {
            if (ModelState.IsValid)
            {
                db.Publicidads.Add(publicidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTipoDePublicidad = new SelectList(db.TipoDePublicidads, "idTipoDePublicidad", "tipo", publicidad.idTipoDePublicidad);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", publicidad.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", publicidad.idUsuarioModifica);
            return View(publicidad);
        }

        // GET: Publicidads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publicidad publicidad = db.Publicidads.Find(id);
            if (publicidad == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTipoDePublicidad = new SelectList(db.TipoDePublicidads, "idTipoDePublicidad", "tipo", publicidad.idTipoDePublicidad);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", publicidad.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", publicidad.idUsuarioModifica);
            return View(publicidad);
        }

        // POST: Publicidads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPublicidad,escala,costo,idTipoDePublicidad,fechaInicio,fechaTermino,idOficina,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Publicidad publicidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publicidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTipoDePublicidad = new SelectList(db.TipoDePublicidads, "idTipoDePublicidad", "tipo", publicidad.idTipoDePublicidad);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", publicidad.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", publicidad.idUsuarioModifica);
            return View(publicidad);
        }

        // GET: Publicidads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publicidad publicidad = db.Publicidads.Find(id);
            if (publicidad == null)
            {
                return HttpNotFound();
            }
            return View(publicidad);
        }

        // POST: Publicidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Publicidad publicidad = db.Publicidads.Find(id);
            db.Publicidads.Remove(publicidad);
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
