using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UpdatedParty.Models
{
    public class StatusType
    {
        public int StatusTypeID { get; set; }

        [DisplayName("Nombre del estatus")]
        public string StatusTypeName { get; set; }

        [DisplayName("Fecha de registro")]
        public DateTime RegisterDate { get; set; }
    }
}