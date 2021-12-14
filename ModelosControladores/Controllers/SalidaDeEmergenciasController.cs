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
    public class SalidaDeEmergenciasController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: SalidaDeEmergencias
        public ActionResult Index()
        {
            var salidaDeEmergencias = db.SalidaDeEmergencias.Include(s => s.Usuario).Include(s => s.Usuario1);
            return View(salidaDeEmergencias.ToList());
        }

        // GET: SalidaDeEmergencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalidaDeEmergencia salidaDeEmergencia = db.SalidaDeEmergencias.Find(id);
            if (salidaDeEmergencia == null)
            {
                return HttpNotFound();
            }
            return View(salidaDeEmergencia);
        }

        // GET: SalidaDeEmergencias/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: SalidaDeEmergencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSalidaDeEmergencia,ubicacion,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] SalidaDeEmergencia salidaDeEmergencia)
        {
            if (ModelState.IsValid)
            {
                db.SalidaDeEmergencias.Add(salidaDeEmergencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", salidaDeEmergencia.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", salidaDeEmergencia.idUsuarioModifica);
            return View(salidaDeEmergencia);
        }

        // GET: SalidaDeEmergencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalidaDeEmergencia salidaDeEmergencia = db.SalidaDeEmergencias.Find(id);
            if (salidaDeEmergencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", salidaDeEmergencia.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", salidaDeEmergencia.idUsuarioModifica);
            return View(salidaDeEmergencia);
        }

        // POST: SalidaDeEmergencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSalidaDeEmergencia,ubicacion,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] SalidaDeEmergencia salidaDeEmergencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salidaDeEmergencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", salidaDeEmergencia.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", salidaDeEmergencia.idUsuarioModifica);
            return View(salidaDeEmergencia);
        }

        // GET: SalidaDeEmergencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalidaDeEmergencia salidaDeEmergencia = db.SalidaDeEmergencias.Find(id);
            if (salidaDeEmergencia == null)
            {
                return HttpNotFound();
            }
            return View(salidaDeEmergencia);
        }

        // POST: SalidaDeEmergencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalidaDeEmergencia salidaDeEmergencia = db.SalidaDeEmergencias.Find(id);
            db.SalidaDeEmergencias.Remove(salidaDeEmergencia);
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
