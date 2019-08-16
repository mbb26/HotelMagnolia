using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelMagnolia.UI.Models;

namespace HotelMagnolia.UI.Controllers
{
    public class HabitacionController : Controller
    {
        private HotelMagnoliaEntities db = new HotelMagnoliaEntities();

        // GET: Habitacion
        public ActionResult Index()
        {
            //var hABITACIONs = db.HABITACIONs.Include(h => h.PRECIO).Include(h => h.TIPO_HABITACION1);
            //return View(hABITACIONs.ToList());
            List<HABITACION> encriptada = db.HABITACIONs.ToList();
            foreach(HABITACION i in encriptada)
            {
                i.NOMBRE = Util.Cypher.Decrypt(i.NOMBRE);
                i.DESCRIPCION = Util.Cypher.Decrypt(i.DESCRIPCION);   
            }
            return View(encriptada);
        }

        // GET: Habitacion/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HABITACION hABITACION = db.HABITACIONs.Find(id);
            hABITACION.NOMBRE = Util.Cypher.Decrypt(hABITACION.NOMBRE);
            hABITACION.DESCRIPCION = Util.Cypher.Decrypt(hABITACION.DESCRIPCION);
            if (hABITACION == null)
            {
                return HttpNotFound();
            }
            return View(hABITACION);
        }

        // GET: Habitacion/Create
        public ActionResult Create()
        {

            //ViewBag.ID_PRECIO = new SelectList(db.PRECIOs, "ID_PRECIO", "TIPO_PRECIO");

            //ViewBag.TIPO_HABITACION = new SelectList(db.TIPO_HABITACION, "ID_TIPO_HABITACION", "NOMBRE");

            var PreciosNuevo = new List<SelectListItem>();
            List<PRECIO> precios = db.PRECIOs.ToList();
            foreach(PRECIO i in precios)
            {
                var nuevo = new SelectListItem();
                nuevo.Value = i.ID_PRECIO;
                nuevo.Text = Util.Cypher.Decrypt(i.TIPO_PRECIO);
                PreciosNuevo.Add(nuevo);
            }

            var TipoHabitacionNuevo = new List<SelectListItem>();
            List<TIPO_HABITACION> Tipos = db.TIPO_HABITACION.ToList();
            foreach (TIPO_HABITACION i in Tipos)
            {
                var nuevo = new SelectListItem();
                nuevo.Value = (i.ID_TIPO_HABITACION).ToString();
                nuevo.Text = Util.Cypher.Decrypt(i.NOMBRE);
                TipoHabitacionNuevo.Add(nuevo);
            }

            ViewBag.TIPO_HABITACION = TipoHabitacionNuevo;
            ViewBag.ID_PRECIO = PreciosNuevo;
            return View();
        }

