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
    public class RubesController : Controller
    {
        private FortuneTellerMVCContext db = new FortuneTellerMVCContext();

        // GET: Rubes
        public ActionResult Index()
        {
            var rubes = db.Rubes.Include(r => r.BirthMonth).Include(r => r.ColorList);

            

            return View(rubes.ToList());
        }

        //here's where you're going to start experimenting:
        //i don't think this will work, at least not what you wrote

            //instead, put it into details section below

        //    public ActionResult RetirementFortune(int age)
        //{
        //    int retYears;

        //    if (age % 2 == 0)
        //    {
        //        retYears = 5;
        //    }
        //    else
        //    {
        //        retYears = 10;
        //    }

        //    return ViewBag.RetYears;

        //    //ViewBag.RetYears = 75; that was from the tutorial page only
        //}

        // GET: Rubes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rube rube = db.Rubes.Find(id);
            if (rube == null)
            {
                return HttpNotFound();
            }

            //you're trying this spot to experiment too:

            //this next line is pure experiment:
            ViewBag.TryMe = 13;
            //it WORKS! (see also view--detail page)

            //another test:
            string anotherTest = "meeeep!";
            ViewBag.TryMeToo = anotherTest;
            //that works too

            int yearsTillRetirement;

            if (rube.Age % 2 == 0)
            {
                yearsTillRetirement = 5;
            }
            else
            {
                yearsTillRetirement = 10;
            }

            ViewBag.RetYears = yearsTillRetirement;    //retYears;
            //OMG finally worked!

            //next part: colors/transport place:




            return View(rube);
        }

        // GET: Rubes/Create
        public ActionResult Create()
        {
            ViewBag.BirthMonthID = new SelectList(db.BirthMonths, "BirthMonthID", "BirthMonth1");
            ViewBag.ColorListID = new SelectList(db.ColorLists, "ColorListID", "Color");
            return View();
        }

        // POST: Rubes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RubeID,FirstName,LastName,ColorListID,BirthMonthID,Age")] Rube rube)
        {
            if (ModelState.IsValid)
            {
                db.Rubes.Add(rube);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BirthMonthID = new SelectList(db.BirthMonths, "BirthMonthID", "BirthMonth1", rube.BirthMonthID);
            ViewBag.ColorListID = new SelectList(db.ColorLists, "ColorListID", "Color", rube.ColorListID);
            return View(rube);
        }

        // GET: Rubes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rube rube = db.Rubes.Find(id);
            if (rube == null)
            {
                return HttpNotFound();
            }
            ViewBag.BirthMonthID = new SelectList(db.BirthMonths, "BirthMonthID", "BirthMonth1", rube.BirthMonthID);
            ViewBag.ColorListID = new SelectList(db.ColorLists, "ColorListID", "Color", rube.ColorListID);
            return View(rube);
        }

        // POST: Rubes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RubeID,FirstName,LastName,ColorListID,BirthMonthID,Age")] Rube rube)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rube).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BirthMonthID = new SelectList(db.BirthMonths, "BirthMonthID", "BirthMonth1", rube.BirthMonthID);
            ViewBag.ColorListID = new SelectList(db.ColorLists, "ColorListID", "Color", rube.ColorListID);
            return View(rube);
        }

        // GET: Rubes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rube rube = db.Rubes.Find(id);
            if (rube == null)
            {
                return HttpNotFound();
            }
            return View(rube);
        }

        // POST: Rubes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rube rube = db.Rubes.Find(id);
            db.Rubes.Remove(rube);
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
