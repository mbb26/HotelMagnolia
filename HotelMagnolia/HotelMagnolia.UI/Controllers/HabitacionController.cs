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
    public class HabitacionController : Controller
    {
        private HotelMagnoliaEntities db = new HotelMagnoliaEntities();

        // GET: Habitacion
        public ActionResult Index()
        {
            var hABITACIONs = db.HABITACIONs.Include(h => h.PRECIO).Include(h => h.TIPO_HABITACION1);
            return View(hABITACIONs.ToList());
        }

        // GET: Habitacion/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HABITACION hABITACION = db.HABITACIONs.Find(id);
            if (hABITACION == null)
            {
                return HttpNotFound();
            }
            return View(hABITACION);
        }

        // GET: Habitacion/Create
        public ActionResult Create()
        {
            ViewBag.ID_PRECIO = new SelectList(db.PRECIOs, "ID_PRECIO", "TIPO_PRECIO");
            ViewBag.TIPO_HABITACION = new SelectList(db.TIPO_HABITACION, "ID_TIPO_HABITACION", "NOMBRE");
            return View();
        }

        // POST: Habitacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_HABITACION,NUMERO,NOMBRE,DESCRIPCION,TIPO_HABITACION,ID_PRECIO")] HABITACION hABITACION)
        {
            if (ModelState.IsValid)
            {
                db.InsertHabitacion(hABITACION.NUMERO, hABITACION.NOMBRE, hABITACION.TIPO_HABITACION, hABITACION.ID_PRECIO);
                //db.HABITACIONs.Add(hABITACION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PRECIO = new SelectList(db.PRECIOs, "ID_PRECIO", "TIPO_PRECIO", hABITACION.ID_PRECIO);
            ViewBag.TIPO_HABITACION = new SelectList(db.TIPO_HABITACION, "ID_TIPO_HABITACION", "NOMBRE", hABITACION.TIPO_HABITACION);
            return View(hABITACION);
        }

        // GET: Habitacion/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HABITACION hABITACION = db.HABITACIONs.Find(id);
            if (hABITACION == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PRECIO = new SelectList(db.PRECIOs, "ID_PRECIO", "TIPO_PRECIO", hABITACION.ID_PRECIO);
            ViewBag.TIPO_HABITACION = new SelectList(db.TIPO_HABITACION, "ID_TIPO_HABITACION", "NOMBRE", hABITACION.TIPO_HABITACION);
            return View(hABITACION);
        }

        // POST: Habitacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_HABITACION,NUMERO,NOMBRE,DESCRIPCION,TIPO_HABITACION,ID_PRECIO")] HABITACION hABITACION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hABITACION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PRECIO = new SelectList(db.PRECIOs, "ID_PRECIO", "TIPO_PRECIO", hABITACION.ID_PRECIO);
            ViewBag.TIPO_HABITACION = new SelectList(db.TIPO_HABITACION, "ID_TIPO_HABITACION", "NOMBRE", hABITACION.TIPO_HABITACION);
            return View(hABITACION);
        }

        // GET: Habitacion/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HABITACION hABITACION = db.HABITACIONs.Find(id);
            if (hABITACION == null)
            {
                return HttpNotFound();
            }
            return View(hABITACION);
        }

        // POST: Habitacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HABITACION hABITACION = db.HABITACIONs.Find(id);
            db.HABITACIONs.Remove(hABITACION);
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
