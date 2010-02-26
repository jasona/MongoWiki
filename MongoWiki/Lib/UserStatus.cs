using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoWiki.Lib
{

    public enum UserStatus : int
    {
        Unapproved = 1,
        Active = 2,
        Disabled = 3,
        Deleted = 4
    }
}
