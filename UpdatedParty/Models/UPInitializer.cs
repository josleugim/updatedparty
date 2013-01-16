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
            //var usertype = new List<UserType> { 
            //new UserType {UserTypeName = "Bar",
            //RegisterDate = DateTime.Now},
            //new UserType {UserTypeName = "Antro",
            //RegisterDate = DateTime.Now}
            //};
            //usertype.ForEach(d => context.UserTypes.Add(d));

            //var statustype = new List<StatusType> { 
            //    new StatusType { StatusTypeName = "Activo",
            //                     RegisterDate = DateTime.Now},
            //    new StatusType {StatusTypeName = "Inactivo",
            //                    RegisterDate = DateTime.Now}
            //};
            //statustype.ForEach(d => context.StatusTypes.Add(d));

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

            //var upuser = new List<UPUser>{

            //    new UPUser { upUserName = "Updated Party Pub",
            //                 upUserEmail = "pub@updatedparty.com",
            //                 upUserPass = "123",
            //                 Promotion = "Lunes de 2x1",
            //                 Event = "Molotov 25 de Junio",
            //                 upSchedule = "De 5:00pm en adelante",
            //                 Price = "Cerverza $30",
            //                 Service = "Valet Parking",
            //                 WebSite = "www.updatedparty.com",
            //                 RegisterDate  = DateTime.Now,
            //                 UserType = usertype[1],
            //                 StatusType = statustype[1]},
            //    new UPUser { upUserName = "Updated Party Antro",
            //                 upUserEmail = "antro@updatedparty.com",
            //                 Promotion = "Lunes de 2x1",
            //                 Event = "Aoki 25 de Junio",
            //                 upSchedule = "De 5:00pm en adelante",
            //                 Price = "Cerverza $30",
            //                 Service = "Valet Parking",
            //                 WebSite = "www.updatedparty.com",
            //                 RegisterDate  = DateTime.Now,
            //                 UserType = usertype[1],
            //                 StatusType = statustype[1]},
            //    };
            //upuser.ForEach(d => context.UPUsers.Add(d));
        }
    }
}