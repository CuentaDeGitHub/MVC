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
    public class ProveedorPedidoesController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: ProveedorPedidoes
        public ActionResult Index()
        {
            var proveedorPedidoes = db.ProveedorPedidoes.Include(p => p.Pedido).Include(p => p.Proveedor).Include(p => p.Usuario).Include(p => p.Usuario1);
            return View(proveedorPedidoes.ToList());
        }

        // GET: ProveedorPedidoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProveedorPedido proveedorPedido = db.ProveedorPedidoes.Find(id);
            if (proveedorPedido == null)
            {
                return HttpNotFound();
            }
            return View(proveedorPedido);
        }

        // GET: ProveedorPedidoes/Create
        public ActionResult Create()
        {
            ViewBag.idPedido = new SelectList(db.Pedidoes, "idPedido", "idPedido");
            ViewBag.idProveedor = new SelectList(db.Proveedors, "idProveedor", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: ProveedorPedidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProveedorPedido,idProveedor,idPedido,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] ProveedorPedido proveedorPedido)
        {
            if (ModelState.IsValid)
            {
                db.ProveedorPedidoes.Add(proveedorPedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPedido = new SelectList(db.Pedidoes, "idPedido", "idPedido", proveedorPedido.idPedido);
            ViewBag.idProveedor = new SelectList(db.Proveedors, "idProveedor", "nombre", proveedorPedido.idProveedor);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", proveedorPedido.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", proveedorPedido.idUsuarioModifica);
            return View(proveedorPedido);
        }

        // GET: ProveedorPedidoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProveedorPedido proveedorPedido = db.ProveedorPedidoes.Find(id);
            if (proveedorPedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPedido = new SelectList(db.Pedidoes, "idPedido", "idPedido", proveedorPedido.idPedido);
            ViewBag.idProveedor = new SelectList(db.Proveedors, "idProveedor", "nombre", proveedorPedido.idProveedor);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", proveedorPedido.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", proveedorPedido.idUsuarioModifica);
            return View(proveedorPedido);
        }

        // POST: ProveedorPedidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProveedorPedido,idProveedor,idPedido,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] ProveedorPedido proveedorPedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proveedorPedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPedido = new SelectList(db.Pedidoes, "idPedido", "idPedido", proveedorPedido.idPedido);
            ViewBag.idProveedor = new SelectList(db.Proveedors, "idProveedor", "nombre", proveedorPedido.idProveedor);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", proveedorPedido.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", proveedorPedido.idUsuarioModifica);
            return View(proveedorPedido);
        }

        // GET: ProveedorPedidoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProveedorPedido proveedorPedido = db.ProveedorPedidoes.Find(id);
            if (proveedorPedido == null)
            {
                return HttpNotFound();
            }
            return View(proveedorPedido);
        }

        // POST: ProveedorPedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProveedorPedido proveedorPedido = db.ProveedorPedidoes.Find(id);
            db.ProveedorPedidoes.Remove(proveedorPedido);
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
