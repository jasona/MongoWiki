using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace MongoWiki.Controllers
{
    public class WikiController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewPage(string page)
        {
            Response.Write("page: " + page);
            return View("Index");
        }

        public ActionResult CreatePage(string page)
        {
            Response.Write("CREATE PAGE: " + page);
            return View("Index");
        }

        public ActionResult EditPage(string page)
        {
            Response.Write("EDIT PAGE: " + page);
            return View("Index");
        }

    }
}
