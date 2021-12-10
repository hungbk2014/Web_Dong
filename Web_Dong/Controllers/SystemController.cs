using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_Dong.Controllers
{
    public class SystemController : Controller
    {
        // GET: System
        public ActionResult Index()
        {
            if (Session["loginsuccess"] == null)
            {
                return Redirect("/");
            }
            ViewBag.username = Session["loginsuccess"];
            return View();
        }
    }
}