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
    public class TipoDePublicidadsController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: TipoDePublicidads
        public ActionResult Index()
        {
            var tipoDePublicidads = db.TipoDePublicidads.Include(t => t.Usuario).Include(t => t.Usuario1);
            return View(tipoDePublicidads.ToList());
        }

        // GET: TipoDePublicidads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDePublicidad tipoDePublicidad = db.TipoDePublicidads.Find(id);
            if (tipoDePublicidad == null)
            {
                return HttpNotFound();
            }
            return View(tipoDePublicidad);
        }

        // GET: TipoDePublicidads/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: TipoDePublicidads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoDePublicidad,tipo,descripcion,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoDePublicidad tipoDePublicidad)
        {
            if (ModelState.IsValid)
            {
                db.TipoDePublicidads.Add(tipoDePublicidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDePublicidad.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDePublicidad.idUsuarioModifica);
            return View(tipoDePublicidad);
        }

        // GET: TipoDePublicidads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDePublicidad tipoDePublicidad = db.TipoDePublicidads.Find(id);
            if (tipoDePublicidad == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDePublicidad.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDePublicidad.idUsuarioModifica);
            return View(tipoDePublicidad);
        }

        // POST: TipoDePublicidads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoDePublicidad,tipo,descripcion,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoDePublicidad tipoDePublicidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDePublicidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDePublicidad.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDePublicidad.idUsuarioModifica);
            return View(tipoDePublicidad);
        }

        // GET: TipoDePublicidads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDePublicidad tipoDePublicidad = db.TipoDePublicidads.Find(id);
            if (tipoDePublicidad == null)
            {
                return HttpNotFound();
            }
            return View(tipoDePublicidad);
        }

        // POST: TipoDePublicidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoDePublicidad tipoDePublicidad = db.TipoDePublicidads.Find(id);
            db.TipoDePublicidads.Remove(tipoDePublicidad);
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
