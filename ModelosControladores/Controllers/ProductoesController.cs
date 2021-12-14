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
    public class ProductoesController : Controller
    {
        private ProyectoOxxoEntities db = new ProyectoOxxoEntities();

        // GET: Productoes
        public ActionResult Index()
        {
            var productoes = db.Productoes.Include(p => p.Marca).Include(p => p.Promocion).Include(p => p.TipoDeProducto).Include(p => p.Usuario).Include(p => p.Usuario1);
            return View(productoes.ToList());
        }

        // GET: Productoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Productoes/Create
        public ActionResult Create()
        {
            ViewBag.idMarca = new SelectList(db.Marcas, "idMarca", "marca1");
            ViewBag.idPromocion = new SelectList(db.Promocions, "idPromocion", "descripcion");
            ViewBag.idTipoDeProducto = new SelectList(db.TipoDeProductoes, "idTipoDeProducto", "tipo");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre");
            return View();
        }

        // POST: Productoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProducto,nombre,cantidad,precio,idMarca,idTipoDeProducto,idPromocion,fechaValida,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Productoes.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idMarca = new SelectList(db.Marcas, "idMarca", "marca1", producto.idMarca);
            ViewBag.idPromocion = new SelectList(db.Promocions, "idPromocion", "descripcion", producto.idPromocion);
            ViewBag.idTipoDeProducto = new SelectList(db.TipoDeProductoes, "idTipoDeProducto", "tipo", producto.idTipoDeProducto);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", producto.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", producto.idUsuarioModifica);
            return View(producto);
        }

        // GET: Productoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.idMarca = new SelectList(db.Marcas, "idMarca", "marca1", producto.idMarca);
            ViewBag.idPromocion = new SelectList(db.Promocions, "idPromocion", "descripcion", producto.idPromocion);
            ViewBag.idTipoDeProducto = new SelectList(db.TipoDeProductoes, "idTipoDeProducto", "tipo", producto.idTipoDeProducto);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", producto.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", producto.idUsuarioModifica);
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProducto,nombre,cantidad,precio,idMarca,idTipoDeProducto,idPromocion,fechaValida,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idMarca = new SelectList(db.Marcas, "idMarca", "marca1", producto.idMarca);
            ViewBag.idPromocion = new SelectList(db.Promocions, "idPromocion", "descripcion", producto.idPromocion);
            ViewBag.idTipoDeProducto = new SelectList(db.TipoDeProductoes, "idTipoDeProducto", "tipo", producto.idTipoDeProducto);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuarios, "idUsuario", "nombre", producto.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuarios, "idUsuario", "nombre", producto.idUsuarioModifica);
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Productoes.Find(id);
            db.Productoes.Remove(producto);
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
