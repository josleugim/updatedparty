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
    public class BarController : Controller
    {
        private readonly UpdatedPartyDB _db = new UpdatedPartyDB();
        //
        // GET: /User/
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
            int id = userid.First();
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
        // GET: /UserType/Details/5
        [Authorize]
        public ViewResult Details(int id)
        {
            //UPUser upusers = db.UPUsers.Find(id);
            //Include de relationship table
            Bar upusers = _db.Bars.Include(t => t.UserType).Single(u => u.BarID == id);

            return View(upusers);
        }

        //
        // GET: /User/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {

            Bar upusers = _db.Bars.Find(id);

            ViewBag.UserTypeId = new SelectList(_db.UserTypes, "UserTypeId", "UserTypeName", upusers.UserTypeId);
            ViewBag.StatusTypeId = new SelectList(_db.StatusTypes, "StatusTypeId", "StatusTypeName", upusers.StatusTypeId);
            ViewBag.TState = new SelectList(_db.TStates, "TStateID", "StateName");
            var del = new List<string> { "Alvaro Obregón", "Azcapotzalco", "Benito Juárez", "Coyoacán", "Cuajimalpa", "Cuauhtémoc", "Gustavo A. Madero",
            "Iztacalco", "Iztapalapa", "Magdalena Contreras", "Miguel Hidalgo", "Milpa Alta", "Tláhuac", "Tlalpan", "Venustiano Carranza", "Xochimilco"};
            ViewBag.delegacion = new SelectList(del);

            return View(upusers);
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

                //db.Entry(upusers).State = EntityState.Modified;
                //upusers.StatusType = status.First();
                //upusers.RegisterDate = DateTime.ParseExact(DateTime.Now.ToShortDateString(), "dd/MM/yyyy", null);
                //db.SaveChanges();
                //Bar upuser = _db.Bars.FirstOrDefault(s => s.BarID.Equals(id));
                UpdateModel(bars);
                if (bars != null) bars.Township = delegacion;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.UserTypeId = new SelectList(db.UserTypes, "UpUserTypeId", "UserTypeName", upusers.UserTypeId);
            //ViewBag.StatusTypeId = new SelectList(db.StatusTypes, "StatusTypeId", "StatusTypeName", upusers.StatusTypeId);
            ViewBag.TState = new SelectList(_db.TStates, "TStateID", "StateName");
            var del = new List<string> { "Alvaro Obregón", "Azcapotzalco", "Benito Juárez", "Coyoacán", "Cuajimalpa", "Cuauhtémoc", "Gustavo A. Madero",
            "Iztacalco", "Iztapalapa", "Magdalena Contreras", "Miguel Hidalgo", "Milpa Alta", "Tláhuac", "Tlalpan", "Venustiano Carranza", "Xochimilco"};
            ViewBag.delegacion = new SelectList(del);
            return View();
        }

        //
        // GET: /StayUP/Create
        [Authorize]
        public ActionResult StayUP(int id)
        {

            //StayUP stayup = db.stayUP.Find(id);

            //ViewBag.UserTypeId = new SelectList(db.UserTypes, "UserTypeId", "UserTypeName", stayup.UserTypeId);
            //ViewBag.StatusTypeId = new SelectList(db.StatusTypes, "StatusTypeId", "StatusTypeName", stayup.StatusTypeId);

            return View();
        }

        //
        // POST: /StayUP/Create
        [Authorize]
        [HttpPost]
        public ActionResult StayUP(StayUP stayup, int id)
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

                //db.Entry(upusers).State = EntityState.Modified;
                //upusers.StatusType = status.First();
                //upusers.RegisterDate = DateTime.ParseExact(DateTime.Now.ToShortDateString(), "dd/MM/yyyy", null);
                //db.SaveChanges();
                //Bar upuser = db.Bars.FirstOrDefault(s => s.BarID.Equals(id));
                //UpdateModel(upuser);
                //db.SaveChanges();
                //return RedirectToAction("Index");

                _db.stayUP.Add(stayup);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.UserTypeId = new SelectList(db.UserTypes, "UpUserTypeId", "UserTypeName", upusers.UserTypeId);
            //ViewBag.StatusTypeId = new SelectList(db.StatusTypes, "StatusTypeId", "StatusTypeName", upusers.StatusTypeId);
            //return View();

            return View(stayup);
        }

        //
        // GET: /Bar/Details/

        public ViewResult BarDetails(int id)
        {
            Bar users = _db.Bars.Find(id);
            return View(users);
        }
    }
}
