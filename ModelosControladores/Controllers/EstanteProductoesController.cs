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
    public class EstanteProductoesController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: EstanteProductoes
        public ActionResult Index()
        {
            var estanteProductoes = db.EstanteProductoes.Include(e => e.Estante).Include(e => e.Producto).Include(e => e.Usuario).Include(e => e.Usuario1);
            return View(estanteProductoes.ToList());
        }

        // GET: EstanteProductoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstanteProducto estanteProducto = db.EstanteProductoes.Find(id);
            if (estanteProducto == null)
            {
                return HttpNotFound();
            }
            return View(estanteProducto);
        }

        // GET: EstanteProductoes/Create
        public ActionResult Create()
        {
            ViewBag.idEstante = new SelectList(db.Estantes, "idEstante", "idEstante");
            ViewBag.idProducto = new SelectList(db.Productoes, "idProducto", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: EstanteProductoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEstanteProducto,idEstante,idProducto,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EstanteProducto estanteProducto)
        {
            if (ModelState.IsValid)
            {
                db.EstanteProductoes.Add(estanteProducto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEstante = new SelectList(db.Estantes, "idEstante", "idEstante", estanteProducto.idEstante);
            ViewBag.idProducto = new SelectList(db.Productoes, "idProducto", "nombre", estanteProducto.idProducto);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", estanteProducto.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", estanteProducto.idUsuarioModifica);
            return View(estanteProducto);
        }

        // GET: EstanteProductoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstanteProducto estanteProducto = db.EstanteProductoes.Find(id);
            if (estanteProducto == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEstante = new SelectList(db.Estantes, "idEstante", "idEstante", estanteProducto.idEstante);
            ViewBag.idProducto = new SelectList(db.Productoes, "idProducto", "nombre", estanteProducto.idProducto);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", estanteProducto.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", estanteProducto.idUsuarioModifica);
            return View(estanteProducto);
        }

        // POST: EstanteProductoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEstanteProducto,idEstante,idProducto,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EstanteProducto estanteProducto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estanteProducto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEstante = new SelectList(db.Estantes, "idEstante", "idEstante", estanteProducto.idEstante);
            ViewBag.idProducto = new SelectList(db.Productoes, "idProducto", "nombre", estanteProducto.idProducto);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", estanteProducto.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", estanteProducto.idUsuarioModifica);
            return View(estanteProducto);
        }

        // GET: EstanteProductoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstanteProducto estanteProducto = db.EstanteProductoes.Find(id);
            if (estanteProducto == null)
            {
                return HttpNotFound();
            }
            return View(estanteProducto);
        }

        // POST: EstanteProductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstanteProducto estanteProducto = db.EstanteProductoes.Find(id);
            db.EstanteProductoes.Remove(estanteProducto);
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
