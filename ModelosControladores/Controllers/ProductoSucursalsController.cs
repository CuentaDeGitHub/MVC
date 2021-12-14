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
    public class ProductoSucursalsController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: ProductoSucursals
        public ActionResult Index()
        {
            var productoSucursals = db.ProductoSucursals.Include(p => p.Producto).Include(p => p.Sucursal).Include(p => p.Usuario).Include(p => p.Usuario1).Include(p => p.Sucursal1);
            return View(productoSucursals.ToList());
        }

        // GET: ProductoSucursals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoSucursal productoSucursal = db.ProductoSucursals.Find(id);
            if (productoSucursal == null)
            {
                return HttpNotFound();
            }
            return View(productoSucursal);
        }

        // GET: ProductoSucursals/Create
        public ActionResult Create()
        {
            ViewBag.idProducto = new SelectList(db.Productoes, "idProducto", "nombre");
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo");
            return View();
        }

        // POST: ProductoSucursals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProductoSucursal,idProducto,idSucursal,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] ProductoSucursal productoSucursal)
        {
            if (ModelState.IsValid)
            {
                db.ProductoSucursals.Add(productoSucursal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idProducto = new SelectList(db.Productoes, "idProducto", "nombre", productoSucursal.idProducto);
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo", productoSucursal.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", productoSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", productoSucursal.idUsuarioModifica);
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo", productoSucursal.idSucursal);
            return View(productoSucursal);
        }

        // GET: ProductoSucursals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoSucursal productoSucursal = db.ProductoSucursals.Find(id);
            if (productoSucursal == null)
            {
                return HttpNotFound();
            }
            ViewBag.idProducto = new SelectList(db.Productoes, "idProducto", "nombre", productoSucursal.idProducto);
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo", productoSucursal.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", productoSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", productoSucursal.idUsuarioModifica);
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo", productoSucursal.idSucursal);
            return View(productoSucursal);
        }

        // POST: ProductoSucursals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProductoSucursal,idProducto,idSucursal,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] ProductoSucursal productoSucursal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productoSucursal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idProducto = new SelectList(db.Productoes, "idProducto", "nombre", productoSucursal.idProducto);
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo", productoSucursal.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", productoSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", productoSucursal.idUsuarioModifica);
            ViewBag.idSucursal = new SelectList(db.Sucursals, "idSucursal", "codigo", productoSucursal.idSucursal);
            return View(productoSucursal);
        }

        // GET: ProductoSucursals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoSucursal productoSucursal = db.ProductoSucursals.Find(id);
            if (productoSucursal == null)
            {
                return HttpNotFound();
            }
            return View(productoSucursal);
        }

        // POST: ProductoSucursals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductoSucursal productoSucursal = db.ProductoSucursals.Find(id);
            db.ProductoSucursals.Remove(productoSucursal);
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
