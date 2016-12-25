using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Claims;
using System.Web.Mvc;
using WebLayer.Models;
using WebLayer.CustomLibraries;

namespace WebLayer.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        // GET: Auth
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(Users model)
        {
            if (!ModelState.IsValid) //Checks if input fields have the correct format
            {
                return View(model); //Returns the view with the input values so that the user doesn't have to retype again
            }
            using (var db = new MainDbContext())
            {
                var emailCheck = db.Users.FirstOrDefault(u => u.Email == model.Email);
                var getPassword = db.Users.Where(u => u.Email == model.Email).Select(u => u.Password);
                var materializePassword = getPassword.ToList();
                if (!materializePassword.Count.Equals(0))
                {
                    var password = materializePassword[0];
                    var decryptedPassword = CustomDecrypt.Decrypt(password);
                    if (model.Email != null && model.Password == decryptedPassword)
                    {
                        var getName = db.Users.Where(u => u.Email == model.Email).Select(u => u.Name);
                        var materializeName = getName.ToList();
                        var name = materializeName[0];

                        var getCity = db.Users.Where(u => u.Email == model.Email).Select(u => u.City);
                        var materializeCity = getCity.ToList();
                        var city = materializeCity[0];

                        var getEmail = db.Users.Where(u => u.Email == model.Email).Select(u => u.Email);
                        var materializeEmail = getEmail.ToList();
                        var email = materializeEmail[0];

                        var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, name),
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Country, city)
                    },
                            "ApplicationCookie");
                        var ctx = Request.GetOwinContext();
                        var authManager = ctx.Authentication;

                        authManager.SignIn(identity);

                        return RedirectToAction("Index", "Home");
                    }
                }
                

               
            }
            ModelState.AddModelError("", "Invalid email or password");
            return View(model); //Should always be  declared on the end of an action method. Laddar viewen Login med modelen som parameter
        }


        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Login", "Auth");
        }
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(Users model)
        {
            using (var db = new MainDbContext())
            {
                var queryUser = db.Users.FirstOrDefault(u => u.Email == model.Email);
                if (queryUser == null)
                {
                    var encryptedPassword = CustomEncrypt.Encrypt(model.Password);
                    var user = db.Users.Create();
                    user.Email = model.Email;
                    user.Password = encryptedPassword;
                    user.City = model.City;
                    user.Name = model.Name;
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                else
                {
                    return RedirectToAction("Registration");
                }
                return View();
            }
        }

    }
}

