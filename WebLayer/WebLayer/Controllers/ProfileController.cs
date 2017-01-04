using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLayer.Models;

namespace WebLayer.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            ViewData.Model = new Users();
            return View();
        }
        [HttpPost]
        public ActionResult Upload()
        {
            var db = new MainDbContext();
            string directory = Server.MapPath("~/UserPhotos");
            Users user = new Users();
            HttpPostedFileBase photo = Request.Files["photo"];

            if (photo != null && photo.ContentLength > 0)
            {
                var fileName = Path.GetFileName(photo.FileName);
                photo.SaveAs(Path.Combine(directory, "profile.jpg"));
                
               
            }

            return RedirectToAction("Index");
        }
    }
}