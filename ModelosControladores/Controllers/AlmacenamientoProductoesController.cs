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
    public class AlmacenamientoProductoesController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: AlmacenamientoProductoes
        public ActionResult Index()
        {
            var almacenamientoProductoes = db.AlmacenamientoProductoes.Include(a => a.Almacenamiento).Include(a => a.Producto).Include(a => a.Usuario).Include(a => a.Usuario1);
            return View(almacenamientoProductoes.ToList());
        }

        // GET: AlmacenamientoProductoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlmacenamientoProducto almacenamientoProducto = db.AlmacenamientoProductoes.Find(id);
            if (almacenamientoProducto == null)
            {
                return HttpNotFound();
            }
            return View(almacenamientoProducto);
        }

        // GET: AlmacenamientoProductoes/Create
        public ActionResult Create()
        {
            ViewBag.idAlmacenamiento = new SelectList(db.Almacenamientoes, "idAlmacenamiento", "descripcion");
            ViewBag.idProducto = new SelectList(db.Productoes, "idProducto", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: AlmacenamientoProductoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAlmacenamientoProducto,idAlmacenamiento,idProducto,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] AlmacenamientoProducto almacenamientoProducto)
        {
            if (ModelState.IsValid)
            {
                db.AlmacenamientoProductoes.Add(almacenamientoProducto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAlmacenamiento = new SelectList(db.Almacenamientoes, "idAlmacenamiento", "descripcion", almacenamientoProducto.idAlmacenamiento);
            ViewBag.idProducto = new SelectList(db.Productoes, "idProducto", "nombre", almacenamientoProducto.idProducto);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", almacenamientoProducto.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", almacenamientoProducto.idUsuarioModifica);
            return View(almacenamientoProducto);
        }

        // GET: AlmacenamientoProductoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlmacenamientoProducto almacenamientoProducto = db.AlmacenamientoProductoes.Find(id);
            if (almacenamientoProducto == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAlmacenamiento = new SelectList(db.Almacenamientoes, "idAlmacenamiento", "descripcion", almacenamientoProducto.idAlmacenamiento);
            ViewBag.idProducto = new SelectList(db.Productoes, "idProducto", "nombre", almacenamientoProducto.idProducto);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", almacenamientoProducto.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", almacenamientoProducto.idUsuarioModifica);
            return View(almacenamientoProducto);
        }

        // POST: AlmacenamientoProductoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAlmacenamientoProducto,idAlmacenamiento,idProducto,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] AlmacenamientoProducto almacenamientoProducto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(almacenamientoProducto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAlmacenamiento = new SelectList(db.Almacenamientoes, "idAlmacenamiento", "descripcion", almacenamientoProducto.idAlmacenamiento);
            ViewBag.idProducto = new SelectList(db.Productoes, "idProducto", "nombre", almacenamientoProducto.idProducto);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", almacenamientoProducto.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", almacenamientoProducto.idUsuarioModifica);
            return View(almacenamientoProducto);
        }

        // GET: AlmacenamientoProductoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlmacenamientoProducto almacenamientoProducto = db.AlmacenamientoProductoes.Find(id);
            if (almacenamientoProducto == null)
            {
                return HttpNotFound();
            }
            return View(almacenamientoProducto);
        }

        // POST: AlmacenamientoProductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlmacenamientoProducto almacenamientoProducto = db.AlmacenamientoProductoes.Find(id);
            db.AlmacenamientoProductoes.Remove(almacenamientoProducto);
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
