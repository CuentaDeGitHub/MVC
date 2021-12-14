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
    public class PaginaWebsController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: PaginaWebs
        public ActionResult Index()
        {
            var paginaWebs = db.PaginaWebs.Include(p => p.Usuario).Include(p => p.Usuario1);
            return View(paginaWebs.ToList());
        }

        // GET: PaginaWebs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaginaWeb paginaWeb = db.PaginaWebs.Find(id);
            if (paginaWeb == null)
            {
                return HttpNotFound();
            }
            return View(paginaWeb);
        }

        // GET: PaginaWebs/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: PaginaWebs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPaginaWeb,nombre,dominio,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] PaginaWeb paginaWeb)
        {
            if (ModelState.IsValid)
            {
                db.PaginaWebs.Add(paginaWeb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", paginaWeb.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", paginaWeb.idUsuarioModifica);
            return View(paginaWeb);
        }

        // GET: PaginaWebs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaginaWeb paginaWeb = db.PaginaWebs.Find(id);
            if (paginaWeb == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", paginaWeb.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", paginaWeb.idUsuarioModifica);
            return View(paginaWeb);
        }

        // POST: PaginaWebs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPaginaWeb,nombre,dominio,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] PaginaWeb paginaWeb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paginaWeb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", paginaWeb.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", paginaWeb.idUsuarioModifica);
            return View(paginaWeb);
        }

        // GET: PaginaWebs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaginaWeb paginaWeb = db.PaginaWebs.Find(id);
            if (paginaWeb == null)
            {
                return HttpNotFound();
            }
            return View(paginaWeb);
        }

        // POST: PaginaWebs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PaginaWeb paginaWeb = db.PaginaWebs.Find(id);
            db.PaginaWebs.Remove(paginaWeb);
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
