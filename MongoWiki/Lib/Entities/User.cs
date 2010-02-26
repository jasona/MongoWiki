using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoWiki.Lib.Entities
{
    public class User
    {
        public User() { }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public int? Status { get; set; }
        public int? Role { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastLoginDate { get; set; }

    }
}
