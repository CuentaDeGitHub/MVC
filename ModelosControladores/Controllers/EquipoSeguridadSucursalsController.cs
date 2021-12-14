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
    public class EquipoSeguridadSucursalsController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: EquipoSeguridadSucursals
        public ActionResult Index()
        {
            var equipoSeguridadSucursals = db.EquipoSeguridadSucursals.Include(e => e.EquipoSeguridad).Include(e => e.Sucursal).Include(e => e.Usuario).Include(e => e.Usuario1);
            return View(equipoSeguridadSucursals.ToList());
        }

        // GET: EquipoSeguridadSucursals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoSeguridadSucursal equipoSeguridadSucursal = db.EquipoSeguridadSucursals.Find(id);
            if (equipoSeguridadSucursal == null)
            {
                return HttpNotFound();
            }
            return View(equipoSeguridadSucursal);
        }

        // GET: EquipoSeguridadSucursals/Create
        public ActionResult Create()
        {
            ViewBag.idEquipoSeguridad = new SelectList(db.EquipoSeguridads, "idEquipoSeguridad", "descripcion");
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: EquipoSeguridadSucursals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEquipoSeguridadSucursal,idEquipoSeguridad,idSucursal,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EquipoSeguridadSucursal equipoSeguridadSucursal)
        {
            if (ModelState.IsValid)
            {
                db.EquipoSeguridadSucursals.Add(equipoSeguridadSucursal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEquipoSeguridad = new SelectList(db.EquipoSeguridads, "idEquipoSeguridad", "descripcion", equipoSeguridadSucursal.idEquipoSeguridad);
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo", equipoSeguridadSucursal.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", equipoSeguridadSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", equipoSeguridadSucursal.idUsuarioModifica);
            return View(equipoSeguridadSucursal);
        }

        // GET: EquipoSeguridadSucursals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoSeguridadSucursal equipoSeguridadSucursal = db.EquipoSeguridadSucursals.Find(id);
            if (equipoSeguridadSucursal == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEquipoSeguridad = new SelectList(db.EquipoSeguridads, "idEquipoSeguridad", "descripcion", equipoSeguridadSucursal.idEquipoSeguridad);
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo", equipoSeguridadSucursal.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", equipoSeguridadSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", equipoSeguridadSucursal.idUsuarioModifica);
            return View(equipoSeguridadSucursal);
        }

        // POST: EquipoSeguridadSucursals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEquipoSeguridadSucursal,idEquipoSeguridad,idSucursal,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EquipoSeguridadSucursal equipoSeguridadSucursal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipoSeguridadSucursal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEquipoSeguridad = new SelectList(db.EquipoSeguridads, "idEquipoSeguridad", "descripcion", equipoSeguridadSucursal.idEquipoSeguridad);
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo", equipoSeguridadSucursal.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", equipoSeguridadSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", equipoSeguridadSucursal.idUsuarioModifica);
            return View(equipoSeguridadSucursal);
        }

        // GET: EquipoSeguridadSucursals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoSeguridadSucursal equipoSeguridadSucursal = db.EquipoSeguridadSucursals.Find(id);
            if (equipoSeguridadSucursal == null)
            {
                return HttpNotFound();
            }
            return View(equipoSeguridadSucursal);
        }

        // POST: EquipoSeguridadSucursals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EquipoSeguridadSucursal equipoSeguridadSucursal = db.EquipoSeguridadSucursals.Find(id);
            db.EquipoSeguridadSucursals.Remove(equipoSeguridadSucursal);
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
