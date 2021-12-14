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
    public class BolsaSucursalsController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: BolsaSucursals
        public ActionResult Index()
        {
            var bolsaSucursals = db.BolsaSucursals.Include(b => b.Bolsa).Include(b => b.Sucursal).Include(b => b.Usuario).Include(b => b.Usuario1);
            return View(bolsaSucursals.ToList());
        }

        // GET: BolsaSucursals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BolsaSucursal bolsaSucursal = db.BolsaSucursals.Find(id);
            if (bolsaSucursal == null)
            {
                return HttpNotFound();
            }
            return View(bolsaSucursal);
        }

        // GET: BolsaSucursals/Create
        public ActionResult Create()
        {
            ViewBag.idBolsa = new SelectList(db.Bolsas, "idBolsa", "material");
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: BolsaSucursals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idBolsaSucursal,idBolsa,idSucursal,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] BolsaSucursal bolsaSucursal)
        {
            if (ModelState.IsValid)
            {
                db.BolsaSucursals.Add(bolsaSucursal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idBolsa = new SelectList(db.Bolsas, "idBolsa", "material", bolsaSucursal.idBolsa);
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo", bolsaSucursal.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", bolsaSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", bolsaSucursal.idUsuarioModifica);
            return View(bolsaSucursal);
        }

        // GET: BolsaSucursals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BolsaSucursal bolsaSucursal = db.BolsaSucursals.Find(id);
            if (bolsaSucursal == null)
            {
                return HttpNotFound();
            }
            ViewBag.idBolsa = new SelectList(db.Bolsas, "idBolsa", "material", bolsaSucursal.idBolsa);
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo", bolsaSucursal.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", bolsaSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", bolsaSucursal.idUsuarioModifica);
            return View(bolsaSucursal);
        }

        // POST: BolsaSucursals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idBolsaSucursal,idBolsa,idSucursal,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] BolsaSucursal bolsaSucursal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bolsaSucursal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idBolsa = new SelectList(db.Bolsas, "idBolsa", "material", bolsaSucursal.idBolsa);
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo", bolsaSucursal.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", bolsaSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", bolsaSucursal.idUsuarioModifica);
            return View(bolsaSucursal);
        }

        // GET: BolsaSucursals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BolsaSucursal bolsaSucursal = db.BolsaSucursals.Find(id);
            if (bolsaSucursal == null)
            {
                return HttpNotFound();
            }
            return View(bolsaSucursal);
        }

        // POST: BolsaSucursals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BolsaSucursal bolsaSucursal = db.BolsaSucursals.Find(id);
            db.BolsaSucursals.Remove(bolsaSucursal);
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
