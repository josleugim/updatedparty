using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UpdatedParty.Models;
using System.Data.Objects;
using PagedList;
using System.Web.Helpers;

namespace UpdatedParty.Controllers
{
    public class HomeController : Controller
    {
        private readonly UpdatedPartyDB _db = new UpdatedPartyDB();


        public ViewResult Index(string sortOrder, string coloniaUp, string delegacion, int? page)
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
                stayup = stayup.Where(s => s.Bar.Township == delegacion
                    && !String.IsNullOrEmpty(s.Bar.Cologne)
                    && s.Bar.Cologne.Contains(coloniaUp));
                //stayup = stayup.Join(_db.Bars, s => s.Bar.Township == delegacion, )
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

            const int pageSize = 10;
            int pageNumber = (page ?? 1);

            //return View(stayup.ToList().Take(10));
            return View(stayup.ToPagedList(pageNumber, pageSize));
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
            //if (!String.IsNullOrEmpty(bar))
            //    bBar = true;
            //if (!String.IsNullOrEmpty(antro))
            //    bAntro = true;
            //if (!String.IsNullOrEmpty(after))
            //    bAfter = true;
            if (!String.IsNullOrEmpty(estacionamiento))
                bEstac = true;
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

            //var results = from b in _db.Bars
            //              where !String.IsNullOrEmpty(b.Cologne)
            //              && b.Cologne.Contains(colonia)
            //              select b;
            //if (bBar)
            //{
            //    results = results.Where(b => b.BarType.Equals(true));
            //}

            //Solo busca bares
            if (!String.IsNullOrEmpty(bar) && String.IsNullOrEmpty(antro) && String.IsNullOrEmpty(after))
            {
                var results2 = _db.Bars
                             .Where(u => u.Township.ToUpper().Contains(delegacion.ToUpper())
                                         && !String.IsNullOrEmpty(u.Cologne)
                                         && u.Cologne.Contains(colonia)
                                         && u.BarType.Equals(true))
                                         .Select(r => new
                                         {
                                             r.BarID,
                                             r.BarName
                                         });
                return Json(results2, JsonRequestBehavior.AllowGet);
            }
            //Solo busca antros
            if (!String.IsNullOrEmpty(antro) && String.IsNullOrEmpty(bar) && String.IsNullOrEmpty(after))
            {
                var results2 = _db.Bars
                             .Where(u => u.Township.ToUpper().Contains(delegacion.ToUpper())
                                         && !String.IsNullOrEmpty(u.Cologne)
                                         && u.Cologne.Contains(colonia)
                                         && u.Antro.Equals(true))
                                         .Select(r => new
                                         {
                                             r.BarID,
                                             r.BarName
                                         });
                return Json(results2, JsonRequestBehavior.AllowGet);
            }
            //Busca antros y bares
            if (!String.IsNullOrEmpty(antro) && !String.IsNullOrEmpty(bar) && String.IsNullOrEmpty(after))
            {
                var results2 = _db.Bars
                             .Where(u => u.Township.ToUpper().Contains(delegacion.ToUpper())
                                         && !String.IsNullOrEmpty(u.Cologne)
                                         && u.Cologne.Contains(colonia)
                                         && (u.BarType.Equals(true) || u.Antro.Equals(true)))
                                         .Select(r => new
                                         {
                                             r.BarID,
                                             r.BarName
                                         });
                return Json(results2, JsonRequestBehavior.AllowGet);
            }

            //Solo busca afters
            if (String.IsNullOrEmpty(antro) && String.IsNullOrEmpty(bar) && !String.IsNullOrEmpty(after))
            {
                var results2 = _db.Bars
                             .Where(u => u.Township.ToUpper().Contains(delegacion.ToUpper())
                                         && !String.IsNullOrEmpty(u.Cologne)
                                         && u.Cologne.Contains(colonia)
                                         && u.After.Equals(true))
                                         .Select(r => new
                                         {
                                             r.BarID,
                                             r.BarName
                                         });
                return Json(results2, JsonRequestBehavior.AllowGet);
            }

            //Busca after y bares
            if (String.IsNullOrEmpty(antro) && !String.IsNullOrEmpty(bar) && !String.IsNullOrEmpty(after))
            {
                var results2 = _db.Bars
                             .Where(u => u.Township.ToUpper().Contains(delegacion.ToUpper())
                                         && !String.IsNullOrEmpty(u.Cologne)
                                         && u.Cologne.Contains(colonia)
                                         && (u.BarType.Equals(true) || u.After.Equals(true)))
                                         .Select(r => new
                                         {
                                             r.BarID,
                                             r.BarName
                                         });
                return Json(results2, JsonRequestBehavior.AllowGet);
            }

            //Busca antros y after
            if (!String.IsNullOrEmpty(antro) && String.IsNullOrEmpty(bar) && !String.IsNullOrEmpty(after))
            {
                var results2 = _db.Bars
                             .Where(u => u.Township.ToUpper().Contains(delegacion.ToUpper())
                                         && !String.IsNullOrEmpty(u.Cologne)
                                         && u.Cologne.Contains(colonia)
                                         && (u.After.Equals(true) || u.Antro.Equals(true)))
                                         .Select(r => new
                                         {
                                             r.BarID,
                                             r.BarName
                                         });
                return Json(results2, JsonRequestBehavior.AllowGet);
            }

            if (!String.IsNullOrEmpty(colonia))
            {
                var results2 = _db.Bars
                             .Where(u => u.Township.ToUpper().Contains(delegacion.ToUpper())
                                         && u.Cologne.Contains(colonia))
                                         .Select(r => new
                                         {
                                             r.BarID,
                                             r.BarName
                                         });
                return Json(results2, JsonRequestBehavior.AllowGet);
            }

            //Buscatodo
            var results = _db.Bars
                             .Where(u => u.Township.ToUpper().Equals(delegacion.ToUpper()))
                                         .Select(r => new
                                         {
                                             r.BarID,
                                             r.BarName
                                         });
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        public ActionResult Rate(string rate)
        {

            return View();
        }

        public ViewResult Headache()
        {
            return View();
        }

        /// <summary>
        /// Contacts the specified email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="nombre">The nombre.</param>
        /// <param name="emailMessage">The email message.</param>
        /// <returns></returns>
        [HttpPost]
        public ViewResult Contact(string email, string nombre, string emailMessage) // Your model is passed in here
        {
            try
            {
                WebMail.SmtpServer = "mail.updatedparty.com";
                WebMail.Send("contacto@updatedparty.com", "Contacto:" + nombre, emailMessage, email);

                return View();
            }

            catch (Exception ex)
            {
                ViewData.ModelState.AddModelError("_FORM", ex.ToString());
            }
            return View("ContactFail");
        }

        [HttpPost]
        public ViewResult Suscribe(string newsletterEmail)
        {
            var searchEmail = from n in _db.Newsletters
                              where n.Email.Equals(newsletterEmail)
                              select n;
            if (!searchEmail.Any())
            {
                var newsletter = new Newsletter();

                newsletter.Email = newsletterEmail;
                newsletter.RegisterDate = DateTime.Now;
                _db.Newsletters.Add(newsletter);
                _db.SaveChanges();

                return View();
            }

            return View("SuscribeExist");
        }

        public ViewResult AvisoPrivacidad()
        {
            return View();
        }
    }
}