        // POST: Habitacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_HABITACION,NUMERO,NOMBRE,DESCRIPCION,FOTO,TIPO_HABITACION,ID_PRECIO")] HABITACION hABITACION)
        {
            if (ModelState.IsValid)
            {
                USUARIO usuarioSesion = (USUARIO)Session["Usuario"];
                String logDetalle = "Numero:" + hABITACION.NUMERO + "/Nombre:" + hABITACION.NOMBRE + "/Descripcion:" + hABITACION.DESCRIPCION + "/Foto:" + hABITACION.FOTO + "/Tipo Habitacion:" + hABITACION.TIPO_HABITACION + "/Precio:" + hABITACION.ID_PRECIO;
                hABITACION.NOMBRE = Util.Cypher.Encrypt(hABITACION.NOMBRE);
                hABITACION.DESCRIPCION = Util.Cypher.Encrypt(hABITACION.DESCRIPCION);
                logDetalle = Util.Cypher.Encrypt(logDetalle);
                db.InsertHabitacion(hABITACION.NUMERO, hABITACION.NOMBRE, hABITACION.TIPO_HABITACION, hABITACION.ID_PRECIO, hABITACION.DESCRIPCION, hABITACION.FOTO, usuarioSesion.ID_USUARIO, DateTime.Now, 01, "Nueva Habitacion", logDetalle);       
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PRECIO = new SelectList(db.PRECIOs, "ID_PRECIO", "TIPO_PRECIO", hABITACION.ID_PRECIO);
            ViewBag.TIPO_HABITACION = new SelectList(db.TIPO_HABITACION, "ID_TIPO_HABITACION", "NOMBRE", hABITACION.TIPO_HABITACION);
            return View(hABITACION);
        }

        // GET: Habitacion/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HABITACION hABITACION = db.HABITACIONs.Find(id);
            hABITACION.NOMBRE = Util.Cypher.Decrypt(hABITACION.NOMBRE);
            hABITACION.DESCRIPCION = Util.Cypher.Decrypt(hABITACION.DESCRIPCION);
            if (hABITACION == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PRECIO = new SelectList(db.PRECIOs, "ID_PRECIO", "TIPO_PRECIO", hABITACION.ID_PRECIO);
            ViewBag.TIPO_HABITACION = new SelectList(db.TIPO_HABITACION, "ID_TIPO_HABITACION", "NOMBRE", hABITACION.TIPO_HABITACION);
            return View(hABITACION);
        }

        // POST: Habitacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_HABITACION,NUMERO,NOMBRE,DESCRIPCION,FOTO,TIPO_HABITACION,ID_PRECIO")] HABITACION hABITACION)
        {
            if (ModelState.IsValid)
            {
                USUARIO usuarioSesion = (USUARIO)Session["Usuario"];
                String logDetalle = "IDHabitacion:"+ hABITACION .ID_HABITACION+ "Numero:" + hABITACION.NUMERO + "/Nombre:" + hABITACION.NOMBRE + "/Descripcion:" + hABITACION.DESCRIPCION + "/Foto:" + hABITACION.FOTO + "/Tipo Habitacion:" + hABITACION.TIPO_HABITACION + "/Precio:" + hABITACION.ID_PRECIO;
                logDetalle = Util.Cypher.Encrypt(logDetalle);
                hABITACION.NOMBRE = Util.Cypher.Encrypt(hABITACION.NOMBRE);
                hABITACION.DESCRIPCION = Util.Cypher.Encrypt(hABITACION.DESCRIPCION);
                db.InsertBitacora(usuarioSesion.ID_USUARIO, DateTime.Now, 02, "Modificar Habitacion", logDetalle, hABITACION.ID_HABITACION);
                db.Entry(hABITACION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PRECIO = new SelectList(db.PRECIOs, "ID_PRECIO", "TIPO_PRECIO", hABITACION.ID_PRECIO);
            ViewBag.TIPO_HABITACION = new SelectList(db.TIPO_HABITACION, "ID_TIPO_HABITACION", "NOMBRE", hABITACION.TIPO_HABITACION);
            return View(hABITACION);
        }

        // GET: Habitacion/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HABITACION hABITACION = db.HABITACIONs.Find(id);
            hABITACION.NOMBRE = Util.Cypher.Decrypt(hABITACION.NOMBRE);
            hABITACION.DESCRIPCION = Util.Cypher.Decrypt(hABITACION.DESCRIPCION);
            if (hABITACION == null)
            {
                return HttpNotFound();
            }
            return View(hABITACION);
        }

        // POST: Habitacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HABITACION hABITACION = db.HABITACIONs.Find(id);
            USUARIO usuarioSesion = (USUARIO)Session["Usuario"];
            hABITACION.NOMBRE = Util.Cypher.Decrypt(hABITACION.NOMBRE);
            hABITACION.DESCRIPCION = Util.Cypher.Decrypt(hABITACION.DESCRIPCION);
            String logDetalle = "IDHabitacion:" + hABITACION.ID_HABITACION + "Numero:" + hABITACION.NUMERO + "/Nombre:" + hABITACION.NOMBRE + "/Descripcion:" + hABITACION.DESCRIPCION + "/Foto:" + hABITACION.FOTO + "/Tipo Habitacion:" + hABITACION.TIPO_HABITACION + "/Precio:" + hABITACION.PRECIO;
            logDetalle = Util.Cypher.Encrypt(logDetalle);
            db.InsertBitacora(usuarioSesion.ID_USUARIO, DateTime.Now, 03, "Eliminar Habitacion", logDetalle, hABITACION.ID_HABITACION);
            db.HABITACIONs.Remove(hABITACION);
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
