using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoWiki.Lib.Entities
{
    public class Account
    {
        public Account() { }

        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Subdomain { get; set; }
        public int? Status { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
