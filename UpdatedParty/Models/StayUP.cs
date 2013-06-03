using System;
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

        [DisplayName("Promoción del evento")]
        [MaxLength(140, ErrorMessage = "* 140 caracteres máximo")]
        [Required(ErrorMessage = "* Escribe una promoción")]
        public string PromotionEvent { get; set; }

        [DisplayName("Nombre del evento")]
        [MaxLength(140, ErrorMessage = "* 140 caracteres máximo")]
        //[Required(ErrorMessage = "* Nombre del evento requerido")]
        public string EventName { get; set; }

        [Required(ErrorMessage = "* La fecha es importante")]
        [DisplayName("Fecha del evento")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? EventDate { get; set; }

        [DisplayName("Descripción del evento")]
        [MaxLength(255, ErrorMessage = "* 255 caracteres máximo")]
        public string EventDescription { get; set; }

        [DisplayName("Banner del evento")]
        public string EventBanner { get; set; }

        [DisplayName("Banner de promoción")]
        public string PromotionBanner { get; set; }

        [DisplayName("Activo")]
        public bool IsActived { get; set; }

        public DateTime RegisterDate { get; set; }

        public virtual Bar Bar { get; set; }
    }
}