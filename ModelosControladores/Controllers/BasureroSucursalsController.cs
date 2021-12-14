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
    public class BasureroSucursalsController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: BasureroSucursals
        public ActionResult Index()
        {
            var basureroSucursals = db.BasureroSucursals.Include(b => b.Basurero).Include(b => b.Sucursal).Include(b => b.Usuario).Include(b => b.Usuario1);
            return View(basureroSucursals.ToList());
        }

        // GET: BasureroSucursals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BasureroSucursal basureroSucursal = db.BasureroSucursals.Find(id);
            if (basureroSucursal == null)
            {
                return HttpNotFound();
            }
            return View(basureroSucursal);
        }

        // GET: BasureroSucursals/Create
        public ActionResult Create()
        {
            ViewBag.idBasurero = new SelectList(db.Basureroes, "idBasurero", "tipo");
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: BasureroSucursals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idBasureroSucursal,idBasurero,idSucursal,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] BasureroSucursal basureroSucursal)
        {
            if (ModelState.IsValid)
            {
                db.BasureroSucursals.Add(basureroSucursal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idBasurero = new SelectList(db.Basureroes, "idBasurero", "tipo", basureroSucursal.idBasurero);
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo", basureroSucursal.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", basureroSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", basureroSucursal.idUsuarioModifica);
            return View(basureroSucursal);
        }

        // GET: BasureroSucursals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BasureroSucursal basureroSucursal = db.BasureroSucursals.Find(id);
            if (basureroSucursal == null)
            {
                return HttpNotFound();
            }
            ViewBag.idBasurero = new SelectList(db.Basureroes, "idBasurero", "tipo", basureroSucursal.idBasurero);
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo", basureroSucursal.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", basureroSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", basureroSucursal.idUsuarioModifica);
            return View(basureroSucursal);
        }

        // POST: BasureroSucursals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idBasureroSucursal,idBasurero,idSucursal,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] BasureroSucursal basureroSucursal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(basureroSucursal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idBasurero = new SelectList(db.Basureroes, "idBasurero", "tipo", basureroSucursal.idBasurero);
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo", basureroSucursal.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", basureroSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", basureroSucursal.idUsuarioModifica);
            return View(basureroSucursal);
        }

        // GET: BasureroSucursals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BasureroSucursal basureroSucursal = db.BasureroSucursals.Find(id);
            if (basureroSucursal == null)
            {
                return HttpNotFound();
            }
            return View(basureroSucursal);
        }

        // POST: BasureroSucursals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BasureroSucursal basureroSucursal = db.BasureroSucursals.Find(id);
            db.BasureroSucursals.Remove(basureroSucursal);
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
