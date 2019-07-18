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
            return View(db.PRECIOs.ToList());
        }

        // GET: Precio/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRECIO pRECIO = db.PRECIOs.Find(id);
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
                db.PRECIOs.Add(pRECIO);
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
