using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebLayer.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index(string id)
        {
            MainDbContext db = new MainDbContext();
            string searchString = id;
            var users = from m in db.Users
                        select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.Name.Contains(searchString));
            }

            return View(users);
        }

    }
}