using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UpdatedParty.Models
{
    public class Gallery
    {
        public int GalleryID { get; set; }

        public int BarId { get; set; }

        public string UrlImage { get; set; }

        public bool IsActived { get; set; }

        public DateTime RegisterDate { get; set; }

        public virtual Bar Bar { get; set; }
    }
}