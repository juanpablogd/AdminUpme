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
    public class EnlacesController : Controller
    {
        private geo db = new geo();

        // GET: /Enlaces/
        public ActionResult Index()
        {
            var geob_enlaces_panel = db.GEOB_ENLACES_PANEL.Include(g => g.GEOB_ESTADO).Include(g => g.GEOB_PANEL);
            return View(geob_enlaces_panel.ToList());
        }

        // GET: /Enlaces/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GEOB_ENLACES_PANEL geob_enlaces_panel = db.GEOB_ENLACES_PANEL.Find(id);
            if (geob_enlaces_panel == null)
            {
                return HttpNotFound();
            }
            return View(geob_enlaces_panel);
        }

        // GET: /Enlaces/Create
        public ActionResult Create()
        {
            ViewBag.FK_ID_ESTADO = new SelectList(db.GEOB_ESTADO, "ID_ESTADO", "ESTADO");
            ViewBag.FK_ID_PANEL = new SelectList(db.GEOB_PANEL, "ID_PANEL", "DESCRIPCION");
            return View();
        }

        // POST: /Enlaces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID_ENLACE,FK_ID_PANEL,TITULO,DESCRIPCION,URL_ENLACE,FK_ID_ESTADO,FK_ID_USUARIO,FECHA_REGISTRO")] GEOB_ENLACES_PANEL geob_enlaces_panel)
        {
            if (ModelState.IsValid)
            {
                db.GEOB_ENLACES_PANEL.Add(geob_enlaces_panel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_ID_ESTADO = new SelectList(db.GEOB_ESTADO, "ID_ESTADO", "ESTADO", geob_enlaces_panel.FK_ID_ESTADO);
            ViewBag.FK_ID_PANEL = new SelectList(db.GEOB_PANEL, "ID_PANEL", "DESCRIPCION", geob_enlaces_panel.FK_ID_PANEL);
            return View(geob_enlaces_panel);
        }

        // GET: /Enlaces/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GEOB_ENLACES_PANEL geob_enlaces_panel = db.GEOB_ENLACES_PANEL.Find(id);
            if (geob_enlaces_panel == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_ID_ESTADO = new SelectList(db.GEOB_ESTADO, "ID_ESTADO", "ESTADO", geob_enlaces_panel.FK_ID_ESTADO);
            ViewBag.FK_ID_PANEL = new SelectList(db.GEOB_PANEL, "ID_PANEL", "DESCRIPCION", geob_enlaces_panel.FK_ID_PANEL);
            return View(geob_enlaces_panel);
        }

        // POST: /Enlaces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID_ENLACE,FK_ID_PANEL,TITULO,DESCRIPCION,URL_ENLACE,FK_ID_ESTADO,FK_ID_USUARIO,FECHA_REGISTRO")] GEOB_ENLACES_PANEL geob_enlaces_panel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(geob_enlaces_panel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_ID_ESTADO = new SelectList(db.GEOB_ESTADO, "ID_ESTADO", "ESTADO", geob_enlaces_panel.FK_ID_ESTADO);
            ViewBag.FK_ID_PANEL = new SelectList(db.GEOB_PANEL, "ID_PANEL", "DESCRIPCION", geob_enlaces_panel.FK_ID_PANEL);
            return View(geob_enlaces_panel);
        }

        // GET: /Enlaces/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GEOB_ENLACES_PANEL geob_enlaces_panel = db.GEOB_ENLACES_PANEL.Find(id);
            if (geob_enlaces_panel == null)
            {
                return HttpNotFound();
            }
            return View(geob_enlaces_panel);
        }

        // POST: /Enlaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            GEOB_ENLACES_PANEL geob_enlaces_panel = db.GEOB_ENLACES_PANEL.Find(id);
            db.GEOB_ENLACES_PANEL.Remove(geob_enlaces_panel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ListadoEnlaces()
        {
            IQueryable ResultadoQuery = null;

            ResultadoQuery = db.GEOB_ENLACES_PANEL.Select(c => new
            {
                id = c.ID_ENLACE,
                titulo = c.TITULO,
                descripcion = c.DESCRIPCION,
                url = c.URL_ENLACE,
                id_panel = c.FK_ID_PANEL,
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
