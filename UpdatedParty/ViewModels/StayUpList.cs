using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using UpdatedParty.Models;
using System.Web.Mvc;

namespace UpdatedParty.ViewModels
{
    public class StayUpList
    {
        public int ID { get; set; }
        public string Name { get; set; }
        //public MultiSelectList Items { get; set; }
    }
}