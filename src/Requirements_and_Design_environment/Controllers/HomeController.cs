using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Requirements_and_Design_environment.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Default/
        public ActionResult Index()
        {
            string theme;
            if(Request.Cookies["theme"] != null)
                theme = Request.Cookies["theme"].Value;
            else 
                theme = "cerulean";
            ViewData["theme"] = theme;
            return View();
        }
	}
}