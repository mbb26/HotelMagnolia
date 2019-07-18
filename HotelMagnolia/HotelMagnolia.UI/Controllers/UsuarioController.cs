﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelMagnolia.UI.Models;

namespace HotelMagnolia.UI.Controllers
{
    public class UsuarioController : Controller
    {

        private HotelMagnoliaEntities db = new HotelMagnoliaEntities();
        public ActionResult CambiarPassword() => View();

        // GET: Usuario/LogOut
        public ActionResult LogOut()
        {
            Session["Usuario"] = null;
            return RedirectToAction("Index", "Home");
        }

        // GET: Usuario/LogIn
        public ActionResult LogIn()
        {
            return View();
        }

        // POST: Usuario/LogIn
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn([Bind(Include = "PASSWORD,USER_NAME")] USUARIO uSUARIO)
        {
            string result = db.ValidateUser(uSUARIO.USER_NAME, uSUARIO.PASSWORD).FirstOrDefault();
            

            USUARIO User = db.USUARIOs.Find(result);
            if (User != null) {
                Session["Usuario"] = User;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Session["Usuario"] = null;
                ModelState.AddModelError("PASSWORD", "Usuario o contraseña incorrectos");
                return View();
            }
        }

        // GET: Usuario
        public ActionResult Index()
        {
            var uSUARIOs = db.USUARIOs.Include(u => u.ROL);
            return View(uSUARIOs.ToList());
        }

        // GET: Usuario/Details/5
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

        // GET: Usuario/Create
        public ActionResult Create()
        {
            ViewBag.ID_ROL = new SelectList(db.ROLs, "ID_ROL", "NOMBRE");
            return View();
        }

        // POST: Usuario/Create
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

        // GET: Usuario/Edit/5
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

        // POST: Usuario/Edit/5
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

        // GET: Usuario/Delete/5
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

        // POST: Usuario/Delete/5
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