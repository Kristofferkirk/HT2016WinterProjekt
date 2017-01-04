﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebLayer.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }
       [HttpPost]  
public ActionResult Index(HttpPostedFileBase file)  
{  
    if (file != null && file.ContentLength > 0)  
        try 
        {  
            string path = Path.Combine(Server.MapPath("~/images/profile"),  
                                      "profile.jpg");  
            file.SaveAs(path);  
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
    return View();  
}
    }
}