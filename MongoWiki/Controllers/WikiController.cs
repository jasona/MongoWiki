using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using NoRM;
using MongoWiki.Lib;
using MongoWiki.Lib.Entities;
using System.Text;

namespace MongoWiki.Controllers
{
    public class WikiController : Controller
    {

        public ActionResult Index()
        {
            return this.RedirectToAction("ViewPage", new { page = "home" });
        }

        public ActionResult ViewPage(string page)
        {
            page = Utility.ScrubPageUrl(page);

            MongoCollection<WikiPage> pages = new MongoServer().GetDatabase("MongoWiki").GetCollection<WikiPage>("WikiPage");

            WikiPage wikiPage = pages.FindOne(new { URL = page });


            // If the page isn't found, lets create it
            if (wikiPage == null)
                return this.RedirectToAction("CreatePage", new { page = page });
            else
            {
                // If the page is found, let's parse it for auto-links
                StringBuilder sb = new StringBuilder(wikiPage.Body);
                List<KeyValuePair<string,string>> links = Utility.ParseWordLinks(wikiPage.Body);

                foreach (KeyValuePair<string, string> link in links)
                {
                    string format = "<a href=\"/wiki/{0}\">{1}</a>";

                    // While parsing, let's see if the page exists already
                    WikiPage checkPage = pages.FindOne(new { URL = link.Value });

                    // If not, we'll format the link and point it at the create page
                    if (checkPage == null)
                        format = "<a href=\"/wiki/create/{0}\" class=\"newlink\" title=\"This page does not exist. Click here to create it!\"><font color=\"red\">{1}</font></a>";
                    else
                        format = "<a href=\"/wiki/{0}\" title=\"" + checkPage.Body.Substring(0, (checkPage.Body.Length >= 30 ? 30 : checkPage.Body.Length)) + "...\">{1}</a>";

                    sb.Replace(link.Key, string.Format(format, link.Value, link.Key));
                }

                // Converty crlf's to <br>'s
                sb.Replace("\n", "<br/>");

                // Set it back to the model
                wikiPage.Body = sb.ToString();   
   
                return View("ViewWikiPage", wikiPage);
            }
        }

        public ActionResult CreatePage(string page)
        {
            ViewData["page"] = page;

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
            page = Utility.ScrubPageUrl(page);

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
            pages.UpdateOne(new { URL = page.URL }, page);


            // Save the previous revision
            MongoCollection<WikiPageRevision> revs = new MongoServer().GetDatabase("MongoWiki").GetCollection<WikiPageRevision>("WikiPageRevision");
            WikiPageRevision rev = new WikiPageRevision(prevPage);
            rev.RevisionDate = DateTime.Now;
            revs.Insert(rev);

            return this.RedirectToAction("ViewPage", new { page = page.URL });
        }

    }
}
