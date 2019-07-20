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
    public class ReservacionController : Controller
    {
        private HotelMagnoliaEntities db = new HotelMagnoliaEntities();

        // GET: Reservacion
        public ActionResult Index()
        {
            var rESERVACIONs = db.RESERVACIONs.Include(r => r.TIPO_HABITACION1).Include(r => r.USUARIO);
            return View(rESERVACIONs.ToList());
        }

        // GET: Reservacion/Details/5
        public ActionResult Details(string id)
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

        // GET: Reservacion/Create
        public ActionResult Create()
        {
            ViewBag.TIPO_HABITACION = new SelectList(db.TIPO_HABITACION, "ID_TIPO_HABITACION", "NOMBRE");
            ViewBag.ID_USUARIO = new SelectList(db.USUARIOs, "ID_USUARIO", "NOMBRE");
            return View();
        }

        // POST: Reservacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_RESERVACION,ID_USUARIO,FECHA_ENTRADA,FECHA_SALIDA,TIPO_HABITACION,ESTADO_RESERVACION")] RESERVACION rESERVACION)
        {
            if (ModelState.IsValid)
            {
                USUARIO usuarioSesion = (USUARIO)Session["Usuario"];
                db.InsertReservacion(rESERVACION.ID_USUARIO, rESERVACION.FECHA_ENTRADA, rESERVACION.FECHA_SALIDA, rESERVACION.TIPO_HABITACION, rESERVACION.ESTADO_RESERVACION);
                //db.InsertBitacora(usuarioSesion.ID_USUARIO, DateTime.Now,);
                //db.RESERVACIONs.Add(rESERVACION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TIPO_HABITACION = new SelectList(db.TIPO_HABITACION, "ID_TIPO_HABITACION", "NOMBRE", rESERVACION.TIPO_HABITACION);
            ViewBag.ID_USUARIO = new SelectList(db.USUARIOs, "ID_USUARIO", "NOMBRE", rESERVACION.ID_USUARIO);
            return View(rESERVACION);
        }

        // GET: Reservacion/Edit/5
        public ActionResult Edit(string id)
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
            ViewBag.TIPO_HABITACION = new SelectList(db.TIPO_HABITACION, "ID_TIPO_HABITACION", "NOMBRE", rESERVACION.TIPO_HABITACION);
            ViewBag.ID_USUARIO = new SelectList(db.USUARIOs, "ID_USUARIO", "NOMBRE", rESERVACION.ID_USUARIO);
            return View(rESERVACION);
        }

        // POST: Reservacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_RESERVACION,ID_USUARIO,FECHA_ENTRADA,FECHA_SALIDA,TIPO_HABITACION,ESTADO_RESERVACION")] RESERVACION rESERVACION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rESERVACION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TIPO_HABITACION = new SelectList(db.TIPO_HABITACION, "ID_TIPO_HABITACION", "NOMBRE", rESERVACION.TIPO_HABITACION);
            ViewBag.ID_USUARIO = new SelectList(db.USUARIOs, "ID_USUARIO", "NOMBRE", rESERVACION.ID_USUARIO);
            return View(rESERVACION);
        }

        // GET: Reservacion/Delete/5
        public ActionResult Delete(string id)
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

        // POST: Reservacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
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
