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
    public class BolsasController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: Bolsas
        public ActionResult Index()
        {
            var bolsas = db.Bolsas.Include(b => b.Usuario).Include(b => b.Usuario1);
            return View(bolsas.ToList());
        }

        // GET: Bolsas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bolsa bolsa = db.Bolsas.Find(id);
            if (bolsa == null)
            {
                return HttpNotFound();
            }
            return View(bolsa);
        }

        // GET: Bolsas/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: Bolsas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idBolsa,material,tamaño,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Bolsa bolsa)
        {
            if (ModelState.IsValid)
            {
                db.Bolsas.Add(bolsa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", bolsa.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", bolsa.idUsuarioModifica);
            return View(bolsa);
        }

        // GET: Bolsas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bolsa bolsa = db.Bolsas.Find(id);
            if (bolsa == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", bolsa.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", bolsa.idUsuarioModifica);
            return View(bolsa);
        }

        // POST: Bolsas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idBolsa,material,tamaño,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Bolsa bolsa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bolsa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", bolsa.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", bolsa.idUsuarioModifica);
            return View(bolsa);
        }

        // GET: Bolsas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bolsa bolsa = db.Bolsas.Find(id);
            if (bolsa == null)
            {
                return HttpNotFound();
            }
            return View(bolsa);
        }

        // POST: Bolsas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bolsa bolsa = db.Bolsas.Find(id);
            db.Bolsas.Remove(bolsa);
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
