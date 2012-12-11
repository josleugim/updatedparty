using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UpdatedParty.Models
{
    public class Complain
    {
        [Key]
        public int ComplainID { get; set; }
        public int ComplainTypeId { get; set; }
        public int BarId { get; set; }

        public string ComplainComment { get; set; }
        public DateTime RegisterDate { get; set; }
        public virtual ComplainType ComplainType { get; set; }
        public virtual Bar Bar { get; set; }
    }
}