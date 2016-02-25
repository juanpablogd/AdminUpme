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
    public class GruposController : Controller
    {
        private geo db = new geo();

        // GET: /Grupos/
        public ActionResult Index()
        {
            var geob_grupos = db.GEOB_GRUPOS.Include(g => g.GEOB_ESTADO).Include(g => g.GEOB_TEMATICAS);
            return View(geob_grupos.ToList());
        }

        // GET: /Grupos/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GEOB_GRUPOS geob_grupos = db.GEOB_GRUPOS.Find(id);
            if (geob_grupos == null)
            {
                return HttpNotFound();
            }
            return View(geob_grupos);
        }

        // GET: /Grupos/Create
        public ActionResult Create()
        {
            ViewBag.FK_ID_ESTADO = new SelectList(db.GEOB_ESTADO, "ID_ESTADO", "ESTADO");
            ViewBag.FK_ID_TEMATICA = new SelectList(db.GEOB_TEMATICAS, "ID_TEMATICA", "NOMBRE");
            return View();
        }

        // POST: /Grupos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID_GRUPO,GRUPO,FK_ID_TEMATICA,FK_ID_ESTADO,FK_ID_USUARIO,FECHA_REGISTRO")] GEOB_GRUPOS geob_grupos)
        {
            if (ModelState.IsValid)
            {
                db.GEOB_GRUPOS.Add(geob_grupos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_ID_ESTADO = new SelectList(db.GEOB_ESTADO, "ID_ESTADO", "ESTADO", geob_grupos.FK_ID_ESTADO);
            ViewBag.FK_ID_TEMATICA = new SelectList(db.GEOB_TEMATICAS, "ID_TEMATICA", "NOMBRE", geob_grupos.FK_ID_TEMATICA);
            return View(geob_grupos);
        }

        // GET: /Grupos/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GEOB_GRUPOS geob_grupos = db.GEOB_GRUPOS.Find(id);
            if (geob_grupos == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_ID_ESTADO = new SelectList(db.GEOB_ESTADO, "ID_ESTADO", "ESTADO", geob_grupos.FK_ID_ESTADO);
            ViewBag.FK_ID_TEMATICA = new SelectList(db.GEOB_TEMATICAS, "ID_TEMATICA", "NOMBRE", geob_grupos.FK_ID_TEMATICA);
            return View(geob_grupos);
        }

        // POST: /Grupos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID_GRUPO,GRUPO,FK_ID_TEMATICA,FK_ID_ESTADO,FK_ID_USUARIO,FECHA_REGISTRO")] GEOB_GRUPOS geob_grupos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(geob_grupos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_ID_ESTADO = new SelectList(db.GEOB_ESTADO, "ID_ESTADO", "ESTADO", geob_grupos.FK_ID_ESTADO);
            ViewBag.FK_ID_TEMATICA = new SelectList(db.GEOB_TEMATICAS, "ID_TEMATICA", "NOMBRE", geob_grupos.FK_ID_TEMATICA);
            return View(geob_grupos);
        }

        // GET: /Grupos/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GEOB_GRUPOS geob_grupos = db.GEOB_GRUPOS.Find(id);
            if (geob_grupos == null)
            {
                return HttpNotFound();
            }
            return View(geob_grupos);
        }

        // POST: /Grupos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            GEOB_GRUPOS geob_grupos = db.GEOB_GRUPOS.Find(id);
            db.GEOB_GRUPOS.Remove(geob_grupos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ListadoGrupos()
        {
            IQueryable ResultadoQuery = null;

            ResultadoQuery = db.GEOB_GRUPOS.Select(c => new
            {
                id = c.ID_GRUPO,
                titulo = c.GRUPO,
                id_tema = c.FK_ID_TEMATICA,
                tema = c.GEOB_TEMATICAS.NOMBRE,
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
