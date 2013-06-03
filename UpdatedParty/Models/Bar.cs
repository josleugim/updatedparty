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
        //public int UserTypeId { get; set; }
        //public int StatusTypeId { get; set; }
        public int TStateId { get; set; }

        [DisplayName("Nombre de usuario")]
        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(50, ErrorMessage = "* 50 caracteres máximo")]
        public string BarName { get; set; }

        [DisplayName("Logo del bar")]
        public string BarLogo { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "El email es requerido")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Ingresa un email válido")]
        [MaxLength(50, ErrorMessage = "* 50 caracteres máximo")]
        public string Email { get; set; }

        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "La contraseña es requerida")]
        [MaxLength(25, ErrorMessage = "* 25 caracteres máximo")]
        public string Pass { get; set; }

        [DisplayName("Horario")]
        [MaxLength(50, ErrorMessage = "* 50 caracteres máximo")]
        public string BarSchedule { get; set; }

        [DisplayName("Precio")]
        public int? Price { get; set; }

        [DisplayName("Sitio Web")]
        [MaxLength(250, ErrorMessage = "* 250 caracteres máximo.")]
        [RegularExpression(@"^http(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$", ErrorMessage = "Formato: http://www.updatedparty.com, copia y pega tu URL")]
        public string WebSite { get; set; }

        [DisplayName("Facebook")]
        [MaxLength(250, ErrorMessage = "* 250 caracteres máximo")]
        [RegularExpression(@"^http(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$", ErrorMessage = "Formato: http://www.updatedparty.com, copia y pega tu URL")]
        public string Facebook { get; set; }

        [DisplayName("Twitter")]
        [MaxLength(250, ErrorMessage = "* 250 caracteres máximo")]
        [RegularExpression(@"^http(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$", ErrorMessage = "Formato: http://www.updatedparty.com, copia y pega tu URL")]
        public string Twitter { get; set; }

        [DisplayName("Reseña")]
        public string Review { get; set; }

        [DisplayName("Teléfono de reservación")]
        public long? PhoneNumber { get; set; }

        //Dirección
        [DisplayName("Calle y número")]
        [MaxLength(30, ErrorMessage = "* 30 caracteres máximo")]
        public string Street { get; set; }

        [DisplayName("Colonia")]
        [MaxLength(30, ErrorMessage = "* 30 caracteres máximo")]
        public string Cologne { get; set; }

        [DisplayName("Municipio/Delegación")]
        public string Township { get; set; }

        [DisplayName("Estado")]
        public virtual TState TState { get; set; }

        [DisplayName("País")]
        [MaxLength(30, ErrorMessage = "* 30 caracteres máximo")]
        public string Country { get; set; }

        [DisplayName("Promoción de cumpleaños")]
        [MaxLength(200, ErrorMessage = "* 200 caracteres máximo")]
        public string BirthdayPromotion { get; set; }

        [DisplayName("De 18 a 23")]
        public bool YoungAge { get; set; }
        [DisplayName("De 24 a 29")]
        public bool MidAge { get; set; }
        [DisplayName("De 30 +")]
        public bool OldAge { get; set; }

        [DisplayName("Google Maps")]
        public string googlemaps { get; set; }

        //
        //Giro
        [DisplayName("Bar")]
        public bool BarType { get; set; }

        [DisplayName("Antro")]
        public bool Antro { get; set; }

        [DisplayName("Valet parking")]
        public bool Parking { get; set; }

        [DisplayName("After")]
        public bool After { get; set; }

        //
        //Giro
        [DisplayName("Cerveza artesanal")]
        public bool CervezaArtesanal { get; set; }

        [DisplayName("Pub")]
        public bool Pub { get; set; }

        [DisplayName("Karaoke")]
        public bool Karaoke { get; set; }

        [DisplayName("Botanero")]
        public bool Botanero { get; set; }

        [DisplayName("Gay")]
        public bool GayBar { get; set; }

        [DisplayName("Mezcalería")]
        public bool Mezcaleria { get; set; }

        [DisplayName("Cervecería")]
        public bool Cerveceria { get; set; }

        [DisplayName("Billar")]
        public bool Billar { get; set; }

        [DisplayName("Dance floor")]
        public bool DanceFloor { get; set; }

        [DisplayName("Sports bar")]
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

        [DisplayName("Dj")]
        public bool Dj { get; set; }

        [DisplayName("Activo")]
        public bool IsActived { get; set; }

        [DisplayName("Nivel premium")]
        public int? PremiumLevel { get; set; }

        [DisplayName("Fecha de registro")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime RegisterDate { get; set; }

        //public virtual UserType UserType { get; set; }

        //public virtual StatusType StatusType { get; set; }
    }
}