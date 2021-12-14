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
    public class EmpleadoTurnoesController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: EmpleadoTurnoes
        public ActionResult Index()
        {
            var empleadoTurnoes = db.EmpleadoTurnoes.Include(e => e.Empleado).Include(e => e.Turno).Include(e => e.Usuario).Include(e => e.Usuario1);
            return View(empleadoTurnoes.ToList());
        }

        // GET: EmpleadoTurnoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadoTurno empleadoTurno = db.EmpleadoTurnoes.Find(id);
            if (empleadoTurno == null)
            {
                return HttpNotFound();
            }
            return View(empleadoTurno);
        }

        // GET: EmpleadoTurnoes/Create
        public ActionResult Create()
        {
            ViewBag.idEmpleado = new SelectList(db.Empleadoes, "idEmpleado", "apellidoPaterno");
            ViewBag.idTurno = new SelectList(db.Turnoes, "idTurno", "descripcion");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: EmpleadoTurnoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEmpleadoTurno,idEmpleado,idTurno,fechaInicio,fechaTermino,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EmpleadoTurno empleadoTurno)
        {
            if (ModelState.IsValid)
            {
                db.EmpleadoTurnoes.Add(empleadoTurno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEmpleado = new SelectList(db.Empleadoes, "idEmpleado", "apellidoPaterno", empleadoTurno.idEmpleado);
            ViewBag.idTurno = new SelectList(db.Turnoes, "idTurno", "descripcion", empleadoTurno.idTurno);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", empleadoTurno.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", empleadoTurno.idUsuarioModifica);
            return View(empleadoTurno);
        }

        // GET: EmpleadoTurnoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadoTurno empleadoTurno = db.EmpleadoTurnoes.Find(id);
            if (empleadoTurno == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEmpleado = new SelectList(db.Empleadoes, "idEmpleado", "apellidoPaterno", empleadoTurno.idEmpleado);
            ViewBag.idTurno = new SelectList(db.Turnoes, "idTurno", "descripcion", empleadoTurno.idTurno);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", empleadoTurno.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", empleadoTurno.idUsuarioModifica);
            return View(empleadoTurno);
        }

        // POST: EmpleadoTurnoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEmpleadoTurno,idEmpleado,idTurno,fechaInicio,fechaTermino,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EmpleadoTurno empleadoTurno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleadoTurno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEmpleado = new SelectList(db.Empleadoes, "idEmpleado", "apellidoPaterno", empleadoTurno.idEmpleado);
            ViewBag.idTurno = new SelectList(db.Turnoes, "idTurno", "descripcion", empleadoTurno.idTurno);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", empleadoTurno.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", empleadoTurno.idUsuarioModifica);
            return View(empleadoTurno);
        }

        // GET: EmpleadoTurnoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadoTurno empleadoTurno = db.EmpleadoTurnoes.Find(id);
            if (empleadoTurno == null)
            {
                return HttpNotFound();
            }
            return View(empleadoTurno);
        }

        // POST: EmpleadoTurnoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpleadoTurno empleadoTurno = db.EmpleadoTurnoes.Find(id);
            db.EmpleadoTurnoes.Remove(empleadoTurno);
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
