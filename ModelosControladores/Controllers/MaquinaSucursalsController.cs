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
    public class MaquinaSucursalsController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: MaquinaSucursals
        public ActionResult Index()
        {
            var maquinaSucursals = db.MaquinaSucursals.Include(m => m.Maquina).Include(m => m.Sucursal).Include(m => m.Usuario).Include(m => m.Usuario1);
            return View(maquinaSucursals.ToList());
        }

        // GET: MaquinaSucursals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaquinaSucursal maquinaSucursal = db.MaquinaSucursals.Find(id);
            if (maquinaSucursal == null)
            {
                return HttpNotFound();
            }
            return View(maquinaSucursal);
        }

        // GET: MaquinaSucursals/Create
        public ActionResult Create()
        {
            ViewBag.idMaquina = new SelectList(db.Maquinas, "idMaquina", "fabricante");
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: MaquinaSucursals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMaquinaSucursal,idMaquina,idSucursal,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] MaquinaSucursal maquinaSucursal)
        {
            if (ModelState.IsValid)
            {
                db.MaquinaSucursals.Add(maquinaSucursal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idMaquina = new SelectList(db.Maquinas, "idMaquina", "fabricante", maquinaSucursal.idMaquina);
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo", maquinaSucursal.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", maquinaSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", maquinaSucursal.idUsuarioModifica);
            return View(maquinaSucursal);
        }

        // GET: MaquinaSucursals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaquinaSucursal maquinaSucursal = db.MaquinaSucursals.Find(id);
            if (maquinaSucursal == null)
            {
                return HttpNotFound();
            }
            ViewBag.idMaquina = new SelectList(db.Maquinas, "idMaquina", "fabricante", maquinaSucursal.idMaquina);
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo", maquinaSucursal.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", maquinaSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", maquinaSucursal.idUsuarioModifica);
            return View(maquinaSucursal);
        }

        // POST: MaquinaSucursals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMaquinaSucursal,idMaquina,idSucursal,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] MaquinaSucursal maquinaSucursal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maquinaSucursal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idMaquina = new SelectList(db.Maquinas, "idMaquina", "fabricante", maquinaSucursal.idMaquina);
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo", maquinaSucursal.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", maquinaSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", maquinaSucursal.idUsuarioModifica);
            return View(maquinaSucursal);
        }

        // GET: MaquinaSucursals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaquinaSucursal maquinaSucursal = db.MaquinaSucursals.Find(id);
            if (maquinaSucursal == null)
            {
                return HttpNotFound();
            }
            return View(maquinaSucursal);
        }

        // POST: MaquinaSucursals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MaquinaSucursal maquinaSucursal = db.MaquinaSucursals.Find(id);
            db.MaquinaSucursals.Remove(maquinaSucursal);
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
