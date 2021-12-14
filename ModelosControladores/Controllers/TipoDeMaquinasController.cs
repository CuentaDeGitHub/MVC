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
    public class TipoDeMaquinasController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: TipoDeMaquinas
        public ActionResult Index()
        {
            var tipoDeMaquinas = db.TipoDeMaquinas.Include(t => t.Usuario).Include(t => t.Usuario1);
            return View(tipoDeMaquinas.ToList());
        }

        // GET: TipoDeMaquinas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeMaquina tipoDeMaquina = db.TipoDeMaquinas.Find(id);
            if (tipoDeMaquina == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeMaquina);
        }

        // GET: TipoDeMaquinas/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: TipoDeMaquinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoDeMaquina,tipo,descripcion,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoDeMaquina tipoDeMaquina)
        {
            if (ModelState.IsValid)
            {
                db.TipoDeMaquinas.Add(tipoDeMaquina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDeMaquina.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDeMaquina.idUsuarioModifica);
            return View(tipoDeMaquina);
        }

        // GET: TipoDeMaquinas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeMaquina tipoDeMaquina = db.TipoDeMaquinas.Find(id);
            if (tipoDeMaquina == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDeMaquina.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDeMaquina.idUsuarioModifica);
            return View(tipoDeMaquina);
        }

        // POST: TipoDeMaquinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoDeMaquina,tipo,descripcion,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoDeMaquina tipoDeMaquina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDeMaquina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDeMaquina.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDeMaquina.idUsuarioModifica);
            return View(tipoDeMaquina);
        }

        // GET: TipoDeMaquinas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeMaquina tipoDeMaquina = db.TipoDeMaquinas.Find(id);
            if (tipoDeMaquina == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeMaquina);
        }

        // POST: TipoDeMaquinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoDeMaquina tipoDeMaquina = db.TipoDeMaquinas.Find(id);
            db.TipoDeMaquinas.Remove(tipoDeMaquina);
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
