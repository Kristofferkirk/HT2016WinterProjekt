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

        public ActionResult Profil(Users user)
        {
            var db = new MainDbContext();
            var id = User.Identity.Name;
            var currentUserDB = db.Users.FirstOrDefault(s => s.Name == id);
            var currentUserID = currentUserDB.UId;
            var entity = db.Users.FirstOrDefault(s => s.UId == user.UId);
            if (user.UId == currentUserID)
            {
                return View(user);
            }
            else
            {
                return View(entity);
            }


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
        public ActionResult FriendRequest()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FriendRequest(FriendRequests model)
        {

            if (ModelState.IsValid)
            {

            
                
                    var currentUserName = User.Identity.Name;
                    var db = new MainDbContext();
                    var newrequest = db.Requests.Create();
                    var id = "Kristoffer Kirkerud"; //Get current profile name here
                    var currentUserID = db.Users.FirstOrDefault(s => s.Name == currentUserName);
                    var entityitem = db.Users.FirstOrDefault(s => s.Name == id);

                    newrequest.Message = model.Message;
                    newrequest.UserId = currentUserID.UId;
                    newrequest.FutureFriendId = entityitem.UId;
                    
                    db.Requests.Add(newrequest);
                    db.SaveChanges();
                    
                    Response.Redirect(Request.RawUrl);
                    ViewBag.Message = "Friend Request Sent!";
                }
                
            else
            {
                Response.Redirect(Request.RawUrl);
                ViewBag.Message = "Something is terrible";

            }

            return View();

        }
        public ActionResult WallPost()
        {
            return View();
        }

    }
}