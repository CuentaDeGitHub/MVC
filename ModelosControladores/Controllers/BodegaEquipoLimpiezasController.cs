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
    public class BodegaEquipoLimpiezasController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: BodegaEquipoLimpiezas
        public ActionResult Index()
        {
            var bodegaEquipoLimpiezas = db.BodegaEquipoLimpiezas.Include(b => b.Bodega).Include(b => b.EquipoLimpieza).Include(b => b.Usuario).Include(b => b.Usuario1);
            return View(bodegaEquipoLimpiezas.ToList());
        }

        // GET: BodegaEquipoLimpiezas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BodegaEquipoLimpieza bodegaEquipoLimpieza = db.BodegaEquipoLimpiezas.Find(id);
            if (bodegaEquipoLimpieza == null)
            {
                return HttpNotFound();
            }
            return View(bodegaEquipoLimpieza);
        }

        // GET: BodegaEquipoLimpiezas/Create
        public ActionResult Create()
        {
            ViewBag.idBodega = new SelectList(db.Bodegas, "idBodega", "codigo");
            ViewBag.idEquipoLimpieza = new SelectList(db.EquipoLimpiezas, "idEquipoLimpieza", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: BodegaEquipoLimpiezas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idBodegaEquipoLimpieza,idBodega,idEquipoLimpieza,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] BodegaEquipoLimpieza bodegaEquipoLimpieza)
        {
            if (ModelState.IsValid)
            {
                db.BodegaEquipoLimpiezas.Add(bodegaEquipoLimpieza);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idBodega = new SelectList(db.Bodegas, "idBodega", "codigo", bodegaEquipoLimpieza.idBodega);
            ViewBag.idEquipoLimpieza = new SelectList(db.EquipoLimpiezas, "idEquipoLimpieza", "nombre", bodegaEquipoLimpieza.idEquipoLimpieza);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", bodegaEquipoLimpieza.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", bodegaEquipoLimpieza.idUsuarioModifica);
            return View(bodegaEquipoLimpieza);
        }

        // GET: BodegaEquipoLimpiezas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BodegaEquipoLimpieza bodegaEquipoLimpieza = db.BodegaEquipoLimpiezas.Find(id);
            if (bodegaEquipoLimpieza == null)
            {
                return HttpNotFound();
            }
            ViewBag.idBodega = new SelectList(db.Bodegas, "idBodega", "codigo", bodegaEquipoLimpieza.idBodega);
            ViewBag.idEquipoLimpieza = new SelectList(db.EquipoLimpiezas, "idEquipoLimpieza", "nombre", bodegaEquipoLimpieza.idEquipoLimpieza);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", bodegaEquipoLimpieza.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", bodegaEquipoLimpieza.idUsuarioModifica);
            return View(bodegaEquipoLimpieza);
        }

        // POST: BodegaEquipoLimpiezas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idBodegaEquipoLimpieza,idBodega,idEquipoLimpieza,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] BodegaEquipoLimpieza bodegaEquipoLimpieza)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bodegaEquipoLimpieza).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idBodega = new SelectList(db.Bodegas, "idBodega", "codigo", bodegaEquipoLimpieza.idBodega);
            ViewBag.idEquipoLimpieza = new SelectList(db.EquipoLimpiezas, "idEquipoLimpieza", "nombre", bodegaEquipoLimpieza.idEquipoLimpieza);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", bodegaEquipoLimpieza.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", bodegaEquipoLimpieza.idUsuarioModifica);
            return View(bodegaEquipoLimpieza);
        }

        // GET: BodegaEquipoLimpiezas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BodegaEquipoLimpieza bodegaEquipoLimpieza = db.BodegaEquipoLimpiezas.Find(id);
            if (bodegaEquipoLimpieza == null)
            {
                return HttpNotFound();
            }
            return View(bodegaEquipoLimpieza);
        }

        // POST: BodegaEquipoLimpiezas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BodegaEquipoLimpieza bodegaEquipoLimpieza = db.BodegaEquipoLimpiezas.Find(id);
            db.BodegaEquipoLimpiezas.Remove(bodegaEquipoLimpieza);
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
