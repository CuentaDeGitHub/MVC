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
    public class EstacionamientoesController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: Estacionamientoes
        public ActionResult Index()
        {
            var estacionamientoes = db.Estacionamientoes.Include(e => e.Usuario).Include(e => e.Usuario1);
            return View(estacionamientoes.ToList());
        }

        // GET: Estacionamientoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estacionamiento estacionamiento = db.Estacionamientoes.Find(id);
            if (estacionamiento == null)
            {
                return HttpNotFound();
            }
            return View(estacionamiento);
        }

        // GET: Estacionamientoes/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: Estacionamientoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEstacionamiento,numeroLugares,numeroLugaresDiscapacitados,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Estacionamiento estacionamiento)
        {
            if (ModelState.IsValid)
            {
                db.Estacionamientoes.Add(estacionamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", estacionamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", estacionamiento.idUsuarioModifica);
            return View(estacionamiento);
        }

        // GET: Estacionamientoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estacionamiento estacionamiento = db.Estacionamientoes.Find(id);
            if (estacionamiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", estacionamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", estacionamiento.idUsuarioModifica);
            return View(estacionamiento);
        }

        // POST: Estacionamientoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEstacionamiento,numeroLugares,numeroLugaresDiscapacitados,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Estacionamiento estacionamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estacionamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", estacionamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", estacionamiento.idUsuarioModifica);
            return View(estacionamiento);
        }

        // GET: Estacionamientoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estacionamiento estacionamiento = db.Estacionamientoes.Find(id);
            if (estacionamiento == null)
            {
                return HttpNotFound();
            }
            return View(estacionamiento);
        }

        // POST: Estacionamientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estacionamiento estacionamiento = db.Estacionamientoes.Find(id);
            db.Estacionamientoes.Remove(estacionamiento);
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
