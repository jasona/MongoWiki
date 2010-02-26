using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoWiki.Lib.Entities
{
    public class WikiPageRevision : WikiPage
    {

        public WikiPageRevision() { }

        public WikiPageRevision(WikiPage page) 
            : base(page.ID, page.Title, page.URL, page.Body, page.CreateDate)
        {
        }

        public string RevisedId { get; set; }
        public DateTime RevisionDate { get; set; }

    }
}
