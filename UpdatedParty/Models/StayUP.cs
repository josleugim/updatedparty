﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UpdatedParty.Models
{
    public class StayUP
    {
        public int StayUPID { get; set; }

        public int BarId { get; set; }

        [DisplayName("Promoción")]
        public string Promotion { get; set; }

        [DisplayName("Evento")]
        public string BarEvent { get; set; }

        [DisplayName("Fecha del evento")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? EventDate { get; set; }

        public DateTime RegisterDate { get; set; }

        public virtual Bar Bar { get; set; }
    }
}