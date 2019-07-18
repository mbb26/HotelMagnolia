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
    public class ActividadController : Controller
    {
        private HotelMagnoliaEntities db = new HotelMagnoliaEntities();

        // GET: Actividad
        public ActionResult Index()
        {
            return View(db.ACTIVIDADs.ToList());
        }

        // GET: Actividad/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACTIVIDAD aCTIVIDAD = db.ACTIVIDADs.Find(id);
            if (aCTIVIDAD == null)
            {
                return HttpNotFound();
            }
            return View(aCTIVIDAD);
        }

        // GET: Actividad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Actividad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ACTIVIDAD,NOMBRE,DESCRIPCION,IMG")] ACTIVIDAD aCTIVIDAD)
        {
            if (ModelState.IsValid)
            {
                db.InsertActividad(aCTIVIDAD.NOMBRE, aCTIVIDAD.DESCRIPCION, aCTIVIDAD.IMG);
                //db.ACTIVIDADs.Add(aCTIVIDAD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aCTIVIDAD);
        }

        // GET: Actividad/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACTIVIDAD aCTIVIDAD = db.ACTIVIDADs.Find(id);
            if (aCTIVIDAD == null)
            {
                return HttpNotFound();
            }
            return View(aCTIVIDAD);
        }

        // POST: Actividad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ACTIVIDAD,NOMBRE,DESCRIPCION,IMG")] ACTIVIDAD aCTIVIDAD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aCTIVIDAD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aCTIVIDAD);
        }

        // GET: Actividad/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACTIVIDAD aCTIVIDAD = db.ACTIVIDADs.Find(id);
            if (aCTIVIDAD == null)
            {
                return HttpNotFound();
            }
            return View(aCTIVIDAD);
        }

        // POST: Actividad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ACTIVIDAD aCTIVIDAD = db.ACTIVIDADs.Find(id);
            db.ACTIVIDADs.Remove(aCTIVIDAD);
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
