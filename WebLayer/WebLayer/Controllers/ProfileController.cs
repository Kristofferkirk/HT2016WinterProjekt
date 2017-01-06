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
            

           var entityitem = db.Users.FirstOrDefault(s => s.Name == id);
           Users user = db.Users.Find(entityitem.UId);

            return View(user);
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
                    
            string path = Path.Combine(Server.MapPath("~/images/profile/"),  
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
                Response.Redirect(Request.RawUrl);
                ViewBag.Message = "You have not specified a file.";
                
            }
            
            return View(user);
              
        }
        public ActionResult ProfilePage(Users user2)
        {
            var id = user2.Name;
            var db = new MainDbContext();
            

            var entityitem = db.Users.FirstOrDefault(s => s.Name == id);
            Users user = db.Users.Find(entityitem.UId);

            return View("Admin1");
        }
        [HttpGet]
        public ActionResult MyAction(string search)
        {
            //do whatever you need with the parameter, 
            //like using it as parameter in Linq to Entities or Linq to Sql, etc. 
            //Suppose your search result will be put in variable "result".
            var searchName = search;
            var db = new MainDbContext();

            var entityitem = db.Users.FirstOrDefault(s => s.Name == searchName);
            Users user = db.Users.Find(entityitem.UId);
            ViewData.Model = user;
            return RedirectToAction("Profile", "Index", new { Id = user });
        }

    }
}