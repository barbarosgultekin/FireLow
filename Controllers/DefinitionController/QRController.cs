using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using System.Drawing.Imaging;

namespace FireLow.Controllers
{
    public class QRController : Controller
    {
        FLEntities db = new FLEntities();
        public ActionResult QRTAG()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult QRVIEW(Int32 id)
        {
            PRODUCT _proc;

            ViewBag.id = id;




            if (id != 0)
            {
                try
                {
                    _proc = db.PRODUCTs.Find(id);

                    ViewBag.TAREA = _proc.TAREA;
                    ViewBag.TCUSTOMER = _proc.TCUSTOMER;
                    ViewBag.CID = _proc.CID;
                    ViewBag.SERIAL = _proc.SERIAL;
                    ViewBag.PTYPE = _proc.PTYPE;
                    ViewBag.FIRSTFILLING = _proc.FIRSTFILLING;
                    ViewBag.NEXTFILLING = _proc.NEXTFILLING;
                    ViewBag.TPERIOD = _proc.TPERIOD;
                    ViewBag.INFO = _proc.INFO;
                    ViewBag.ID = _proc.ID;

                }
                catch (Exception)
                {
                    return RedirectToAction("ERRPage", "Error");
                    throw;
                }
            }
            else
            {
                return RedirectToAction("ERRPage", "Error");
            }

            return View(_proc);
        }
    }
}