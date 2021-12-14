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
    public class TipoDeAsentamientoesController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: TipoDeAsentamientoes
        public ActionResult Index()
        {
            var tipoDeAsentamientoes = db.TipoDeAsentamientoes.Include(t => t.Usuario).Include(t => t.Usuario1);
            return View(tipoDeAsentamientoes.ToList());
        }

        // GET: TipoDeAsentamientoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeAsentamiento tipoDeAsentamiento = db.TipoDeAsentamientoes.Find(id);
            if (tipoDeAsentamiento == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeAsentamiento);
        }

        // GET: TipoDeAsentamientoes/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: TipoDeAsentamientoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoDeAsentamiento,tipo,codigo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoDeAsentamiento tipoDeAsentamiento)
        {
            if (ModelState.IsValid)
            {
                db.TipoDeAsentamientoes.Add(tipoDeAsentamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDeAsentamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDeAsentamiento.idUsuarioModifica);
            return View(tipoDeAsentamiento);
        }

        // GET: TipoDeAsentamientoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeAsentamiento tipoDeAsentamiento = db.TipoDeAsentamientoes.Find(id);
            if (tipoDeAsentamiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDeAsentamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDeAsentamiento.idUsuarioModifica);
            return View(tipoDeAsentamiento);
        }

        // POST: TipoDeAsentamientoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoDeAsentamiento,tipo,codigo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoDeAsentamiento tipoDeAsentamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDeAsentamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDeAsentamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDeAsentamiento.idUsuarioModifica);
            return View(tipoDeAsentamiento);
        }

        // GET: TipoDeAsentamientoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeAsentamiento tipoDeAsentamiento = db.TipoDeAsentamientoes.Find(id);
            if (tipoDeAsentamiento == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeAsentamiento);
        }

        // POST: TipoDeAsentamientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoDeAsentamiento tipoDeAsentamiento = db.TipoDeAsentamientoes.Find(id);
            db.TipoDeAsentamientoes.Remove(tipoDeAsentamiento);
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
