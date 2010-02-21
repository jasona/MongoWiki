using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using NoRM;
using MongoWiki.Lib;
using MongoWiki.Models;

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
            MongoDatabase db = new MongoServer().GetDatabase("MongoWiki");

            WikiPage wikiPage = db.GetCollection<WikiPage>("WikiPage").FindOne(new { URL = page });


            // If the page isn't found, lets create it
            if (wikiPage == null)
                return new RedirectResult("/wiki/create/" + page);
            else
                return View("ViewWikiPage", wikiPage);
        }

        public ActionResult CreatePage(string page)
        {
            return View("CreateWikiPage");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public RedirectResult CreatePage(WikiPage page)
        {
            MongoDatabase db = new MongoServer().GetDatabase("MongoWiki");

            db.GetCollection<WikiPage>("WikiPage").Insert(page);

            return new RedirectResult("/wiki/" + page.URL);
        }

        public ActionResult EditPage(string page)
        {
            return View("Index");
        }

    }
}
