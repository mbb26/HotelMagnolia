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
    public class ReservacionesController : Controller
    {
        private ProyectoHotelMagnoliaEntities db = new ProyectoHotelMagnoliaEntities();

        // GET: Reservaciones
        public ActionResult Index()
        {
            var rESERVACIONs = db.RESERVACIONs.Include(r => r.HABITACION).Include(r => r.USUARIO);
            return View(rESERVACIONs.ToList());
        }

        // GET: Reservaciones/Details/5
        public ActionResult Details(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESERVACION rESERVACION = db.RESERVACIONs.Find(id);
            if (rESERVACION == null)
            {
                return HttpNotFound();
            }
            return View(rESERVACION);
        }

        // GET: Reservaciones/Create
        public ActionResult Create()
        {
            ViewBag.ID_CONSECUTIVOS = new SelectList(db.HABITACIONs, "ID_HABITAICIONES", "NOMBRE");
            ViewBag.ID_USUARIO = new SelectList(db.USUARIOs, "ID_USUARIO", "NOMBRE");
            return View();
        }

        // POST: Reservaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_CONSECUTIVOS,ID_USUARIO,FECHA_ENTRADA,FECHA_SALIDA,TIPO_HABITACION,ESTADO_RESERVACION")] RESERVACION rESERVACION)
        {
            if (ModelState.IsValid)
            {
                db.RESERVACIONs.Add(rESERVACION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CONSECUTIVOS = new SelectList(db.HABITACIONs, "ID_HABITAICIONES", "NOMBRE", rESERVACION.ID_CONSECUTIVOS);
            ViewBag.ID_USUARIO = new SelectList(db.USUARIOs, "ID_USUARIO", "NOMBRE", rESERVACION.ID_USUARIO);
            return View(rESERVACION);
        }

        // GET: Reservaciones/Edit/5
        public ActionResult Edit(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESERVACION rESERVACION = db.RESERVACIONs.Find(id);
            if (rESERVACION == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CONSECUTIVOS = new SelectList(db.HABITACIONs, "ID_HABITAICIONES", "NOMBRE", rESERVACION.ID_CONSECUTIVOS);
            ViewBag.ID_USUARIO = new SelectList(db.USUARIOs, "ID_USUARIO", "NOMBRE", rESERVACION.ID_USUARIO);
            return View(rESERVACION);
        }

        // POST: Reservaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_CONSECUTIVOS,ID_USUARIO,FECHA_ENTRADA,FECHA_SALIDA,TIPO_HABITACION,ESTADO_RESERVACION")] RESERVACION rESERVACION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rESERVACION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CONSECUTIVOS = new SelectList(db.HABITACIONs, "ID_HABITAICIONES", "NOMBRE", rESERVACION.ID_CONSECUTIVOS);
            ViewBag.ID_USUARIO = new SelectList(db.USUARIOs, "ID_USUARIO", "NOMBRE", rESERVACION.ID_USUARIO);
            return View(rESERVACION);
        }

        // GET: Reservaciones/Delete/5
        public ActionResult Delete(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESERVACION rESERVACION = db.RESERVACIONs.Find(id);
            if (rESERVACION == null)
            {
                return HttpNotFound();
            }
            return View(rESERVACION);
        }

        // POST: Reservaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DateTime id)
        {
            RESERVACION rESERVACION = db.RESERVACIONs.Find(id);
            db.RESERVACIONs.Remove(rESERVACION);
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
