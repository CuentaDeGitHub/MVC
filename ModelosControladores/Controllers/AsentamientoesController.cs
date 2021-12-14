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
    public class AsentamientoesController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: Asentamientoes
        public ActionResult Index()
        {
            var asentamientoes = db.Asentamientoes.Include(a => a.Municipio).Include(a => a.TipoDeAsentamiento).Include(a => a.Usuario).Include(a => a.Usuario1).Include(a => a.Zona);
            return View(asentamientoes.ToList());
        }

        // GET: Asentamientoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asentamiento asentamiento = db.Asentamientoes.Find(id);
            if (asentamiento == null)
            {
                return HttpNotFound();
            }
            return View(asentamiento);
        }

        // GET: Asentamientoes/Create
        public ActionResult Create()
        {
            ViewBag.idMunicipio = new SelectList(db.Municipios, "idMunicipio", "codigo");
            ViewBag.idTipoDeAsentamiento = new SelectList(db.TipoDeAsentamientoes, "idTipoDeAsentamiento", "tipo");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idZona = new SelectList(db.Zonas, "idZona", "nombre");
            return View();
        }

        // POST: Asentamientoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAsentamiento,id,descripcion,codigoPostal,idTipoDeAsentamiento,idMunicipio,idZona,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Asentamiento asentamiento)
        {
            if (ModelState.IsValid)
            {
                db.Asentamientoes.Add(asentamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idMunicipio = new SelectList(db.Municipios, "idMunicipio", "codigo", asentamiento.idMunicipio);
            ViewBag.idTipoDeAsentamiento = new SelectList(db.TipoDeAsentamientoes, "idTipoDeAsentamiento", "tipo", asentamiento.idTipoDeAsentamiento);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", asentamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", asentamiento.idUsuarioModifica);
            ViewBag.idZona = new SelectList(db.Zonas, "idZona", "nombre", asentamiento.idZona);
            return View(asentamiento);
        }

        // GET: Asentamientoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asentamiento asentamiento = db.Asentamientoes.Find(id);
            if (asentamiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.idMunicipio = new SelectList(db.Municipios, "idMunicipio", "codigo", asentamiento.idMunicipio);
            ViewBag.idTipoDeAsentamiento = new SelectList(db.TipoDeAsentamientoes, "idTipoDeAsentamiento", "tipo", asentamiento.idTipoDeAsentamiento);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", asentamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", asentamiento.idUsuarioModifica);
            ViewBag.idZona = new SelectList(db.Zonas, "idZona", "nombre", asentamiento.idZona);
            return View(asentamiento);
        }

        // POST: Asentamientoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAsentamiento,id,descripcion,codigoPostal,idTipoDeAsentamiento,idMunicipio,idZona,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Asentamiento asentamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asentamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idMunicipio = new SelectList(db.Municipios, "idMunicipio", "codigo", asentamiento.idMunicipio);
            ViewBag.idTipoDeAsentamiento = new SelectList(db.TipoDeAsentamientoes, "idTipoDeAsentamiento", "tipo", asentamiento.idTipoDeAsentamiento);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", asentamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", asentamiento.idUsuarioModifica);
            ViewBag.idZona = new SelectList(db.Zonas, "idZona", "nombre", asentamiento.idZona);
            return View(asentamiento);
        }

        // GET: Asentamientoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asentamiento asentamiento = db.Asentamientoes.Find(id);
            if (asentamiento == null)
            {
                return HttpNotFound();
            }
            return View(asentamiento);
        }

        // POST: Asentamientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asentamiento asentamiento = db.Asentamientoes.Find(id);
            db.Asentamientoes.Remove(asentamiento);
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
