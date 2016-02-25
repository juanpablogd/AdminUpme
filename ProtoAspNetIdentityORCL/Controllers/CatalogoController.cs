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
    public class CatalogoController : Controller
    {
        private geo db = new geo();

        // GET: /Catalogo/
        public ActionResult Index()
        {
            var geob_tipo_catalogo = db.GEOB_TIPO_CATALOGO.Include(g => g.GEOB_ESTADO);
            return View(geob_tipo_catalogo.ToList());
        }

        // GET: /Catalogo/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GEOB_TIPO_CATALOGO geob_tipo_catalogo = db.GEOB_TIPO_CATALOGO.Find(id);
            if (geob_tipo_catalogo == null)
            {
                return HttpNotFound();
            }
            return View(geob_tipo_catalogo);
        }

        // GET: /Catalogo/Create
        public ActionResult Create()
        {
            ViewBag.FK_ID_ESTADO = new SelectList(db.GEOB_ESTADO, "ID_ESTADO", "ESTADO");
            return View();
        }

        // POST: /Catalogo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID_TIPO_CATAL,TIPO_MAPA,FK_ID_ESTADO")] GEOB_TIPO_CATALOGO geob_tipo_catalogo)
        {
            if (ModelState.IsValid)
            {
                db.GEOB_TIPO_CATALOGO.Add(geob_tipo_catalogo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_ID_ESTADO = new SelectList(db.GEOB_ESTADO, "ID_ESTADO", "ESTADO", geob_tipo_catalogo.FK_ID_ESTADO);
            return View(geob_tipo_catalogo);
        }

        // GET: /Catalogo/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GEOB_TIPO_CATALOGO geob_tipo_catalogo = db.GEOB_TIPO_CATALOGO.Find(id);
            if (geob_tipo_catalogo == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_ID_ESTADO = new SelectList(db.GEOB_ESTADO, "ID_ESTADO", "ESTADO", geob_tipo_catalogo.FK_ID_ESTADO);
            return View(geob_tipo_catalogo);
        }

        // POST: /Catalogo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID_TIPO_CATAL,TIPO_MAPA,FK_ID_ESTADO")] GEOB_TIPO_CATALOGO geob_tipo_catalogo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(geob_tipo_catalogo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_ID_ESTADO = new SelectList(db.GEOB_ESTADO, "ID_ESTADO", "ESTADO", geob_tipo_catalogo.FK_ID_ESTADO);
            return View(geob_tipo_catalogo);
        }

        // GET: /Catalogo/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GEOB_TIPO_CATALOGO geob_tipo_catalogo = db.GEOB_TIPO_CATALOGO.Find(id);
            if (geob_tipo_catalogo == null)
            {
                return HttpNotFound();
            }
            return View(geob_tipo_catalogo);
        }

        // POST: /Catalogo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            GEOB_TIPO_CATALOGO geob_tipo_catalogo = db.GEOB_TIPO_CATALOGO.Find(id);
            db.GEOB_TIPO_CATALOGO.Remove(geob_tipo_catalogo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ListadoCatalogo()
        {
            IQueryable ResultadoQuery = null;

            ResultadoQuery = db.GEOB_TIPO_CATALOGO.Select(c => new
            {
                id = c.ID_TIPO_CATAL,
                titulo = c.TIPO_MAPA,
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
