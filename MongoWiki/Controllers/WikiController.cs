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
            return this.RedirectToAction("ViewPage", new { page = "Home" });
        }

        public ActionResult ViewPage(string page)
        {
            MongoCollection<WikiPage> pages = new MongoServer().GetDatabase("MongoWiki").GetCollection<WikiPage>("WikiPage");

            WikiPage wikiPage = pages.FindOne(new { URL = page });


            // If the page isn't found, lets create it
            if (wikiPage == null)
                return this.RedirectToAction("CreatePage", new { page = page });
            else
                return View("ViewWikiPage", wikiPage);
        }

        public ActionResult CreatePage(string page)
        {
            return View("CreateWikiPage");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreatePage(WikiPage page)
        {
            MongoCollection<WikiPage> pages = new MongoServer().GetDatabase("MongoWiki").GetCollection<WikiPage>("WikiPage");

            pages.Insert(page);

            return this.RedirectToAction("ViewPage", new { page = page.URL });
        }

        public ActionResult EditPage(string page)
        {
            MongoCollection<WikiPage> pages = new MongoServer().GetDatabase("MongoWiki").GetCollection<WikiPage>("WikiPage");

            WikiPage wikiPage = pages.FindOne(new { URL = page });


            // If the page isn't found, lets create it
            if (wikiPage == null)
                return this.RedirectToAction("CreatePage", new { page = page });
            else
                return View("EditWikiPage", wikiPage);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditPage(WikiPage page)
        {
            MongoCollection<WikiPage> pages = new MongoServer().GetDatabase("MongoWiki").GetCollection<WikiPage>("WikiPage");

            // Get the previous version
            WikiPage prevPage = pages.FindOne(new { URL = page.URL });

            // Save the updateone
            pages.UpdateOne(page, page);

            // Save the previous revision
            MongoCollection<WikiPageRevision> revs = new MongoServer().GetDatabase("MongoWiki").GetCollection<WikiPageRevision>("WikiPageRevision");
            WikiPageRevision rev = new WikiPageRevision(prevPage);
            rev.RevisionDate = DateTime.Now;
            revs.Insert(rev);

            return this.RedirectToAction("ViewPage", new { page = page.URL });
        }

    }
}
