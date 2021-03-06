﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;            // Database.SetInitialize
using UpdatedParty.Models;
using System.Globalization;
using System.Threading;              // MovieInitializer

namespace UpdatedParty
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "BarsDetails", // Route name
                "{Name}/{id}", // URL with parameters
                new { controller = "BarDetails", action = "Index"}, // Parameter defaults
                new { id = @"^\d+$" }
            );

            //RouteTable.Routes.MapRoute(null, "{Name}", new { controller = "Bar", action = "BarDetails", id = "" });

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            //Database.SetInitializer<UpdatedPartyDB>(new UPInitializer());
            Database.SetInitializer<UpdatedPartyDB>(null);
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //Culture for México
            Thread.CurrentThread.CurrentCulture = new CultureInfo(1034);
        }
    }
}