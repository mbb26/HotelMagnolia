using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelMagnolia.UI.Models;

namespace HotelMagnolia.UI.Controllers
{
    public class PrecioController : Controller
    {
        private HotelMagnoliaEntities db = new HotelMagnoliaEntities();

        // GET: Precio
        public ActionResult Index()
        {
            List<PRECIO> encriptada = db.PRECIOs.ToList();
            foreach(PRECIO i in encriptada)
            {
                i.TIPO_PRECIO = Util.Cypher.Decrypt(i.TIPO_PRECIO);
            }
            return View(encriptada);
        }

        // GET: Precio/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRECIO pRECIO = db.PRECIOs.Find(id);
            pRECIO.TIPO_PRECIO = Util.Cypher.Decrypt(pRECIO.TIPO_PRECIO);
            if (pRECIO == null)
            {
                return HttpNotFound();
            }
            return View(pRECIO);
        }

        // GET: Precio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Precio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PRECIO,TIPO_PRECIO,PRECIO1")] PRECIO pRECIO)
        {
            if (ModelState.IsValid)
            {
                USUARIO usuarioSesion = (USUARIO)Session["Usuario"];
                String LogDetalle= "Tipo Precio:" + pRECIO.TIPO_PRECIO + "/Precio:" + pRECIO.PRECIO1;
                pRECIO.TIPO_PRECIO = Util.Cypher.Encrypt(pRECIO.TIPO_PRECIO);
                LogDetalle = Util.Cypher.Encrypt(LogDetalle);
                db.InsertPrecios(pRECIO.TIPO_PRECIO, pRECIO.PRECIO1, usuarioSesion.ID_USUARIO,1, "Nuevo Precio", LogDetalle);
                //db.InsertPrecios(pRECIO.TIPO_PRECIO, pRECIO.PRECIO1, usuarioSesion.ID_USUARIO, DateTime.Now, 1, "Agregar Precio");
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pRECIO);
        }

        // GET: Precio/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRECIO pRECIO = db.PRECIOs.Find(id);
            pRECIO.TIPO_PRECIO = Util.Cypher.Decrypt(pRECIO.TIPO_PRECIO);
            if (pRECIO == null)
            {
                return HttpNotFound();
            }
            return View(pRECIO);
        }

        // POST: Precio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PRECIO,TIPO_PRECIO,PRECIO1")] PRECIO pRECIO)
        {
            if (ModelState.IsValid)
            {
                USUARIO usuarioSesion = (USUARIO)Session["Usuario"];
                String LogDetalle = "Tipo Precio:" + pRECIO.TIPO_PRECIO + "/Precio:" + pRECIO.PRECIO1;
                LogDetalle = Util.Cypher.Encrypt(LogDetalle);
                db.InsertBitacora(usuarioSesion.ID_USUARIO, 2, "Modificar Precio", LogDetalle, pRECIO.ID_PRECIO);
                pRECIO.TIPO_PRECIO = Util.Cypher.Encrypt(pRECIO.TIPO_PRECIO);
                db.Entry(pRECIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pRECIO);
        }

        // GET: Precio/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRECIO pRECIO = db.PRECIOs.Find(id);
            pRECIO.TIPO_PRECIO = Util.Cypher.Decrypt(pRECIO.TIPO_PRECIO);
            if (pRECIO == null)
            {
                return HttpNotFound();
            }
            return View(pRECIO);
        }

        // POST: Precio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PRECIO pRECIO = db.PRECIOs.Find(id);
            USUARIO usuarioSesion = (USUARIO)Session["Usuario"];
            pRECIO.TIPO_PRECIO = Util.Cypher.Decrypt(pRECIO.TIPO_PRECIO);
            String LogDetalle = "Tipo Precio:" + pRECIO.TIPO_PRECIO + "/Precio:" + pRECIO.PRECIO1;
            LogDetalle = Util.Cypher.Encrypt(LogDetalle);
            db.InsertBitacora(usuarioSesion.ID_USUARIO, 3, "Eliminar Precio", LogDetalle, pRECIO.ID_PRECIO);

            db.PRECIOs.Remove(pRECIO);
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
