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
    public class Tipo_BitacoraController : Controller
    {
        private HotelMagnoliaEntities db = new HotelMagnoliaEntities();

        // GET: Tipo_Bitacora
        public ActionResult Index()
        {
            return View(db.TIPO_BITACORA.ToList());
        }

        // GET: Tipo_Bitacora/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_BITACORA tIPO_BITACORA = db.TIPO_BITACORA.Find(id);
            if (tIPO_BITACORA == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_BITACORA);
        }

        // GET: Tipo_Bitacora/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_Bitacora/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TIPO_BITACORA,NOMBRE")] TIPO_BITACORA tIPO_BITACORA)
        {
            if (ModelState.IsValid)
            {
                db.TIPO_BITACORA.Add(tIPO_BITACORA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tIPO_BITACORA);
        }

        // GET: Tipo_Bitacora/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_BITACORA tIPO_BITACORA = db.TIPO_BITACORA.Find(id);
            if (tIPO_BITACORA == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_BITACORA);
        }

        // POST: Tipo_Bitacora/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TIPO_BITACORA,NOMBRE")] TIPO_BITACORA tIPO_BITACORA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPO_BITACORA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tIPO_BITACORA);
        }

        // GET: Tipo_Bitacora/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_BITACORA tIPO_BITACORA = db.TIPO_BITACORA.Find(id);
            if (tIPO_BITACORA == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_BITACORA);
        }

        // POST: Tipo_Bitacora/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TIPO_BITACORA tIPO_BITACORA = db.TIPO_BITACORA.Find(id);
            db.TIPO_BITACORA.Remove(tIPO_BITACORA);
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
