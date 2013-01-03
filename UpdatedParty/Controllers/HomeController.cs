﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
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

            var del = new List<string> { "Alvaro Obregón", "Azcapotzalco", "Benito Juárez", "Coyoacán", "Cuajimalpa", "Cuauhtémoc", "Gustavo A. Madero",
            "Iztacalco", "Iztapalapa", "Magdalena Contreras", "Miguel Hidalgo", "Milpa Alta", "Tláhuac", "Tlalpan", "Venustiano Carranza", "Xochimilco"};
            ViewBag.delegacion = new SelectList(del);

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            //return View(stayup.ToList().Take(10));
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
            var bBar = false;
            var bAntro = false;
            var bEstac = false;
            var bAfter = false;
            var bPub = false;
            var bKaraoke = false;
            var bBotanero = false;
            var bGaybar = false;
            var bMezcaleria = false;
            var bCerve = false;
            var bAlter = false;
            var bRock = false;
            var bElectro = false;
            var bHipH = false;
            var bJazzB = false;
            var bReggae = false;
            var bTrova = false;
            var bLounge = false;
            var bBanda = false;
            var bPop = false;
            var bDisco = false;
            var bTropical = false;

            //
            //Change value to true
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

            //
            //Search bar promotions or events of today
            if (!String.IsNullOrEmpty(promocion) || !String.IsNullOrEmpty(evento) && !String.IsNullOrEmpty(bar) && String.IsNullOrEmpty(antro) && String.IsNullOrEmpty(after))
            {
                DateTime datenow = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                var barResult = _db.Bars.Join(_db.stayUP, u => u.BarID, s => s.BarId, (u, s) => new { u, s })
                    // ReSharper disable ImplicitlyCapturedClosure
                                    .Where(@t => EntityFunctions.TruncateTime(@t.s.EventDate) == datenow
                                        // ReSharper restore ImplicitlyCapturedClosure
                                                 && @t.u.Township.ToUpper().Contains(delegacion.ToUpper())
                                                 && !String.IsNullOrEmpty(@t.u.Cologne)
                                                 && !String.IsNullOrEmpty(@t.s.Promotion)
                                                 && !String.IsNullOrEmpty(@t.s.BarEvent)
                                                 && @t.u.Cologne.Contains(colonia)
                                                 && @t.u.BarType.Equals(bBar)
                                                 && @t.u.Parking.Equals(bEstac)
                                                 && @t.u.Pub.Equals(bPub)
                                                 && @t.u.Karaoke.Equals(bKaraoke)
                                                 && @t.u.Botanero.Equals(bBotanero)
                                                 && @t.u.GayBar.Equals(bGaybar)
                                                 && @t.u.Mezcaleria.Equals(bMezcaleria)
                                                 && @t.u.Cerveceria.Equals(bCerve)
                                                 && @t.u.Alternative.Equals(bAlter)
                                                 && @t.u.Rock.Equals(bRock)
                                                 && @t.u.Electronic.Equals(bElectro)
                                                 && @t.u.HipHop.Equals(bHipH)
                                                 && @t.u.JazzBlues.Equals(bJazzB)
                                                 && @t.u.Reggae.Equals(bReggae)
                                                 && @t.u.Trova.Equals(bTrova)
                                                 && @t.u.Lounge.Equals(bLounge)
                                                 && @t.u.Banda.Equals(bBanda)
                                                 && @t.u.Pop.Equals(bPop)
                                                 && @t.u.Disco.Equals(bDisco)
                                                 && @t.u.Tropical.Equals(bTropical))
                                    .Select(@t => new { @t.u.BarName, @t.u.BarID });

                return Json(barResult, JsonRequestBehavior.AllowGet);
            }
            if (!String.IsNullOrEmpty(promocion) || !String.IsNullOrEmpty(evento) && !String.IsNullOrEmpty(bar) && !String.IsNullOrEmpty(antro) && String.IsNullOrEmpty(after))
            {
                //Search Bar and Antro
                DateTime datenow = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                var barResult = _db.Bars.Join(_db.stayUP, u => u.BarID, s => s.BarId, (u, s) => new { u, s })
                    // ReSharper disable ImplicitlyCapturedClosure
                                   .Where(@t => EntityFunctions.TruncateTime(@t.s.EventDate) == datenow
                                                // ReSharper restore ImplicitlyCapturedClosure
                                                && @t.u.Township.ToUpper().Contains(delegacion.ToUpper())
                                                && !String.IsNullOrEmpty(@t.u.Cologne)
                                                && !String.IsNullOrEmpty(@t.s.Promotion)
                                                && !String.IsNullOrEmpty(@t.s.BarEvent)
                                                && @t.u.Cologne.Contains(colonia)
                                                && (@t.u.BarType.Equals(bBar) || @t.u.Antro.Equals(bAntro))
                                                && @t.u.Parking.Equals(bEstac)
                                                && @t.u.Pub.Equals(bPub)
                                                && @t.u.Karaoke.Equals(bKaraoke)
                                                && @t.u.Botanero.Equals(bBotanero)
                                                && @t.u.GayBar.Equals(bGaybar)
                                                && @t.u.Mezcaleria.Equals(bMezcaleria)
                                                && @t.u.Cerveceria.Equals(bCerve)
                                                && @t.u.Alternative.Equals(bAlter)
                                                && @t.u.Rock.Equals(bRock)
                                                && @t.u.Electronic.Equals(bElectro)
                                                && @t.u.HipHop.Equals(bHipH)
                                                && @t.u.JazzBlues.Equals(bJazzB)
                                                && @t.u.Reggae.Equals(bReggae)
                                                && @t.u.Trova.Equals(bTrova)
                                                && @t.u.Lounge.Equals(bLounge)
                                                && @t.u.Banda.Equals(bBanda)
                                                && @t.u.Pop.Equals(bPop)
                                                && @t.u.Disco.Equals(bDisco)
                                                && @t.u.Tropical.Equals(bTropical))
                                   .Select(@t => new { @t.u.BarName, @t.u.BarID });

                return Json(barResult, JsonRequestBehavior.AllowGet);
            }
            
            if (!String.IsNullOrEmpty(promocion) || !String.IsNullOrEmpty(evento) && !String.IsNullOrEmpty(bar) && !String.IsNullOrEmpty(antro) && !String.IsNullOrEmpty(after))
            {
                //Search Bar, Antro and After
                DateTime datenow = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                var barResult = _db.Bars.Join(_db.stayUP, u => u.BarID, s => s.BarId, (u, s) => new { u, s })
                    // ReSharper disable ImplicitlyCapturedClosure
                                   .Where(@t => EntityFunctions.TruncateTime(@t.s.EventDate) == datenow
                                                // ReSharper restore ImplicitlyCapturedClosure
                                                && @t.u.Township.ToUpper().Contains(delegacion.ToUpper())
                                                && !String.IsNullOrEmpty(@t.u.Cologne)
                                                && !String.IsNullOrEmpty(@t.s.Promotion)
                                                && !String.IsNullOrEmpty(@t.s.BarEvent)
                                                && @t.u.Cologne.Contains(colonia)
                                                && (@t.u.BarType.Equals(bBar) || @t.u.Antro.Equals(bAntro) || @t.u.After.Equals(bAfter))
                                                && @t.u.Parking.Equals(bEstac)
                                                && @t.u.Pub.Equals(bPub)
                                                && @t.u.Karaoke.Equals(bKaraoke)
                                                && @t.u.Botanero.Equals(bBotanero)
                                                && @t.u.GayBar.Equals(bGaybar)
                                                && @t.u.Mezcaleria.Equals(bMezcaleria)
                                                && @t.u.Cerveceria.Equals(bCerve)
                                                && @t.u.Alternative.Equals(bAlter)
                                                && @t.u.Rock.Equals(bRock)
                                                && @t.u.Electronic.Equals(bElectro)
                                                && @t.u.HipHop.Equals(bHipH)
                                                && @t.u.JazzBlues.Equals(bJazzB)
                                                && @t.u.Reggae.Equals(bReggae)
                                                && @t.u.Trova.Equals(bTrova)
                                                && @t.u.Lounge.Equals(bLounge)
                                                && @t.u.Banda.Equals(bBanda)
                                                && @t.u.Pop.Equals(bPop)
                                                && @t.u.Disco.Equals(bDisco)
                                                && @t.u.Tropical.Equals(bTropical))
                                   .Select(@t => new { @t.u.BarName, @t.u.BarID });

                return Json(barResult, JsonRequestBehavior.AllowGet);
            }
            
            if (!String.IsNullOrEmpty(promocion) ||
                     !String.IsNullOrEmpty(evento) && String.IsNullOrEmpty(bar) && !String.IsNullOrEmpty(antro) && String.IsNullOrEmpty(after))
            {
                //Search Antro
                DateTime datenow = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                var barResult = _db.Bars.Join(_db.stayUP, u => u.BarID, s => s.BarId, (u, s) => new { u, s })
                    // ReSharper disable ImplicitlyCapturedClosure
                                   .Where(@t => EntityFunctions.TruncateTime(@t.s.EventDate) == datenow
                                                // ReSharper restore ImplicitlyCapturedClosure
                                                && @t.u.Township.ToUpper().Contains(delegacion.ToUpper())
                                                && !String.IsNullOrEmpty(@t.u.Cologne)
                                                && !String.IsNullOrEmpty(@t.s.Promotion)
                                                && !String.IsNullOrEmpty(@t.s.BarEvent)
                                                && @t.u.Cologne.Contains(colonia)
                                                && @t.u.Antro.Equals(bAntro)
                                                && @t.u.Parking.Equals(bEstac)
                                                && @t.u.Pub.Equals(bPub)
                                                && @t.u.Karaoke.Equals(bKaraoke)
                                                && @t.u.Botanero.Equals(bBotanero)
                                                && @t.u.GayBar.Equals(bGaybar)
                                                && @t.u.Mezcaleria.Equals(bMezcaleria)
                                                && @t.u.Cerveceria.Equals(bCerve)
                                                && @t.u.Alternative.Equals(bAlter)
                                                && @t.u.Rock.Equals(bRock)
                                                && @t.u.Electronic.Equals(bElectro)
                                                && @t.u.HipHop.Equals(bHipH)
                                                && @t.u.JazzBlues.Equals(bJazzB)
                                                && @t.u.Reggae.Equals(bReggae)
                                                && @t.u.Trova.Equals(bTrova)
                                                && @t.u.Lounge.Equals(bLounge)
                                                && @t.u.Banda.Equals(bBanda)
                                                && @t.u.Pop.Equals(bPop)
                                                && @t.u.Disco.Equals(bDisco)
                                                && @t.u.Tropical.Equals(bTropical))
                                   .Select(@t => new { @t.u.BarName, @t.u.BarID });

                return Json(barResult, JsonRequestBehavior.AllowGet);
            }
            
            if (!String.IsNullOrEmpty(promocion) || !String.IsNullOrEmpty(evento) 
                && String.IsNullOrEmpty(bar) && !String.IsNullOrEmpty(antro) && !String.IsNullOrEmpty(after))
            {
                //Search Antro and After
                DateTime datenow = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                var barResult = _db.Bars.Join(_db.stayUP, u => u.BarID, s => s.BarId, (u, s) => new { u, s })
                    // ReSharper disable ImplicitlyCapturedClosure
                                   .Where(@t => EntityFunctions.TruncateTime(@t.s.EventDate) == datenow
                                                // ReSharper restore ImplicitlyCapturedClosure
                                                && @t.u.Township.ToUpper().Contains(delegacion.ToUpper())
                                                && !String.IsNullOrEmpty(@t.u.Cologne)
                                                && !String.IsNullOrEmpty(@t.s.Promotion)
                                                && !String.IsNullOrEmpty(@t.s.BarEvent)
                                                && @t.u.Cologne.Contains(colonia)
                                                && (@t.u.Antro.Equals(bAntro) || @t.u.After.Equals((bAfter)))
                                                && @t.u.Parking.Equals(bEstac)
                                                && @t.u.Pub.Equals(bPub)
                                                && @t.u.Karaoke.Equals(bKaraoke)
                                                && @t.u.Botanero.Equals(bBotanero)
                                                && @t.u.GayBar.Equals(bGaybar)
                                                && @t.u.Mezcaleria.Equals(bMezcaleria)
                                                && @t.u.Cerveceria.Equals(bCerve)
                                                && @t.u.Alternative.Equals(bAlter)
                                                && @t.u.Rock.Equals(bRock)
                                                && @t.u.Electronic.Equals(bElectro)
                                                && @t.u.HipHop.Equals(bHipH)
                                                && @t.u.JazzBlues.Equals(bJazzB)
                                                && @t.u.Reggae.Equals(bReggae)
                                                && @t.u.Trova.Equals(bTrova)
                                                && @t.u.Lounge.Equals(bLounge)
                                                && @t.u.Banda.Equals(bBanda)
                                                && @t.u.Pop.Equals(bPop)
                                                && @t.u.Disco.Equals(bDisco)
                                                && @t.u.Tropical.Equals(bTropical))
                                   .Select(@t => new { @t.u.BarName, @t.u.BarID });

                return Json(barResult, JsonRequestBehavior.AllowGet);
            }
            
            if (!String.IsNullOrEmpty(promocion) || !String.IsNullOrEmpty(evento) 
                && String.IsNullOrEmpty(bar) && String.IsNullOrEmpty(antro) && !String.IsNullOrEmpty(after))
            {
                //Search After
                DateTime datenow = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                var barResult = _db.Bars.Join(_db.stayUP, u => u.BarID, s => s.BarId, (u, s) => new { u, s })
                    // ReSharper disable ImplicitlyCapturedClosure
                                   .Where(@t => EntityFunctions.TruncateTime(@t.s.EventDate) == datenow
                                                // ReSharper restore ImplicitlyCapturedClosure
                                                && @t.u.Township.ToUpper().Contains(delegacion.ToUpper())
                                                && !String.IsNullOrEmpty(@t.u.Cologne)
                                                && !String.IsNullOrEmpty(@t.s.Promotion)
                                                && !String.IsNullOrEmpty(@t.s.BarEvent)
                                                && @t.u.Cologne.Contains(colonia)
                                                && @t.u.After.Equals((bAfter))
                                                && @t.u.Parking.Equals(bEstac)
                                                && @t.u.Pub.Equals(bPub)
                                                && @t.u.Karaoke.Equals(bKaraoke)
                                                && @t.u.Botanero.Equals(bBotanero)
                                                && @t.u.GayBar.Equals(bGaybar)
                                                && @t.u.Mezcaleria.Equals(bMezcaleria)
                                                && @t.u.Cerveceria.Equals(bCerve)
                                                && @t.u.Alternative.Equals(bAlter)
                                                && @t.u.Rock.Equals(bRock)
                                                && @t.u.Electronic.Equals(bElectro)
                                                && @t.u.HipHop.Equals(bHipH)
                                                && @t.u.JazzBlues.Equals(bJazzB)
                                                && @t.u.Reggae.Equals(bReggae)
                                                && @t.u.Trova.Equals(bTrova)
                                                && @t.u.Lounge.Equals(bLounge)
                                                && @t.u.Banda.Equals(bBanda)
                                                && @t.u.Pop.Equals(bPop)
                                                && @t.u.Disco.Equals(bDisco)
                                                && @t.u.Tropical.Equals(bTropical))
                                   .Select(@t => new { @t.u.BarName, @t.u.BarID });

                return Json(barResult, JsonRequestBehavior.AllowGet);
            }

            if (!String.IsNullOrEmpty(promocion) || !String.IsNullOrEmpty(evento)
                && !String.IsNullOrEmpty(bar) && String.IsNullOrEmpty(antro) && !String.IsNullOrEmpty(after))
            {
                //Search Bar and After
                DateTime datenow = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                var barResult = _db.Bars.Join(_db.stayUP, u => u.BarID, s => s.BarId, (u, s) => new { u, s })
                    // ReSharper disable ImplicitlyCapturedClosure
                                   .Where(@t => EntityFunctions.TruncateTime(@t.s.EventDate) == datenow
                                       // ReSharper restore ImplicitlyCapturedClosure
                                                && @t.u.Township.ToUpper().Contains(delegacion.ToUpper())
                                                && !String.IsNullOrEmpty(@t.u.Cologne)
                                                && !String.IsNullOrEmpty(@t.s.Promotion)
                                                && !String.IsNullOrEmpty(@t.s.BarEvent)
                                                && @t.u.Cologne.Contains(colonia)
                                                && (@t.u.BarType.Equals(bBar) || @t.u.After.Equals((bAfter)))
                                                && @t.u.Parking.Equals(bEstac)
                                                && @t.u.Pub.Equals(bPub)
                                                && @t.u.Karaoke.Equals(bKaraoke)
                                                && @t.u.Botanero.Equals(bBotanero)
                                                && @t.u.GayBar.Equals(bGaybar)
                                                && @t.u.Mezcaleria.Equals(bMezcaleria)
                                                && @t.u.Cerveceria.Equals(bCerve)
                                                && @t.u.Alternative.Equals(bAlter)
                                                && @t.u.Rock.Equals(bRock)
                                                && @t.u.Electronic.Equals(bElectro)
                                                && @t.u.HipHop.Equals(bHipH)
                                                && @t.u.JazzBlues.Equals(bJazzB)
                                                && @t.u.Reggae.Equals(bReggae)
                                                && @t.u.Trova.Equals(bTrova)
                                                && @t.u.Lounge.Equals(bLounge)
                                                && @t.u.Banda.Equals(bBanda)
                                                && @t.u.Pop.Equals(bPop)
                                                && @t.u.Disco.Equals(bDisco)
                                                && @t.u.Tropical.Equals(bTropical))
                                   .Select(@t => new { @t.u.BarName, @t.u.BarID });

                return Json(barResult, JsonRequestBehavior.AllowGet);
            }

            //
            //Search without promotion or event
            if (!String.IsNullOrEmpty(bar) && String.IsNullOrEmpty(antro) && String.IsNullOrEmpty(after))
            {
                var barResult = _db.Bars
                    .Where(u => u.Township.ToUpper().Contains(delegacion.ToUpper())
                        && !String.IsNullOrEmpty(u.Cologne)
                        && u.Cologne.Contains(colonia)
                        && u.BarType.Equals(bBar)
                        && u.Parking.Equals(bEstac)
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
                        r.BarID
                    });

                return Json(barResult, JsonRequestBehavior.AllowGet);
            }

            //Searchs if the bar has promotion today
            DateTime datenow2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            var barResult2 = _db.Bars.Join(_db.stayUP, u => u.BarID, s => s.BarId, (u, s) => new { u, s })
                // ReSharper disable ImplicitlyCapturedClosure
                                .Where(@t => EntityFunctions.TruncateTime(@t.s.EventDate) == datenow2
                                    // ReSharper restore ImplicitlyCapturedClosure
                                             && @t.u.Township.ToUpper().Contains(delegacion.ToUpper())
                                             && !String.IsNullOrEmpty(@t.u.Cologne)
                                             && !String.IsNullOrEmpty(@t.s.Promotion)
                                             && !String.IsNullOrEmpty(@t.s.BarEvent)
                                             && (@t.u.BarType.Equals(bBar) || @t.u.Antro.Equals(bAntro))
                                             && @t.u.Parking.Equals(bEstac)
                                             && @t.u.Pub.Equals(bPub)
                                             && @t.u.Karaoke.Equals(bKaraoke)
                                             && @t.u.Botanero.Equals(bBotanero)
                                             && @t.u.GayBar.Equals(bGaybar)
                                             && @t.u.Mezcaleria.Equals(bMezcaleria)
                                             && @t.u.Cerveceria.Equals(bCerve)
                                             && @t.u.Alternative.Equals(bAlter)
                                             && @t.u.Rock.Equals(bRock)
                                             && @t.u.Electronic.Equals(bElectro)
                                             && @t.u.HipHop.Equals(bHipH)
                                             && @t.u.JazzBlues.Equals(bJazzB)
                                             && @t.u.Reggae.Equals(bReggae)
                                             && @t.u.Trova.Equals(bTrova)
                                             && @t.u.Lounge.Equals(bLounge)
                                             && @t.u.Banda.Equals(bBanda)
                                             && @t.u.Pop.Equals(bPop)
                                             && @t.u.Disco.Equals(bDisco)
                                             && @t.u.Tropical.Equals(bTropical))
                                .Select(@t => new { @t.u.BarName, @t.u.BarID });

            return Json(barResult2, JsonRequestBehavior.AllowGet);
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
