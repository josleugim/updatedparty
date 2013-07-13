using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using UpdatedParty.Helpers;
using UpdatedParty.Models;
using UpdatedParty.ViewModels;

namespace UpdatedParty.Controllers
{
    public class BarController : Controller
    {
        private readonly UpdatedPartyDB _db = new UpdatedPartyDB();
        //
        // GET: /User/Always redirect to here
        [Authorize]
        public ActionResult Index()
        {
            var userid = from u in _db.Bars
                         where u.Email == User.Identity.Name
                         select u.BarID;

            if (!userid.Any())
            {
                Session.Clear();
                FormsAuthentication.SignOut();
                Session.Abandon();
                return RedirectToAction("Index", "Home");
            }

            var id = userid.First();
            return RedirectToAction("Create", "StayUP", new { id });

        }
        [Authorize]
        //
        // GET: /User/
        public ActionResult General()
        {
            var userid = from u in _db.Bars
                         where u.Email == User.Identity.Name
                         select u.BarID;
            int id = userid.First();
            return RedirectToAction("Edit", "Bar", new { id });

        }

        //
        // GET: /User/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            Bar bars = _db.Bars.Find(id);

            ViewBag.TStateId = new SelectList(_db.TStates, "TStateID", "StateName", bars.TStateId);
            var del = new List<string> { "Alvaro Obregón", "Azcapotzalco", "Benito Juárez", "Coyoacán", "Cuajimalpa", "Cuauhtémoc", "Gustavo A. Madero",
            "Iztacalco", "Iztapalapa", "Magdalena Contreras", "Miguel Hidalgo", "Milpa Alta", "Tláhuac", "Tlalpan", "Venustiano Carranza", "Xochimilco"};
            ViewBag.delegacion = new SelectList(del);
            ViewBag.BusinessTypeId = new SelectList(_db.BusinessTypes, "BusinessTypeId", "TypeName", bars.BusinessTypeId);

            return View(bars);
        }

        //
        // POST: /User/Edit/5
        [Authorize]
        [HttpPost]
        //public ActionResult Edit(UPUser upusers)
        public ActionResult Edit(Bar bars, string delegacion)
        {
            if (ModelState.IsValid)
            {

                _db.Entry(bars).State = EntityState.Modified;

                if (!String.IsNullOrEmpty(delegacion)) bars.Township = delegacion;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TStateId = new SelectList(_db.TStates, "TStateID", "StateName", bars.TStateId);
            var del = new List<string> { "Alvaro Obregón", "Azcapotzalco", "Benito Juárez", "Coyoacán", "Cuajimalpa", "Cuauhtémoc", "Gustavo A. Madero",
            "Iztacalco", "Iztapalapa", "Magdalena Contreras", "Miguel Hidalgo", "Milpa Alta", "Tláhuac", "Tlalpan", "Venustiano Carranza", "Xochimilco"};
            ViewBag.delegacion = new SelectList(del);
            return View(bars);
        }

        //
        // GET: /Bar/Details/

        //public ActionResult BarDetails(int id, string Name)
        //{
        //    Bar bars = _db.Bars.Find(id);

        //    // make sure the productName for the route matches the encoded product name
        //    string expectedName = bars.BarName.ToSeoUrl();
        //    string actualName = (Name ?? "").ToLower();

        //    JsonSearch(id);

        //    if (expectedName != actualName)
        //    {
        //        return RedirectToActionPermanent("BarDetails", "Bar", new { id = bars.BarID, Name = expectedName });
        //    }

        //    return View(bars);

        //}

        //public JsonResult JsonSearch(int id)
        //{
        //    //var cars = new List<string> { "http://slidesjs.com/examples/standard/img/slide-1.jpg", "http://slidesjs.com/examples/standard/img/slide-2.jpg" };
        //    //var cars = new List<string> { "Ferrari", "Buick" };

        //    var barimg = from g in _db.Galleries
        //                 where g.BarId == id
        //                 && g.IsActived
        //                 select g.UrlImage;

        //    ViewBag.Num = barimg.Count();

        //    return Json(barimg, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult MyBarView()
        {
            var bar = _db.Bars.FirstOrDefault(c => c.Email.Equals(User.Identity.Name));
            if (bar != null) return RedirectToAction("Index","BarDetails", new { id = bar.BarID, Name = bar.BarName.ToSeoUrl() });

            return View("Error");
        }

        //public JsonResult GetStateList()
        //{

        //    List<ListItem> list = new List<ListItem>() {

        //     new ListItem() { Value = "1", Text = "VA" },

        //     new ListItem() { Value = "2", Text = "MD" },

        //    new ListItem() { Value = "3", Text = "DC" }

        //};

        //    return this.Json(list, JsonRequestBehavior.AllowGet);

        //}
    }
}
