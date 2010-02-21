using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MongoWiki.Lib;

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
            return View("Index");
        }

        public ActionResult CreatePage(string page)
        {
            return View("Index");
        }

        public ActionResult EditPage(string page)
        {
            return View("Index");
        }

    }
}
