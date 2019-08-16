using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelMagnolia.UI.Models;
using HotelMagnolia.UI.Util;

namespace HotelMagnolia.UI.Controllers
{
    public class UsuarioController : Controller
    {
        private string PERMISOS_ADMIN_SEGURIDAD = "1,2";

        private readonly HotelMagnoliaEntities db = new HotelMagnoliaEntities();
        public ActionResult CambiarPassword() {
            USUARIO usuarioSesion = (USUARIO)Session["Usuario"];
            if (usuarioSesion == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        // POST: Usuario/CambiarPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CambiarPassword([Bind(Include = "ID_USUARIOS")] USUARIO uSUARIO, string current_password, string new_password, string confirm_password)
        {
            ActionResult resultado = View();
            USUARIO usuarioSesion = (USUARIO)Session["Usuario"];
            string detalle = "Usuario:" + uSUARIO.USER_NAME + "/Contraseña anterior:" + current_password + "/Contaseña nueva:" + new_password;
            detalle = Util.Cypher.Encrypt(detalle);
            string userid = usuarioSesion.ID_USUARIO;
            Debug.WriteLine("TEST" + userid);
            db.InsertBitacora(usuarioSesion.ID_USUARIO, 2, "Cambio Contraseña", detalle,userid);
            current_password = Util.Cypher.Encrypt(current_password);
            new_password = Util.Cypher.Encrypt(new_password);
            confirm_password = Util.Cypher.Encrypt(confirm_password);
            if (usuarioSesion == null)
            {
                resultado = RedirectToAction("Index", "Home");
            }
            else
            {
                if (usuarioSesion.PASSWORD != current_password)
                {
                    ModelState.AddModelError("PASSWORD", "La contraseña actual no coincide");
                }
                else
                {
                    if (confirm_password != new_password)
                    {
                        ModelState.AddModelError("CONFIRM_PASSWORD", "Las contraseñas indicadas no coinciden");
                    }
                    else
                    {
                        if (current_password == new_password)
                        {
                            ModelState.AddModelError("NEW_PASSWORD", "La contraseña nueva no puede ser igual a la actual");
                        }
                        else
                        {
                            usuarioSesion.PASSWORD = new_password;
                            Session["Usuario"] = usuarioSesion;
                            
                            db.Entry(usuarioSesion).State = EntityState.Modified;
                            db.SaveChanges();
                            TempData["SuccessMessage"] = "La contraseña ha sido cambiada con éxito";
                            resultado = RedirectToAction("Success", "Home");
                        }
                    }
                }
            }
            return resultado;
        }

            // GET: Usuario/LogOut
            public ActionResult LogOut()
        {
            Session["Usuario"] = null;
            TempData["SuccessMessage"] = "Se ha cerrado la sesión con éxito";
            return RedirectToAction("Success", "Home");
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
            System.Diagnostics.Debug.WriteLine("User: " + Cypher.Encrypt(uSUARIO.USER_NAME));
            System.Diagnostics.Debug.WriteLine("Pass: " + Cypher.Encrypt(uSUARIO.PASSWORD));

            string result = db.ValidateUser(Cypher.Encrypt(uSUARIO.USER_NAME), Cypher.Encrypt(uSUARIO.PASSWORD)).FirstOrDefault();

            System.Diagnostics.Debug.WriteLine("Result: " + result);
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
                List<USUARIO> ListaUsers = uSUARIOs.ToList();
                foreach(USUARIO i in ListaUsers)
                {
                    i.NOMBRE = Util.Cypher.Decrypt(i.NOMBRE);
                    i.APELLIDO1 = Util.Cypher.Decrypt(i.APELLIDO1);
                    i.APELLIDO2 = Util.Cypher.Decrypt(i.APELLIDO2);
                    i.CORREO = Util.Cypher.Decrypt(i.CORREO);
                    i.USER_NAME = Util.Cypher.Decrypt(i.USER_NAME);
                }
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
                USUARIO usuarioSesion = (USUARIO)Session["Usuario"];
                String LogDetalle = "Nombre:" + uSUARIO.NOMBRE + "/Apellido1:" + uSUARIO.APELLIDO1 + "/Apellido2:" + uSUARIO.APELLIDO2 + "/Correo:" + uSUARIO.CORREO + "/Telefono:" + uSUARIO.TELEFONO + "/Rol:" + uSUARIO.ROL;
                LogDetalle = Util.Cypher.Encrypt(LogDetalle);
                db.InsertBitacora(usuarioSesion.ID_USUARIO, 1, "Nuevo Usuario", LogDetalle, "N/A");
                uSUARIO.NOMBRE = Util.Cypher.Encrypt(uSUARIO.NOMBRE);
                uSUARIO.APELLIDO1=Util.Cypher.Encrypt(uSUARIO.APELLIDO1);
                uSUARIO.APELLIDO2=Util.Cypher.Encrypt(uSUARIO.APELLIDO2);
                uSUARIO.CORREO=Util.Cypher.Encrypt(uSUARIO.CORREO);
                uSUARIO.PASSWORD = Util.Cypher.Encrypt(uSUARIO.PASSWORD);
                uSUARIO.USER_NAME = Util.Cypher.Encrypt(uSUARIO.USER_NAME);
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
                uSUARIO.NOMBRE = Util.Cypher.Decrypt(uSUARIO.NOMBRE);
                uSUARIO.APELLIDO1 = Util.Cypher.Decrypt(uSUARIO.APELLIDO1);
                uSUARIO.APELLIDO2 = Util.Cypher.Decrypt(uSUARIO.APELLIDO2);
                uSUARIO.CORREO = Util.Cypher.Decrypt(uSUARIO.CORREO);
                uSUARIO.PASSWORD = Util.Cypher.Decrypt(uSUARIO.PASSWORD);
                uSUARIO.USER_NAME = Util.Cypher.Decrypt(uSUARIO.USER_NAME);
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
                USUARIO usuarioSesion = (USUARIO)Session["Usuario"];
                String LogDetalle = "Nombre:" + uSUARIO.NOMBRE + "/Apellido1:" + uSUARIO.APELLIDO1 + "/Apellido2:" + uSUARIO.APELLIDO2 + "/Correo:" + uSUARIO.CORREO + "/Telefono:" + uSUARIO.TELEFONO + "/Rol:" + uSUARIO.ROL;
                LogDetalle = Util.Cypher.Encrypt(LogDetalle);
                
                db.InsertBitacora(usuarioSesion.ID_USUARIO, 2, "Modificar Usuario", LogDetalle, usuarioSesion.ID_USUARIO);
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
                uSUARIO.NOMBRE = Util.Cypher.Decrypt(uSUARIO.NOMBRE);
                uSUARIO.APELLIDO1 = Util.Cypher.Decrypt(uSUARIO.APELLIDO1);
                uSUARIO.APELLIDO2 = Util.Cypher.Decrypt(uSUARIO.APELLIDO2);
                uSUARIO.CORREO = Util.Cypher.Decrypt(uSUARIO.CORREO);
                uSUARIO.PASSWORD = Util.Cypher.Decrypt(uSUARIO.PASSWORD);
                uSUARIO.USER_NAME = Util.Cypher.Decrypt(uSUARIO.USER_NAME);
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
            USUARIO usuarioSesion = (USUARIO)Session["Usuario"];
            String LogDetalle = "Nombre:" + uSUARIO.NOMBRE + "/Apellido1:" + uSUARIO.APELLIDO1 + "/Apellido2:" + uSUARIO.APELLIDO2 + "/Correo:" + uSUARIO.CORREO + "/Telefono:" + uSUARIO.TELEFONO + "/Rol:" + uSUARIO.ROL;
            LogDetalle = Util.Cypher.Encrypt(LogDetalle);
            db.InsertBitacora(usuarioSesion.ID_USUARIO, 3, "Eliminar Usuario", LogDetalle, uSUARIO.ID_USUARIO);
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