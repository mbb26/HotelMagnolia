using System;
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
        private string PERMISOS_ADMIN_SEGURIDAD = "1,2";

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
            USUARIO usuarioSesion = (USUARIO)Session["Usuario"];
            if (usuarioSesion != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
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
            USUARIO usuarioSesion = (USUARIO)Session["Usuario"];
            if (usuarioSesion != null && PERMISOS_ADMIN_SEGURIDAD.IndexOf(usuarioSesion.ID_ROL.ToString()) > -1)
            {
                var uSUARIOs = db.USUARIOs.Include(u => u.ROL);
                return View(uSUARIOs.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Usuario/Details/5
        public ActionResult Details(string id)
        {
            USUARIO usuarioSesion = (USUARIO)Session["Usuario"];
            if (usuarioSesion != null && PERMISOS_ADMIN_SEGURIDAD.IndexOf(usuarioSesion.ID_ROL.ToString()) > -1)
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
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            USUARIO usuarioSesion = (USUARIO)Session["Usuario"];
            if (usuarioSesion != null && PERMISOS_ADMIN_SEGURIDAD.IndexOf(usuarioSesion.ID_ROL.ToString()) > -1)
            {
                ViewBag.ID_ROL = new SelectList(db.ROLs, "ID_ROL", "NOMBRE");
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
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
                db.InsertUsuarios(uSUARIO.NOMBRE, uSUARIO.APELLIDO1, uSUARIO.APELLIDO2, uSUARIO.CORREO, uSUARIO.TELEFONO, uSUARIO.PASSWORD, uSUARIO.USER_NAME, uSUARIO.ID_ROL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ROL = new SelectList(db.ROLs, "ID_ROL", "NOMBRE", uSUARIO.ID_ROL);
            return View(uSUARIO);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(string id)
        {
            USUARIO usuarioSesion = (USUARIO)Session["Usuario"];
            if (usuarioSesion != null && PERMISOS_ADMIN_SEGURIDAD.IndexOf(usuarioSesion.ID_ROL.ToString()) > -1)
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
                if (uSUARIO.ID_USUARIO == usuarioSesion.ID_USUARIO)
                {
                    return RedirectToAction("Index");
                }
                ViewBag.ID_ROL = new SelectList(db.ROLs, "ID_ROL", "NOMBRE", uSUARIO.ID_ROL);
                return View(uSUARIO);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
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
            USUARIO usuarioSesion = (USUARIO)Session["Usuario"];
            if (usuarioSesion != null && PERMISOS_ADMIN_SEGURIDAD.IndexOf(usuarioSesion.ID_ROL.ToString()) > -1)
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
                if (uSUARIO.ID_USUARIO == usuarioSesion.ID_USUARIO)
                {
                    return RedirectToAction("Index");
                }
                return View(uSUARIO);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
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