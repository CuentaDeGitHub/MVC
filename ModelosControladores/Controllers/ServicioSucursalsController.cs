﻿using System;
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
    public class ServicioSucursalsController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: ServicioSucursals
        public ActionResult Index()
        {
            var servicioSucursals = db.ServicioSucursals.Include(s => s.Servicio).Include(s => s.Sucursal).Include(s => s.Usuario).Include(s => s.Usuario1);
            return View(servicioSucursals.ToList());
        }

        // GET: ServicioSucursals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicioSucursal servicioSucursal = db.ServicioSucursals.Find(id);
            if (servicioSucursal == null)
            {
                return HttpNotFound();
            }
            return View(servicioSucursal);
        }

        // GET: ServicioSucursals/Create
        public ActionResult Create()
        {
            ViewBag.idServicio = new SelectList(db.Servicios, "idServicio", "numeroDeReferencia");
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: ServicioSucursals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idServicioSucursal,idServicio,idSucursal,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] ServicioSucursal servicioSucursal)
        {
            if (ModelState.IsValid)
            {
                db.ServicioSucursals.Add(servicioSucursal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idServicio = new SelectList(db.Servicios, "idServicio", "numeroDeReferencia", servicioSucursal.idServicio);
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo", servicioSucursal.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", servicioSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", servicioSucursal.idUsuarioModifica);
            return View(servicioSucursal);
        }

        // GET: ServicioSucursals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicioSucursal servicioSucursal = db.ServicioSucursals.Find(id);
            if (servicioSucursal == null)
            {
                return HttpNotFound();
            }
            ViewBag.idServicio = new SelectList(db.Servicios, "idServicio", "numeroDeReferencia", servicioSucursal.idServicio);
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo", servicioSucursal.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", servicioSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", servicioSucursal.idUsuarioModifica);
            return View(servicioSucursal);
        }

        // POST: ServicioSucursals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idServicioSucursal,idServicio,idSucursal,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] ServicioSucursal servicioSucursal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicioSucursal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idServicio = new SelectList(db.Servicios, "idServicio", "numeroDeReferencia", servicioSucursal.idServicio);
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo", servicioSucursal.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", servicioSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", servicioSucursal.idUsuarioModifica);
            return View(servicioSucursal);
        }

        // GET: ServicioSucursals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicioSucursal servicioSucursal = db.ServicioSucursals.Find(id);
            if (servicioSucursal == null)
            {
                return HttpNotFound();
            }
            return View(servicioSucursal);
        }

        // POST: ServicioSucursals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServicioSucursal servicioSucursal = db.ServicioSucursals.Find(id);
            db.ServicioSucursals.Remove(servicioSucursal);
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
