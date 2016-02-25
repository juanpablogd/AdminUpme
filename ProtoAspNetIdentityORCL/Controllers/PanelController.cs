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
    public class PanelController : Controller
    {
        private geo db = new geo();

        // GET: /Panel/
        public ActionResult Index()
        {
            var geob_panel = db.GEOB_PANEL.Include(g => g.GEOB_ESTADO);
            return View(geob_panel.ToList());
        }

        // GET: /Panel/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GEOB_PANEL geob_panel = db.GEOB_PANEL.Find(id);
            if (geob_panel == null)
            {
                return HttpNotFound();
            }
            return View(geob_panel);
        }

        // GET: /Panel/Create
        public ActionResult Create()
        {
            ViewBag.FK_ID_ESTADO = new SelectList(db.GEOB_ESTADO, "ID_ESTADO", "ESTADO");
            return View();
        }

        // POST: /Panel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID_PANEL,DESCRIPCION,TITULO,FK_ID_ESTADO,FK_ID_USUARIO,FECHA_REGISTRO")] GEOB_PANEL geob_panel)
        {
            if (ModelState.IsValid)
            {
                db.GEOB_PANEL.Add(geob_panel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_ID_ESTADO = new SelectList(db.GEOB_ESTADO, "ID_ESTADO", "ESTADO", geob_panel.FK_ID_ESTADO);
            return View(geob_panel);
        }

        // GET: /Panel/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GEOB_PANEL geob_panel = db.GEOB_PANEL.Find(id);
            if (geob_panel == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_ID_ESTADO = new SelectList(db.GEOB_ESTADO, "ID_ESTADO", "ESTADO", geob_panel.FK_ID_ESTADO);
            return View(geob_panel);
        }

        // POST: /Panel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID_PANEL,DESCRIPCION,TITULO,FK_ID_ESTADO,FK_ID_USUARIO,FECHA_REGISTRO")] GEOB_PANEL geob_panel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(geob_panel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_ID_ESTADO = new SelectList(db.GEOB_ESTADO, "ID_ESTADO", "ESTADO", geob_panel.FK_ID_ESTADO);
            return View(geob_panel);
        }

        // GET: /Panel/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GEOB_PANEL geob_panel = db.GEOB_PANEL.Find(id);
            if (geob_panel == null)
            {
                return HttpNotFound();
            }
            return View(geob_panel);
        }

        // POST: /Panel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            GEOB_PANEL geob_panel = db.GEOB_PANEL.Find(id);
            db.GEOB_PANEL.Remove(geob_panel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult ListadoPanel()
        {
            IQueryable ResultadoQuery = null;

            ResultadoQuery = db.GEOB_PANEL.Select(c => new
            {
                id = c.ID_PANEL,
                titulo = c.TITULO,
                descripcion = c.DESCRIPCION,
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
