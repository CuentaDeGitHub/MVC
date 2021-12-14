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
    public class BodegaEstantesController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: BodegaEstantes
        public ActionResult Index()
        {
            var bodegaEstantes = db.BodegaEstantes.Include(b => b.Bodega).Include(b => b.Estante).Include(b => b.Usuario).Include(b => b.Usuario1);
            return View(bodegaEstantes.ToList());
        }

        // GET: BodegaEstantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BodegaEstante bodegaEstante = db.BodegaEstantes.Find(id);
            if (bodegaEstante == null)
            {
                return HttpNotFound();
            }
            return View(bodegaEstante);
        }

        // GET: BodegaEstantes/Create
        public ActionResult Create()
        {
            ViewBag.idBodega = new SelectList(db.Bodegas, "idBodega", "codigo");
            ViewBag.idEstante = new SelectList(db.Estantes, "idEstante", "idEstante");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: BodegaEstantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idBodegaEstante,idBodega,idEstante,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] BodegaEstante bodegaEstante)
        {
            if (ModelState.IsValid)
            {
                db.BodegaEstantes.Add(bodegaEstante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idBodega = new SelectList(db.Bodegas, "idBodega", "codigo", bodegaEstante.idBodega);
            ViewBag.idEstante = new SelectList(db.Estantes, "idEstante", "idEstante", bodegaEstante.idEstante);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", bodegaEstante.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", bodegaEstante.idUsuarioModifica);
            return View(bodegaEstante);
        }

        // GET: BodegaEstantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BodegaEstante bodegaEstante = db.BodegaEstantes.Find(id);
            if (bodegaEstante == null)
            {
                return HttpNotFound();
            }
            ViewBag.idBodega = new SelectList(db.Bodegas, "idBodega", "codigo", bodegaEstante.idBodega);
            ViewBag.idEstante = new SelectList(db.Estantes, "idEstante", "idEstante", bodegaEstante.idEstante);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", bodegaEstante.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", bodegaEstante.idUsuarioModifica);
            return View(bodegaEstante);
        }

        // POST: BodegaEstantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idBodegaEstante,idBodega,idEstante,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] BodegaEstante bodegaEstante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bodegaEstante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idBodega = new SelectList(db.Bodegas, "idBodega", "codigo", bodegaEstante.idBodega);
            ViewBag.idEstante = new SelectList(db.Estantes, "idEstante", "idEstante", bodegaEstante.idEstante);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", bodegaEstante.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", bodegaEstante.idUsuarioModifica);
            return View(bodegaEstante);
        }

        // GET: BodegaEstantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BodegaEstante bodegaEstante = db.BodegaEstantes.Find(id);
            if (bodegaEstante == null)
            {
                return HttpNotFound();
            }
            return View(bodegaEstante);
        }

        // POST: BodegaEstantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BodegaEstante bodegaEstante = db.BodegaEstantes.Find(id);
            db.BodegaEstantes.Remove(bodegaEstante);
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
