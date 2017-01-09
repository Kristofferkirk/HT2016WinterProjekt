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
            var currentUserDB = db.Users.FirstOrDefault(s => s.Name == id);
            var currentUserID = currentUserDB.UId;
            Users user = db.Users.Find(currentUserID);

            return View(user);
        }

        public ActionResult Profil(int id)
        {
            var db = new MainDbContext();
            var currentUserName = User.Identity.Name;
            var currentUserDB = db.Users.FirstOrDefault(s => s.Name == currentUserName);
            var currentUserID = currentUserDB.UId;
            var entity = db.Users.FirstOrDefault(s => s.UId == id);
            if (entity.UId == currentUserID)
            {
                return RedirectToAction("Index", "Profile");
            }
            else
            {
                return View(entity);
            }


        }

        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Users user)
        {
            var db = new MainDbContext();
            var id = User.Identity.Name;
            var currentUserDB = db.Users.FirstOrDefault(s => s.Name == id);
           
                currentUserDB.Age = user.Age;
            
            
                currentUserDB.City = user.City;
            
            
                currentUserDB.Country = user.Country;
            
            
                currentUserDB.Email = user.Email;
            
            
                currentUserDB.Name = user.Name;
            
                        
            db.Entry(currentUserDB).State = EntityState.Modified;
            db.SaveChanges();
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
        public ActionResult FriendRequest()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FriendRequest(FriendRequests model, Users user)
        {

           

            
                
                    var currentUserName = User.Identity.Name;
                    var db = new MainDbContext();
                    var newrequest = db.Requests.Create();
                    var id = model.FutureFriendId; //Get current profile name here
                    var currentUserID = db.Users.FirstOrDefault(s => s.Name == currentUserName);
                    var entityitem = db.Users.FirstOrDefault(s => s.UId == id);

                    newrequest.Message = model.Message;
                    newrequest.UserId = currentUserID.UId;
                    newrequest.FutureFriendId = entityitem.UId;
                    
                    db.Requests.Add(newrequest);
                    db.SaveChanges();
                    
                    Response.Redirect(Request.RawUrl);
                    ViewBag.Message = "Friend Request Sent!";
               
          

            return View();

        }
        public ActionResult WallPost()
        {
            return View();
        }
        public void SendFriendRequest(int userID)
        {
            try {
                var currentUserName = User.Identity.Name;
                var db = new MainDbContext();
                var newrequest = db.Requests.Create();
                var requestUserID = db.Users.FirstOrDefault(s => s.UId == userID);
                var currentUserID = db.Users.FirstOrDefault(s => s.Name == currentUserName);
                var findRequest1 = db.Requests.Find(requestUserID.UId);
                var findRequest2 = db.Requests.Find(currentUserID.UId);

                newrequest.Message = "Vill du bli min vän?";
                newrequest.UserId = currentUserID.UId;
                newrequest.FutureFriendId = requestUserID.UId;
                db.Requests.Add(newrequest);
                db.SaveChanges();
                RedirectToAction("Index", "Profile");



                ViewBag.Message = "Friend Request Sent!";
            }
            catch(NullReferenceException ex)
            {

            }



        }

    }
}