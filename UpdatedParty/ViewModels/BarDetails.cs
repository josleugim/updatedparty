using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UpdatedParty.Models;
using PagedList;

namespace UpdatedParty.ViewModels
{
    public class BarDetails
    {
        public int BarId { get; set; }
        public List<StayUP> Evento { get; set; }
        public string FoursquareVenue { get; set; }
        public virtual Bar Bar { get; set; }
    }
}