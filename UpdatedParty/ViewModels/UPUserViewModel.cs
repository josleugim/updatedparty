using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using UpdatedParty.Models;

namespace UpdatedParty.ViewModels
{
    public class UPUserViewModel
    {
        public UPUser UPUsers { get; set;}
        public List<UserType> UserTypes { get; set; }
    }
}