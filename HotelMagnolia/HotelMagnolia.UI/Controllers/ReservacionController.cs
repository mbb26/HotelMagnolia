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
    public class ReservacionController : Controller
    {
        private HotelMagnoliaEntities db = new HotelMagnoliaEntities();

        // GET: Reservacion
        public ActionResult Index()
        {
            var rESERVACIONs = db.RESERVACIONs.Include(r => r.CLIENTE).Include(r => r.ESTADO_RESERVACION1).Include(r => r.TIPO_HABITACION1);
            return View(rESERVACIONs.ToList());
        }

        // GET: Reservacion/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESERVACION rESERVACION = db.RESERVACIONs.Find(id);
            if (rESERVACION == null)
            {
                return HttpNotFound();
            }
            return View(rESERVACION);
        }

        // GET: Reservacion/Create
        public ActionResult Create()
        {
            //ViewBag.ID_CLIENTE = new SelectList(db.CLIENTEs, "ID_CLIENTE", "NOMBRE");
            ViewBag.ESTADO_RESERVACION = new SelectList(db.ESTADO_RESERVACION, "ID_ESTADO", "NOMBRE");
            //ViewBag.TIPO_HABITACION = new SelectList(db.TIPO_HABITACION, "ID_TIPO_HABITACION", "NOMBRE");
            var ClientesNuevo = new List<SelectListItem>();
            List<CLIENTE> clientes = db.CLIENTEs.ToList();
            foreach (CLIENTE i in clientes)
            {
                var nuevo = new SelectListItem();
                nuevo.Value = (i.ID_CLIENTE).ToString();
                nuevo.Text = Util.Cypher.Decrypt(i.NOMBRE);
                ClientesNuevo.Add(nuevo);
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
            ViewBag.ID_CLIENTE = ClientesNuevo;
            ViewBag.TIPO_HABITACION = TipoHabitacionNuevo;
            return View();
        }

        // POST: Reservacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_RESERVACION,ID_CLIENTE,FECHA_ENTRADA,FECHA_SALIDA,TIPO_HABITACION,ESTADO_RESERVACION")] RESERVACION rESERVACION)
        {
            if (ModelState.IsValid)
            {
                USUARIO usuarioSesion = (USUARIO)Session["Usuario"];

                String LogDetalle = "IDCliente:" + rESERVACION.ID_CLIENTE + "/Fecha Entrada:" + rESERVACION.FECHA_ENTRADA + "/Fecha Salida:" + rESERVACION.FECHA_SALIDA + "/Tipo Habitacion:" + rESERVACION.TIPO_HABITACION + "/Estado:" + rESERVACION.ESTADO_RESERVACION;
                LogDetalle = Util.Cypher.Encrypt(LogDetalle);
                //db.InsertReservacion(rESERVACION.ID_CLIENTE, rESERVACION.FECHA_ENTRADA, rESERVACION.FECHA_SALIDA, rESERVACION.TIPO_HABITACION, rESERVACION.ESTADO_RESERVACION, usuarioSesion.ID_USUARIO, DateTime.Now, 1, "Nueva Reservacion", LogDetalle);
                db.InsertReservacion(rESERVACION.ID_CLIENTE, rESERVACION.FECHA_ENTRADA, rESERVACION.FECHA_SALIDA, rESERVACION.TIPO_HABITACION, rESERVACION.ESTADO_RESERVACION, usuarioSesion.ID_USUARIO, DateTime.Now, 1, "Nueva reservacion", LogDetalle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTEs, "ID_CLIENTE", "NOMBRE", rESERVACION.ID_CLIENTE);
            ViewBag.ESTADO_RESERVACION = new SelectList(db.ESTADO_RESERVACION, "ID_ESTADO", "NOMBRE", rESERVACION.ESTADO_RESERVACION);
            ViewBag.TIPO_HABITACION = new SelectList(db.TIPO_HABITACION, "ID_TIPO_HABITACION", "NOMBRE", rESERVACION.TIPO_HABITACION);
            return View(rESERVACION);
        }

        // GET: Reservacion/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESERVACION rESERVACION = db.RESERVACIONs.Find(id);
            if (rESERVACION == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTEs, "ID_CLIENTE", "NOMBRE", rESERVACION.ID_CLIENTE);
            ViewBag.ESTADO_RESERVACION = new SelectList(db.ESTADO_RESERVACION, "ID_ESTADO", "NOMBRE", rESERVACION.ESTADO_RESERVACION);
            ViewBag.TIPO_HABITACION = new SelectList(db.TIPO_HABITACION, "ID_TIPO_HABITACION", "NOMBRE", rESERVACION.TIPO_HABITACION);
            return View(rESERVACION);
        }

        // POST: Reservacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_RESERVACION,ID_CLIENTE,FECHA_ENTRADA,FECHA_SALIDA,TIPO_HABITACION,ESTADO_RESERVACION")] RESERVACION rESERVACION)
        {
            if (ModelState.IsValid)
            {
                USUARIO usuarioSesion = (USUARIO)Session["Usuario"];

                String LogDetalle = "IDCliente:" + rESERVACION.ID_CLIENTE + "/Fecha Entrada:" + rESERVACION.FECHA_ENTRADA + "/Fecha Salida:" + rESERVACION.FECHA_SALIDA + "/Tipo Habitacion:" + rESERVACION.TIPO_HABITACION + "/Estado:" + rESERVACION.ESTADO_RESERVACION;
                LogDetalle = Util.Cypher.Encrypt(LogDetalle);
                db.InsertBitacora(usuarioSesion.ID_USUARIO, 2, "Modificar Reservacion", LogDetalle, rESERVACION.ID_RESERVACION);
                db.Entry(rESERVACION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTEs, "ID_CLIENTE", "NOMBRE", rESERVACION.ID_CLIENTE);
            ViewBag.ESTADO_RESERVACION = new SelectList(db.ESTADO_RESERVACION, "ID_ESTADO", "NOMBRE", rESERVACION.ESTADO_RESERVACION);
            ViewBag.TIPO_HABITACION = new SelectList(db.TIPO_HABITACION, "ID_TIPO_HABITACION", "NOMBRE", rESERVACION.TIPO_HABITACION);
            return View(rESERVACION);
        }

        // GET: Reservacion/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESERVACION rESERVACION = db.RESERVACIONs.Find(id);
            if (rESERVACION == null)
            {
                return HttpNotFound();
            }
            return View(rESERVACION);
        }

        // POST: Reservacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            RESERVACION rESERVACION = db.RESERVACIONs.Find(id);
            USUARIO usuarioSesion = (USUARIO)Session["Usuario"];
            String LogDetalle = "IDCliente:" + rESERVACION.ID_CLIENTE + "/Fecha Entrada:" + rESERVACION.FECHA_ENTRADA + "/Fecha Salida:" + rESERVACION.FECHA_SALIDA + "/Tipo Habitacion:" + rESERVACION.TIPO_HABITACION + "/Estado:" + rESERVACION.ESTADO_RESERVACION;
            LogDetalle = Util.Cypher.Encrypt(LogDetalle);
            db.InsertBitacora(usuarioSesion.ID_USUARIO, 3, "EliminarReservacion", LogDetalle, rESERVACION.ID_RESERVACION);
            db.RESERVACIONs.Remove(rESERVACION);
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
