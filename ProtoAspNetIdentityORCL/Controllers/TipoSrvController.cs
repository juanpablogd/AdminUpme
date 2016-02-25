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
    public class TipoSrvController : Controller
    {
        private geo db = new geo();

        // GET: /TipoSrv/
        public ActionResult Index()
        {
            var geob_tipo_srv = db.GEOB_TIPO_SRV.Include(g => g.GEOB_ESTADO);
            return View(geob_tipo_srv.ToList());
        }

        // GET: /TipoSrv/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GEOB_TIPO_SRV geob_tipo_srv = db.GEOB_TIPO_SRV.Find(id);
            if (geob_tipo_srv == null)
            {
                return HttpNotFound();
            }
            return View(geob_tipo_srv);
        }

        // GET: /TipoSrv/Create
        public ActionResult Create()
        {
            ViewBag.FK_ID_ESTADO = new SelectList(db.GEOB_ESTADO, "ID_ESTADO", "ESTADO");
            return View();
        }

        // POST: /TipoSrv/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID_TIPO_SRV,NOMBRE,ESTANDARD,FK_ID_ESTADO,FK_ID_USUARIO,FECHA_REGISTRO")] GEOB_TIPO_SRV geob_tipo_srv)
        {
            if (ModelState.IsValid)
            {
                db.GEOB_TIPO_SRV.Add(geob_tipo_srv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_ID_ESTADO = new SelectList(db.GEOB_ESTADO, "ID_ESTADO", "ESTADO", geob_tipo_srv.FK_ID_ESTADO);
            return View(geob_tipo_srv);
        }

        // GET: /TipoSrv/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GEOB_TIPO_SRV geob_tipo_srv = db.GEOB_TIPO_SRV.Find(id);
            if (geob_tipo_srv == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_ID_ESTADO = new SelectList(db.GEOB_ESTADO, "ID_ESTADO", "ESTADO", geob_tipo_srv.FK_ID_ESTADO);
            return View(geob_tipo_srv);
        }

        // POST: /TipoSrv/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID_TIPO_SRV,NOMBRE,ESTANDARD,FK_ID_ESTADO,FK_ID_USUARIO,FECHA_REGISTRO")] GEOB_TIPO_SRV geob_tipo_srv)
        {
            if (ModelState.IsValid)
            {
                db.Entry(geob_tipo_srv).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_ID_ESTADO = new SelectList(db.GEOB_ESTADO, "ID_ESTADO", "ESTADO", geob_tipo_srv.FK_ID_ESTADO);
            return View(geob_tipo_srv);
        }

        // GET: /TipoSrv/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GEOB_TIPO_SRV geob_tipo_srv = db.GEOB_TIPO_SRV.Find(id);
            if (geob_tipo_srv == null)
            {
                return HttpNotFound();
            }
            return View(geob_tipo_srv);
        }

        // POST: /TipoSrv/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            GEOB_TIPO_SRV geob_tipo_srv = db.GEOB_TIPO_SRV.Find(id);
            db.GEOB_TIPO_SRV.Remove(geob_tipo_srv);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ListadoTipoSrv()
        {
            IQueryable ResultadoQuery = null;

            ResultadoQuery = db.GEOB_TIPO_SRV.Select(c => new
            {
                id = c.ID_TIPO_SRV,
                titulo = c.NOMBRE,
                descripcion = c.ESTANDARD,
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
