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
    public class TransaccionsController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: Transaccions
        public ActionResult Index()
        {
            var transaccions = db.Transaccions.Include(t => t.MetodoDePago).Include(t => t.Producto).Include(t => t.Servicio).Include(t => t.TipoDeTransaccion).Include(t => t.Usuario).Include(t => t.Usuario1);
            return View(transaccions.ToList());
        }

        // GET: Transaccions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = db.Transaccions.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            return View(transaccion);
        }

        // GET: Transaccions/Create
        public ActionResult Create()
        {
            ViewBag.idMetodoDePago = new SelectList(db.MetodoDePagoes, "idMetodoDePago", "metodo");
            ViewBag.idProducto = new SelectList(db.Productoes, "idProducto", "nombre");
            ViewBag.idServicio = new SelectList(db.Servicios, "idServicio", "numeroDeReferencia");
            ViewBag.idTipoDeTransaccion = new SelectList(db.TipoDeTransaccions, "idTipoDeTransaccion", "tipo");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: Transaccions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTransaccion,monto,idMetodoDePago,idProducto,idServicio,idTipoDeTransaccion,numeroReferencia,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                db.Transaccions.Add(transaccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idMetodoDePago = new SelectList(db.MetodoDePagoes, "idMetodoDePago", "metodo", transaccion.idMetodoDePago);
            ViewBag.idProducto = new SelectList(db.Productoes, "idProducto", "nombre", transaccion.idProducto);
            ViewBag.idServicio = new SelectList(db.Servicios, "idServicio", "numeroDeReferencia", transaccion.idServicio);
            ViewBag.idTipoDeTransaccion = new SelectList(db.TipoDeTransaccions, "idTipoDeTransaccion", "tipo", transaccion.idTipoDeTransaccion);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", transaccion.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", transaccion.idUsuarioModifica);
            return View(transaccion);
        }

        // GET: Transaccions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = db.Transaccions.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idMetodoDePago = new SelectList(db.MetodoDePagoes, "idMetodoDePago", "metodo", transaccion.idMetodoDePago);
            ViewBag.idProducto = new SelectList(db.Productoes, "idProducto", "nombre", transaccion.idProducto);
            ViewBag.idServicio = new SelectList(db.Servicios, "idServicio", "numeroDeReferencia", transaccion.idServicio);
            ViewBag.idTipoDeTransaccion = new SelectList(db.TipoDeTransaccions, "idTipoDeTransaccion", "tipo", transaccion.idTipoDeTransaccion);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", transaccion.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", transaccion.idUsuarioModifica);
            return View(transaccion);
        }

        // POST: Transaccions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTransaccion,monto,idMetodoDePago,idProducto,idServicio,idTipoDeTransaccion,numeroReferencia,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idMetodoDePago = new SelectList(db.MetodoDePagoes, "idMetodoDePago", "metodo", transaccion.idMetodoDePago);
            ViewBag.idProducto = new SelectList(db.Productoes, "idProducto", "nombre", transaccion.idProducto);
            ViewBag.idServicio = new SelectList(db.Servicios, "idServicio", "numeroDeReferencia", transaccion.idServicio);
            ViewBag.idTipoDeTransaccion = new SelectList(db.TipoDeTransaccions, "idTipoDeTransaccion", "tipo", transaccion.idTipoDeTransaccion);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", transaccion.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", transaccion.idUsuarioModifica);
            return View(transaccion);
        }

        // GET: Transaccions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = db.Transaccions.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            return View(transaccion);
        }

        // POST: Transaccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaccion transaccion = db.Transaccions.Find(id);
            db.Transaccions.Remove(transaccion);
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
