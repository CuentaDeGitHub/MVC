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
    public class EquipoVigilanciadSucursalsController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: EquipoVigilanciadSucursals
        public ActionResult Index()
        {
            var equipoVigilanciadSucursals = db.EquipoVigilanciadSucursals.Include(e => e.EquipoVigilancia).Include(e => e.Sucursal).Include(e => e.Usuario).Include(e => e.Usuario1);
            return View(equipoVigilanciadSucursals.ToList());
        }

        // GET: EquipoVigilanciadSucursals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoVigilanciadSucursal equipoVigilanciadSucursal = db.EquipoVigilanciadSucursals.Find(id);
            if (equipoVigilanciadSucursal == null)
            {
                return HttpNotFound();
            }
            return View(equipoVigilanciadSucursal);
        }

        // GET: EquipoVigilanciadSucursals/Create
        public ActionResult Create()
        {
            ViewBag.idEquipoVigilancia = new SelectList(db.EquipoVigilancias, "idEquipoVigilancia", "descripcion");
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: EquipoVigilanciadSucursals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEquipoVigilanciadSucursal,idEquipoVigilancia,idSucursal,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EquipoVigilanciadSucursal equipoVigilanciadSucursal)
        {
            if (ModelState.IsValid)
            {
                db.EquipoVigilanciadSucursals.Add(equipoVigilanciadSucursal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEquipoVigilancia = new SelectList(db.EquipoVigilancias, "idEquipoVigilancia", "descripcion", equipoVigilanciadSucursal.idEquipoVigilancia);
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo", equipoVigilanciadSucursal.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", equipoVigilanciadSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", equipoVigilanciadSucursal.idUsuarioModifica);
            return View(equipoVigilanciadSucursal);
        }

        // GET: EquipoVigilanciadSucursals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoVigilanciadSucursal equipoVigilanciadSucursal = db.EquipoVigilanciadSucursals.Find(id);
            if (equipoVigilanciadSucursal == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEquipoVigilancia = new SelectList(db.EquipoVigilancias, "idEquipoVigilancia", "descripcion", equipoVigilanciadSucursal.idEquipoVigilancia);
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo", equipoVigilanciadSucursal.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", equipoVigilanciadSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", equipoVigilanciadSucursal.idUsuarioModifica);
            return View(equipoVigilanciadSucursal);
        }

        // POST: EquipoVigilanciadSucursals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEquipoVigilanciadSucursal,idEquipoVigilancia,idSucursal,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EquipoVigilanciadSucursal equipoVigilanciadSucursal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipoVigilanciadSucursal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEquipoVigilancia = new SelectList(db.EquipoVigilancias, "idEquipoVigilancia", "descripcion", equipoVigilanciadSucursal.idEquipoVigilancia);
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo", equipoVigilanciadSucursal.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", equipoVigilanciadSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", equipoVigilanciadSucursal.idUsuarioModifica);
            return View(equipoVigilanciadSucursal);
        }

        // GET: EquipoVigilanciadSucursals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoVigilanciadSucursal equipoVigilanciadSucursal = db.EquipoVigilanciadSucursals.Find(id);
            if (equipoVigilanciadSucursal == null)
            {
                return HttpNotFound();
            }
            return View(equipoVigilanciadSucursal);
        }

        // POST: EquipoVigilanciadSucursals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EquipoVigilanciadSucursal equipoVigilanciadSucursal = db.EquipoVigilanciadSucursals.Find(id);
            db.EquipoVigilanciadSucursals.Remove(equipoVigilanciadSucursal);
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
