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
    public class ConsecutivoController : Controller
    {
        private HotelMagnoliaEntities db = new HotelMagnoliaEntities();

        // GET: Consecutivo
        public ActionResult Index()
        {
            return View(db.CONSECUTIVOes.ToList());
        }

        // GET: Consecutivo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONSECUTIVO cONSECUTIVO = db.CONSECUTIVOes.Find(id);
            if (cONSECUTIVO == null)
            {
                return HttpNotFound();
            }
            return View(cONSECUTIVO);
        }

        // GET: Consecutivo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Consecutivo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_CONSECUTIVOS,NOMBRE,VALOR,TIENE_PREFIJO,PREFIJO,POSEE_RANGO,RANGO_INICIAL,RANGO_FINAL")] CONSECUTIVO cONSECUTIVO)
        {
            if (ModelState.IsValid)
            {
                db.CONSECUTIVOes.Add(cONSECUTIVO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cONSECUTIVO);
        }

        // GET: Consecutivo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONSECUTIVO cONSECUTIVO = db.CONSECUTIVOes.Find(id);
            if (cONSECUTIVO == null)
            {
                return HttpNotFound();
            }
            return View(cONSECUTIVO);
        }

        // POST: Consecutivo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_CONSECUTIVOS,NOMBRE,VALOR,TIENE_PREFIJO,PREFIJO,POSEE_RANGO,RANGO_INICIAL,RANGO_FINAL")] CONSECUTIVO cONSECUTIVO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cONSECUTIVO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cONSECUTIVO);
        }

        // GET: Consecutivo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONSECUTIVO cONSECUTIVO = db.CONSECUTIVOes.Find(id);
            if (cONSECUTIVO == null)
            {
                return HttpNotFound();
            }
            return View(cONSECUTIVO);
        }

        // POST: Consecutivo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CONSECUTIVO cONSECUTIVO = db.CONSECUTIVOes.Find(id);
            db.CONSECUTIVOes.Remove(cONSECUTIVO);
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
