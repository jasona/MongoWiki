using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoWiki.Models
{
    public class WikiPage
    {
        public WikiPage()
        {
        }

        public string ID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string CreateDate { get; set; }

    }
}
