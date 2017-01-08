using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLayer.Models;

namespace WebLayer.Controllers
{
    public class FriendRequestController : Controller
    {
        // GET: FriendRequest
        public ActionResult Index()
        {
            return View();
        }

        // GET: FriendRequest/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FriendRequest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FriendRequest/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FriendRequest/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FriendRequest/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FriendRequest/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FriendRequest/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Index(FriendRequests request, Users user)
        {

            if (ModelState.IsValid)
                try
                {
                    var currentUserName = User.Identity.Name;
                    var db = new MainDbContext();
                    var newrequest = db.Requests.Create();
                    var id = "Kristoffer Kirkerud"; //Get current profile name here
                    var currentUserID = db.Users.FirstOrDefault(s => s.Name == currentUserName);
                    var entityitem = db.Users.FirstOrDefault(s => s.Name == id);


                    newrequest.UserId = currentUserID.UId;
                    newrequest.FutureFriendId = entityitem.UId;
                    db.Entry(entityitem).State = EntityState.Modified;
                    db.Requests.Add(newrequest);
                    db.SaveChanges();

                    Response.Redirect(Request.RawUrl);
                    ViewBag.Message = "Friend Request Sent!";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                Response.Redirect(Request.RawUrl);
                ViewBag.Message = "Something is terrible";

            }

            return View();

        }
    }
}
