using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UpdatedParty.Models
{
    public class Photo
    {
        [Key]
        public int PhotoID { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime RegisterDate { get; set; }
        public SocialMedia SocialMedia { get; set; }
    }
}