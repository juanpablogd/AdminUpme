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
    public class ClaseCPController : Controller
    {
        private pcUpmeCnx db = new pcUpmeCnx();

        // GET: /ClaseCP/
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
            return View(db.MUB_CLASE_CP.ToList());
        }

        // GET: /ClaseCP/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MUB_CLASE_CP mub_clase_cp = db.MUB_CLASE_CP.Find(id);
            if (mub_clase_cp == null)
            {
                return HttpNotFound();
            }
            return View(mub_clase_cp);
        }

        // GET: /ClaseCP/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ClaseCP/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID_CLASE_CP,NOM_CLASE_CP,ID_USUARIO_ACTUALIZACION,FECHA_ACTUALIZACION")] MUB_CLASE_CP mub_clase_cp)
        {
            if (ModelState.IsValid)
            {
                mub_clase_cp.ID_USUARIO_ACTUALIZACION = Convert.ToInt32(GlobalVariables.idUsuario);
                db.MUB_CLASE_CP.Add(mub_clase_cp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mub_clase_cp);
        }

        // GET: /ClaseCP/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MUB_CLASE_CP mub_clase_cp = db.MUB_CLASE_CP.Find(id);
            if (mub_clase_cp == null)
            {
                return HttpNotFound();
            }
            return View(mub_clase_cp);
        }

        // POST: /ClaseCP/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID_CLASE_CP,NOM_CLASE_CP,ID_USUARIO_ACTUALIZACION,FECHA_ACTUALIZACION")] MUB_CLASE_CP mub_clase_cp)
        {
            if (ModelState.IsValid)
            {
                mub_clase_cp.ID_USUARIO_ACTUALIZACION = Convert.ToInt32(GlobalVariables.idUsuario);
                db.Entry(mub_clase_cp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mub_clase_cp);
        }

        // GET: /ClaseCP/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MUB_CLASE_CP mub_clase_cp = db.MUB_CLASE_CP.Find(id);
            if (mub_clase_cp == null)
            {
                return HttpNotFound();
            }
            return View(mub_clase_cp);
        }

        // POST: /ClaseCP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            MUB_CLASE_CP mub_clase_cp = db.MUB_CLASE_CP.Find(id);
            db.MUB_CLASE_CP.Remove(mub_clase_cp);
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
