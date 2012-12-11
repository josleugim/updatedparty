using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UpdatedParty.Models
{
    public class Bar
    {
        public int BarID { get; set; }
        public int UserTypeId { get; set; }
        public int StatusTypeId { get; set; }
        public int TStateId { get; set; }

        [DisplayName("Nombre de usuario")]
        [Required(ErrorMessage = "El nombre es requerido")]
        public string BarName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "El email es requerido")]
        public string Email { get; set; }

        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "La contraseña es requerida")]
        public string Pass { get; set; }

        //[DisplayName("Promoción")]
        //public string Promotion { get; set; }

        //[DisplayName("Evento")]
        //public string Event { get; set; }

        [DisplayName("Horario")]
        public string BarSchedule { get; set; }

        [DisplayName("Precio")]
        public Decimal? Price { get; set; }

        [DisplayName("Servicios")]
        public string BarService { get; set; }

        [DisplayName("Sitio Web")]
        public string WebSite { get; set; }

        [DisplayName("Género Musical")]
        public string MusicGender { get; set; }

        [DisplayName("Forma de pago")]
        public string Payment { get; set; }

        [DisplayName("Reseña")]
        public string Review { get; set; }

        //Dirección
        [DisplayName("Calle")]
        public string Street { get; set; }

        [DisplayName("Colonia")]
        public string Cologne { get; set; }

        [DisplayName("Municipio")]
        public string Township { get; set; }

        [DisplayName("Estado")]
        public virtual TState TState { get; set; }

        [DisplayName("País")]
        public string Country { get; set; }

        [DisplayName("Fecha de registro")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime RegisterDate { get; set; }

        public virtual UserType UserType { get; set; }

        public virtual StatusType StatusType { get; set; }
    }
}