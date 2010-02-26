using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoWiki.Lib.Entities;

namespace MongoWiki.Lib.Binders
{
    public class UserBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            User user = new User();
            int status = 1;
            int role = 1;
            DateTime createDate;
            DateTime lastLoginDate;

            user.FirstName = controllerContext.HttpContext.Request.Form["FirstName"];
            user.LastName = controllerContext.HttpContext.Request.Form["LastName"];
            user.UserName = controllerContext.HttpContext.Request.Form["UserName"];
            user.EmailAddress = controllerContext.HttpContext.Request.Form["EmailAddress"];
            user.Password = controllerContext.HttpContext.Request.Form["Password"];
            
            if (int.TryParse(controllerContext.HttpContext.Request.Form["Status"], out status))
                user.Status = status;

            if (int.TryParse(controllerContext.HttpContext.Request.Form["Role"], out role))
                user.Role = role;

            if (DateTime.TryParse(controllerContext.HttpContext.Request.Form["CreateDate"], out createDate))
                user.CreateDate = createDate;
            else
                user.CreateDate = DateTime.Now;

            if (DateTime.TryParse(controllerContext.HttpContext.Request.Form["LastLoginDate"], out lastLoginDate))
                user.LastLoginDate = lastLoginDate;

            return user;
        }
    }
}
