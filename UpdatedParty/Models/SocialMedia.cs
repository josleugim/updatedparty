using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UpdatedParty.Models
{
    public class SocialMedia
    {
        public int SocialMediaID { get; set; }
        public int BarId { get; set; }

        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string GoogleMap { get; set; }
        public DateTime RegisterDate { get; set; }
        public virtual Bar Bar { get; set; }
    }
}