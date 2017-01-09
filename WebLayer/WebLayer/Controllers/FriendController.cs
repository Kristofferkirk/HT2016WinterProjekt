using System;
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

            MainDbContext db = new MainDbContext();
            var id = User.Identity.Name;
            var currentUser = db.Users.FirstOrDefault(s => s.Name == id);
            var currentUserId = db.Users.Find(currentUser.UId);
            
            List<FriendList> model = new List<FriendList>();
            
            var innerJoinQueryUser2 = (from user in db.Users
                                  join friend in db.Friend
                                  on user.UId equals friend.User1

                                  select new
                                  {
                                      user1Name = friend.Name1,
                                      user2Name = friend.Name2,
                                      user1ID = friend.User1,
                                      user2ID = friend.User2

                                  }).ToList();
            
            foreach (var item in innerJoinQueryUser2)
            {
                if (item.user1ID == currentUserId.UId|| item.user2ID == currentUserId.UId)
                {
                    if(item.user1Name != currentUserId.Name && item.user1ID != currentUser.UId)
                    {
                        model.Add(new FriendList()
                        {

                            Name1 = item.user1Name
                        });
                    }
                    if(item.user2Name != currentUserId.Name && item.user2ID != currentUser.UId)
                    {
                        model.Add(new FriendList()
                        {

                            Name1 = item.user2Name
                        });

                    }
                    
                }

            }
            return View(model);
        }

        public ActionResult Requests(FriendRequests request)
        { ///hahaha komment
            try {
                var db = new MainDbContext();
                var id = User.Identity.Name;
                // request.UserId.Equals(user.UId)
                var user = db.Users.FirstOrDefault(s => s.Name == id);
                request = db.Requests.FirstOrDefault(s => s.FutureFriendId == user.UId);
                var searchforUser = db.Requests.Find(user.UId);
                var currentRequests = db.Requests.FirstOrDefault(s => s.FutureFriendId == user.UId);
                if (request.FutureFriendId == user.UId)
                {
                    ViewBag.Message = "Du har vänförfrågningar!";
                    return View();
                }
                return View();

            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
                ViewBag.Message = "Du har inga vänförfrågningar";
                return View();
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
                friend.Name1 = user.Name;
                friend.Name2 = friendName.Name;
                db.Friend.Add(friend);
                db.Requests.Remove(request);
                db.SaveChanges();
                RedirectToAction("Index");

            }
            else
            {


            }



        }
    }
}