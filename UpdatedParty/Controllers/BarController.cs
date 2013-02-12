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
            //ViewBag.UserType = db.UserTypes.Select(u => u.UserTypeName);
            //ViewBag.StatusType = db.StatusTypes.Select(s => s.StatusTypeName);

            //var upusers = db.UPUsers.Include(a => a.UserType)
            //    .Include(s => s.StatusType)
            //    .Where(n => n.upUserEmail == User.Identity.Name);
            //return View(upusers.ToList());
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
            //ViewBag.UserType = db.UserTypes.Select(u => u.UserTypeName);
            //ViewBag.StatusType = db.StatusTypes.Select(s => s.StatusTypeName);

            //var upusers = db.UPUsers.Include(a => a.UserType)
            //    .Include(s => s.StatusType)
            //    .Where(n => n.upUserEmail == User.Identity.Name);
            //return View(upusers.ToList());
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

            //ViewBag.UserTypeId = new SelectList(_db.UserTypes, "UserTypeId", "UserTypeName", upusers.UserTypeId);
            //ViewBag.StatusTypeId = new SelectList(_db.StatusTypes, "StatusTypeId", "StatusTypeName", upusers.StatusTypeId);
            ViewBag.TStateId = new SelectList(_db.TStates, "TStateID", "StateName", bars.TStateId);
            var del = new List<string> { "Alvaro Obregón", "Azcapotzalco", "Benito Juárez", "Coyoacán", "Cuajimalpa", "Cuauhtémoc", "Gustavo A. Madero",
            "Iztacalco", "Iztapalapa", "Magdalena Contreras", "Miguel Hidalgo", "Milpa Alta", "Tláhuac", "Tlalpan", "Venustiano Carranza", "Xochimilco"};
            ViewBag.delegacion = new SelectList(del);

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
                //var userid = from u in db.UPUsers
                //             where u.upUserEmail == User.Identity.Name
                //             select u.StatusType.StatusTypeId;
                //int id = userid.First();

                //var status = from s in db.StatusTypes
                //             where s.StatusTypeId == id
                //             select s;

                _db.Entry(bars).State = EntityState.Modified;
                //upusers.StatusType = status.First();
                //upusers.RegisterDate = DateTime.ParseExact(DateTime.Now.ToShortDateString(), "dd/MM/yyyy", null);
                //db.SaveChanges();
                //Bar upuser = _db.Bars.FirstOrDefault(s => s.BarID.Equals(id));
                //UpdateModel(bars);
                if (!String.IsNullOrEmpty(delegacion)) bars.Township = delegacion;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.UserTypeId = new SelectList(db.UserTypes, "UpUserTypeId", "UserTypeName", upusers.UserTypeId);
            //ViewBag.StatusTypeId = new SelectList(db.StatusTypes, "StatusTypeId", "StatusTypeName", upusers.StatusTypeId);
            ViewBag.TStateId = new SelectList(_db.TStates, "TStateID", "StateName", bars.TStateId);
            var del = new List<string> { "Alvaro Obregón", "Azcapotzalco", "Benito Juárez", "Coyoacán", "Cuajimalpa", "Cuauhtémoc", "Gustavo A. Madero",
            "Iztacalco", "Iztapalapa", "Magdalena Contreras", "Miguel Hidalgo", "Milpa Alta", "Tláhuac", "Tlalpan", "Venustiano Carranza", "Xochimilco"};
            ViewBag.delegacion = new SelectList(del);
            return View(bars);
        }

        //
        // GET: /Bar/Details/

        public ActionResult BarDetails(int id, string Name)
        {
            Bar bars = _db.Bars.Find(id);

            // make sure the productName for the route matches the encoded product name
            string expectedName = bars.BarName.ToSeoUrl();
            string actualName = (Name ?? "").ToLower();

            JsonSearch(id);

            if (expectedName != actualName)
            {
                return RedirectToActionPermanent("BarDetails", "Bar", new { id = bars.BarID, Name = expectedName });
            }

            return View(bars);

        }

        public JsonResult JsonSearch(int id)
        {
            //var cars = new List<string> { "http://slidesjs.com/examples/standard/img/slide-1.jpg", "http://slidesjs.com/examples/standard/img/slide-2.jpg" };
            //var cars = new List<string> { "Ferrari", "Buick" };

            var barimg = from g in _db.Galleries
                         where g.BarId == id
                         && g.IsActived
                         select g.UrlImage;

            ViewBag.Num = barimg.Count();

            return Json(barimg, JsonRequestBehavior.AllowGet);
        }

        public ActionResult MyBarView()
        {
            var bar = _db.Bars.FirstOrDefault(c => c.Email.Equals(User.Identity.Name));
            if (bar != null) return RedirectToAction("BarDetails", new { id = bar.BarID, Name = bar.BarName.ToSeoUrl() });

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
