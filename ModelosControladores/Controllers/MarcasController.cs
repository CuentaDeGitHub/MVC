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
    public class MarcasController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: Marcas
        public ActionResult Index()
        {
            var marcas = db.Marcas.Include(m => m.Usuario).Include(m => m.Usuario1);
            return View(marcas.ToList());
        }

        // GET: Marcas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marca marca = db.Marcas.Find(id);
            if (marca == null)
            {
                return HttpNotFound();
            }
            return View(marca);
        }

        // GET: Marcas/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: Marcas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMarca,marca1,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Marca marca)
        {
            if (ModelState.IsValid)
            {
                db.Marcas.Add(marca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", marca.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", marca.idUsuarioModifica);
            return View(marca);
        }

        // GET: Marcas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marca marca = db.Marcas.Find(id);
            if (marca == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", marca.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", marca.idUsuarioModifica);
            return View(marca);
        }

        // POST: Marcas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMarca,marca1,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Marca marca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", marca.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", marca.idUsuarioModifica);
            return View(marca);
        }

        // GET: Marcas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marca marca = db.Marcas.Find(id);
            if (marca == null)
            {
                return HttpNotFound();
            }
            return View(marca);
        }

        // POST: Marcas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Marca marca = db.Marcas.Find(id);
            db.Marcas.Remove(marca);
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
