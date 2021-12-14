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
    public class DineroesController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: Dineroes
        public ActionResult Index()
        {
            var dineroes = db.Dineroes.Include(d => d.Usuario).Include(d => d.Usuario1);
            return View(dineroes.ToList());
        }

        // GET: Dineroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dinero dinero = db.Dineroes.Find(id);
            if (dinero == null)
            {
                return HttpNotFound();
            }
            return View(dinero);
        }

        // GET: Dineroes/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: Dineroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDinero,valor,tipo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Dinero dinero)
        {
            if (ModelState.IsValid)
            {
                db.Dineroes.Add(dinero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", dinero.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", dinero.idUsuarioModifica);
            return View(dinero);
        }

        // GET: Dineroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dinero dinero = db.Dineroes.Find(id);
            if (dinero == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", dinero.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", dinero.idUsuarioModifica);
            return View(dinero);
        }

        // POST: Dineroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDinero,valor,tipo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Dinero dinero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dinero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", dinero.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", dinero.idUsuarioModifica);
            return View(dinero);
        }

        // GET: Dineroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dinero dinero = db.Dineroes.Find(id);
            if (dinero == null)
            {
                return HttpNotFound();
            }
            return View(dinero);
        }

        // POST: Dineroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dinero dinero = db.Dineroes.Find(id);
            db.Dineroes.Remove(dinero);
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
