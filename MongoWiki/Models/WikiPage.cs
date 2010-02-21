using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoWiki.Models
{
    public class WikiPage
    {
        public WikiPage() { }
        public WikiPage(string id, string title, string url, string body, DateTime? createDate)
        {
            this.ID = id;
            this.Title = title;
            this.URL = url;
            this.Body = body;
            this.CreateDate = createDate;
        }

        public string ID { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public string Body { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }

    }
}
