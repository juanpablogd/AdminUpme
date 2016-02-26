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
    public class MapasController : Controller
    {
        private geo db = new geo();

        // GET: /Mapas/
        public ActionResult Index()
        {
            var geob_mapas_catalogo = db.GEOB_MAPAS_CATALOGO.Include(g => g.GEOB_ESTADO).Include(g => g.GEOB_GRUPOS).Include(g => g.GEOB_TIPO_CATALOGO).Include(g => g.GEOB_TEMATICAS);
            return View(geob_mapas_catalogo.ToList());
        }

        [HttpPost]
        public ActionResult Index([Bind(Include = "ID_MAPA,FK_ID_TEMATICA,CATALOGO,TITULO,DESCRIPCION,URL_IMG,URL_MANUAL,TAGS,FK_ID_TIPO_CATAL,URL,FECHA_PUBLICACION,FUENTE,FK_ID_USUARIO,FECHA_REGISTRO,FK_ID_ESTADO,FK_ID_GRUPO")] GEOB_MAPAS_CATALOGO geob_mapas_catalogo)
        {
            var txt_buscar = Request.Form["txt_buscar"];
            if (txt_buscar == "" || txt_buscar == null)
            {   //RETORNA A LA LISTA DE INICIO
                return RedirectToAction("Index", "Mapas");
            }

            var geob_mapas_catalogov = db.GEOB_MAPAS_CATALOGO.Where(h => h.TITULO.Contains(txt_buscar) || h.GEOB_TEMATICAS.DESCRIPCION.Contains(txt_buscar)).Include(g => g.GEOB_ESTADO).Include(g => g.GEOB_GRUPOS).Include(g => g.GEOB_TIPO_CATALOGO).Include(g => g.GEOB_TEMATICAS);
            return View(geob_mapas_catalogov.ToList());

        }

        public ActionResult Mapas()
        {
            var geob_mapas_catalogo = db.GEOB_MAPAS_CATALOGO.Include(g => g.GEOB_ESTADO).Include(g => g.GEOB_GRUPOS).Include(g => g.GEOB_TIPO_CATALOGO).Include(g => g.GEOB_TEMATICAS);
            return View(geob_mapas_catalogo.ToList());
        }

        public ActionResult Visores()
        {
            var geob_mapas_catalogo = db.GEOB_MAPAS_CATALOGO.Include(g => g.GEOB_ESTADO).Include(g => g.GEOB_GRUPOS).Include(g => g.GEOB_TIPO_CATALOGO).Include(g => g.GEOB_TEMATICAS);
            return View(geob_mapas_catalogo.ToList());
        }

        // GET: /Mapas/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GEOB_MAPAS_CATALOGO geob_mapas_catalogo = db.GEOB_MAPAS_CATALOGO.Find(id);
            if (geob_mapas_catalogo == null)
            {
                return HttpNotFound();
            }
            return View(geob_mapas_catalogo);
        }

        // GET: /Mapas/Create
        public ActionResult Create()
        {
            ViewBag.FK_ID_ESTADO = new SelectList(db.GEOB_ESTADO, "ID_ESTADO", "ESTADO");
            ViewBag.FK_ID_GRUPO = new SelectList(db.GEOB_GRUPOS, "ID_GRUPO", "GRUPO");
            ViewBag.FK_ID_TIPO_CATAL = new SelectList(db.GEOB_TIPO_CATALOGO, "ID_TIPO_CATAL", "TIPO_MAPA");
            ViewBag.FK_ID_TEMATICA = new SelectList(db.GEOB_TEMATICAS, "ID_TEMATICA", "NOMBRE");
            return View();
        }

        // POST: /Mapas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID_MAPA,FK_ID_TEMATICA,CATALOGO,TITULO,DESCRIPCION,URL_IMG,URL_MANUAL,TAGS,FK_ID_TIPO_CATAL,URL,FECHA_PUBLICACION,FUENTE,FK_ID_USUARIO,FECHA_REGISTRO,FK_ID_ESTADO,FK_ID_GRUPO")] GEOB_MAPAS_CATALOGO geob_mapas_catalogo)
        {
            if (ModelState.IsValid)
            {
                db.GEOB_MAPAS_CATALOGO.Add(geob_mapas_catalogo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_ID_ESTADO = new SelectList(db.GEOB_ESTADO, "ID_ESTADO", "ESTADO", geob_mapas_catalogo.FK_ID_ESTADO);
            ViewBag.FK_ID_GRUPO = new SelectList(db.GEOB_GRUPOS, "ID_GRUPO", "GRUPO", geob_mapas_catalogo.FK_ID_GRUPO);
            ViewBag.FK_ID_TIPO_CATAL = new SelectList(db.GEOB_TIPO_CATALOGO, "ID_TIPO_CATAL", "TIPO_MAPA", geob_mapas_catalogo.FK_ID_TIPO_CATAL);
            ViewBag.FK_ID_TEMATICA = new SelectList(db.GEOB_TEMATICAS, "ID_TEMATICA", "NOMBRE", geob_mapas_catalogo.FK_ID_TEMATICA);
            return View(geob_mapas_catalogo);
        }

        // GET: /Mapas/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GEOB_MAPAS_CATALOGO geob_mapas_catalogo = db.GEOB_MAPAS_CATALOGO.Find(id);
            if (geob_mapas_catalogo == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_ID_ESTADO = new SelectList(db.GEOB_ESTADO, "ID_ESTADO", "ESTADO", geob_mapas_catalogo.FK_ID_ESTADO);
            ViewBag.FK_ID_GRUPO = new SelectList(db.GEOB_GRUPOS, "ID_GRUPO", "GRUPO", geob_mapas_catalogo.FK_ID_GRUPO);
            ViewBag.FK_ID_TIPO_CATAL = new SelectList(db.GEOB_TIPO_CATALOGO, "ID_TIPO_CATAL", "TIPO_MAPA", geob_mapas_catalogo.FK_ID_TIPO_CATAL);
            ViewBag.FK_ID_TEMATICA = new SelectList(db.GEOB_TEMATICAS, "ID_TEMATICA", "NOMBRE", geob_mapas_catalogo.FK_ID_TEMATICA);
            return View(geob_mapas_catalogo);
        }

        // POST: /Mapas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID_MAPA,FK_ID_TEMATICA,CATALOGO,TITULO,DESCRIPCION,URL_IMG,URL_MANUAL,TAGS,FK_ID_TIPO_CATAL,URL,FECHA_PUBLICACION,FUENTE,FK_ID_USUARIO,FECHA_REGISTRO,FK_ID_ESTADO,FK_ID_GRUPO")] GEOB_MAPAS_CATALOGO geob_mapas_catalogo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(geob_mapas_catalogo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_ID_ESTADO = new SelectList(db.GEOB_ESTADO, "ID_ESTADO", "ESTADO", geob_mapas_catalogo.FK_ID_ESTADO);
            ViewBag.FK_ID_GRUPO = new SelectList(db.GEOB_GRUPOS, "ID_GRUPO", "GRUPO", geob_mapas_catalogo.FK_ID_GRUPO);
            ViewBag.FK_ID_TIPO_CATAL = new SelectList(db.GEOB_TIPO_CATALOGO, "ID_TIPO_CATAL", "TIPO_MAPA", geob_mapas_catalogo.FK_ID_TIPO_CATAL);
            ViewBag.FK_ID_TEMATICA = new SelectList(db.GEOB_TEMATICAS, "ID_TEMATICA", "NOMBRE", geob_mapas_catalogo.FK_ID_TEMATICA);
            return View(geob_mapas_catalogo);
        }

        // GET: /Mapas/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GEOB_MAPAS_CATALOGO geob_mapas_catalogo = db.GEOB_MAPAS_CATALOGO.Find(id);
            if (geob_mapas_catalogo == null)
            {
                return HttpNotFound();
            }
            return View(geob_mapas_catalogo);
        }

        // POST: /Mapas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            GEOB_MAPAS_CATALOGO geob_mapas_catalogo = db.GEOB_MAPAS_CATALOGO.Find(id);
            db.GEOB_MAPAS_CATALOGO.Remove(geob_mapas_catalogo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ListadoMapas()
        {
            IQueryable ResultadoQuery = null;

            ResultadoQuery = db.GEOB_MAPAS_CATALOGO.Select(c => new
            {
                id = c.ID_MAPA,
                titulo = c.TITULO,
                descripcion = c.DESCRIPCION,
                id_tema = c.FK_ID_TEMATICA,
                tema = c.GEOB_TEMATICAS.NOMBRE,
                id_catalogo = c.FK_ID_TIPO_CATAL,
                catalogo = c.GEOB_TIPO_CATALOGO.TIPO_MAPA,
                id_grupo = c.FK_ID_GRUPO,
                grupo = c.GEOB_GRUPOS.GRUPO,
                tags = c.TAGS,
                url_mapa = c.URL,
                img = c.URL_IMG,
                manual = c.URL_MANUAL,
                fuente =c.FUENTE,
                fecha_pub = c.FECHA_PUBLICACION,
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
