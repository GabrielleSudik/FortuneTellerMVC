using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FortuneTellerMVC.Models;

namespace FortuneTellerMVC.Controllers
{
    public class VacaySpotsController : Controller
    {
        private FortuneTellerMVCContext db = new FortuneTellerMVCContext();

        // GET: VacaySpots
        public ActionResult Index()
        {
            return View(db.VacaySpots.ToList());
        }

        // GET: VacaySpots/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VacaySpot vacaySpot = db.VacaySpots.Find(id);
            if (vacaySpot == null)
            {
                return HttpNotFound();
            }
            return View(vacaySpot);
        }

        // GET: VacaySpots/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VacaySpots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VacaySpotID,VacaySpot1")] VacaySpot vacaySpot)
        {
            if (ModelState.IsValid)
            {
                db.VacaySpots.Add(vacaySpot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vacaySpot);
        }

        // GET: VacaySpots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VacaySpot vacaySpot = db.VacaySpots.Find(id);
            if (vacaySpot == null)
            {
                return HttpNotFound();
            }
            return View(vacaySpot);
        }

        // POST: VacaySpots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VacaySpotID,VacaySpot1")] VacaySpot vacaySpot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacaySpot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vacaySpot);
        }

        // GET: VacaySpots/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VacaySpot vacaySpot = db.VacaySpots.Find(id);
            if (vacaySpot == null)
            {
                return HttpNotFound();
            }
            return View(vacaySpot);
        }

        // POST: VacaySpots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VacaySpot vacaySpot = db.VacaySpots.Find(id);
            db.VacaySpots.Remove(vacaySpot);
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
