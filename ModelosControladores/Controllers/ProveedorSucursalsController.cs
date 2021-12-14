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
    public class ProveedorSucursalsController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: ProveedorSucursals
        public ActionResult Index()
        {
            var proveedorSucursals = db.ProveedorSucursals.Include(p => p.Proveedor).Include(p => p.Usuario).Include(p => p.Usuario1);
            return View(proveedorSucursals.ToList());
        }

        // GET: ProveedorSucursals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProveedorSucursal proveedorSucursal = db.ProveedorSucursals.Find(id);
            if (proveedorSucursal == null)
            {
                return HttpNotFound();
            }
            return View(proveedorSucursal);
        }

        // GET: ProveedorSucursals/Create
        public ActionResult Create()
        {
            ViewBag.idProveedor = new SelectList(db.Proveedors, "idProveedor", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: ProveedorSucursals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProveedorSucursal,idProveedor,idSucursal,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] ProveedorSucursal proveedorSucursal)
        {
            if (ModelState.IsValid)
            {
                db.ProveedorSucursals.Add(proveedorSucursal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idProveedor = new SelectList(db.Proveedors, "idProveedor", "nombre", proveedorSucursal.idProveedor);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", proveedorSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", proveedorSucursal.idUsuarioModifica);
            return View(proveedorSucursal);
        }

        // GET: ProveedorSucursals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProveedorSucursal proveedorSucursal = db.ProveedorSucursals.Find(id);
            if (proveedorSucursal == null)
            {
                return HttpNotFound();
            }
            ViewBag.idProveedor = new SelectList(db.Proveedors, "idProveedor", "nombre", proveedorSucursal.idProveedor);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", proveedorSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", proveedorSucursal.idUsuarioModifica);
            return View(proveedorSucursal);
        }

        // POST: ProveedorSucursals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProveedorSucursal,idProveedor,idSucursal,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] ProveedorSucursal proveedorSucursal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proveedorSucursal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idProveedor = new SelectList(db.Proveedors, "idProveedor", "nombre", proveedorSucursal.idProveedor);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", proveedorSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", proveedorSucursal.idUsuarioModifica);
            return View(proveedorSucursal);
        }

        // GET: ProveedorSucursals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProveedorSucursal proveedorSucursal = db.ProveedorSucursals.Find(id);
            if (proveedorSucursal == null)
            {
                return HttpNotFound();
            }
            return View(proveedorSucursal);
        }

        // POST: ProveedorSucursals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProveedorSucursal proveedorSucursal = db.ProveedorSucursals.Find(id);
            db.ProveedorSucursals.Remove(proveedorSucursal);
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
