using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace UpdatedParty.Models
{
    public class UPInitializer : DropCreateDatabaseIfModelChanges<UpdatedPartyDB>
    {
        protected override void Seed(UpdatedPartyDB context)
        {
            //base.Seed(context);
            var type = new List<BusinessType> { 
                new BusinessType{
                    TypeName = "Antro"
                },
                new BusinessType{
                    TypeName = "Bar"
                },
                new BusinessType{
                    TypeName = "After"
                },
                new BusinessType{
                    TypeName = "Restaurant Bar"
                },
                new BusinessType{
                    TypeName = "Pub"
                }
            };
            type.ForEach(t => context.BusinessTypes.Add(t));

            var states = new List<TState>
            {
                new TState
                {
                    StateName = "Distrito Federal",
                    StateAbbreviation = "DF",
                    RegisterDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                },
                new TState
                {
                    StateName = "Hidalgo",
                    StateAbbreviation = "HGO",
                    RegisterDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                }
            };
            states.ForEach(s => context.TStates.Add(s));

            var bares = new List<Bar> { 
                new Bar{
                    BusinessType = type.Single(t => t.TypeName == "Antro"),
                    TState = states.Single(s => s.StateAbbreviation == "DF"),
                    BarName = "CatWalk",
                    Pass = "123456",
                    Email = "catwalk@updatedparty.com",
                    Street = "Tamaulipas 63" ,
                    Cologne = "Condesa",
                    Township = "Cuauhtémoc",
                    BarSchedule = "22:00 a 3:00 hrs ",
                    PhoneNumber = 5559531729,
                    Parking = true,
                    MidAge = true,
                    WebSite = "http://www.catwalk.mx/",
                    Facebook = "https://www.facebook.com/CondesaCatwalk",
                    Twitter = "https://twitter.com/CatWalkCondesa",
                    Review = "CatWalk, un lugar diferente en el centro de Condesa,te ofrece un concepto innovador al estilo Neoyorkino donde a través de su encanto visual te transporta a un ambiente urbano, trendy y relajado para crear momentos y experiencias inigualables. Antro de moda, antro tipo Industrial Urbano de 3 pisos: MainRoom, mezzanine lounge y terraza tipo Deck con alberca; antro con un DowntownBeach Club y Grill. Tenemos variedad de presentaciones musicales y artísticas, enfatizando el giro de la Moda y el glamour en los shows. Prestamos especial atención en el cuidado al cliente, tenemos seguridad en todo el lugar, así como paramédico y servicio de taxi seguro. Memorable y divertido Tenemos sorpresa en espectáculos, puedes interactuar ya que el show se fusiona con los clientes, la gente termina divertida de aquí somos un lugar memorable, divertido y con gran ambiente.",
                    Banda = true,
                    Pop = true,
                    Dj = true,
                    OpenBar = true,
                    IsActived = true,
                    RegisterDate = DateTime.Now
                },
                new Bar{
                    BusinessType = type.Single(t => t.TypeName == "Pub"),
                    TState = states.Single(s => s.StateAbbreviation == "DF"),
                    BarName = "Black Horse",
                    Pass = "123456",
                    Email = "info@caballonegro.com",
                    Street = "Mexicali 85",
                    Cologne = "Condesa",
                    Township = "Cuauhtémoc",
                    BarSchedule = "Martes a sabado 6pm a 2am",
                    PhoneNumber = 52118740,
                    Parking = true,
                    MidAge = true,
                    WebSite = "http://www.caballonegro.com/",
                    Facebook = "https://www.facebook.com/blackhorsemx",
                    Twitter = "https://twitter.com/blackhorsedf",
                    Review = "Funk.hip.hop.indie + cheese.",
                    Alternative = true,
                    Rock = true,
                    HipHop = true,
                    JazzBlues = true,
                    Pub = true,
                    IsActived = true,
                    RegisterDate = DateTime.Now
                },
                new Bar{
                    BusinessType = type.Single(t => t.TypeName == "Restaurant Bar"),
                    TState = states.Single(s => s.StateAbbreviation == "DF"),
                    BarName = "Salón Malafama",
                    Pass = "123456",
                    Email = "salonmalafama@updatedparty.com",
                    Street = "Michoacán 78",
                    Cologne = "Condesa",
                    Township = "Cuauhtémoc",
                    BarSchedule = "L-J 10 a 1:00 hrs V-S 13 a 2:30 hrs D 13 a 00",
                    PhoneNumber = 55535138,
                    Parking = true,
                    YoungAge = true,
                    MidAge = true,
                    OldAge = true,
                    WebSite = "http://salonmalafama.com.mx/",
                    Review = "Salón Malafama un nuevo concepto de Billar/Galeria en la condesa para pasar una tarde con los amigos, disfrutar de la copa y la buena musica!!",
                    Rock = true,
                    HipHop = true,
                    JazzBlues = true,
                    Lounge = true,
                    Cerveceria = true,
                    Botanero = true,
                    RestaurantBar = true,
                    Billar = true,
                    IsActived = true,
                    RegisterDate = DateTime.Now
                },
                new Bar{
                    BusinessType = type.Single(t => t.TypeName == "Bar"),
                    TState = states.Single(s => s.StateAbbreviation == "DF"),
                    BarName = "Diente de Oro",
                    Pass = "123456",
                    Email = "dientedeoro@updatedparty.com",
                    Street = "Iztaccihuatl 36 local b",
                    Cologne = "Condesa",
                    Township = "Cuauhtémoc",
                    BarSchedule = "6pm a 2 am",
                    PhoneNumber = 52644617,
                    MidAge = true,
                    OldAge = true,
                    Facebook = "https://www.facebook.com/diente.deoro.5",
                    Twitter = "https://twitter.com/DientedeOro",
                    Review = "Si quieres escuchar muy buena música y tomarte un buen Whisky el Diente de Oro es el lugar perfecto con un ambiente totalmente amigable, tenemos mas de 70 whiskys desde single malt, blended y bourbon. De cualquier forma si quieres tomarte una chela, ron, vodka, ginebra o un brandy también manejamos algunas marcas.",
                    Rock = true,
                    IsActived = true,
                    RegisterDate = DateTime.Now
                },
                new Bar{
                    BusinessType = type.Single(t => t.TypeName == "Bar"),
                    TState = states.Single(s => s.StateAbbreviation == "DF"),
                    BarName = "Bar Berlin Insurgentes",
                    Pass = "123456",
                    Email = "berlin@updatedparty.com",
                    Street = "Insurgentes sur 1217",
                    Cologne = "Extremadura Insurgentes",
                    Township = "Benito Juárez",
                    OldAge = true,
                    WebSite = "http://www.barberlin.com.mx/",
                    Facebook = "https://www.facebook.com/barberlin.insurgentes",
                    Review = "Si buscas en un buen lugar para rockear piensa en Berlín.",
                    Rock = true,
                    IsActived = true,
                    RegisterDate = DateTime.Now
                }
            };
            bares.ForEach(b => context.Bars.Add(b));
        }
    }
}