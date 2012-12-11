using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UpdatedParty.Models
{
    public class ComplainType
    {
        [Key]
        public int ComplainTypeID { get; set; }
        public string ComplainTypeName { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}