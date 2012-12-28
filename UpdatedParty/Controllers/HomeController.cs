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
            return View(stayup.ToPagedList(pageNumber, pageSize));
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
            //Convert string to bool
            bool bBar = false;
            bool bAntro = false;
            bool bEstac = false;
            bool bAfter = false;
            bool bPub = false;
            bool bKaraoke = false;
            bool bBotanero = false;
            bool bGaybar = false;
            bool bMezcaleria = false;
            bool bCerve = false;
            bool bAlter = false;
            bool bRock = false;
            bool bElectro = false;
            bool bHipH = false;
            bool bJazzB = false;
            bool bReggae = false;
            bool bTrova = false;
            bool bLounge = false;
            bool bBanda = false;
            bool bPop = false;
            bool bDisco = false;
            bool bTropical = false;

            if (!String.IsNullOrEmpty(bar))
                bBar = true;
            if (!String.IsNullOrEmpty(antro))
                bAntro = true;
            if (!String.IsNullOrEmpty(estacionamiento))
                bEstac = true;
            if (!String.IsNullOrEmpty(after))
                bAfter = true;
            if (!String.IsNullOrEmpty(pub))
                bPub = true;
            if (!String.IsNullOrEmpty(karaoke))
                bKaraoke = true;
            if (!String.IsNullOrEmpty(botanero))
                bBotanero = true;
            if (!String.IsNullOrEmpty(gaybar))
                bGaybar = true;
            if (!String.IsNullOrEmpty(mezcaleria))
                bMezcaleria = true;
            if (!String.IsNullOrEmpty(cerveceria))
                bCerve = true;
            if (!String.IsNullOrEmpty(alternativo))
                bAlter = true;
            if (!String.IsNullOrEmpty(rock))
                bRock = true;
            if (!String.IsNullOrEmpty(electro))
                bElectro = true;
            if (!String.IsNullOrEmpty(hiphop))
                bHipH = true;
            if (!String.IsNullOrEmpty(jazzblues))
                bJazzB = true;
            if (!String.IsNullOrEmpty(reggae))
                bReggae = true;
            if (!String.IsNullOrEmpty(trova))
                bTrova = true;
            if (!String.IsNullOrEmpty(lounge))
                bLounge = true;
            if (!String.IsNullOrEmpty(banda))
                bBanda = true;
            if (!String.IsNullOrEmpty(pop))
                bPop = true;
            if (!String.IsNullOrEmpty(disco))
                bDisco = true;
            if (!String.IsNullOrEmpty(tropical))
                bTropical = true;


            if (!String.IsNullOrEmpty(colonia))
            {
                var barResult = _db.Bars
                    .Where(u => u.Township.ToUpper().Contains(delegacion.ToUpper())
                        && u.Cologne.Contains(colonia)
                        && u.BarType.Equals(bBar)
                        && u.Antro.Equals(bAntro)
                        && u.Parking.Equals(bEstac)
                        && u.After.Equals(bAfter)
                        && u.Pub.Equals(bPub)
                        && u.Karaoke.Equals(bKaraoke)
                        && u.Botanero.Equals(bBotanero)
                        && u.GayBar.Equals(bGaybar)
                        && u.Mezcaleria.Equals(bMezcaleria)
                        && u.Cerveceria.Equals(bCerve)
                        && u.Alternative.Equals(bAlter)
                        && u.Rock.Equals(bRock)
                        && u.Electronic.Equals(bElectro)
                        && u.HipHop.Equals(bHipH)
                        && u.JazzBlues.Equals(bJazzB)
                        && u.Reggae.Equals(bReggae)
                        && u.Trova.Equals(bTrova)
                        && u.Lounge.Equals(bLounge)
                        && u.Banda.Equals(bBanda)
                        && u.Pop.Equals(bPop)
                        && u.Disco.Equals(bDisco)
                        && u.Tropical.Equals(bTropical)
                        )
                    .Select(r => new
                    {
                        r.BarName,
                        r.Email,
                        r.BarID
                    });

                return Json(barResult, JsonRequestBehavior.AllowGet);
            }
            else
            {
                //
                //Validar cuando todos los checkbox estan en false
                var barResult = _db.Bars
                    .Where(u => u.Township.ToUpper().Contains(delegacion.ToUpper())
                        && u.BarType.Equals(bBar)
                        && u.Antro.Equals(bAntro)
                        && u.Parking.Equals(bEstac)
                        && u.After.Equals(bAfter)
                        && u.Pub.Equals(bPub)
                        && u.Karaoke.Equals(bKaraoke)
                        && u.Botanero.Equals(bBotanero)
                        && u.GayBar.Equals(bGaybar)
                        && u.Mezcaleria.Equals(bMezcaleria)
                        && u.Cerveceria.Equals(bCerve)
                        && u.Alternative.Equals(bAlter)
                        && u.Rock.Equals(bRock)
                        && u.Electronic.Equals(bElectro)
                        && u.HipHop.Equals(bHipH)
                        && u.JazzBlues.Equals(bJazzB)
                        && u.Reggae.Equals(bReggae)
                        && u.Trova.Equals(bTrova)
                        && u.Lounge.Equals(bLounge)
                        && u.Banda.Equals(bBanda)
                        && u.Pop.Equals(bPop)
                        && u.Disco.Equals(bDisco)
                        && u.Tropical.Equals(bTropical)
                        )
                    .Select(r => new
                    {
                        r.BarName,
                        r.Email,
                        r.BarID
                    });

                return Json(barResult, JsonRequestBehavior.AllowGet);
            }

            //var bars = _db.Bars
            //    .Where(u => u.Township.ToUpper().Contains(delegacion.ToUpper()))
            //    .Select(r => new
            //    {
            //        r.BarName,
            //        r.Email,
            //        r.BarID
            //    });

            //return Json(bars, JsonRequestBehavior.AllowGet);
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
