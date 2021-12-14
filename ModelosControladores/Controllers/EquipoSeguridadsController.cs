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
    public class EquipoSeguridadsController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: EquipoSeguridads
        public ActionResult Index()
        {
            var equipoSeguridads = db.EquipoSeguridads.Include(e => e.Usuario).Include(e => e.Usuario1);
            return View(equipoSeguridads.ToList());
        }

        // GET: EquipoSeguridads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoSeguridad equipoSeguridad = db.EquipoSeguridads.Find(id);
            if (equipoSeguridad == null)
            {
                return HttpNotFound();
            }
            return View(equipoSeguridad);
        }

        // GET: EquipoSeguridads/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: EquipoSeguridads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEquipoSeguridad,descripcion,ubicacion,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EquipoSeguridad equipoSeguridad)
        {
            if (ModelState.IsValid)
            {
                db.EquipoSeguridads.Add(equipoSeguridad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", equipoSeguridad.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", equipoSeguridad.idUsuarioModifica);
            return View(equipoSeguridad);
        }

        // GET: EquipoSeguridads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoSeguridad equipoSeguridad = db.EquipoSeguridads.Find(id);
            if (equipoSeguridad == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", equipoSeguridad.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", equipoSeguridad.idUsuarioModifica);
            return View(equipoSeguridad);
        }

        // POST: EquipoSeguridads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEquipoSeguridad,descripcion,ubicacion,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EquipoSeguridad equipoSeguridad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipoSeguridad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", equipoSeguridad.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", equipoSeguridad.idUsuarioModifica);
            return View(equipoSeguridad);
        }

        // GET: EquipoSeguridads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoSeguridad equipoSeguridad = db.EquipoSeguridads.Find(id);
            if (equipoSeguridad == null)
            {
                return HttpNotFound();
            }
            return View(equipoSeguridad);
        }

        // POST: EquipoSeguridads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EquipoSeguridad equipoSeguridad = db.EquipoSeguridads.Find(id);
            db.EquipoSeguridads.Remove(equipoSeguridad);
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
