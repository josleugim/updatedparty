using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UpdatedParty.Models;

namespace UpdatedParty.Controllers
{ 
    public class GalleryController : Controller
    {
        private UpdatedPartyDB db = new UpdatedPartyDB();

        //
        // GET: /Gallery/

        public ViewResult Index()
        {
            var galleries = db.Galleries.Include(g => g.Bar);
            return View(galleries.ToList());
        }

        //
        // GET: /Gallery/Details/5

        public ViewResult Details(int id)
        {
            Gallery gallery = db.Galleries.Find(id);
            return View(gallery);
        }

        //
        // GET: /Gallery/Create

        public ActionResult Create()
        {
            //ViewBag.UPUserID = new SelectList(db.UPUsers, "UPUserID", "upUserName");
            return View();
        } 

        //
        // POST: /Gallery/Create

        [HttpPost]
        public ActionResult Create(Gallery gallery)
        {
            if (ModelState.IsValid)
            {
                db.Galleries.Add(gallery);
                var upuser = from u in db.Bars
                             where u.Email == User.Identity.Name
                             select u;

                gallery.Bar = upuser.First();
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.UPUserID = new SelectList(db.Bars, "UPUserID", "upUserName", gallery.BarId);
            return View(gallery);
        }
        
        //
        // GET: /Gallery/Edit/5
 
        public ActionResult Edit(int id)
        {
            Gallery gallery = db.Galleries.Find(id);
            ViewBag.UPUserID = new SelectList(db.Bars, "UPUserID", "upUserName", gallery.BarId);
            return View(gallery);
        }

        //
        // POST: /Gallery/Edit/5

        [HttpPost]
        public ActionResult Edit(Gallery gallery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gallery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UPUserID = new SelectList(db.Bars, "UPUserID", "upUserName", gallery.BarId);
            return View(gallery);
        }

        //
        // GET: /Gallery/Delete/5
 
        //public ActionResult Delete(int id)
        //{
        //    Gallery gallery = db.Galleries.Find(id);
        //    return View(gallery);
        //}

        ////
        //// POST: /Gallery/Delete/5

        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(int id)
        //{            
        //    Gallery gallery = db.Galleries.Find(id);
        //    db.Galleries.Remove(gallery);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}