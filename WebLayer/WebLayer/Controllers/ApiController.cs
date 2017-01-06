using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebLayer.Controllers
{
    public class ApiController : Controller
    {
        // GET: Api
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getProfile(int Queryid)
        {
            Boolean succeded = true;
            if (succeded)
            {
                return Json(new
                {
                    Succeded = false, //sätt värden från profile modellen
                    Id = Queryid,
                    Name = "@nameval",
                    Age = "@ageval",
                    Etc = "etc etc"

                });
            }
            else
            {
                return Json(new
                {
                    succeded = false
                });

            }
        }
    }
}