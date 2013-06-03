using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UpdatedParty.Models;
using System.Data.Objects;
using System.IO;

namespace UpdatedParty.Controllers
{
    public class StayUPController : Controller
    {
        private readonly UpdatedPartyDB _db = new UpdatedPartyDB();

        //
        // GET: /StayUP/

        public ViewResult Index()
        {
            var stayup = _db.stayUP.Include(s => s.Bar).Where(b => b.Bar.Email == User.Identity.Name);
            return View(stayup.ToList());
        }

        //
        // GET: /StayUP/Details/5

        public ViewResult Details(int id)
        {
            StayUP stayup = _db.stayUP.Find(id);
            return View(stayup);
        }

        //
        // GET: /StayUP/Create

        public ActionResult Create(int id)
        {
            //ViewBag.BarId = new SelectList(_db.Bars, "BarID", "BarName");
            return View();
        }

        //
        // POST: /StayUP/Create

        [HttpPost]
        public ActionResult Create(StayUP stayup, int id, HttpPostedFileBase imagen, HttpPostedFileBase promo)
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
                    var oldEvent = from e in _db.stayUP
                                   where EntityFunctions.TruncateTime(e.EventDate) == date1
                                   & e.Bar.BarID == id
                                   select e;
                    if (!oldEvent.Any())
                    {
                        Bar bar = _db.Bars.FirstOrDefault(s => s.BarID.Equals(id));
                        _db.stayUP.Add(stayup);
                        stayup.RegisterDate = DateTime.Now;
                        stayup.Bar = bar;
                        stayup.IsActived = true;

                        if (imagen != null)
                        {
                            if (imagen.ContentLength != 0)
                            {
                                var reader = new StreamReader(imagen.InputStream);
                                imagen.SaveAs(Server.MapPath("/Content/gallery/") + "b" + bar.BarName + imagen.FileName);
                                stayup.EventBanner = "../../Content/gallery/" + "b" + bar.BarName + imagen.FileName;
                            }
                        }

                        if (promo != null)
                            if (promo.ContentLength != 0)
                            {
                                var reader = new StreamReader(promo.InputStream);
                                promo.SaveAs(Server.MapPath("/Content/gallery/") + "d" + bar.BarName + promo.FileName);
                                stayup.PromotionBanner = "../../Content/gallery/" + "d" + bar.BarName + promo.FileName;
                            }

                        _db.SaveChanges();
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

            ViewBag.BarId = new SelectList(_db.Bars, "BarID", "BarName", stayup.BarId);
            return View(stayup);
        }

        //
        // GET: /StayUP/Edit/5

        public ActionResult Edit(int id)
        {
            var stayup = _db.stayUP.Find(id);
            return View(stayup);
        }

        //
        // POST: /StayUP/Edit/5

        [HttpPost]
        public ActionResult Edit(StayUP stayup, HttpPostedFileBase imagen, HttpPostedFileBase promo)
        {
            if (ModelState.IsValid)
            {
                var barname = _db.Bars.Find(stayup.BarId);

                _db.Entry(stayup).State = EntityState.Modified;
                if (imagen != null)
                {
                    if (imagen.ContentLength != 0)
                    {
                        var reader = new StreamReader(imagen.InputStream);
                        imagen.SaveAs(Server.MapPath("/Content/gallery/") + "ban" + barname.BarName + imagen.FileName);
                        stayup.EventBanner = "../../Content/gallery/" + "ban" + barname.BarName + imagen.FileName;
                    }
                }


                if (promo != null)
                    if (promo.ContentLength != 0)
                    {
                        var reader = new StreamReader(promo.InputStream);
                        promo.SaveAs(Server.MapPath("/Content/gallery/") + "des" + barname.BarName + promo.FileName);
                        stayup.PromotionBanner = "../../Content/gallery/" + "des" + barname.BarName + promo.FileName;
                    }

                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(stayup);
        }

        //
        // GET: /StayUP/Delete/5

        public ActionResult Delete(int id)
        {
            StayUP stayup = _db.stayUP.Find(id);
            return View(stayup);
        }

        //
        // POST: /StayUP/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            StayUP stayup = _db.stayUP.Find(id);
            //_db.stayUP.Remove(stayup);
            stayup.IsActived = false;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}