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
    public class TipoDeServiciosController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: TipoDeServicios
        public ActionResult Index()
        {
            var tipoDeServicios = db.TipoDeServicios.Include(t => t.Usuario).Include(t => t.Usuario1);
            return View(tipoDeServicios.ToList());
        }

        // GET: TipoDeServicios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeServicio tipoDeServicio = db.TipoDeServicios.Find(id);
            if (tipoDeServicio == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeServicio);
        }

        // GET: TipoDeServicios/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: TipoDeServicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoDeServicio,descripcion,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoDeServicio tipoDeServicio)
        {
            if (ModelState.IsValid)
            {
                db.TipoDeServicios.Add(tipoDeServicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDeServicio.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDeServicio.idUsuarioModifica);
            return View(tipoDeServicio);
        }

        // GET: TipoDeServicios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeServicio tipoDeServicio = db.TipoDeServicios.Find(id);
            if (tipoDeServicio == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDeServicio.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDeServicio.idUsuarioModifica);
            return View(tipoDeServicio);
        }

        // POST: TipoDeServicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoDeServicio,descripcion,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoDeServicio tipoDeServicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDeServicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDeServicio.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDeServicio.idUsuarioModifica);
            return View(tipoDeServicio);
        }

        // GET: TipoDeServicios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeServicio tipoDeServicio = db.TipoDeServicios.Find(id);
            if (tipoDeServicio == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeServicio);
        }

        // POST: TipoDeServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoDeServicio tipoDeServicio = db.TipoDeServicios.Find(id);
            db.TipoDeServicios.Remove(tipoDeServicio);
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
