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
    public class TensionController : Controller
    {
        private pcUpmeCnx db = new pcUpmeCnx();

        // GET: /Tension/
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
            var mub_tension = db.MUB_TENSION.Include(m => m.MUB_NIVEL_TENSION);
            return View(mub_tension.ToList());
        }

        // GET: /Tension/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MUB_TENSION mub_tension = db.MUB_TENSION.Find(id);
            if (mub_tension == null)
            {
                return HttpNotFound();
            }
            return View(mub_tension);
        }

        // GET: /Tension/Create
        public ActionResult Create()
        {
            ViewBag.ID_NIVEL_TENSION = new SelectList(db.MUB_NIVEL_TENSION, "ID_NIVEL_TENSION", "DESCRIPCION");
            return View();
        }

        // POST: /Tension/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID_TENSION,ID_NIVEL_TENSION,DESCRIPCION")] MUB_TENSION mub_tension)
        {
            if (ModelState.IsValid)
            {
                db.MUB_TENSION.Add(mub_tension);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_NIVEL_TENSION = new SelectList(db.MUB_NIVEL_TENSION, "ID_NIVEL_TENSION", "DESCRIPCION", mub_tension.ID_NIVEL_TENSION);
            return View(mub_tension);
        }

        // GET: /Tension/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MUB_TENSION mub_tension = db.MUB_TENSION.Find(id);
            if (mub_tension == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_NIVEL_TENSION = new SelectList(db.MUB_NIVEL_TENSION, "ID_NIVEL_TENSION", "DESCRIPCION", mub_tension.ID_NIVEL_TENSION);
            return View(mub_tension);
        }

        // POST: /Tension/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID_TENSION,ID_NIVEL_TENSION,DESCRIPCION")] MUB_TENSION mub_tension)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mub_tension).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_NIVEL_TENSION = new SelectList(db.MUB_NIVEL_TENSION, "ID_NIVEL_TENSION", "DESCRIPCION", mub_tension.ID_NIVEL_TENSION);
            return View(mub_tension);
        }

        // GET: /Tension/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MUB_TENSION mub_tension = db.MUB_TENSION.Find(id);
            if (mub_tension == null)
            {
                return HttpNotFound();
            }
            return View(mub_tension);
        }

        // POST: /Tension/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            MUB_TENSION mub_tension = db.MUB_TENSION.Find(id);
            db.MUB_TENSION.Remove(mub_tension);
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
