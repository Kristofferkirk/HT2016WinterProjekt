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
            try {

                //To find other users type /profile/profil/id to find them (under construction....)
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
            catch(NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index", "Profile");
            }
        }

        public ActionResult Edit()
        {
            /// under construction
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Users user)
        {
            /// under construction
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
    
        
        public ActionResult WallPost()
        {
            /// under construction
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
                /// under construction
            }



        }

    }
}