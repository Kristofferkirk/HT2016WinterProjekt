using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace WebLayer.App_Start
{
    //Using Microsofts Owin Packages as a middlelayer between web and application, Cookies for cookiebased authentication for login
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            /*CookieAuth = In a nutshell, it means you provide a word and set its value in which 
              this word will be used to bridge the communication of the app and server.
              */
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/auth/login")
            });
        }
    }
}