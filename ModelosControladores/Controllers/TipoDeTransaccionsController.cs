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
    public class TipoDeTransaccionsController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: TipoDeTransaccions
        public ActionResult Index()
        {
            var tipoDeTransaccions = db.TipoDeTransaccions.Include(t => t.Usuario).Include(t => t.Usuario1);
            return View(tipoDeTransaccions.ToList());
        }

        // GET: TipoDeTransaccions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeTransaccion tipoDeTransaccion = db.TipoDeTransaccions.Find(id);
            if (tipoDeTransaccion == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeTransaccion);
        }

        // GET: TipoDeTransaccions/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: TipoDeTransaccions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoDeTransaccion,tipo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoDeTransaccion tipoDeTransaccion)
        {
            if (ModelState.IsValid)
            {
                db.TipoDeTransaccions.Add(tipoDeTransaccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDeTransaccion.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDeTransaccion.idUsuarioModifica);
            return View(tipoDeTransaccion);
        }

        // GET: TipoDeTransaccions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeTransaccion tipoDeTransaccion = db.TipoDeTransaccions.Find(id);
            if (tipoDeTransaccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDeTransaccion.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDeTransaccion.idUsuarioModifica);
            return View(tipoDeTransaccion);
        }

        // POST: TipoDeTransaccions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoDeTransaccion,tipo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoDeTransaccion tipoDeTransaccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDeTransaccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDeTransaccion.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDeTransaccion.idUsuarioModifica);
            return View(tipoDeTransaccion);
        }

        // GET: TipoDeTransaccions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeTransaccion tipoDeTransaccion = db.TipoDeTransaccions.Find(id);
            if (tipoDeTransaccion == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeTransaccion);
        }

        // POST: TipoDeTransaccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoDeTransaccion tipoDeTransaccion = db.TipoDeTransaccions.Find(id);
            db.TipoDeTransaccions.Remove(tipoDeTransaccion);
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
