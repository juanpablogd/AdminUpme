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
    public class TematicasController : Controller
    {
        private geo db = new geo();

        // GET: /Tematicas/
        public ActionResult Index()
        {
            var geob_tematicas = db.GEOB_TEMATICAS.Include(g => g.GEOB_ESTADO);
            return View(geob_tematicas.ToList());
        }

        // GET: /Tematicas/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GEOB_TEMATICAS geob_tematicas = db.GEOB_TEMATICAS.Find(id);
            if (geob_tematicas == null)
            {
                return HttpNotFound();
            }
            return View(geob_tematicas);
        }

        // GET: /Tematicas/Create
        public ActionResult Create()
        {
            ViewBag.FK_ID_ESTADO = new SelectList(db.GEOB_ESTADO, "ID_ESTADO", "ESTADO");
            return View();
        }

        // POST: /Tematicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID_TEMATICA,NOMBRE,URL_IMG,FK_ID_ESTADO,FK_ID_USUARIO,FECHA_REGISTRO,DESCRIPCION")] GEOB_TEMATICAS geob_tematicas)
        {
            if (ModelState.IsValid)
            {
                db.GEOB_TEMATICAS.Add(geob_tematicas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_ID_ESTADO = new SelectList(db.GEOB_ESTADO, "ID_ESTADO", "ESTADO", geob_tematicas.FK_ID_ESTADO);
            return View(geob_tematicas);
        }

        // GET: /Tematicas/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GEOB_TEMATICAS geob_tematicas = db.GEOB_TEMATICAS.Find(id);
            if (geob_tematicas == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_ID_ESTADO = new SelectList(db.GEOB_ESTADO, "ID_ESTADO", "ESTADO", geob_tematicas.FK_ID_ESTADO);
            return View(geob_tematicas);
        }

        // POST: /Tematicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID_TEMATICA,NOMBRE,URL_IMG,FK_ID_ESTADO,FK_ID_USUARIO,FECHA_REGISTRO,DESCRIPCION")] GEOB_TEMATICAS geob_tematicas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(geob_tematicas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_ID_ESTADO = new SelectList(db.GEOB_ESTADO, "ID_ESTADO", "ESTADO", geob_tematicas.FK_ID_ESTADO);
            return View(geob_tematicas);
        }

        // GET: /Tematicas/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GEOB_TEMATICAS geob_tematicas = db.GEOB_TEMATICAS.Find(id);
            if (geob_tematicas == null)
            {
                return HttpNotFound();
            }
            return View(geob_tematicas);
        }

        // POST: /Tematicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            GEOB_TEMATICAS geob_tematicas = db.GEOB_TEMATICAS.Find(id);
            db.GEOB_TEMATICAS.Remove(geob_tematicas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult ListadoTemas()
        {
            IQueryable ResultadoQuery = null;

            ResultadoQuery = db.GEOB_TEMATICAS.Select(c => new
            {
                id = c.ID_TEMATICA,
                titulo = c.NOMBRE,
                descripcion = c.DESCRIPCION,
                img = c.URL_IMG,
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
