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

            //looks like you have to change strings of colors ("red") etc
            //for the color ID int.
            //let's see if we get the right thing...
            //yeah you did, with some edits.

            //you started with 0 - 6. might need to switch to 1 - 7. 
            //Later: You did switch.

            //step two will be filling in the transportation table with data
            //and linking that instead of what you write here.
            //not done yet.

            string transport = "";

            //this next line is what you'd type (or something close to it)
            //if you joined the color and transport tables.
            //basically, it says, for whatever the rube's color choice is,
            //find the matching transportation item
            //you didn't join those tables before, so it won't work now.

            //rube.Transportation = db.Transportations.Where(t => t.ColorId == rube.ColorListID).FirstOrDefault();

            switch (rube.ColorListID)
            {
                case 7:  //this number out of order because you first started with 0, switched to 1.
                    transport = "car";  //Transportation(1); that, and variations of it don't work.
                    break;
                case 1:
                    transport = "pogo stick";
                    break;
                case 2:
                    transport = "bicycle";
                    break;
                case 3:
                    transport = "spaceship";
                    break;
                case 4:
                    transport = "boat";
                    break;
                case 5:
                    transport = "skateboard";
                    break;
                case 6:
                    transport = "Harley Davidson";
                    break;
            }

            ViewBag.RetVehicle = transport;

            //here you're just trying to print an item from another database
            //ie, just get, say, ID 2 in transportation to print

            //ViewBag.SampleVehicle = Transportation.TransportationID;

            //now the month/dollars in bank bit:

            double dollars;

            if (rube.BirthMonthID >= 1 && rube.BirthMonthID <= 4)
            {
                dollars = 25000;
            }
            else if (rube.BirthMonthID >= 5 && rube.BirthMonthID <= 8)
            {
                dollars = 300000;
            }
            else if (rube.BirthMonthID >= 9 && rube.BirthMonthID <= 12)
            {
                dollars = 6.37;
            }
            else
            {
                dollars = 0;
            }

            ViewBag.DollarsInBank = dollars;


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
