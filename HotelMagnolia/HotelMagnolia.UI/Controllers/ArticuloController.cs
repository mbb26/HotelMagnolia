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
    public class ArticuloController : Controller
    {
        private HotelMagnoliaEntities db = new HotelMagnoliaEntities();

        // GET: Articulo
        public ActionResult Index()
        {
            var aRTICULOes = db.ARTICULOes.Include(a => a.PRECIO);
            //List<ARTICULO> listaArticulos = db.ARTICULOes.ToList();
            //foreach(ARTICULO i in listaArticulos)
            //{
            //    i.PRECIO.= Util.Cypher.Decrypt(i.ID_PRECIO);
            //}
            //return View(listaArticulos);
            return View(aRTICULOes.ToList());
        }

        // GET: Articulo/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTICULO aRTICULO = db.ARTICULOes.Find(id);
            if (aRTICULO == null)
            {
                return HttpNotFound();
            }
            return View(aRTICULO);
        }

        // GET: Articulo/Create
        public ActionResult Create()
        {
            ViewBag.ID_PRECIO = new SelectList(db.PRECIOs, "ID_PRECIO", "TIPO_PRECIO");

            //var PrecioNuevo = new List<SelectListItem>();
            //List<PRECIO> Tipos = db.PRECIOs.ToList();
            //foreach (PRECIO i in Tipos)
            //{
            //    var nuevo = new SelectListItem();
            //    nuevo.Value = (i.PRECIO1.ToString());
            //    nuevo.Text = Util.Cypher.Decrypt(i.TIPO_PRECIO);
            //    PrecioNuevo.Add(nuevo);
            //}

            //ViewBag.ID_PRECIO = PrecioNuevo;
            return View();
        }

        // POST: Articulo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ARTICULO,DESCRIPCION,ID_PRECIO,IMG")] ARTICULO aRTICULO)
        {
            if (ModelState.IsValid)
            {
                USUARIO usuarioSesion = (USUARIO)Session["Usuario"];
                //db.ARTICULOes.Add(aRTICULO);
                String LogDetalle = "Descripcion:" + aRTICULO.DESCRIPCION + "/Precio:" + aRTICULO.ID_PRECIO;
                LogDetalle = Util.Cypher.Encrypt(LogDetalle);
                db.InsertArticulo(aRTICULO.DESCRIPCION, aRTICULO.ID_PRECIO, aRTICULO.IMG, usuarioSesion.ID_USUARIO, 1, "Nuevo Articulo", LogDetalle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PRECIO = new SelectList(db.PRECIOs, "ID_PRECIO", "TIPO_PRECIO", aRTICULO.ID_PRECIO);
            return View(aRTICULO);
        }

        // GET: Articulo/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTICULO aRTICULO = db.ARTICULOes.Find(id);
            if (aRTICULO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PRECIO = new SelectList(db.PRECIOs, "ID_PRECIO", "TIPO_PRECIO", aRTICULO.ID_PRECIO);
            return View(aRTICULO);
        }

        // POST: Articulo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ARTICULO,DESCRIPCION,ID_PRECIO,IMG")] ARTICULO aRTICULO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aRTICULO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PRECIO = new SelectList(db.PRECIOs, "ID_PRECIO", "TIPO_PRECIO", aRTICULO.ID_PRECIO);
            return View(aRTICULO);
        }

        // GET: Articulo/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTICULO aRTICULO = db.ARTICULOes.Find(id);
            if (aRTICULO == null)
            {
                return HttpNotFound();
            }
            return View(aRTICULO);
        }

        // POST: Articulo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ARTICULO aRTICULO = db.ARTICULOes.Find(id);
            db.ARTICULOes.Remove(aRTICULO);
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
