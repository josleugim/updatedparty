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

        [DisplayName("Horario")]
        public string BarSchedule { get; set; }

        [DisplayName("Precio")]
        public int? Price { get; set; }

        [DisplayName("Sitio Web")]
        public string WebSite { get; set; }

        [DisplayName("Facebook")]
        public string Facebook { get; set; }

        [DisplayName("Twitter")]
        public string Twitter { get; set; }

        [DisplayName("Reseña")]
        public string Review { get; set; }

        //Dirección
        [DisplayName("Calle")]
        public string Street { get; set; }

        [DisplayName("Colonia")]
        public string Cologne { get; set; }

        [DisplayName("Municipio/Delegación")]
        public string Township { get; set; }

        [DisplayName("Estado")]
        public virtual TState TState { get; set; }

        [DisplayName("País")]
        public string Country { get; set; }

        [DisplayName("Promoción de cumpleaños")]
        public string BirthdayPromotion { get; set; }

        [DisplayName("De 18 a 23")]
        public bool YoungAge { get; set; }
        [DisplayName("De 24 a 29")]
        public bool MidAge { get; set; }
        [DisplayName("De 30 +")]
        public bool OldAge { get; set; }

        //
        //Tipo
        //
        [DisplayName("Bar")]
        public bool BarType { get; set; }

        [DisplayName("Antro")]
        public bool Antro { get; set; }

        [DisplayName("Valet parking")]
        public bool Parking { get; set; }

        [DisplayName("After")]
        public bool After { get; set; }

        [DisplayName("Pub")]
        public bool Pub { get; set; }

        [DisplayName("Karaoke")]
        public bool Karaoke { get; set; }

        [DisplayName("Botanero")]
        public bool Botanero { get; set; }

        [DisplayName("Gaybar")]
        public bool GayBar { get; set; }

        [DisplayName("Mezcalería")]
        public bool Mezcaleria { get; set; }

        [DisplayName("Cervecería")]
        public bool Cerveceria { get; set; }

        [DisplayName("Billar")]
        public bool Billar { get; set; }

        [DisplayName("Dance floor")]
        public bool DanceFloor { get; set; }

        [DisplayName("SportsBar")]
        public bool SportsBar { get; set; }

        [DisplayName("Al aire libre")]
        public bool OpenBar { get; set; }

        [DisplayName("Restaurant bar")]
        public bool RestaurantBar { get; set; }

        //
        //Música
        //
        [DisplayName("Alternativo")]
        public bool Alternative { get; set; }

        [DisplayName("Rock")]
        public bool Rock { get; set; }

        [DisplayName("Electrónica")]
        public bool Electronic { get; set; }

        [DisplayName("Hip - Hop")]
        public bool HipHop { get; set; }

        [DisplayName("Jazz / Blues")]
        public bool JazzBlues { get; set; }

        [DisplayName("Reggae")]
        public bool Reggae { get; set; }

        [DisplayName("Trova")]
        public bool Trova { get; set; }

        [DisplayName("Lounge")]
        public bool Lounge { get; set; }

        [DisplayName("Banda")]
        public bool Banda { get; set; }

        [DisplayName("Pop")]
        public bool Pop { get; set; }

        [DisplayName("Disco")]
        public bool Disco { get; set; }

        [DisplayName("Tropical")]
        public bool Tropical { get; set; }

        [DisplayName("Fecha de registro")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime RegisterDate { get; set; }

        public virtual UserType UserType { get; set; }

        public virtual StatusType StatusType { get; set; }
    }
}