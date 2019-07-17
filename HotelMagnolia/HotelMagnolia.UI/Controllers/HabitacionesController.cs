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
    public class HabitacionesController : Controller
    {
        private ProyectoHotelMagnoliaEntities db = new ProyectoHotelMagnoliaEntities();

        // GET: Habitaciones
        public ActionResult Index()
        {
            var hABITACIONs = db.HABITACIONs.Include(h => h.PRECIO);
            return View(hABITACIONs.ToList());
        }

        // GET: Habitaciones/Details/5
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

        // GET: Habitaciones/Create
        public ActionResult Create()
        {
            ViewBag.ID_PRECIO = new SelectList(db.PRECIOs, "ID_PRECIO", "TIPO_PRECIO");
            return View();
        }

        // POST: Habitaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_HABITAICIONES,NUMERO,NOMBRE,DESCRIPCION,ID_PRECIO")] HABITACION hABITACION)
        {
            if (ModelState.IsValid)
            {
                db.HABITACIONs.Add(hABITACION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PRECIO = new SelectList(db.PRECIOs, "ID_PRECIO", "TIPO_PRECIO", hABITACION.ID_PRECIO);
            return View(hABITACION);
        }

        // GET: Habitaciones/Edit/5
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
            return View(hABITACION);
        }

        // POST: Habitaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_HABITAICIONES,NUMERO,NOMBRE,DESCRIPCION,ID_PRECIO")] HABITACION hABITACION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hABITACION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PRECIO = new SelectList(db.PRECIOs, "ID_PRECIO", "TIPO_PRECIO", hABITACION.ID_PRECIO);
            return View(hABITACION);
        }

        // GET: Habitaciones/Delete/5
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

        // POST: Habitaciones/Delete/5
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
