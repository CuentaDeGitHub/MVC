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
    public class CajaDineroesController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: CajaDineroes
        public ActionResult Index()
        {
            var cajaDineroes = db.CajaDineroes.Include(c => c.Caja).Include(c => c.Dinero).Include(c => c.Usuario).Include(c => c.Usuario1);
            return View(cajaDineroes.ToList());
        }

        // GET: CajaDineroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CajaDinero cajaDinero = db.CajaDineroes.Find(id);
            if (cajaDinero == null)
            {
                return HttpNotFound();
            }
            return View(cajaDinero);
        }

        // GET: CajaDineroes/Create
        public ActionResult Create()
        {
            ViewBag.idCaja = new SelectList(db.Cajas, "idCaja", "modelo");
            ViewBag.idDinero = new SelectList(db.Dineroes, "idDinero", "tipo");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: CajaDineroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCajaDinero,idCaja,idDinero,cantidad,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] CajaDinero cajaDinero)
        {
            if (ModelState.IsValid)
            {
                db.CajaDineroes.Add(cajaDinero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCaja = new SelectList(db.Cajas, "idCaja", "modelo", cajaDinero.idCaja);
            ViewBag.idDinero = new SelectList(db.Dineroes, "idDinero", "tipo", cajaDinero.idDinero);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", cajaDinero.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", cajaDinero.idUsuarioModifica);
            return View(cajaDinero);
        }

        // GET: CajaDineroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CajaDinero cajaDinero = db.CajaDineroes.Find(id);
            if (cajaDinero == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCaja = new SelectList(db.Cajas, "idCaja", "modelo", cajaDinero.idCaja);
            ViewBag.idDinero = new SelectList(db.Dineroes, "idDinero", "tipo", cajaDinero.idDinero);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", cajaDinero.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", cajaDinero.idUsuarioModifica);
            return View(cajaDinero);
        }

        // POST: CajaDineroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCajaDinero,idCaja,idDinero,cantidad,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] CajaDinero cajaDinero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cajaDinero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCaja = new SelectList(db.Cajas, "idCaja", "modelo", cajaDinero.idCaja);
            ViewBag.idDinero = new SelectList(db.Dineroes, "idDinero", "tipo", cajaDinero.idDinero);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", cajaDinero.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", cajaDinero.idUsuarioModifica);
            return View(cajaDinero);
        }

        // GET: CajaDineroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CajaDinero cajaDinero = db.CajaDineroes.Find(id);
            if (cajaDinero == null)
            {
                return HttpNotFound();
            }
            return View(cajaDinero);
        }

        // POST: CajaDineroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CajaDinero cajaDinero = db.CajaDineroes.Find(id);
            db.CajaDineroes.Remove(cajaDinero);
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
