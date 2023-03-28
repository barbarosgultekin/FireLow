using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FireLow.Controllers.ReportController
{
    public class ReportingController : Controller
    {
        FLEntities db = new FLEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReportDate()
        {

            return View();
        }

        public ActionResult Report()
        {
            if (Request.Form.Count > 0)
            {
                try
                {


                    DateTime from = Convert.ToDateTime(Request.Form["from"]);
                    DateTime to = Convert.ToDateTime(Request.Form["to"]);
                    String RType = Request.Form["RTYPE"];
                    ViewBag.rtype = RType;
                    ViewBag.from = from;
                    ViewBag.to = to;                   

                    switch (RType)
                    {
                        case "MANOMETER":
                            var a = db.sp_cmanoreport(from, to).ToList();
                            return View(a);

                        case "PCHANGE":
                            var b = db.sp_cpressreport(from, to).ToList();
                            return View(b);

                        case "FILL":
                            var c = db.sp_fillreport(from, to).ToList();
                            return View(c);

                        case "CARE":
                            var d = db.sp_carereport(from, to).ToList();
                            return View(d);

                        case "MEMBRANE":
                            var e = db.sp_cmemreport(from, to).ToList();
                            return View(e);
                    }
                }
                catch (Exception)
                {
                    return RedirectToAction("PageNull", "Error");
                    throw;
                }
            }
            return View();
        }
    }
}