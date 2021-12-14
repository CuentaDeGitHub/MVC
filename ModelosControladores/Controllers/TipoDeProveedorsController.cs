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
    public class TipoDeProveedorsController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: TipoDeProveedors
        public ActionResult Index()
        {
            var tipoDeProveedors = db.TipoDeProveedors.Include(t => t.Usuario).Include(t => t.Usuario1);
            return View(tipoDeProveedors.ToList());
        }

        // GET: TipoDeProveedors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeProveedor tipoDeProveedor = db.TipoDeProveedors.Find(id);
            if (tipoDeProveedor == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeProveedor);
        }

        // GET: TipoDeProveedors/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: TipoDeProveedors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoDeProveedor,descripcion,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoDeProveedor tipoDeProveedor)
        {
            if (ModelState.IsValid)
            {
                db.TipoDeProveedors.Add(tipoDeProveedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDeProveedor.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDeProveedor.idUsuarioModifica);
            return View(tipoDeProveedor);
        }

        // GET: TipoDeProveedors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeProveedor tipoDeProveedor = db.TipoDeProveedors.Find(id);
            if (tipoDeProveedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDeProveedor.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDeProveedor.idUsuarioModifica);
            return View(tipoDeProveedor);
        }

        // POST: TipoDeProveedors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoDeProveedor,descripcion,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoDeProveedor tipoDeProveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDeProveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDeProveedor.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDeProveedor.idUsuarioModifica);
            return View(tipoDeProveedor);
        }

        // GET: TipoDeProveedors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeProveedor tipoDeProveedor = db.TipoDeProveedors.Find(id);
            if (tipoDeProveedor == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeProveedor);
        }

        // POST: TipoDeProveedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoDeProveedor tipoDeProveedor = db.TipoDeProveedors.Find(id);
            db.TipoDeProveedors.Remove(tipoDeProveedor);
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
