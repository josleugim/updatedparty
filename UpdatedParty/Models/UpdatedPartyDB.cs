using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace UpdatedParty.Models
{
    /// <summary>
    /// ORM to SQL Server
    /// </summary>
    public class UpdatedPartyDB:DbContext
    {
        //Use this code in only in the development server
        public UpdatedPartyDB()
            : base("name=UpdatedPartyDB")
        { }

        public DbSet<TState> TStates { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<BusinessType> BusinessTypes { get; set; }
        public DbSet<Bar> Bars { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<StayUP> stayUP { get; set; }
    }
}