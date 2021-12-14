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
    public class SucursalsController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: Sucursals
        public ActionResult Index()
        {
            var sucursals = db.Sucursals.Include(s => s.Asentamiento).Include(s => s.Bodega).Include(s => s.Estacionamiento).Include(s => s.Oficina).Include(s => s.SalidaDeEmergencia).Include(s => s.Usuario).Include(s => s.Usuario1);
            return View(sucursals.ToList());
        }

        // GET: Sucursals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucursal sucursal = db.Sucursals.Find(id);
            if (sucursal == null)
            {
                return HttpNotFound();
            }
            return View(sucursal);
        }

        // GET: Sucursals/Create
        public ActionResult Create()
        {
            ViewBag.idAsentamiento = new SelectList(db.Asentamientoes, "idAsentamiento", "descripcion");
            ViewBag.idBodega = new SelectList(db.Bodegas, "idBodega", "codigo");
            ViewBag.idEstacionamiento = new SelectList(db.Estacionamientoes, "idEstacionamiento", "idEstacionamiento");
            ViewBag.idOficina = new SelectList(db.Oficinas, "idOficina", "nombre");
            ViewBag.idSalidaDeEmergencia = new SelectList(db.SalidaDeEmergencias, "idSalidaDeEmergencia", "ubicacion");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: Sucursals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSucursal,codigo,idAsentamiento,idBodega,idOficina,idSalidaDeEmergencia,idEstacionamiento,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Sucursal sucursal)
        {
            if (ModelState.IsValid)
            {
                db.Sucursals.Add(sucursal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAsentamiento = new SelectList(db.Asentamientoes, "idAsentamiento", "descripcion", sucursal.idAsentamiento);
            ViewBag.idBodega = new SelectList(db.Bodegas, "idBodega", "codigo", sucursal.idBodega);
            ViewBag.idEstacionamiento = new SelectList(db.Estacionamientoes, "idEstacionamiento", "idEstacionamiento", sucursal.idEstacionamiento);
            ViewBag.idOficina = new SelectList(db.Oficinas, "idOficina", "nombre", sucursal.idOficina);
            ViewBag.idSalidaDeEmergencia = new SelectList(db.SalidaDeEmergencias, "idSalidaDeEmergencia", "ubicacion", sucursal.idSalidaDeEmergencia);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", sucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", sucursal.idUsuarioModifica);
            return View(sucursal);
        }

        // GET: Sucursals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucursal sucursal = db.Sucursals.Find(id);
            if (sucursal == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAsentamiento = new SelectList(db.Asentamientoes, "idAsentamiento", "descripcion", sucursal.idAsentamiento);
            ViewBag.idBodega = new SelectList(db.Bodegas, "idBodega", "codigo", sucursal.idBodega);
            ViewBag.idEstacionamiento = new SelectList(db.Estacionamientoes, "idEstacionamiento", "idEstacionamiento", sucursal.idEstacionamiento);
            ViewBag.idOficina = new SelectList(db.Oficinas, "idOficina", "nombre", sucursal.idOficina);
            ViewBag.idSalidaDeEmergencia = new SelectList(db.SalidaDeEmergencias, "idSalidaDeEmergencia", "ubicacion", sucursal.idSalidaDeEmergencia);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", sucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", sucursal.idUsuarioModifica);
            return View(sucursal);
        }

        // POST: Sucursals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSucursal,codigo,idAsentamiento,idBodega,idOficina,idSalidaDeEmergencia,idEstacionamiento,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Sucursal sucursal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sucursal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAsentamiento = new SelectList(db.Asentamientoes, "idAsentamiento", "descripcion", sucursal.idAsentamiento);
            ViewBag.idBodega = new SelectList(db.Bodegas, "idBodega", "codigo", sucursal.idBodega);
            ViewBag.idEstacionamiento = new SelectList(db.Estacionamientoes, "idEstacionamiento", "idEstacionamiento", sucursal.idEstacionamiento);
            ViewBag.idOficina = new SelectList(db.Oficinas, "idOficina", "nombre", sucursal.idOficina);
            ViewBag.idSalidaDeEmergencia = new SelectList(db.SalidaDeEmergencias, "idSalidaDeEmergencia", "ubicacion", sucursal.idSalidaDeEmergencia);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", sucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", sucursal.idUsuarioModifica);
            return View(sucursal);
        }

        // GET: Sucursals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucursal sucursal = db.Sucursals.Find(id);
            if (sucursal == null)
            {
                return HttpNotFound();
            }
            return View(sucursal);
        }

        // POST: Sucursals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sucursal sucursal = db.Sucursals.Find(id);
            db.Sucursals.Remove(sucursal);
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
