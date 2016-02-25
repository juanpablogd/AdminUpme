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
    public class CarruselController : Controller
    {
        private geo db = new geo();

        // GET: /Carrusel/
        public ActionResult Index()
        {
            var geob_carrousel = db.GEOB_CARROUSEL.Include(g => g.GEOB_ESTADO);
            return View(geob_carrousel.ToList());
        }

        public ActionResult Home()
        {
            var geob_carrousel = db.GEOB_CARROUSEL.Include(g => g.GEOB_ESTADO);
            return View(geob_carrousel.ToList());
        }
        public ActionResult Visor()
        {
            return View();
        }

        // GET: /Carrusel/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GEOB_CARROUSEL geob_carrousel = db.GEOB_CARROUSEL.Find(id);
            if (geob_carrousel == null)
            {
                return HttpNotFound();
            }
            return View(geob_carrousel);
        }

        // GET: /Carrusel/Create
        public ActionResult Create()
        {
            ViewBag.FK_ID_ESTADO = new SelectList(db.GEOB_ESTADO, "ID_ESTADO", "ESTADO");
            return View();
        }

        // POST: /Carrusel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID_CARROUSEL,TITULO,SUBTITULO,URL_IMG_FONDO,FK_ID_USUARIO,FECHA_REGISTRO,FK_ID_ESTADO")] GEOB_CARROUSEL geob_carrousel)
        {
            if (ModelState.IsValid)
            {
                db.GEOB_CARROUSEL.Add(geob_carrousel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_ID_ESTADO = new SelectList(db.GEOB_ESTADO, "ID_ESTADO", "ESTADO", geob_carrousel.FK_ID_ESTADO);
            return View(geob_carrousel);
        }

        // GET: /Carrusel/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GEOB_CARROUSEL geob_carrousel = db.GEOB_CARROUSEL.Find(id);
            if (geob_carrousel == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_ID_ESTADO = new SelectList(db.GEOB_ESTADO, "ID_ESTADO", "ESTADO", geob_carrousel.FK_ID_ESTADO);
            return View(geob_carrousel);
        }

        // POST: /Carrusel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID_CARROUSEL,TITULO,SUBTITULO,URL_IMG_FONDO,FK_ID_USUARIO,FECHA_REGISTRO,FK_ID_ESTADO")] GEOB_CARROUSEL geob_carrousel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(geob_carrousel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_ID_ESTADO = new SelectList(db.GEOB_ESTADO, "ID_ESTADO", "ESTADO", geob_carrousel.FK_ID_ESTADO);
            return View(geob_carrousel);
        }

        // GET: /Carrusel/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GEOB_CARROUSEL geob_carrousel = db.GEOB_CARROUSEL.Find(id);
            if (geob_carrousel == null)
            {
                return HttpNotFound();
            }
            return View(geob_carrousel);
        }

        // POST: /Carrusel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            GEOB_CARROUSEL geob_carrousel = db.GEOB_CARROUSEL.Find(id);
            db.GEOB_CARROUSEL.Remove(geob_carrousel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ListadoCarrusel()
        {
            IQueryable ResultadoQuery = null;

            ResultadoQuery = db.GEOB_CARROUSEL.Select(c => new
            {
                id = c.ID_CARROUSEL,
                titulo = c.TITULO,
                subtitulo = c.SUBTITULO,
                img = c.URL_IMG_FONDO,
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
