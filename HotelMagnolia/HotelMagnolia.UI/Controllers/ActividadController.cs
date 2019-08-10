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
            List<ACTIVIDAD> Encriptada = db.ACTIVIDADs.ToList();
            foreach (ACTIVIDAD i in Encriptada)
            {
                i.NOMBRE = Util.Cypher.Decrypt(i.NOMBRE);
                i.DESCRIPCION = Util.Cypher.Decrypt(i.DESCRIPCION);
            }
            return View(Encriptada);
            //return View(db.ACTIVIDADs.ToList());
        }

        // GET: Actividad/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACTIVIDAD aCTIVIDAD = db.ACTIVIDADs.Find(id);
            aCTIVIDAD.NOMBRE = Util.Cypher.Decrypt(aCTIVIDAD.NOMBRE);
            aCTIVIDAD.DESCRIPCION = Util.Cypher.Decrypt(aCTIVIDAD.DESCRIPCION);
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
                USUARIO usuarioSesion = (USUARIO)Session["Usuario"];
                String logDetalle = "Nombre:" + aCTIVIDAD.NOMBRE + "/Descripcion:" + aCTIVIDAD.DESCRIPCION + "/Foto:" + aCTIVIDAD.IMG;
                aCTIVIDAD.NOMBRE = Util.Cypher.Crypt(aCTIVIDAD.NOMBRE);
                aCTIVIDAD.DESCRIPCION = Util.Cypher.Crypt(aCTIVIDAD.DESCRIPCION);
                logDetalle = Util.Cypher.Crypt(logDetalle);
                db.InsertActividadTEST(aCTIVIDAD.NOMBRE, aCTIVIDAD.DESCRIPCION, aCTIVIDAD.IMG, usuarioSesion.ID_USUARIO, DateTime.Now, 01, "Nueva actividad", logDetalle);
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
            aCTIVIDAD.NOMBRE = Util.Cypher.Decrypt(aCTIVIDAD.NOMBRE);
            aCTIVIDAD.DESCRIPCION = Util.Cypher.Decrypt(aCTIVIDAD.DESCRIPCION);
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
                USUARIO usuarioSesion = (USUARIO)Session["Usuario"];
                String logDetalle = "Nombre:" + aCTIVIDAD.NOMBRE + "/Descripcion:" + aCTIVIDAD.DESCRIPCION + "/Foto:" + aCTIVIDAD.IMG;
                logDetalle = Util.Cypher.Crypt(logDetalle);
                aCTIVIDAD.NOMBRE = Util.Cypher.Crypt(aCTIVIDAD.NOMBRE);
                aCTIVIDAD.DESCRIPCION = Util.Cypher.Crypt(aCTIVIDAD.DESCRIPCION);
                db.InsertBitacora(usuarioSesion.ID_USUARIO, DateTime.Now, 02, "Modificar Actividad", logDetalle, aCTIVIDAD.ID_ACTIVIDAD);
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
            aCTIVIDAD.NOMBRE = Util.Cypher.Decrypt(aCTIVIDAD.NOMBRE);
            aCTIVIDAD.DESCRIPCION = Util.Cypher.Decrypt(aCTIVIDAD.DESCRIPCION);
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
