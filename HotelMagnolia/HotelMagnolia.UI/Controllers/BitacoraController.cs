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
    public class BitacoraController : Controller
    {
        public ActionResult CheckBinnacle() => View();

        public ActionResult CheckErrors() => View();

        private HotelMagnoliaEntities db = new HotelMagnoliaEntities();

        // GET: Bitacora
        public ActionResult Index()
        {
            var bITACORAs = db.BITACORAs.Include(b => b.USUARIO).Include(b => b.USUARIO1);
            return View(bITACORAs.ToList());
        }

        // GET: Bitacora/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BITACORA bITACORA = db.BITACORAs.Find(id);
            if (bITACORA == null)
            {
                return HttpNotFound();
            }
            return View(bITACORA);
        }

        // GET: Bitacora/Create
        public ActionResult Create()
        {
            ViewBag.TIPO = new SelectList(db.USUARIOs, "ID_USUARIO", "NOMBRE");
            ViewBag.ID_USUARIO = new SelectList(db.USUARIOs, "ID_USUARIO", "NOMBRE");
            return View();
        }

        // POST: Bitacora/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_BITACORA,ID_USUARIO,FECHA,CODIGO,TIPO,Descripcion,Registro_en_detalle")] BITACORA bITACORA)
        {
            if (ModelState.IsValid)
            {
                db.BITACORAs.Add(bITACORA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TIPO = new SelectList(db.USUARIOs, "ID_USUARIO", "NOMBRE", bITACORA.TIPO);
            ViewBag.ID_USUARIO = new SelectList(db.USUARIOs, "ID_USUARIO", "NOMBRE", bITACORA.ID_USUARIO);
            return View(bITACORA);
        }

        // GET: Bitacora/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BITACORA bITACORA = db.BITACORAs.Find(id);
            if (bITACORA == null)
            {
                return HttpNotFound();
            }
            ViewBag.TIPO = new SelectList(db.USUARIOs, "ID_USUARIO", "NOMBRE", bITACORA.TIPO);
            ViewBag.ID_USUARIO = new SelectList(db.USUARIOs, "ID_USUARIO", "NOMBRE", bITACORA.ID_USUARIO);
            return View(bITACORA);
        }

        // POST: Bitacora/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_BITACORA,ID_USUARIO,FECHA,CODIGO,TIPO,Descripcion,Registro_en_detalle")] BITACORA bITACORA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bITACORA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TIPO = new SelectList(db.USUARIOs, "ID_USUARIO", "NOMBRE", bITACORA.TIPO);
            ViewBag.ID_USUARIO = new SelectList(db.USUARIOs, "ID_USUARIO", "NOMBRE", bITACORA.ID_USUARIO);
            return View(bITACORA);
        }

        // GET: Bitacora/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BITACORA bITACORA = db.BITACORAs.Find(id);
            if (bITACORA == null)
            {
                return HttpNotFound();
            }
            return View(bITACORA);
        }

        // POST: Bitacora/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BITACORA bITACORA = db.BITACORAs.Find(id);
            db.BITACORAs.Remove(bITACORA);
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