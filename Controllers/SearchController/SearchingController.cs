using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FireLow.Controllers.SearchController
{
    public class SearchingController : Controller
    {
        FLEntities db = new FLEntities();

        public ActionResult Search(int jid)
        {
            try
            {
                var checklist = db.CHECKLISTs.Find(jid);

                ViewBag.JID = checklist.JID;
                ViewBag.WPLACE = checklist.WPLACE;
                ViewBag.ACTION = checklist.ACTION;
                ViewBag.CID = checklist.CID;

            }
            catch (Exception)
            {
                return RedirectToAction("PageNull", "Error");
                throw;
            }
            return View();
        }
    }
}