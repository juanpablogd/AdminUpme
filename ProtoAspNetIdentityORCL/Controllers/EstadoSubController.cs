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
    public class EstadoSubController : Controller
    {
        private pcUpmeCnx db = new pcUpmeCnx();

        // GET: /EstadoSub/
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
            return View(db.MUB_ESTADO_SUB.ToList());
        }

        // GET: /EstadoSub/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MUB_ESTADO_SUB mub_estado_sub = db.MUB_ESTADO_SUB.Find(id);
            if (mub_estado_sub == null)
            {
                return HttpNotFound();
            }
            return View(mub_estado_sub);
        }

        // GET: /EstadoSub/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /EstadoSub/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID_ESTADO_SUB,NOM_ESTADO_SUB,ACTIVO")] MUB_ESTADO_SUB mub_estado_sub)
        {
            if (ModelState.IsValid)
            {
                db.MUB_ESTADO_SUB.Add(mub_estado_sub);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mub_estado_sub);
        }

        // GET: /EstadoSub/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MUB_ESTADO_SUB mub_estado_sub = db.MUB_ESTADO_SUB.Find(id);
            if (mub_estado_sub == null)
            {
                return HttpNotFound();
            }
            return View(mub_estado_sub);
        }

        // POST: /EstadoSub/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID_ESTADO_SUB,NOM_ESTADO_SUB,ACTIVO")] MUB_ESTADO_SUB mub_estado_sub)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mub_estado_sub).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mub_estado_sub);
        }

        // GET: /EstadoSub/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MUB_ESTADO_SUB mub_estado_sub = db.MUB_ESTADO_SUB.Find(id);
            if (mub_estado_sub == null)
            {
                return HttpNotFound();
            }
            return View(mub_estado_sub);
        }

        // POST: /EstadoSub/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            MUB_ESTADO_SUB mub_estado_sub = db.MUB_ESTADO_SUB.Find(id);
            db.MUB_ESTADO_SUB.Remove(mub_estado_sub);
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
