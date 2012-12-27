using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UpdatedParty.ViewModels;
using UpdatedParty.Models;
using System.Data.Objects;
using PagedList;

namespace UpdatedParty.Controllers
{
    public class HomeController : Controller
    {
        private UpdatedPartyDB _db = new UpdatedPartyDB();


        public ViewResult Index(string sortOrder, string searchString, string delegacion, int? page)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name desc" : "";
            //ViewBag.DateSortParm = sortOrder == "Date" ? "Date desc" : "Date";
            DateTime datenow = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            if (Request.HttpMethod != "GET")
                page = 1;


            var stayup = from u in _db.stayUP
                         where EntityFunctions.TruncateTime(u.EventDate) == datenow
                         select u;

            if (!String.IsNullOrEmpty(delegacion))
            {
                stayup = stayup.Where(s => s.Bar.Township == delegacion);
            }

            //var quote = _db.UPUsers.OrderBy(q => _db.GetNewId()).First();

            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    stayup = stayup.Where(s => s.BarEvent.ToUpper().Contains(searchString.ToUpper())
            //                           || s.Promotion.ToUpper().Contains(searchString.ToUpper()));
            //}

            switch (sortOrder)
            {
                case "Name desc":
                    stayup = stayup.OrderByDescending(s => s.Bar.BarName);
                    break;
                //case "Date":
                //    stayup = stayup.OrderBy(s => s.RegisterDate);
                //    break;
                //case "Date desc":
                //    stayup = stayup.OrderByDescending(s => s.RegisterDate);
                //    break;
                default:
                    stayup = stayup.OrderBy(s => s.Bar.Email);
                    break;
            }

            List<string> del = new List<string> { "Alvaro Obregón", "Azcapotzalco", "Benito Juárez", "Coyoacán", "Cuajimalpa", "Cuauhtémoc", "Gustavo A. Madero",
            "Iztacalco", "Iztapalapa", "Magdalena Contreras", "Miguel Hidalgo", "Milpa Alta", "Tláhuac", "Tlalpan", "Venustiano Carranza", "Xochimilco"};
            ViewBag.delegacion = new SelectList(del);

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            //return View(stayup.ToList().Take(10));
            return View(stayup.ToPagedList(pageNumber,pageSize));
        }

        public ViewResult AdvancedSearch(int? page)
        {
            DateTime datenow = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            if (Request.HttpMethod != "GET")
                page = 1;

            var stayup = from u in _db.stayUP
                         where EntityFunctions.TruncateTime(u.EventDate) == datenow
                         select u;

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(stayup.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult JsonSearch(string delegacion, string colonia, string bar, string antro, string promocion, string evento,
            string estacionamiento, string after, string pub, string karaoke, string botanero, string gaybar, string mezcaleria,
            string cerveceria, string alternativo, string rock, string electro, string hiphop, string jazzblues, string reggae,
            string trova, string lounge, string banda, string pop, string disco, string tropical)
        {
            if (!String.IsNullOrEmpty(colonia))
            {
                if (bar != null && antro == null && promocion == null && evento == null && estacionamiento == null && after == null && pub == null && karaoke == null
                    && botanero == null && gaybar == null && mezcaleria == null && cerveceria == null && alternativo == null && rock == null && electro == null
                    && hiphop == null && jazzblues == null && reggae == null && trova == null && lounge == null && banda == null && pop == null && disco == null
                    && tropical == null)
                {
                    var barResult = _db.Bars
                    .Where(u => u.Township.ToUpper().Contains(delegacion.ToUpper())
                    && u.BarType.Equals(true)
                    && u.Cologne.Contains(colonia))
                    .Select(r => new
                    {
                        r.BarName,
                        r.Email,
                        r.BarID
                    });

                    return Json(barResult, JsonRequestBehavior.AllowGet);
                }
                else if (bar == null && antro != null && promocion == null && evento == null && estacionamiento == null && after == null && pub == null && karaoke == null
                    && botanero == null && gaybar == null && mezcaleria == null && cerveceria == null && alternativo == null && rock == null && electro == null
                    && hiphop == null && jazzblues == null && reggae == null && trova == null && lounge == null && banda == null && pop == null && disco == null
                    && tropical == null)
                {
                    var barResult = _db.Bars
                    .Where(u => u.Township.ToUpper().Contains(delegacion.ToUpper())
                    && u.Antro.Equals(true)
                    && u.Cologne.Contains(colonia))
                    .Select(r => new
                    {
                        r.BarName,
                        r.Email,
                        r.BarID
                    });

                    return Json(barResult, JsonRequestBehavior.AllowGet);
                }
                else if (bar == null && antro == null && promocion != null && evento == null && estacionamiento == null && after == null && pub == null && karaoke == null
                    && botanero == null && gaybar == null && mezcaleria == null && cerveceria == null && alternativo == null && rock == null && electro == null
                    && hiphop == null && jazzblues == null && reggae == null && trova == null && lounge == null && banda == null && pop == null && disco == null
                    && tropical == null)
                {
                    //Searchs if the bar has promotion today
                    DateTime datenow = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    var barResult = from u in _db.Bars
                                    join s in _db.stayUP
                                    on u.BarID equals s.BarId
                                    where s.Promotion != null
                                    && u.Cologne.Contains(colonia)
                                    && u.Township.ToUpper().Contains(delegacion.ToUpper())
                                    && EntityFunctions.TruncateTime(s.EventDate) == datenow
                                    select new { u.BarName, u.BarID};

                    return Json(barResult, JsonRequestBehavior.AllowGet);
                }
            }
            

            var bars = _db.Bars
                .Where(u => u.Township.ToUpper().Contains(delegacion.ToUpper()))
                .Select(r => new
                {
                    r.BarName,
                    r.Email,
                    r.BarID
                });

            return Json(bars, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Gallery/Details/

        public ViewResult Details(int id)
        {
            Bar users = _db.Bars.Find(id);
            return View(users);
        }

        //[HttpPost]
        public ActionResult Rate(string rate)
        {
            
                return View();
        }
    }
}
