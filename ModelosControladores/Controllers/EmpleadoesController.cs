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
    public class EmpleadoesController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: Empleadoes
        public ActionResult Index()
        {
            var empleadoes = db.Empleadoes.Include(e => e.EstadoCivil).Include(e => e.Estudio).Include(e => e.Nacionalidad).Include(e => e.Puesto).Include(e => e.Sucursal).Include(e => e.Usuario).Include(e => e.Usuario1);
            return View(empleadoes.ToList());
        }

        // GET: Empleadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleadoes.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleadoes/Create
        public ActionResult Create()
        {
            ViewBag.idEstadoCivil = new SelectList(db.EstadoCivils, "idEstadoCivil", "descripcion");
            ViewBag.idEstudios = new SelectList(db.Estudios, "idEstudios", "descripcion");
            ViewBag.idNacionalidad = new SelectList(db.Nacionalidads, "idNacionalidad", "descripcion");
            ViewBag.idPuesto = new SelectList(db.Puestoes, "idPuesto", "descripcion");
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: Empleadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEmpleado,apellidoPaterno,apellidoMaterno,nombre,RFC,telefono,idEstadoCivil,idEstudios,idPuesto,idNacionalidad,idSucursal,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Empleadoes.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEstadoCivil = new SelectList(db.EstadoCivils, "idEstadoCivil", "descripcion", empleado.idEstadoCivil);
            ViewBag.idEstudios = new SelectList(db.Estudios, "idEstudios", "descripcion", empleado.idEstudios);
            ViewBag.idNacionalidad = new SelectList(db.Nacionalidads, "idNacionalidad", "descripcion", empleado.idNacionalidad);
            ViewBag.idPuesto = new SelectList(db.Puestoes, "idPuesto", "descripcion", empleado.idPuesto);
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo", empleado.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", empleado.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", empleado.idUsuarioModifica);
            return View(empleado);
        }

        // GET: Empleadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleadoes.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEstadoCivil = new SelectList(db.EstadoCivils, "idEstadoCivil", "descripcion", empleado.idEstadoCivil);
            ViewBag.idEstudios = new SelectList(db.Estudios, "idEstudios", "descripcion", empleado.idEstudios);
            ViewBag.idNacionalidad = new SelectList(db.Nacionalidads, "idNacionalidad", "descripcion", empleado.idNacionalidad);
            ViewBag.idPuesto = new SelectList(db.Puestoes, "idPuesto", "descripcion", empleado.idPuesto);
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo", empleado.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", empleado.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", empleado.idUsuarioModifica);
            return View(empleado);
        }

        // POST: Empleadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEmpleado,apellidoPaterno,apellidoMaterno,nombre,RFC,telefono,idEstadoCivil,idEstudios,idPuesto,idNacionalidad,idSucursal,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEstadoCivil = new SelectList(db.EstadoCivils, "idEstadoCivil", "descripcion", empleado.idEstadoCivil);
            ViewBag.idEstudios = new SelectList(db.Estudios, "idEstudios", "descripcion", empleado.idEstudios);
            ViewBag.idNacionalidad = new SelectList(db.Nacionalidads, "idNacionalidad", "descripcion", empleado.idNacionalidad);
            ViewBag.idPuesto = new SelectList(db.Puestoes, "idPuesto", "descripcion", empleado.idPuesto);
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo", empleado.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", empleado.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", empleado.idUsuarioModifica);
            return View(empleado);
        }

        // GET: Empleadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleadoes.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = db.Empleadoes.Find(id);
            db.Empleadoes.Remove(empleado);
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
