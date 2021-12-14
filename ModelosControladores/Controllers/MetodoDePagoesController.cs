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
    public class MetodoDePagoesController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: MetodoDePagoes
        public ActionResult Index()
        {
            var metodoDePagoes = db.MetodoDePagoes.Include(m => m.Usuario).Include(m => m.Usuario1);
            return View(metodoDePagoes.ToList());
        }

        // GET: MetodoDePagoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetodoDePago metodoDePago = db.MetodoDePagoes.Find(id);
            if (metodoDePago == null)
            {
                return HttpNotFound();
            }
            return View(metodoDePago);
        }

        // GET: MetodoDePagoes/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: MetodoDePagoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMetodoDePago,metodo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] MetodoDePago metodoDePago)
        {
            if (ModelState.IsValid)
            {
                db.MetodoDePagoes.Add(metodoDePago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", metodoDePago.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", metodoDePago.idUsuarioModifica);
            return View(metodoDePago);
        }

        // GET: MetodoDePagoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetodoDePago metodoDePago = db.MetodoDePagoes.Find(id);
            if (metodoDePago == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", metodoDePago.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", metodoDePago.idUsuarioModifica);
            return View(metodoDePago);
        }

        // POST: MetodoDePagoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMetodoDePago,metodo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] MetodoDePago metodoDePago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(metodoDePago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", metodoDePago.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", metodoDePago.idUsuarioModifica);
            return View(metodoDePago);
        }

        // GET: MetodoDePagoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetodoDePago metodoDePago = db.MetodoDePagoes.Find(id);
            if (metodoDePago == null)
            {
                return HttpNotFound();
            }
            return View(metodoDePago);
        }

        // POST: MetodoDePagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MetodoDePago metodoDePago = db.MetodoDePagoes.Find(id);
            db.MetodoDePagoes.Remove(metodoDePago);
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
