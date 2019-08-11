using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelMagnolia.UI.Models;
using HotelMagnolia.UI.Util;

namespace HotelMagnolia.UI.Controllers
{
    public class Tipo_HabitacionController : Controller
    {
        private HotelMagnoliaEntities db = new HotelMagnoliaEntities();

        // GET: Tipo_Habitacion
        public ActionResult Index()
        {
            List<TIPO_HABITACION> Encriptada = db.TIPO_HABITACION.ToList();
            foreach (TIPO_HABITACION i in Encriptada)
            {
                i.NOMBRE = Util.Cypher.Decrypt(i.NOMBRE);
                i.DESCRIPCION = Util.Cypher.Decrypt(i.DESCRIPCION);
            }
            return View(db.TIPO_HABITACION.ToList());
        }

        // GET: Tipo_Habitacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_HABITACION tIPO_HABITACION = db.TIPO_HABITACION.Find(id);
            tIPO_HABITACION.NOMBRE = Util.Cypher.Decrypt(tIPO_HABITACION.NOMBRE);
            tIPO_HABITACION.DESCRIPCION = Util.Cypher.Decrypt(tIPO_HABITACION.DESCRIPCION);

            if (tIPO_HABITACION == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_HABITACION);
        }

        // GET: Tipo_Habitacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_Habitacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TIPO_HABITACION,NOMBRE,DESCRIPCION")] TIPO_HABITACION tIPO_HABITACION)
        {
            if (ModelState.IsValid)
            {
                tIPO_HABITACION.NOMBRE = Util.Cypher.Encrypt(tIPO_HABITACION.NOMBRE);
                tIPO_HABITACION.DESCRIPCION = Util.Cypher.Encrypt(tIPO_HABITACION.DESCRIPCION);

                db.TIPO_HABITACION.Add(tIPO_HABITACION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tIPO_HABITACION);
        }

        // GET: Tipo_Habitacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_HABITACION tIPO_HABITACION = db.TIPO_HABITACION.Find(id);
            tIPO_HABITACION.NOMBRE = Util.Cypher.Decrypt(tIPO_HABITACION.NOMBRE);
            tIPO_HABITACION.DESCRIPCION = Util.Cypher.Decrypt(tIPO_HABITACION.DESCRIPCION);
            if (tIPO_HABITACION == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_HABITACION);
        }

        // POST: Tipo_Habitacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TIPO_HABITACION,NOMBRE,DESCRIPCION")] TIPO_HABITACION tIPO_HABITACION)
        {
            if (ModelState.IsValid)
            {
                tIPO_HABITACION.NOMBRE = Util.Cypher.Encrypt(tIPO_HABITACION.NOMBRE);
                tIPO_HABITACION.DESCRIPCION = Util.Cypher.Encrypt(tIPO_HABITACION.DESCRIPCION);
                db.Entry(tIPO_HABITACION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tIPO_HABITACION);
        }

        // GET: Tipo_Habitacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_HABITACION tIPO_HABITACION = db.TIPO_HABITACION.Find(id);
            if (tIPO_HABITACION == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_HABITACION);
        }

        // POST: Tipo_Habitacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TIPO_HABITACION tIPO_HABITACION = db.TIPO_HABITACION.Find(id);
            db.TIPO_HABITACION.Remove(tIPO_HABITACION);
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
