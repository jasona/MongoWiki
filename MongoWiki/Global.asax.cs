using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MongoWiki.Models;
using MongoWiki.Lib.Binders;

namespace MongoWiki
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "",
                new { controller = "Wiki", Action = "Index" }
                );

            routes.MapRoute(
                "Wiki",
                "wiki/{page}",
                new { controller = "Wiki", Action = "ViewPage", page = ""}
                );

            routes.MapRoute(
                "CreateWiki",
                "wiki/create/{page}",
                new { controller = "Wiki", Action = "CreatePage", page = "" }
                );

            routes.MapRoute(
                "EditWiki",
                "wiki/edit/{page}",
                new { controller = "Wiki", Action = "EditPage", page = "" }
                );

            
        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);

            ModelBinders.Binders[typeof(WikiPage)] = new WikiPageBinder();
        }
    }
}