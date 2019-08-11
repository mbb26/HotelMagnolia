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
    public class ClienteController : Controller
    {
        private HotelMagnoliaEntities db = new HotelMagnoliaEntities();

        // GET: Cliente
        public ActionResult Index()
        {
            var cLIENTEs = db.CLIENTEs.Include(c => c.HABITACION);
            List<CLIENTE> encriptada = cLIENTEs.ToList();
            foreach(CLIENTE i in encriptada)
            {
                i.NOMBRE = Util.Cypher.Decrypt(i.NOMBRE);
            }
            return View(cLIENTEs.ToList());
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE cLIENTE = db.CLIENTEs.Find(id);
            cLIENTE.NOMBRE = Util.Cypher.Decrypt(cLIENTE.NOMBRE);
            if (cLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(cLIENTE);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            ViewBag.ID_HABITACION = new SelectList(db.HABITACIONs, "ID_HABITACION", "NOMBRE");
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_CLIENTE,NOMBRE,ACTIVO,ID_HABITACION")] CLIENTE cLIENTE)
        {
            if (ModelState.IsValid)
            {
                USUARIO usuarioSesion = (USUARIO)Session["Usuario"];
                cLIENTE.NOMBRE = Util.Cypher.Encrypt(cLIENTE.NOMBRE);
                String logDetalle = "IDCliente:" + cLIENTE.ID_CLIENTE+ "Nombre" + cLIENTE.NOMBRE + "/Activo:" + cLIENTE.ACTIVO.ToString() +"/IDHabitacion:"+cLIENTE.ID_HABITACION;
                logDetalle = Util.Cypher.Encrypt(logDetalle);
                db.InsertBitacora(usuarioSesion.ID_USUARIO, DateTime.Now, 01, "Insertar cliente", logDetalle , cLIENTE.ID_CLIENTE.ToString());
                db.CLIENTEs.Add(cLIENTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_HABITACION = new SelectList(db.HABITACIONs, "ID_HABITACION", "NOMBRE", cLIENTE.ID_HABITACION);
            return View(cLIENTE);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE cLIENTE = db.CLIENTEs.Find(id);
            cLIENTE.NOMBRE = Util.Cypher.Decrypt(cLIENTE.NOMBRE);

            
            if (cLIENTE == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_HABITACION = new SelectList(db.HABITACIONs, "ID_HABITACION", "NOMBRE", cLIENTE.ID_HABITACION);
            return View(cLIENTE);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_CLIENTE,NOMBRE,ACTIVO,ID_HABITACION")] CLIENTE cLIENTE)
        {
            if (ModelState.IsValid)
            {
                USUARIO usuarioSesion = (USUARIO)Session["Usuario"];
                String logDetalle = "IDCliente:" + cLIENTE.ID_CLIENTE + "Nombre" + cLIENTE.NOMBRE + "/Activo:" + cLIENTE.ACTIVO.ToString() + "/IDHabitacion:" + cLIENTE.ID_HABITACION;
                logDetalle = Util.Cypher.Encrypt(logDetalle);
                db.InsertBitacora(usuarioSesion.ID_USUARIO, DateTime.Now, 02, "Modificar cliente", logDetalle, cLIENTE.ID_CLIENTE.ToString());
                cLIENTE.NOMBRE = Util.Cypher.Encrypt(cLIENTE.NOMBRE);
                db.Entry(cLIENTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_HABITACION = new SelectList(db.HABITACIONs, "ID_HABITACION", "NOMBRE", cLIENTE.ID_HABITACION);
            return View(cLIENTE);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE cLIENTE = db.CLIENTEs.Find(id);
            cLIENTE.NOMBRE = Util.Cypher.Decrypt(cLIENTE.NOMBRE);
            if (cLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(cLIENTE);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLIENTE cLIENTE = db.CLIENTEs.Find(id);

            USUARIO usuarioSesion = (USUARIO)Session["Usuario"];
            String logDetalle = "IDCliente:" + cLIENTE.ID_CLIENTE + "Nombre" + cLIENTE.NOMBRE + "/Activo:" + cLIENTE.ACTIVO.ToString() + "/IDHabitacion:" + cLIENTE.ID_HABITACION;
            logDetalle = Util.Cypher.Encrypt(logDetalle);
            db.InsertBitacora(usuarioSesion.ID_USUARIO, DateTime.Now, 03, "Eliminar cliente", logDetalle, cLIENTE.ID_CLIENTE.ToString());

            db.CLIENTEs.Remove(cLIENTE);
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
