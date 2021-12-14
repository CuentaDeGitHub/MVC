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
    public class UniformesController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: Uniformes
        public ActionResult Index()
        {
            var uniformes = db.Uniformes.Include(u => u.Empleado).Include(u => u.Usuario).Include(u => u.Usuario1);
            return View(uniformes.ToList());
        }

        // GET: Uniformes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uniforme uniforme = db.Uniformes.Find(id);
            if (uniforme == null)
            {
                return HttpNotFound();
            }
            return View(uniforme);
        }

        // GET: Uniformes/Create
        public ActionResult Create()
        {
            ViewBag.idEmpleado = new SelectList(db.Empleadoes, "idEmpleado", "apellidoPaterno");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: Uniformes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idUniforme,pieza,talla,idEmpleado,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Uniforme uniforme)
        {
            if (ModelState.IsValid)
            {
                db.Uniformes.Add(uniforme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEmpleado = new SelectList(db.Empleadoes, "idEmpleado", "apellidoPaterno", uniforme.idEmpleado);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", uniforme.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", uniforme.idUsuarioModifica);
            return View(uniforme);
        }

        // GET: Uniformes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uniforme uniforme = db.Uniformes.Find(id);
            if (uniforme == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEmpleado = new SelectList(db.Empleadoes, "idEmpleado", "apellidoPaterno", uniforme.idEmpleado);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", uniforme.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", uniforme.idUsuarioModifica);
            return View(uniforme);
        }

        // POST: Uniformes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUniforme,pieza,talla,idEmpleado,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Uniforme uniforme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uniforme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEmpleado = new SelectList(db.Empleadoes, "idEmpleado", "apellidoPaterno", uniforme.idEmpleado);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", uniforme.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", uniforme.idUsuarioModifica);
            return View(uniforme);
        }

        // GET: Uniformes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uniforme uniforme = db.Uniformes.Find(id);
            if (uniforme == null)
            {
                return HttpNotFound();
            }
            return View(uniforme);
        }

        // POST: Uniformes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Uniforme uniforme = db.Uniformes.Find(id);
            db.Uniformes.Remove(uniforme);
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
