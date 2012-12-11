using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UpdatedParty.Models
{
    public class TState
    {
        public int TStateID { get; set; }
        public string StateName { get; set; }
        public string StateAbbreviation { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}