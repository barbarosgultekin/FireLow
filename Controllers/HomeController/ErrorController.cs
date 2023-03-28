using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FireLow.Views.Home
{
    public class ErrorController : Controller
    {
        [AllowAnonymous]
        public ActionResult Page404()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }
        [AllowAnonymous]
        public ActionResult Page500()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }
        public ActionResult PageNull()
        {           
            return View();
        }
    }
}
