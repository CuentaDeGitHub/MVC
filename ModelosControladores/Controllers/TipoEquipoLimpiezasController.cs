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
    public class TipoEquipoLimpiezasController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: TipoEquipoLimpiezas
        public ActionResult Index()
        {
            var tipoEquipoLimpiezas = db.TipoEquipoLimpiezas.Include(t => t.Usuario).Include(t => t.Usuario1);
            return View(tipoEquipoLimpiezas.ToList());
        }

        // GET: TipoEquipoLimpiezas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEquipoLimpieza tipoEquipoLimpieza = db.TipoEquipoLimpiezas.Find(id);
            if (tipoEquipoLimpieza == null)
            {
                return HttpNotFound();
            }
            return View(tipoEquipoLimpieza);
        }

        // GET: TipoEquipoLimpiezas/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: TipoEquipoLimpiezas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoEquipoLimpieza,tipo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoEquipoLimpieza tipoEquipoLimpieza)
        {
            if (ModelState.IsValid)
            {
                db.TipoEquipoLimpiezas.Add(tipoEquipoLimpieza);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoEquipoLimpieza.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoEquipoLimpieza.idUsuarioModifica);
            return View(tipoEquipoLimpieza);
        }

        // GET: TipoEquipoLimpiezas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEquipoLimpieza tipoEquipoLimpieza = db.TipoEquipoLimpiezas.Find(id);
            if (tipoEquipoLimpieza == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoEquipoLimpieza.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoEquipoLimpieza.idUsuarioModifica);
            return View(tipoEquipoLimpieza);
        }

        // POST: TipoEquipoLimpiezas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoEquipoLimpieza,tipo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoEquipoLimpieza tipoEquipoLimpieza)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoEquipoLimpieza).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoEquipoLimpieza.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoEquipoLimpieza.idUsuarioModifica);
            return View(tipoEquipoLimpieza);
        }

        // GET: TipoEquipoLimpiezas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEquipoLimpieza tipoEquipoLimpieza = db.TipoEquipoLimpiezas.Find(id);
            if (tipoEquipoLimpieza == null)
            {
                return HttpNotFound();
            }
            return View(tipoEquipoLimpieza);
        }

        // POST: TipoEquipoLimpiezas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoEquipoLimpieza tipoEquipoLimpieza = db.TipoEquipoLimpiezas.Find(id);
            db.TipoEquipoLimpiezas.Remove(tipoEquipoLimpieza);
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
