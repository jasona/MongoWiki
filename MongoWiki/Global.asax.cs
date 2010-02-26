using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MongoWiki.Lib.Entities;
using MongoWiki.Lib.Binders;

namespace MongoWiki
{

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
                "WikiHome",
                "wiki/",
                new { controller = "Wiki", Action = "Index", page = "" }
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

            routes.MapRoute(
                "Account",
                "account/{action}",
                new { controller = "Account"}
                    );

            routes.MapRoute(
                "AdminIndex",
                "admin/",
                new { controller = "Admin", action = "Index" }
                    );

            routes.MapRoute(
                "Admin",
                "admin/{action}",
                new { controller = "Admin" }
                    );

            routes.MapRoute(
                "AdminAction",
                "admin/{action}/{key}",
                new { controller = "Admin" }
                    );
            
        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);

            ModelBinders.Binders[typeof(WikiPage)] = new WikiPageBinder();
            ModelBinders.Binders[typeof(User)] = new UserBinder();
        }
    }
}