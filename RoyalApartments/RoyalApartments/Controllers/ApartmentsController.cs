using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RoyalApartments.Models;

namespace RoyalApartments.Controllers
{
    public class ApartmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Apartments
        public ActionResult Index()
        {
            return View(db.Apartments.ToList());
        }

        // GET: Apartments/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apartments apartments = db.Apartments.Find(id);
            if (apartments == null)
            {
                return HttpNotFound();
            }
            return View(apartments);
        }
        //Only Logged in users can create new profiles
        [Authorize]
        // GET: Apartments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Apartments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Location,Price")] Apartments apartments)
        {
            if (ModelState.IsValid)
            {
                db.Apartments.Add(apartments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(apartments);
        }

        // GET: Apartments/Edit/5
        [Authorize]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apartments apartments = db.Apartments.Find(id);
            if (apartments == null)
            {
                return HttpNotFound();
            }
            return View(apartments);
        }

        // POST: Apartments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,Location,Price")] Apartments apartments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apartments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(apartments);
        }

        // GET: Apartments/Delete/5
        [Authorize]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apartments apartments = db.Apartments.Find(id);
            if (apartments == null)
            {
                return HttpNotFound();
            }
            return View(apartments);
        }

        // POST: Apartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Apartments apartments = db.Apartments.Find(id);
            db.Apartments.Remove(apartments);
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
