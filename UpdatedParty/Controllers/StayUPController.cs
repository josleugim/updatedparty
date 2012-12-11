using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UpdatedParty.Models;
using System.Data.Objects;

namespace UpdatedParty.Controllers
{ 
    public class StayUPController : Controller
    {
        private UpdatedPartyDB db = new UpdatedPartyDB();

        //
        // GET: /StayUP/

        public ViewResult Index()
        {
            var stayup = db.stayUP.Include(s => s.Bar);
            return View(stayup.ToList());
        }

        //
        // GET: /StayUP/Details/5

        public ViewResult Details(int id)
        {
            StayUP stayup = db.stayUP.Find(id);
            return View(stayup);
        }

        //
        // GET: /StayUP/Create

        public ActionResult Create(int id)
        {
            ViewBag.BarId = new SelectList(db.Bars, "BarID", "BarName");
            return View();
        } 

        //
        // POST: /StayUP/Create

        [HttpPost]
        public ActionResult Create(StayUP stayup, int id)
        {
            if (ModelState.IsValid)
            {
                DateTime date1 = Convert.ToDateTime(Convert.ToDateTime(stayup.EventDate).ToShortDateString());
                DateTime date2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                int result = DateTime.Compare(date1, date2);
                
                //Event date isn't earlier than today
                if (result >= 0)
                {
                    //"Date1 is later or equal than Today"
                    var oldEvent = from e in db.stayUP
                                   where EntityFunctions.TruncateTime(e.EventDate) == date1
                                   & e.Bar.BarID == id
                                   select e;
                    if (oldEvent.Count() == 0)
                    {
                        Bar bar = db.Bars.FirstOrDefault(s => s.BarID.Equals(id));
                        db.stayUP.Add(stayup);
                        stayup.RegisterDate = DateTime.Now;
                        stayup.Bar = bar;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        //Ya existe un evento para esta fecha
                    }
                }
                else
                { 
                    //No puedes crear un evento en el pasado
                }
               
                return RedirectToAction("Index");
            }

            ViewBag.BarId = new SelectList(db.Bars, "BarID", "BarName", stayup.BarId);
            return View(stayup);
        }
        
        //
        // GET: /StayUP/Edit/5
 
        public ActionResult Edit(int id)
        {
            StayUP stayup = db.stayUP.Find(id);
            ViewBag.BarId = new SelectList(db.Bars, "BarID", "BarName", stayup.BarId);
            return View(stayup);
        }

        //
        // POST: /StayUP/Edit/5

        [HttpPost]
        public ActionResult Edit(StayUP stayup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stayup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BarId = new SelectList(db.Bars, "BarID", "BarName", stayup.BarId);
            return View(stayup);
        }

        //
        // GET: /StayUP/Delete/5
 
        public ActionResult Delete(int id)
        {
            StayUP stayup = db.stayUP.Find(id);
            return View(stayup);
        }

        //
        // POST: /StayUP/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            StayUP stayup = db.stayUP.Find(id);
            db.stayUP.Remove(stayup);
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