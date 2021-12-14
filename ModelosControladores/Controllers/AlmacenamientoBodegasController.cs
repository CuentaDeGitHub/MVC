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
    public class AlmacenamientoBodegasController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: AlmacenamientoBodegas
        public ActionResult Index()
        {
            var almacenamientoBodegas = db.AlmacenamientoBodegas.Include(a => a.Almacenamiento).Include(a => a.Bodega).Include(a => a.Usuario).Include(a => a.Usuario1);
            return View(almacenamientoBodegas.ToList());
        }

        // GET: AlmacenamientoBodegas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlmacenamientoBodega almacenamientoBodega = db.AlmacenamientoBodegas.Find(id);
            if (almacenamientoBodega == null)
            {
                return HttpNotFound();
            }
            return View(almacenamientoBodega);
        }

        // GET: AlmacenamientoBodegas/Create
        public ActionResult Create()
        {
            ViewBag.idAlmacenamiento = new SelectList(db.Almacenamientoes, "idAlmacenamiento", "descripcion");
            ViewBag.idBodega = new SelectList(db.Bodegas, "idBodega", "codigo");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: AlmacenamientoBodegas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAlmacenamientoBodega,idAlmacenamiento,idBodega,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] AlmacenamientoBodega almacenamientoBodega)
        {
            if (ModelState.IsValid)
            {
                db.AlmacenamientoBodegas.Add(almacenamientoBodega);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAlmacenamiento = new SelectList(db.Almacenamientoes, "idAlmacenamiento", "descripcion", almacenamientoBodega.idAlmacenamiento);
            ViewBag.idBodega = new SelectList(db.Bodegas, "idBodega", "codigo", almacenamientoBodega.idBodega);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", almacenamientoBodega.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", almacenamientoBodega.idUsuarioModifica);
            return View(almacenamientoBodega);
        }

        // GET: AlmacenamientoBodegas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlmacenamientoBodega almacenamientoBodega = db.AlmacenamientoBodegas.Find(id);
            if (almacenamientoBodega == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAlmacenamiento = new SelectList(db.Almacenamientoes, "idAlmacenamiento", "descripcion", almacenamientoBodega.idAlmacenamiento);
            ViewBag.idBodega = new SelectList(db.Bodegas, "idBodega", "codigo", almacenamientoBodega.idBodega);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", almacenamientoBodega.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", almacenamientoBodega.idUsuarioModifica);
            return View(almacenamientoBodega);
        }

        // POST: AlmacenamientoBodegas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAlmacenamientoBodega,idAlmacenamiento,idBodega,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] AlmacenamientoBodega almacenamientoBodega)
        {
            if (ModelState.IsValid)
            {
                db.Entry(almacenamientoBodega).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAlmacenamiento = new SelectList(db.Almacenamientoes, "idAlmacenamiento", "descripcion", almacenamientoBodega.idAlmacenamiento);
            ViewBag.idBodega = new SelectList(db.Bodegas, "idBodega", "codigo", almacenamientoBodega.idBodega);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", almacenamientoBodega.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", almacenamientoBodega.idUsuarioModifica);
            return View(almacenamientoBodega);
        }

        // GET: AlmacenamientoBodegas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlmacenamientoBodega almacenamientoBodega = db.AlmacenamientoBodegas.Find(id);
            if (almacenamientoBodega == null)
            {
                return HttpNotFound();
            }
            return View(almacenamientoBodega);
        }

        // POST: AlmacenamientoBodegas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlmacenamientoBodega almacenamientoBodega = db.AlmacenamientoBodegas.Find(id);
            db.AlmacenamientoBodegas.Remove(almacenamientoBodega);
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
