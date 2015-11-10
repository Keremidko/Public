using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Requirements_and_Design_environment.Controllers
{
    //TODO: Да се сложи eTag за кеширане на темплейтите
    public class TemplateController : Controller
    {
        [HttpGet]
        public PartialViewResult Get(string name)
        {
            return PartialView(String.Format("~/Views/Templates/{0}.cshtml", name));
        }

        [HttpGet]
        public PartialViewResult Modal(string name)
        {
            return PartialView(String.Format("~/Views/Templates/Modals/{0}.cshtml", name));
        }
    }
}