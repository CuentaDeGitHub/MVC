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
    public class LucesSucursalsController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: LucesSucursals
        public ActionResult Index()
        {
            var lucesSucursals = db.LucesSucursals.Include(l => l.Luce).Include(l => l.Sucursal).Include(l => l.Usuario).Include(l => l.Usuario1);
            return View(lucesSucursals.ToList());
        }

        // GET: LucesSucursals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LucesSucursal lucesSucursal = db.LucesSucursals.Find(id);
            if (lucesSucursal == null)
            {
                return HttpNotFound();
            }
            return View(lucesSucursal);
        }

        // GET: LucesSucursals/Create
        public ActionResult Create()
        {
            ViewBag.idLuces = new SelectList(db.Luces, "idLuces", "tipo");
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: LucesSucursals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idLucesSucursal,idLuces,idSucursal,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] LucesSucursal lucesSucursal)
        {
            if (ModelState.IsValid)
            {
                db.LucesSucursals.Add(lucesSucursal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idLuces = new SelectList(db.Luces, "idLuces", "tipo", lucesSucursal.idLuces);
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo", lucesSucursal.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", lucesSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", lucesSucursal.idUsuarioModifica);
            return View(lucesSucursal);
        }

        // GET: LucesSucursals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LucesSucursal lucesSucursal = db.LucesSucursals.Find(id);
            if (lucesSucursal == null)
            {
                return HttpNotFound();
            }
            ViewBag.idLuces = new SelectList(db.Luces, "idLuces", "tipo", lucesSucursal.idLuces);
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo", lucesSucursal.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", lucesSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", lucesSucursal.idUsuarioModifica);
            return View(lucesSucursal);
        }

        // POST: LucesSucursals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idLucesSucursal,idLuces,idSucursal,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] LucesSucursal lucesSucursal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lucesSucursal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idLuces = new SelectList(db.Luces, "idLuces", "tipo", lucesSucursal.idLuces);
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo", lucesSucursal.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", lucesSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", lucesSucursal.idUsuarioModifica);
            return View(lucesSucursal);
        }

        // GET: LucesSucursals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LucesSucursal lucesSucursal = db.LucesSucursals.Find(id);
            if (lucesSucursal == null)
            {
                return HttpNotFound();
            }
            return View(lucesSucursal);
        }

        // POST: LucesSucursals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LucesSucursal lucesSucursal = db.LucesSucursals.Find(id);
            db.LucesSucursals.Remove(lucesSucursal);
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
