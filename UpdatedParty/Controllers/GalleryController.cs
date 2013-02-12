using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UpdatedParty.Models;
using System.IO;

namespace UpdatedParty.Controllers
{ 
    public class GalleryController : Controller
    {
        private readonly UpdatedPartyDB _db = new UpdatedPartyDB();

        //
        // GET: /Gallery/

        public ViewResult Index()
        {
            var galleries = _db.Galleries.Include(g => g.Bar).Where(b => b.Bar.Email == User.Identity.Name).Where(g => g.IsActived);
            return View(galleries.ToList());
        }

        //
        // GET: /Gallery/Details/5

        public ViewResult Details(int id)
        {
            Gallery gallery = _db.Galleries.Find(id);
            return View(gallery);
        }

        //
        // GET: /Gallery/Create

        public ActionResult Create()
        {
            //ViewBag.UPUserID = new SelectList(db.UPUsers, "UPUserID", "upUserName");
            Bar bars = _db.Bars.FirstOrDefault(c => c.Email.Equals(User.Identity.Name));

            var model = new Gallery()
                {
                    BarId = bars.BarID,
                    Bar = bars
                };

            return View(model);
        } 

        //
        // POST: /Gallery/Create

        [HttpPost]
        public ActionResult Create(Gallery gallery, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                if (imagen == null)
                {
                    return View();
                }

                if (imagen.ContentLength == 0)
                {
                    return View();
                }
                _db.Galleries.Add(gallery);
                //var upuser = from u in _db.Bars
                //             where u.Email == User.Identity.Name
                //             select u;

                var reader = new StreamReader(imagen.InputStream);
                imagen.SaveAs(Server.MapPath("/Content/gallery/") + imagen.FileName);
                gallery.UrlImage = "../../Content/gallery/" + imagen.FileName;
                gallery.IsActived = true;
                gallery.RegisterDate = DateTime.Now;
                //gallery.Bar = upuser.First();
                _db.SaveChanges();

                return RedirectToAction("Index");  
            }

            ViewBag.UPUserID = new SelectList(_db.Bars, "UPUserID", "upUserName", gallery.BarId);
            return View(gallery);
        }
        
        //
        // GET: /Gallery/Edit/5
 
        public ActionResult Edit(int id)
        {
            Gallery gallery = _db.Galleries.Find(id);
            ViewBag.UPUserID = new SelectList(_db.Bars, "UPUserID", "upUserName", gallery.BarId);
            return View(gallery);
        }

        //
        // POST: /Gallery/Edit/5

        [HttpPost]
        public ActionResult Edit(Gallery gallery)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(gallery).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UPUserID = new SelectList(_db.Bars, "UPUserID", "upUserName", gallery.BarId);
            return View(gallery);
        }

        //
        // GET: /Gallery/Delete/5

        public ActionResult Delete(int id)
        {
            var gallery = _db.Galleries.Find(id);
            return View(gallery);
        }

        //
        // POST: /Gallery/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var gallery = _db.Galleries.Find(id);
            //_db.Galleries.Remove(gallery);
            gallery.IsActived = false;
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