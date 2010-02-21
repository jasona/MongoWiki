using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoWiki.Models
{
    public class WikiPageRevision : WikiPage
    {

        public WikiPageRevision() { }

        public DateTime RevisionDate { get; set; }

    }
}
