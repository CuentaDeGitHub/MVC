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
    public class PedidoProveedorsController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: PedidoProveedors
        public ActionResult Index()
        {
            var pedidoProveedors = db.PedidoProveedors.Include(p => p.Pedido).Include(p => p.Proveedor).Include(p => p.Usuario).Include(p => p.Usuario1);
            return View(pedidoProveedors.ToList());
        }

        // GET: PedidoProveedors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoProveedor pedidoProveedor = db.PedidoProveedors.Find(id);
            if (pedidoProveedor == null)
            {
                return HttpNotFound();
            }
            return View(pedidoProveedor);
        }

        // GET: PedidoProveedors/Create
        public ActionResult Create()
        {
            ViewBag.idPedido = new SelectList(db.Pedidoes, "idPedido", "idPedido");
            ViewBag.idProveedor = new SelectList(db.Proveedors, "idProveedor", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: PedidoProveedors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPedidoProveedor,idPedido,idProveedor,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] PedidoProveedor pedidoProveedor)
        {
            if (ModelState.IsValid)
            {
                db.PedidoProveedors.Add(pedidoProveedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPedido = new SelectList(db.Pedidoes, "idPedido", "idPedido", pedidoProveedor.idPedido);
            ViewBag.idProveedor = new SelectList(db.Proveedors, "idProveedor", "nombre", pedidoProveedor.idProveedor);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", pedidoProveedor.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", pedidoProveedor.idUsuarioModifica);
            return View(pedidoProveedor);
        }

        // GET: PedidoProveedors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoProveedor pedidoProveedor = db.PedidoProveedors.Find(id);
            if (pedidoProveedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPedido = new SelectList(db.Pedidoes, "idPedido", "idPedido", pedidoProveedor.idPedido);
            ViewBag.idProveedor = new SelectList(db.Proveedors, "idProveedor", "nombre", pedidoProveedor.idProveedor);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", pedidoProveedor.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", pedidoProveedor.idUsuarioModifica);
            return View(pedidoProveedor);
        }

        // POST: PedidoProveedors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPedidoProveedor,idPedido,idProveedor,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] PedidoProveedor pedidoProveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedidoProveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPedido = new SelectList(db.Pedidoes, "idPedido", "idPedido", pedidoProveedor.idPedido);
            ViewBag.idProveedor = new SelectList(db.Proveedors, "idProveedor", "nombre", pedidoProveedor.idProveedor);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", pedidoProveedor.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", pedidoProveedor.idUsuarioModifica);
            return View(pedidoProveedor);
        }

        // GET: PedidoProveedors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoProveedor pedidoProveedor = db.PedidoProveedors.Find(id);
            if (pedidoProveedor == null)
            {
                return HttpNotFound();
            }
            return View(pedidoProveedor);
        }

        // POST: PedidoProveedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PedidoProveedor pedidoProveedor = db.PedidoProveedors.Find(id);
            db.PedidoProveedors.Remove(pedidoProveedor);
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
