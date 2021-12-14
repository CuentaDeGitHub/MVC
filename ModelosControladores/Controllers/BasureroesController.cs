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
    public class BasureroesController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: Basureroes
        public ActionResult Index()
        {
            var basureroes = db.Basureroes.Include(b => b.Usuario).Include(b => b.Usuario1);
            return View(basureroes.ToList());
        }

        // GET: Basureroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Basurero basurero = db.Basureroes.Find(id);
            if (basurero == null)
            {
                return HttpNotFound();
            }
            return View(basurero);
        }

        // GET: Basureroes/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: Basureroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idBasurero,tipo,ubicacion,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Basurero basurero)
        {
            if (ModelState.IsValid)
            {
                db.Basureroes.Add(basurero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", basurero.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", basurero.idUsuarioModifica);
            return View(basurero);
        }

        // GET: Basureroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Basurero basurero = db.Basureroes.Find(id);
            if (basurero == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", basurero.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", basurero.idUsuarioModifica);
            return View(basurero);
        }

        // POST: Basureroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idBasurero,tipo,ubicacion,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Basurero basurero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(basurero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", basurero.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", basurero.idUsuarioModifica);
            return View(basurero);
        }

        // GET: Basureroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Basurero basurero = db.Basureroes.Find(id);
            if (basurero == null)
            {
                return HttpNotFound();
            }
            return View(basurero);
        }

        // POST: Basureroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Basurero basurero = db.Basureroes.Find(id);
            db.Basureroes.Remove(basurero);
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
