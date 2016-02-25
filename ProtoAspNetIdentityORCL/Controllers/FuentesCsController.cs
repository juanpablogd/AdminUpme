using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NSPecor.Models;
using Microsoft.AspNet.Identity;

namespace NSPecor.Controllers
{
    public class FuentesCsController : Controller
    {
        private pcUpmeCnx db = new pcUpmeCnx();

        // GET: /FuentesCs/
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated == false || GlobalVariables.Acceso("ADMIN") == false)
            {
                return RedirectToAction("../Home/Index/");
            }
            else
            {
                if (GlobalVariables.idUsuario == null || GlobalVariables.idUsuario == "" || GlobalVariables.idOrganizacion == null)
                {
                    var usr_actual = User.Identity.GetUserName();
                    foreach (var item in db.MUB_USUARIOS.Where(u => u.EMAIL == usr_actual.ToString()))
                    {
                        GlobalVariables.idUsuario = item.ID_USUARIO.ToString();
                        GlobalVariables.idOrganizacion = item.ID_ORGANIZACION.ToString();
                    }
                }
            }
            return View(db.MUB_FUENTES_CS.ToList());
        }

        // GET: /FuentesCs/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MUB_FUENTES_CS mub_fuentes_cs = db.MUB_FUENTES_CS.Find(id);
            if (mub_fuentes_cs == null)
            {
                return HttpNotFound();
            }
            return View(mub_fuentes_cs);
        }

        // GET: /FuentesCs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /FuentesCs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID_FUENTE_CS,NOM_FUENTE_CS,ID_USUARIO_ACTUALIZACION,FECHA_ACTUALIZACION")] MUB_FUENTES_CS mub_fuentes_cs)
        {
            if (ModelState.IsValid)
            {
                db.MUB_FUENTES_CS.Add(mub_fuentes_cs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mub_fuentes_cs);
        }

        // GET: /FuentesCs/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MUB_FUENTES_CS mub_fuentes_cs = db.MUB_FUENTES_CS.Find(id);
            if (mub_fuentes_cs == null)
            {
                return HttpNotFound();
            }
            return View(mub_fuentes_cs);
        }

        // POST: /FuentesCs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID_FUENTE_CS,NOM_FUENTE_CS,ID_USUARIO_ACTUALIZACION,FECHA_ACTUALIZACION")] MUB_FUENTES_CS mub_fuentes_cs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mub_fuentes_cs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mub_fuentes_cs);
        }

        // GET: /FuentesCs/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MUB_FUENTES_CS mub_fuentes_cs = db.MUB_FUENTES_CS.Find(id);
            if (mub_fuentes_cs == null)
            {
                return HttpNotFound();
            }
            return View(mub_fuentes_cs);
        }

        // POST: /FuentesCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            MUB_FUENTES_CS mub_fuentes_cs = db.MUB_FUENTES_CS.Find(id);
            db.MUB_FUENTES_CS.Remove(mub_fuentes_cs);
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
