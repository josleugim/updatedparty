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
using System.Data.Objects;

namespace UpdatedParty.Controllers
{
    public class BarDetailsController : Controller
    {
        UpdatedPartyDB _db = new UpdatedPartyDB();
        //
        // GET: /Cartelera/

        public ActionResult Index(int id, string name)
        {
            Bar bar = _db.Bars.Find(id);
            // make sure the BarName for the route matches the encoded bar name
            string expectedName = bar.BarName.ToSeoUrl();
            string actualName = (name ?? "").ToLower();

            JsonSearch(id);

            if (expectedName != actualName)
            {
                return RedirectToActionPermanent("Index", "BarDetails", new { id = bar.BarID, name = expectedName });
            }

            //return View(bar);

            var viewmodel = new BarDetails
            {
                Bar = bar,
                Evento = GetStayUpItems(id)
            };

            return View(viewmodel);
        }

        public List<StayUP> GetStayUpItems(int id)
        {
            //return _db.stayUP.Where(b => b.BarId.Equals(id))
            //    .Where(w => w.EventDate > DateTime.Now);

            var nextDay = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            var WhatsUp = (from u in _db.stayUP
                           where EntityFunctions.TruncateTime(u.EventDate) >= nextDay
                           && u.BarId.Equals(id)
                           orderby u.EventDate ascending
                           select u).ToList();

            return WhatsUp;
        }

        public JsonResult JsonSearch(int id)
        {
            //var cars = new List<string> { "http://slidesjs.com/examples/standard/img/slide-1.jpg", "http://slidesjs.com/examples/standard/img/slide-2.jpg" };
            //var cars = new List<string> { "Ferrari", "Buick" };

            //Se ordena por la última imagen subida
            var barimg = from g in _db.Galleries
                         where g.BarId == id
                         && g.IsActived
                         orderby g.RegisterDate descending
                         select g.UrlImage;

            ViewBag.Num = barimg.Count();

            return Json(barimg, JsonRequestBehavior.AllowGet);
        }
    }
}
