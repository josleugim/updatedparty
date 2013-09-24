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


        public ViewResult Index(string sortOrder, string coloniaUp, string delegacion, int? page, int? next)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name desc" : "";

            DateTime nextDay;

            if (next == 31)
                next = 0;

            if (next != null && next > 0)
            {
                nextDay = Convert.ToDateTime(DateTime.Now.AddDays(Convert.ToDouble(next)).ToShortDateString());
            }
            else
                nextDay = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            if (Request.HttpMethod != "GET")
                page = 1;


            var stayup = from u in _db.stayUP
                         where EntityFunctions.TruncateTime(u.EventDate) == nextDay
                         select u;

            if (!String.IsNullOrEmpty(delegacion) && delegacion != "Todas")
            {
                stayup = stayup.Where(s => s.Bar.Township == delegacion
                    && !String.IsNullOrEmpty(s.Bar.Cologne)
                    && s.Bar.Cologne.Contains(coloniaUp));
            }

            if (delegacion == "Todas")
            {
                stayup = stayup.Where(s => s.Bar.Township != null
                    && !String.IsNullOrEmpty(s.Bar.Cologne)
                    && s.Bar.Cologne.Contains(coloniaUp));
            }

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
                    stayup = stayup.OrderByDescending(s => s.Bar.BarID);
                    break;
            }

            var del = new List<string> { "Todas", "Alvaro Obregón", "Benito Juárez", "Cuauhtémoc" };
            ViewBag.delegacion = new SelectList(del);

            ViewBag.NextDay = nextDay.ToString("dddd") + " " + nextDay.Day + " " + nextDay.ToString("MMMM");
            ViewBag.Next = next;

            const int pageSize = 18;
            int pageNumber = (page ?? 1);

            //return View(stayup.ToList().Take(10));
            return View(stayup.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult JsonSearch(string delegacion, string colonia, string antro, string after, string bar, string pub, string restaurant)
        {
            var businessType = new List<string>();
            if (!String.IsNullOrEmpty(antro))
                businessType.Add("Antro");
            if (!String.IsNullOrEmpty(after))
                businessType.Add("After");
            if (!String.IsNullOrEmpty(bar))
                businessType.Add("Bar");
            if (!String.IsNullOrEmpty(pub))
                businessType.Add("Pub");
            if (!String.IsNullOrEmpty(restaurant))
                businessType.Add("Restaurant Bar");
            if(String.IsNullOrEmpty(antro) && string.IsNullOrEmpty(after) && string.IsNullOrEmpty(bar) && string.IsNullOrEmpty(pub) && string.IsNullOrEmpty(restaurant))
            {
                businessType.Add("Antro");
                businessType.Add("After");
                businessType.Add("Bar");
                businessType.Add("Pub");
                businessType.Add("Restaurant Bar");
            }

            //Buscatodo
            if (delegacion == "Todas")
            {
                var results = _db.Bars
                                 .Where(b => b.IsActived
                                 && b.Cologne.Contains(colonia)
                                 && businessType.Contains(b.BusinessType.TypeName))
                                             .Select(r => new
                                             {
                                                 r.BarID,
                                                 r.BarName
                                             });
                return Json(results, JsonRequestBehavior.AllowGet);
            }
            //Por delegación
            var results2 = _db.Bars
                         .Where(u => u.Township.ToUpper().Contains(delegacion.ToUpper())
                                     && !String.IsNullOrEmpty(u.Cologne)
                                     && u.Cologne.Contains(colonia)
                                     && businessType.Contains(u.BusinessType.TypeName))
                                     .Select(r => new
                                     {
                                         r.BarID,
                                         r.BarName
                                     });


            return Json(results2, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        public ActionResult Rate(string rate)
        {

            return View();
        }

        //Blog
        public ViewResult Headache()
        {
            return View();
        }

        public ViewResult Whiskey()
        {
            return View();
        }

        public ViewResult Bailamos()
        {
            return View();
        }

        public ViewResult AntroSustentable()
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