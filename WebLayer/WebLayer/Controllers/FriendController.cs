﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLayer.Models;

namespace WebLayer.Controllers
{
    public class FriendController : Controller
    {
        // GET: Friend
        public ActionResult Index()
        {
           
            
            return View();
        }

        public ActionResult Requests(FriendRequests request)
        {
            var db = new MainDbContext();
            var id = User.Identity.Name;
            var user = db.Users.FirstOrDefault(s => s.Name == id);
            var currentRequests = db.Requests.FirstOrDefault(s => s.FutureFriendId == user.UId);
            if (currentRequests.FRId.Equals(null))
            {
                ViewBag.Message = "Du har inga vänförfrågningar";
                return View();
               
            }
            else {
                ViewBag.Message = "Du har vänförfrågningar!";
                return View(currentRequests);

            }
            
        }
        public void DenyFriendRequest()
        {
            // struktur ska fixas
            var currentUserName = User.Identity.Name;
            var db = new MainDbContext();
            var user = db.Users.FirstOrDefault(s => s.Name == currentUserName);
            var request = db.Requests.FirstOrDefault(s => s.FutureFriendId == user.UId);
            if(request != null)
            {
                db.Requests.Remove(request);
                db.SaveChanges();
                RedirectToAction("Index");
            }
            else
            {
                

            }



        }
        public void AcceptFriendRequest()
        {
            //struktur ska fixas
            var currentUserName = User.Identity.Name;
            var db = new MainDbContext();
            var friend = db.Friend.Create();
            var user = db.Users.FirstOrDefault(s => s.Name == currentUserName);
            
            var request = db.Requests.FirstOrDefault(s => s.FutureFriendId == user.UId);
            
            if (request != null)
            {
                var friendName = db.Users.FirstOrDefault(s => s.UId == request.UserId);
                
                friend.User1 = user.UId;
                friend.User2 = friendName.UId;
                
                db.Friend.Add(friend);
                db.Requests.Remove(request);
                db.SaveChanges();
                
            }
            else
            {


            }



        }
    }
}