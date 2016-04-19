using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NSPecor.Models;

namespace NSPecor.Controllers
{
    public class ServiciosController : Controller
    {
        private geo db = new geo();

        // GET: /Servicios/
        public ActionResult Index()
        {
            var geob_servicios_catalogo = db.GEOB_SERVICIOS_CATALOGO.Include(g => g.GEOB_ESTADO).Include(g => g.GEOB_TIPO_SRV);
            return View(geob_servicios_catalogo.ToList());
        }


        public ActionResult Geoservicios()
        {
            var geob_servicios_catalogo = db.GEOB_SERVICIOS_CATALOGO.Include(g => g.GEOB_ESTADO).Include(g => g.GEOB_TIPO_SRV);
            return View(geob_servicios_catalogo.ToList());
        }
        // GET: /Servicios/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GEOB_SERVICIOS_CATALOGO geob_servicios_catalogo = db.GEOB_SERVICIOS_CATALOGO.Find(id);
            if (geob_servicios_catalogo == null)
            {
                return HttpNotFound();
            }
            return View(geob_servicios_catalogo);
        }

        // GET: /Servicios/Create
        public ActionResult Create()
        {
            ViewBag.FK_ID_ESTADO = new SelectList(db.GEOB_ESTADO, "ID_ESTADO", "ESTADO");
            ViewBag.FK_ID_TIPO_SRV = new SelectList(db.GEOB_TIPO_SRV, "ID_TIPO_SRV", "NOMBRE");
            return View();
        }

        // POST: /Servicios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SERVICIO,TITULO,DESCRIPCION,URL,TAGS,ZIP,FK_ID_TIPO_SRV,FK_ID_ESTADO,FK_ID_USUARIO,FECHA_REGISTRO")] GEOB_SERVICIOS_CATALOGO geob_servicios_catalogo)
        {
            if (ModelState.IsValid)
            {
                db.GEOB_SERVICIOS_CATALOGO.Add(geob_servicios_catalogo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_ID_ESTADO = new SelectList(db.GEOB_ESTADO, "ID_ESTADO", "ESTADO", geob_servicios_catalogo.FK_ID_ESTADO);
            ViewBag.FK_ID_TIPO_SRV = new SelectList(db.GEOB_TIPO_SRV, "ID_TIPO_SRV", "NOMBRE", geob_servicios_catalogo.FK_ID_TIPO_SRV);
            return View(geob_servicios_catalogo);
        }

        // GET: /Servicios/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GEOB_SERVICIOS_CATALOGO geob_servicios_catalogo = db.GEOB_SERVICIOS_CATALOGO.Find(id);
            if (geob_servicios_catalogo == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_ID_ESTADO = new SelectList(db.GEOB_ESTADO, "ID_ESTADO", "ESTADO", geob_servicios_catalogo.FK_ID_ESTADO);
            ViewBag.FK_ID_TIPO_SRV = new SelectList(db.GEOB_TIPO_SRV, "ID_TIPO_SRV", "NOMBRE", geob_servicios_catalogo.FK_ID_TIPO_SRV);
            return View(geob_servicios_catalogo);
        }

        // POST: /Servicios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SERVICIO,TITULO,DESCRIPCION,URL,TAGS,ZIP,FK_ID_TIPO_SRV,FK_ID_ESTADO,FK_ID_USUARIO,FECHA_REGISTRO")] GEOB_SERVICIOS_CATALOGO geob_servicios_catalogo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(geob_servicios_catalogo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_ID_ESTADO = new SelectList(db.GEOB_ESTADO, "ID_ESTADO", "ESTADO", geob_servicios_catalogo.FK_ID_ESTADO);
            ViewBag.FK_ID_TIPO_SRV = new SelectList(db.GEOB_TIPO_SRV, "ID_TIPO_SRV", "NOMBRE", geob_servicios_catalogo.FK_ID_TIPO_SRV);
            return View(geob_servicios_catalogo);
        }

        // GET: /Servicios/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GEOB_SERVICIOS_CATALOGO geob_servicios_catalogo = db.GEOB_SERVICIOS_CATALOGO.Find(id);
            if (geob_servicios_catalogo == null)
            {
                return HttpNotFound();
            }
            return View(geob_servicios_catalogo);
        }

        // POST: /Servicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            GEOB_SERVICIOS_CATALOGO geob_servicios_catalogo = db.GEOB_SERVICIOS_CATALOGO.Find(id);
            db.GEOB_SERVICIOS_CATALOGO.Remove(geob_servicios_catalogo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ListadoServicios()
        {
            IQueryable ResultadoQuery = null;

            ResultadoQuery = db.GEOB_SERVICIOS_CATALOGO.Select(c => new
            {
                id = c.ID_SERVICIO,
                titulo = c.TITULO,
                descripcion = c.DESCRIPCION,
                url = c.URL,
                id_tipo = c.FK_ID_TIPO_SRV,
                tipo = c.GEOB_TIPO_SRV.NOMBRE,
                estandar = c.GEOB_TIPO_SRV.ESTANDARD,
                tags = c.TAGS,
                estado = c.FK_ID_ESTADO
            });

            return Json(ResultadoQuery, JsonRequestBehavior.AllowGet);
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
