using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoWiki.Lib
{
    [Flags]
    public enum Permissions : int
    {
        None = 1,
        Read = 2,
        Create = 4,
        Edit = 8,
        Manage = 16
    }
}
