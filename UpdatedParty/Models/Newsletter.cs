using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UpdatedParty.Models
{
    public class Newsletter
    {
        public int NewsletterId { get; set; }

        public string Email { get; set; }

        public DateTime RegisterDate { get; set; }
    }
}