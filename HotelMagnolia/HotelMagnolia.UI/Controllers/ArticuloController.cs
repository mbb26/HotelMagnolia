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
            return View(aRTICULOes.ToList());
        }

        // GET: Articulo/Details/5
        public ActionResult Details(int? id)
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
            return View();
        }

        // POST: Articulo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ARTICULO,DESCRIPCION_,ID_PRECIO,IMG")] ARTICULO aRTICULO)
        {
            if (ModelState.IsValid)
            {
                db.ARTICULOes.Add(aRTICULO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PRECIO = new SelectList(db.PRECIOs, "ID_PRECIO", "TIPO_PRECIO", aRTICULO.ID_PRECIO);
            return View(aRTICULO);
        }

        // GET: Articulo/Edit/5
        public ActionResult Edit(int? id)
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
        public ActionResult Edit([Bind(Include = "ID_ARTICULO,DESCRIPCION_,ID_PRECIO,IMG")] ARTICULO aRTICULO)
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
        public ActionResult Delete(int? id)
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
        public ActionResult DeleteConfirmed(int id)
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
