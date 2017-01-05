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
            var id = User.Identity.Name;
            var db = new MainDbContext();
            var model = db.Users;

            var entityitem = db.Users.FirstOrDefault(s => s.Name == id);
            Users user = db.Users.Find(entityitem.UId);

            return View(entityitem);
        }
       [HttpPost]  
public ActionResult Index(HttpPostedFileBase file, Users user)  
{  

    if (file != null && file.ContentLength > 0)  
        try 
        {
                    var id = User.Identity.Name;
                    var db = new MainDbContext();
                    var entityitem = db.Users.FirstOrDefault(s => s.Name == id);
                    
            string path = Path.Combine(Server.MapPath("~/images/profile"),  
                                      id + "profilbild.jpg");
                    var filename = id + "profilbild.jpg";
                    entityitem.ImagePath = filename;
                    db.Entry(entityitem).State = EntityState.Modified;
                    db.SaveChanges();
            file.SaveAs(path);
                    Response.Redirect(Request.RawUrl);
                    ViewBag.Message = "File uploaded successfully";  
        }  
        catch (Exception ex)  
        {  
            ViewBag.Message = "ERROR:" + ex.Message.ToString();  
        }  
    else 
    {  
        ViewBag.Message = "You have not specified a file.";  
    }
            
            return View(user);
              
}
        
    }
}