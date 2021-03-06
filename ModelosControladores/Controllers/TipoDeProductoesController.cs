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
    public class TipoDeProductoesController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: TipoDeProductoes
        public ActionResult Index()
        {
            var tipoDeProductoes = db.TipoDeProductoes.Include(t => t.Usuario).Include(t => t.Usuario1);
            return View(tipoDeProductoes.ToList());
        }

        // GET: TipoDeProductoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeProducto tipoDeProducto = db.TipoDeProductoes.Find(id);
            if (tipoDeProducto == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeProducto);
        }

        // GET: TipoDeProductoes/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: TipoDeProductoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoDeProducto,tipo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoDeProducto tipoDeProducto)
        {
            if (ModelState.IsValid)
            {
                db.TipoDeProductoes.Add(tipoDeProducto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDeProducto.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDeProducto.idUsuarioModifica);
            return View(tipoDeProducto);
        }

        // GET: TipoDeProductoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeProducto tipoDeProducto = db.TipoDeProductoes.Find(id);
            if (tipoDeProducto == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDeProducto.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDeProducto.idUsuarioModifica);
            return View(tipoDeProducto);
        }

        // POST: TipoDeProductoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoDeProducto,tipo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoDeProducto tipoDeProducto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDeProducto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDeProducto.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", tipoDeProducto.idUsuarioModifica);
            return View(tipoDeProducto);
        }

        // GET: TipoDeProductoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeProducto tipoDeProducto = db.TipoDeProductoes.Find(id);
            if (tipoDeProducto == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeProducto);
        }

        // POST: TipoDeProductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoDeProducto tipoDeProducto = db.TipoDeProductoes.Find(id);
            db.TipoDeProductoes.Remove(tipoDeProducto);
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
