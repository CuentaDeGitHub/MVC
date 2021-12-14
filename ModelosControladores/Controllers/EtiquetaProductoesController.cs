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
    public class EtiquetaProductoesController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: EtiquetaProductoes
        public ActionResult Index()
        {
            var etiquetaProductoes = db.EtiquetaProductoes.Include(e => e.Etiqueta).Include(e => e.Producto).Include(e => e.Usuario).Include(e => e.Usuario1);
            return View(etiquetaProductoes.ToList());
        }

        // GET: EtiquetaProductoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EtiquetaProducto etiquetaProducto = db.EtiquetaProductoes.Find(id);
            if (etiquetaProducto == null)
            {
                return HttpNotFound();
            }
            return View(etiquetaProducto);
        }

        // GET: EtiquetaProductoes/Create
        public ActionResult Create()
        {
            ViewBag.idEtiqueta = new SelectList(db.Etiquetas, "idEtiqueta", "codigo");
            ViewBag.idProducto = new SelectList(db.Productoes, "idProducto", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: EtiquetaProductoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEtiquetaProducto,idEtiqueta,idProducto,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EtiquetaProducto etiquetaProducto)
        {
            if (ModelState.IsValid)
            {
                db.EtiquetaProductoes.Add(etiquetaProducto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEtiqueta = new SelectList(db.Etiquetas, "idEtiqueta", "codigo", etiquetaProducto.idEtiqueta);
            ViewBag.idProducto = new SelectList(db.Productoes, "idProducto", "nombre", etiquetaProducto.idProducto);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", etiquetaProducto.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", etiquetaProducto.idUsuarioModifica);
            return View(etiquetaProducto);
        }

        // GET: EtiquetaProductoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EtiquetaProducto etiquetaProducto = db.EtiquetaProductoes.Find(id);
            if (etiquetaProducto == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEtiqueta = new SelectList(db.Etiquetas, "idEtiqueta", "codigo", etiquetaProducto.idEtiqueta);
            ViewBag.idProducto = new SelectList(db.Productoes, "idProducto", "nombre", etiquetaProducto.idProducto);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", etiquetaProducto.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", etiquetaProducto.idUsuarioModifica);
            return View(etiquetaProducto);
        }

        // POST: EtiquetaProductoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEtiquetaProducto,idEtiqueta,idProducto,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EtiquetaProducto etiquetaProducto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etiquetaProducto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEtiqueta = new SelectList(db.Etiquetas, "idEtiqueta", "codigo", etiquetaProducto.idEtiqueta);
            ViewBag.idProducto = new SelectList(db.Productoes, "idProducto", "nombre", etiquetaProducto.idProducto);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", etiquetaProducto.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", etiquetaProducto.idUsuarioModifica);
            return View(etiquetaProducto);
        }

        // GET: EtiquetaProductoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EtiquetaProducto etiquetaProducto = db.EtiquetaProductoes.Find(id);
            if (etiquetaProducto == null)
            {
                return HttpNotFound();
            }
            return View(etiquetaProducto);
        }

        // POST: EtiquetaProductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EtiquetaProducto etiquetaProducto = db.EtiquetaProductoes.Find(id);
            db.EtiquetaProductoes.Remove(etiquetaProducto);
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
