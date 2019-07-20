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

namespace HotelMagnolia.UI.Content
{
    public class TestController : Controller
    {
        private HotelMagnoliaEntities db = new HotelMagnoliaEntities();

        // GET: Test
        public ActionResult Index()
        {
            List < TEST > ListaNueva = db.TESTs.ToList();
            foreach(TEST element in ListaNueva)
            {
                element.TEST_NOMBRE = Cypher.Decrypt(element.TEST_NOMBRE);
            }

            //return View(db.TESTs.ToList());
            return View(ListaNueva);
        }

        // GET: Test/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TEST tEST = db.TESTs.Find(id);
            if (tEST == null)
            {
                return HttpNotFound();
            }
            return View(tEST);
        }

        // GET: Test/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Test/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TEST,TEST_NOMBRE")] TEST tEST)
        {
            if (ModelState.IsValid)
            {
                tEST.TEST_NOMBRE = Cypher.Crypt(tEST.TEST_NOMBRE);
                db.TESTs.Add(tEST);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tEST);
        }

        // GET: Test/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TEST tEST = db.TESTs.Find(id);
            if (tEST == null)
            {
                return HttpNotFound();
            }
            return View(tEST);
        }

        // POST: Test/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TEST,TEST_NOMBRE")] TEST tEST)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tEST).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tEST);
        }

        // GET: Test/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TEST tEST = db.TESTs.Find(id);
            if (tEST == null)
            {
                return HttpNotFound();
            }
            return View(tEST);
        }

        // POST: Test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TEST tEST = db.TESTs.Find(id);
            db.TESTs.Remove(tEST);
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
