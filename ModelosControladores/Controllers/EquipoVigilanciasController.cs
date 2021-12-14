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
    public class EquipoVigilanciasController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: EquipoVigilancias
        public ActionResult Index()
        {
            var equipoVigilancias = db.EquipoVigilancias.Include(e => e.Usuario).Include(e => e.Usuario1);
            return View(equipoVigilancias.ToList());
        }

        // GET: EquipoVigilancias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoVigilancia equipoVigilancia = db.EquipoVigilancias.Find(id);
            if (equipoVigilancia == null)
            {
                return HttpNotFound();
            }
            return View(equipoVigilancia);
        }

        // GET: EquipoVigilancias/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: EquipoVigilancias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEquipoVigilancia,descripcion,ubicacion,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EquipoVigilancia equipoVigilancia)
        {
            if (ModelState.IsValid)
            {
                db.EquipoVigilancias.Add(equipoVigilancia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", equipoVigilancia.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", equipoVigilancia.idUsuarioModifica);
            return View(equipoVigilancia);
        }

        // GET: EquipoVigilancias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoVigilancia equipoVigilancia = db.EquipoVigilancias.Find(id);
            if (equipoVigilancia == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", equipoVigilancia.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", equipoVigilancia.idUsuarioModifica);
            return View(equipoVigilancia);
        }

        // POST: EquipoVigilancias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEquipoVigilancia,descripcion,ubicacion,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EquipoVigilancia equipoVigilancia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipoVigilancia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", equipoVigilancia.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", equipoVigilancia.idUsuarioModifica);
            return View(equipoVigilancia);
        }

        // GET: EquipoVigilancias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoVigilancia equipoVigilancia = db.EquipoVigilancias.Find(id);
            if (equipoVigilancia == null)
            {
                return HttpNotFound();
            }
            return View(equipoVigilancia);
        }

        // POST: EquipoVigilancias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EquipoVigilancia equipoVigilancia = db.EquipoVigilancias.Find(id);
            db.EquipoVigilancias.Remove(equipoVigilancia);
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
