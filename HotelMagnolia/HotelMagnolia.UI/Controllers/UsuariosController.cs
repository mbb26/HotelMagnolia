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
    public class UsuariosController : Controller
    {
        public ActionResult Admin() => View();

        public ActionResult AssignRole() => View();

        public ActionResult ChangePassword() => View();

        public ActionResult ListRoles() => View();

        private ProyectoHotelMagnoliaEntities db = new ProyectoHotelMagnoliaEntities();

        // GET: Usuarios
        public ActionResult Index()
        {
            var uSUARIOs = db.USUARIOs.Include(u => u.ROL);
            return View(uSUARIOs.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIOs.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.ID_ROL = new SelectList(db.ROLs, "ID_ROL", "NOMBRE");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_USUARIO,NOMBRE,APELLIDO1,APELLIDO2,CORREO,TELEFONO,PASSWORD,USER_NAME,ID_ROL")] USUARIO uSUARIO)
        {
            if (ModelState.IsValid)
            {
                db.USUARIOs.Add(uSUARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ROL = new SelectList(db.ROLs, "ID_ROL", "NOMBRE", uSUARIO.ID_ROL);
            return View(uSUARIO);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIOs.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ROL = new SelectList(db.ROLs, "ID_ROL", "NOMBRE", uSUARIO.ID_ROL);
            return View(uSUARIO);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_USUARIO,NOMBRE,APELLIDO1,APELLIDO2,CORREO,TELEFONO,PASSWORD,USER_NAME,ID_ROL")] USUARIO uSUARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSUARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ROL = new SelectList(db.ROLs, "ID_ROL", "NOMBRE", uSUARIO.ID_ROL);
            return View(uSUARIO);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIOs.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            USUARIO uSUARIO = db.USUARIOs.Find(id);
            db.USUARIOs.Remove(uSUARIO);
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