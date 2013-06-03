using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UpdatedParty.Models;
using System.Data.Objects;
using PagedList;
using System.Web.Helpers;
using UpdatedParty.ViewModels;

namespace UpdatedParty.Controllers
{
    public class CarteleraController : Controller
    {
        UpdatedPartyDB _db = new UpdatedPartyDB();
        //
        // GET: /Cartelera/

        public ActionResult Index(string sortOrder, string coloniaUp, string delegacion, int? page)
        {
            var viewmodel = new Cartelera
            {
                Evento = GetStayUpItems()
            };

            var del = new List<string> { "Todas", "Alvaro Obregón", "Benito Juárez", "Cuauhtémoc" };
            ViewBag.delegacion = new SelectList(del);

            return View(viewmodel);
        }

        public List<StayUP> GetStayUpItems()
        {
            return _db.stayUP.ToList();
        }

    }
}
