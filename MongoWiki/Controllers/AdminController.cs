using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MongoWiki.Lib.Entities;
using NoRM;

namespace MongoWiki.Controllers
{
    public class AdminController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditUser(string key)
        {
            MongoCollection<User> userColl = new MongoServer().GetDatabase("MongoWiki").GetCollection<User>("User");

            User user = userColl.FindOne(new { UserName = key });

            return View("EditUser", user);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditUser(User user)
        {
            MongoCollection<User> userColl = new MongoServer().GetDatabase("MongoWiki").GetCollection<User>("User");

            userColl.UpdateOne(new { UserName = user.UserName }, user);

            return RedirectToAction("UserList");
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateUser(User user)
        {
            MongoCollection<User> userColl = new MongoServer().GetDatabase("MongoWiki").GetCollection<User>("User");

            userColl.Insert(user);

            return RedirectToAction("UserList");
        }

        public ActionResult UserList()
        {
            MongoCollection<User> userColl = new MongoServer().GetDatabase("MongoWiki").GetCollection<User>("User");

            var users = userColl.Find();
            
            return View("UserList", users);
        }
    }
}
