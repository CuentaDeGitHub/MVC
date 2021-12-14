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
    public class AlmacenamientoesController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: Almacenamientoes
        public ActionResult Index()
        {
            var almacenamientoes = db.Almacenamientoes.Include(a => a.Usuario).Include(a => a.Usuario1);
            return View(almacenamientoes.ToList());
        }

        // GET: Almacenamientoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Almacenamiento almacenamiento = db.Almacenamientoes.Find(id);
            if (almacenamiento == null)
            {
                return HttpNotFound();
            }
            return View(almacenamiento);
        }

        // GET: Almacenamientoes/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: Almacenamientoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAlmacenamiento,descripcion,capacidad,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Almacenamiento almacenamiento)
        {
            if (ModelState.IsValid)
            {
                db.Almacenamientoes.Add(almacenamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", almacenamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", almacenamiento.idUsuarioModifica);
            return View(almacenamiento);
        }

        // GET: Almacenamientoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Almacenamiento almacenamiento = db.Almacenamientoes.Find(id);
            if (almacenamiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", almacenamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", almacenamiento.idUsuarioModifica);
            return View(almacenamiento);
        }

        // POST: Almacenamientoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAlmacenamiento,descripcion,capacidad,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Almacenamiento almacenamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(almacenamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", almacenamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", almacenamiento.idUsuarioModifica);
            return View(almacenamiento);
        }

        // GET: Almacenamientoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Almacenamiento almacenamiento = db.Almacenamientoes.Find(id);
            if (almacenamiento == null)
            {
                return HttpNotFound();
            }
            return View(almacenamiento);
        }

        // POST: Almacenamientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Almacenamiento almacenamiento = db.Almacenamientoes.Find(id);
            db.Almacenamientoes.Remove(almacenamiento);
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
