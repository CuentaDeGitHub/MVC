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
    public class EquipoLimpiezasController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: EquipoLimpiezas
        public ActionResult Index()
        {
            var equipoLimpiezas = db.EquipoLimpiezas.Include(e => e.TipoEquipoLimpieza).Include(e => e.Usuario).Include(e => e.Usuario1);
            return View(equipoLimpiezas.ToList());
        }

        // GET: EquipoLimpiezas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoLimpieza equipoLimpieza = db.EquipoLimpiezas.Find(id);
            if (equipoLimpieza == null)
            {
                return HttpNotFound();
            }
            return View(equipoLimpieza);
        }

        // GET: EquipoLimpiezas/Create
        public ActionResult Create()
        {
            ViewBag.idTipoEquipoLimpieza = new SelectList(db.TipoEquipoLimpiezas, "idTipoEquipoLimpieza", "tipo");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: EquipoLimpiezas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEquipoLimpieza,nombre,idTipoEquipoLimpieza,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EquipoLimpieza equipoLimpieza)
        {
            if (ModelState.IsValid)
            {
                db.EquipoLimpiezas.Add(equipoLimpieza);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTipoEquipoLimpieza = new SelectList(db.TipoEquipoLimpiezas, "idTipoEquipoLimpieza", "tipo", equipoLimpieza.idTipoEquipoLimpieza);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", equipoLimpieza.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", equipoLimpieza.idUsuarioModifica);
            return View(equipoLimpieza);
        }

        // GET: EquipoLimpiezas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoLimpieza equipoLimpieza = db.EquipoLimpiezas.Find(id);
            if (equipoLimpieza == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTipoEquipoLimpieza = new SelectList(db.TipoEquipoLimpiezas, "idTipoEquipoLimpieza", "tipo", equipoLimpieza.idTipoEquipoLimpieza);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", equipoLimpieza.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", equipoLimpieza.idUsuarioModifica);
            return View(equipoLimpieza);
        }

        // POST: EquipoLimpiezas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEquipoLimpieza,nombre,idTipoEquipoLimpieza,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EquipoLimpieza equipoLimpieza)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipoLimpieza).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTipoEquipoLimpieza = new SelectList(db.TipoEquipoLimpiezas, "idTipoEquipoLimpieza", "tipo", equipoLimpieza.idTipoEquipoLimpieza);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", equipoLimpieza.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", equipoLimpieza.idUsuarioModifica);
            return View(equipoLimpieza);
        }

        // GET: EquipoLimpiezas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoLimpieza equipoLimpieza = db.EquipoLimpiezas.Find(id);
            if (equipoLimpieza == null)
            {
                return HttpNotFound();
            }
            return View(equipoLimpieza);
        }

        // POST: EquipoLimpiezas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EquipoLimpieza equipoLimpieza = db.EquipoLimpiezas.Find(id);
            db.EquipoLimpiezas.Remove(equipoLimpieza);
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
