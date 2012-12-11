using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace UpdatedParty.Models
{
    public class UserType
    {
        public int UserTypeID { get; set; }
        public string UserTypeName { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}