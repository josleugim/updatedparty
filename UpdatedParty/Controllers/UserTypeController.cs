using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UpdatedParty.Models;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace UpdatedParty.Controllers
{ 
    public class UserTypeController : Controller
    {
        private UpdatedPartyDB db = new UpdatedPartyDB();

        //
        // GET: /UserType/

        public ViewResult Index()
        {
            return View(db.UserTypes.ToList());
        }

        //
        // GET: /UserType/Details/5

        public ViewResult Details(int id)
        {
            UserType usertype = db.UserTypes.Find(id);
            return View(usertype);
        }

        //@
        // GET: /UserType/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /UserType/Create

        [HttpPost]
        public ActionResult Create(UserType usertype)
        {
            if (ModelState.IsValid)
            {
                db.UserTypes.Add(usertype);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(usertype);
        }
        
        //
        // GET: /UserType/Edit/5
 
        public ActionResult Edit(int id)
        {
            UserType usertype = db.UserTypes.Find(id);
            return View(usertype);
        }

        //
        // POST: /UserType/Edit/5

        [HttpPost]
        public ActionResult Edit(UserType usertype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usertype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usertype);
        }

        //
        // GET: /UserType/Delete/5
 
        public ActionResult Delete(int id)
        {
            UserType usertype = db.UserTypes.Find(id);
            return View(usertype);
        }

        //
        // POST: /UserType/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            UserType usertype = db.UserTypes.Find(id);
            db.UserTypes.Remove(usertype);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}