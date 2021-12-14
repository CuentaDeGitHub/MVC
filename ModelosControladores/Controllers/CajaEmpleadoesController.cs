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
    public class CajaEmpleadoesController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: CajaEmpleadoes
        public ActionResult Index()
        {
            var cajaEmpleadoes = db.CajaEmpleadoes.Include(c => c.Caja).Include(c => c.Empleado).Include(c => c.Usuario).Include(c => c.Usuario1);
            return View(cajaEmpleadoes.ToList());
        }

        // GET: CajaEmpleadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CajaEmpleado cajaEmpleado = db.CajaEmpleadoes.Find(id);
            if (cajaEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(cajaEmpleado);
        }

        // GET: CajaEmpleadoes/Create
        public ActionResult Create()
        {
            ViewBag.idCaja = new SelectList(db.Cajas, "idCaja", "modelo");
            ViewBag.idEmpleado = new SelectList(db.Empleadoes, "idEmpleado", "apellidoPaterno");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: CajaEmpleadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCajaEmpleado,idCaja,idEmpleado,fechaAsignada,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] CajaEmpleado cajaEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.CajaEmpleadoes.Add(cajaEmpleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCaja = new SelectList(db.Cajas, "idCaja", "modelo", cajaEmpleado.idCaja);
            ViewBag.idEmpleado = new SelectList(db.Empleadoes, "idEmpleado", "apellidoPaterno", cajaEmpleado.idEmpleado);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", cajaEmpleado.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", cajaEmpleado.idUsuarioModifica);
            return View(cajaEmpleado);
        }

        // GET: CajaEmpleadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CajaEmpleado cajaEmpleado = db.CajaEmpleadoes.Find(id);
            if (cajaEmpleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCaja = new SelectList(db.Cajas, "idCaja", "modelo", cajaEmpleado.idCaja);
            ViewBag.idEmpleado = new SelectList(db.Empleadoes, "idEmpleado", "apellidoPaterno", cajaEmpleado.idEmpleado);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", cajaEmpleado.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", cajaEmpleado.idUsuarioModifica);
            return View(cajaEmpleado);
        }

        // POST: CajaEmpleadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCajaEmpleado,idCaja,idEmpleado,fechaAsignada,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] CajaEmpleado cajaEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cajaEmpleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCaja = new SelectList(db.Cajas, "idCaja", "modelo", cajaEmpleado.idCaja);
            ViewBag.idEmpleado = new SelectList(db.Empleadoes, "idEmpleado", "apellidoPaterno", cajaEmpleado.idEmpleado);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", cajaEmpleado.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", cajaEmpleado.idUsuarioModifica);
            return View(cajaEmpleado);
        }

        // GET: CajaEmpleadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CajaEmpleado cajaEmpleado = db.CajaEmpleadoes.Find(id);
            if (cajaEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(cajaEmpleado);
        }

        // POST: CajaEmpleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CajaEmpleado cajaEmpleado = db.CajaEmpleadoes.Find(id);
            db.CajaEmpleadoes.Remove(cajaEmpleado);
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
