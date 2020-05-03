using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using spletna_aplikacija.Models;
using System.Xml;

namespace spletna_aplikacija.Controllers
{
    public class miljardersController : Controller
    {
        private miljarderjiEntities db = new miljarderjiEntities();

        // GET: miljarders
        public ActionResult Index()
        {
            return View(db.miljarder.ToList());
        }

        public ActionResult toJson()
        {
            string x;

            return View(db.miljarder.ToList());

        }

        // GET: miljarders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            miljarder miljarder = db.miljarder.Find(id);
            if (miljarder == null)
            {
                return HttpNotFound();
            }
            return View(miljarder);
        }

        // GET: miljarders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: miljarders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ime,Priimek,premozenje,podjetje")] miljarder miljarder)
        {
            if (ModelState.IsValid)
            {
                db.miljarder.Add(miljarder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(miljarder);
        }

        // GET: miljarders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            miljarder miljarder = db.miljarder.Find(id);
            if (miljarder == null)
            {
                return HttpNotFound();
            }
            return View(miljarder);
        }

        // POST: miljarders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ime,Priimek,premozenje,podjetje")] miljarder miljarder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(miljarder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(miljarder);
        }

        // GET: miljarders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            miljarder miljarder = db.miljarder.Find(id);
            if (miljarder == null)
            {
                return HttpNotFound();
            }
            return View(miljarder);
        }

        // POST: miljarders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            miljarder miljarder = db.miljarder.Find(id);
            db.miljarder.Remove(miljarder);
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
