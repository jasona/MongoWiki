﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoWiki.Lib.Entities;

namespace MongoWiki.Lib.Binders
{
    public class WikiPageBinder : IModelBinder
    {

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            DateTime createDate;
            WikiPage page = new WikiPage();


            page.ID = controllerContext.HttpContext.Request.Form["ID"];
            page.Title = controllerContext.HttpContext.Request.Form["Title"];
            page.URL = Utility.FormatForUrl(page.Title);
            page.Body = controllerContext.HttpContext.Request.Form["Body"];
            page.LastUpdateDate = DateTime.Now;

            if (DateTime.TryParse(controllerContext.HttpContext.Request.Form["CreateDate"], out createDate))
                page.CreateDate = createDate;
            else
                page.CreateDate = DateTime.Now;

            return page;
        }

    }
}
