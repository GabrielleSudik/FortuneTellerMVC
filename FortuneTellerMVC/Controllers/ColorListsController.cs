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
    public class ColorListsController : Controller
    {
        private FortuneTellerMVCContext db = new FortuneTellerMVCContext();

        // GET: ColorLists
        public ActionResult Index()
        {
            return View(db.ColorLists.ToList());
        }

        // GET: ColorLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColorList colorList = db.ColorLists.Find(id);
            if (colorList == null)
            {
                return HttpNotFound();
            }
            return View(colorList);
        }

        // GET: ColorLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ColorLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ColorListID,Color")] ColorList colorList)
        {
            if (ModelState.IsValid)
            {
                db.ColorLists.Add(colorList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(colorList);
        }

        // GET: ColorLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColorList colorList = db.ColorLists.Find(id);
            if (colorList == null)
            {
                return HttpNotFound();
            }
            return View(colorList);
        }

        // POST: ColorLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ColorListID,Color")] ColorList colorList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colorList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(colorList);
        }

        // GET: ColorLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColorList colorList = db.ColorLists.Find(id);
            if (colorList == null)
            {
                return HttpNotFound();
            }
            return View(colorList);
        }

        // POST: ColorLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ColorList colorList = db.ColorLists.Find(id);
            db.ColorLists.Remove(colorList);
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
