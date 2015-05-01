using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class OrganizateursController : Controller
    {
        private WebApplication1Context db = new WebApplication1Context();

        // GET: Organizateurs
        public ActionResult Index()
        {
            return View(db.Organizateurs.ToList());
        }

        // GET: Organizateurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organizateur organizateur = db.Organizateurs.Find(id);
            if (organizateur == null)
            {
                return HttpNotFound();
            }
            return View(organizateur);
        }

        // GET: Organizateurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Organizateurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,Age,Specialite")] Organizateur organizateur)
        {
            if (ModelState.IsValid)
            {
                db.Organizateurs.Add(organizateur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(organizateur);
        }

        // GET: Organizateurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organizateur organizateur = db.Organizateurs.Find(id);
            if (organizateur == null)
            {
                return HttpNotFound();
            }
            return View(organizateur);
        }

        // POST: Organizateurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,Age,Specialite")] Organizateur organizateur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organizateur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(organizateur);
        }

        // GET: Organizateurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organizateur organizateur = db.Organizateurs.Find(id);
            if (organizateur == null)
            {
                return HttpNotFound();
            }
            return View(organizateur);
        }

        // POST: Organizateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Organizateur organizateur = db.Organizateurs.Find(id);
            db.Organizateurs.Remove(organizateur);
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
