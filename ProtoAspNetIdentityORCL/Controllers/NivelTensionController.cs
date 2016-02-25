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
    public class NivelTensionController : Controller
    {
        private pcUpmeCnx db = new pcUpmeCnx();

        // GET: /NivelTension/
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
            return View(db.MUB_NIVEL_TENSION.ToList());
        }

        // GET: /NivelTension/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MUB_NIVEL_TENSION mub_nivel_tension = db.MUB_NIVEL_TENSION.Find(id);
            if (mub_nivel_tension == null)
            {
                return HttpNotFound();
            }
            return View(mub_nivel_tension);
        }

        // GET: /NivelTension/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /NivelTension/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID_NIVEL_TENSION,DESCRIPCION")] MUB_NIVEL_TENSION mub_nivel_tension)
        {
            if (ModelState.IsValid)
            {
                db.MUB_NIVEL_TENSION.Add(mub_nivel_tension);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mub_nivel_tension);
        }

        // GET: /NivelTension/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MUB_NIVEL_TENSION mub_nivel_tension = db.MUB_NIVEL_TENSION.Find(id);
            if (mub_nivel_tension == null)
            {
                return HttpNotFound();
            }
            return View(mub_nivel_tension);
        }

        // POST: /NivelTension/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID_NIVEL_TENSION,DESCRIPCION")] MUB_NIVEL_TENSION mub_nivel_tension)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mub_nivel_tension).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mub_nivel_tension);
        }

        // GET: /NivelTension/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MUB_NIVEL_TENSION mub_nivel_tension = db.MUB_NIVEL_TENSION.Find(id);
            if (mub_nivel_tension == null)
            {
                return HttpNotFound();
            }
            return View(mub_nivel_tension);
        }

        // POST: /NivelTension/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            MUB_NIVEL_TENSION mub_nivel_tension = db.MUB_NIVEL_TENSION.Find(id);
            db.MUB_NIVEL_TENSION.Remove(mub_nivel_tension);
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
