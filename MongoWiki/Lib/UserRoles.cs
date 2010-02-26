using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoWiki.Lib
{
    public class UserRoles
    {
        public static readonly Permissions Administrator = Permissions.Manage | Permissions.Create | Permissions.Edit | Permissions.Read;
        public static readonly Permissions Editor = Permissions.Create | Permissions.Edit | Permissions.Read;
        public static readonly Permissions Reader = Permissions.Read;
        public static readonly Permissions Anonymous = Permissions.None;
    }
}
