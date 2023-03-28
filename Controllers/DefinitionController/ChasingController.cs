using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FireLow.Controllers.DefinitionController
{
    public class ChasingController : Controller
    {
        // GET: Chasing
        FLEntities db = new FLEntities();

        public ActionResult ChasingTubeTable()
        {
            if (Session["User"] == null)
                return RedirectToAction("Login");

            var customer = db.CUSTOMERs.ToList();
            var tube = db.PRODUCTs.ToList();           

            string dnow = DateTime.Now.Date.ToString();
           

            foreach (var item in tube)
            {                
                if (item.NEXTFILLING.ToString() == dnow)
                {                   
                    item.FILL = 0;
                    item.CARE = 0;

                    db.SaveChangesAsync();
                  
                }
                
            }

            return View(Tuple.Create(customer, tube));

        }

        public ActionResult ChasingTubeSave(Int32 ID)
        {
            if (Session["User"] == null)
                return RedirectToAction("Login");

            PRODUCT _product = new PRODUCT();
            CUSTOMER _customer = new CUSTOMER();
            DateTime tarih;

            if (ID != 0)
            {
                _product = db.PRODUCTs.Where(x => x.ID == ID).SingleOrDefault();

                _product.SERIAL = Request.Form["SERIAL"];
                _product.FIRSTFILLING = Convert.ToDateTime(Request.Form["FIRSTFILLING"]);
                _product.TPERIOD = Convert.ToInt32(Request.Form["TPERIOD"]);
                _product.FILL = 1;
                _product.FILLDATE = DateTime.Now;

                tarih = Convert.ToDateTime(_product.FIRSTFILLING);

                switch (_product.TPERIOD)
                {

                    case 2:
                        tarih = tarih.AddDays(7);
                        break;

                    case 1:
                        tarih = tarih.AddMonths(1);
                        break;

                    case 4:
                        tarih = tarih.AddYears(1);
                        break;
                    case 3:
                        tarih = tarih.AddMonths(6);
                        break;
                    case 5:
                        tarih = tarih.AddYears(5);
                        break;

                    default:
                        break;
                }

                _product.NEXTFILLING = tarih;

                db.SaveChangesAsync();
                return RedirectToAction("ChasingTubeTable", "Chasing");

            }

            return RedirectToAction("ChasingTubeTable", "Chasing");
        }


        public ActionResult ChasingTubeDetail(Int32 ID)
        {
            if (Session["User"] == null)
                return RedirectToAction("Login");


            var model = db.PRODUCTs.ToList();
            PRODUCT _product;

            ViewBag.id = ID;

            if (ID != 0)
            {
                _product = db.PRODUCTs.Find(ID);

                ViewBag.FIRSTFILLING = _product.FIRSTFILLING;
                ViewBag.SERIAL = _product.SERIAL;
                ViewBag.TPERIOD = _product.TPERIOD;
                ViewBag.TCUSTOMER = _product.TCUSTOMER;
            }

            return View(model);

        }


        public ActionResult ChasingPeriodicTable()
        {
            if (Session["User"] == null)
                return RedirectToAction("Login");

            var customer = db.CUSTOMERs.ToList();
            var tube = db.PRODUCTs.ToList();

            string dnow = DateTime.Now.Date.ToString();

            foreach (var item in tube)
            {
                if (item.NEXTFILLING.ToString() == dnow)
                {
                    item.FILL = 0;
                    item.CARE = 0;

                    db.SaveChangesAsync();

                }

            }

            return View(Tuple.Create(customer, tube));
        }

        public ActionResult ChasingPeriodicDetail(Int32 id)
        {
            if (Session["User"] == null)
                return RedirectToAction("Login");

            CUSTOMER _customer = new CUSTOMER();
            PRODUCT _product = new PRODUCT();

            var customer = db.CUSTOMERs.ToList();
            var product = db.PRODUCTs.ToList();

            _product = db.PRODUCTs.Find(id);

            int cust = 0;
            cust = Convert.ToInt32(_product.CID);

            _customer = db.CUSTOMERs.Find(cust);
            

            if (id != 0)
            {
                ViewBag.APPELLATION = _customer.APPELLATION;
                ViewBag.SERIAL = _product.SERIAL;
                ViewBag.ID = id;                
            }

            return View(customer);
        }


        public ActionResult ChasingPeriodicSave()
        {
            if (Session["User"] == null)
                return RedirectToAction("Login");

            if (Request.Form.Count > 0)
            {

                PRODUCT pro = new PRODUCT();
                CHECKLIST check = new CHECKLIST();

                var checklist = db.CHECKLISTs.ToList();
                var product = db.CHECKLISTs.ToList();
                DateTime tarih;


                int JID = Convert.ToInt32(Request.Form["JID"]);

                if (JID != 0)
                {

                    check.CID = ViewBag.CID;
                    check.PID = ViewBag.ID;
                    check.SSTATUS = Request.Form["SSTATUS"];
                    check.VNU = Request.Form["VNU"];
                    check.SNU = Request.Form["SNU"];
                    check.ACTION = Request.Form["ACTION"];
                    check.WPLACE = Request.Form["WPLACE"];
                    check.WDATE = Convert.ToDateTime(Request.Form["WDATE"]);
                    check.JDESC = Request.Form["JDESC"];
                    check.PRESSURE = Request.Form["PRESSURE"];
                    check.SEAL = Request.Form["SEAL"];
                    check.SVALVE = Request.Form["SVALVE"];
                    check.MANOMETER = Request.Form["MANOMETER"];
                    check.VALVE = Request.Form["VALVE"];
                    check.FUNCTIONALITY = Request.Form["FUNCTIONALITY"];
                    check.RESET = Request.Form["RESET"];
                    check.EPUNCH = Request.Form["EPUNCH"];
                    check.MEMBRANE = Request.Form["MEMBRANE"];
                    check.PCHANGE = Request.Form["PCHANGE"];
                    check.PCONTROL = Request.Form["PCONTROL"];
                    check.DAMAGE = Request.Form["DAMAGE"];
                    check.SIGNAL = Request.Form["SIGNAL"];
                    check.PROTECT = Request.Form["PROTECT"];
                    check.FNEEDLE = Request.Form["FNEEDLE"];

                    pro = db.PRODUCTs.Where(x => x.ID == check.PID).FirstOrDefault();
                    pro.FIRSTFILLING = Convert.ToDateTime(Request.Form["FIRSTFILLING"]);

                    tarih = Convert.ToDateTime(pro.FIRSTFILLING);

                    switch (pro.TPERIOD)
                    {

                        case 2:
                            tarih = tarih.AddDays(7);
                            break;

                        case 1:
                            tarih = tarih.AddMonths(1);
                            break;

                        case 4:
                            tarih = tarih.AddYears(1);
                            break;
                        case 3:
                            tarih = tarih.AddMonths(6);
                            break;
                        case 5:
                            tarih = tarih.AddYears(5);
                            break;

                        default:
                            break;
                    }

                    pro.NEXTFILLING = tarih;

                  
                    pro.CARE = 1;

                    db.SaveChangesAsync();
                    return RedirectToAction("ChasingPeriodicTable", "Chasing");

                }



                check.SSTATUS = Request.Form["SSTATUS"];
                check.VNU = Request.Form["VNU"];
                check.SNU = Request.Form["SNU"];

                pro = db.PRODUCTs.Where(x => x.SERIAL == check.SNU).FirstOrDefault();
                check.CID = Convert.ToInt32(pro.CID);
                check.PID = pro.ID;

                check.ACTION = Request.Form["ACTION"];
                check.WPLACE = Request.Form["WPLACE"];
                check.WDATE = Convert.ToDateTime(Request.Form["WDATE"]);
                check.JDESC = Request.Form["JDESC"];
                check.PRESSURE = Request.Form["PRESSURE"] ?? "NOT";
                check.SEAL = Request.Form["SEAL"] ?? "NOT";
                check.SVALVE = Request.Form["SVALVE"] ?? "NOT";
                check.MANOMETER = Request.Form["MANOMETER"] ?? "NOT";
                check.VALVE = Request.Form["VALVE"] ?? "NOT";
                check.FUNCTIONALITY = Request.Form["FUNCTIONALITY"] ?? "NOT";
                check.RESET = Request.Form["RESET"] ?? "NOT";
                check.EPUNCH = Request.Form["EPUNCH"] ?? "NOT";
                check.MEMBRANE = Request.Form["MEMBRANE"] ?? "NOT";
                check.PCHANGE = Request.Form["PCHANGE"] ?? "NOT";
                check.PCONTROL = Request.Form["PCONTROL"] ?? "NOT";
                check.DAMAGE = Request.Form["DAMAGE"] ?? "NOT";
                check.SIGNAL = Request.Form["SIGNAL"] ?? "NOT";
                check.PROTECT = Request.Form["PROTECT"] ?? "NOT";
                check.FNEEDLE = Request.Form["FNEEDLE"] ?? "NOT";

                pro.FIRSTFILLING = Convert.ToDateTime(Request.Form["WDATE"]);

                tarih = Convert.ToDateTime(pro.FIRSTFILLING);

                switch (pro.TPERIOD)
                {

                    case 2:
                        tarih = tarih.AddDays(7);
                        break;

                    case 1:
                        tarih = tarih.AddMonths(1);
                        break;

                    case 4:
                        tarih = tarih.AddYears(1);
                        break;
                    case 3:
                        tarih = tarih.AddMonths(6);
                        break;
                    case 5:
                        tarih = tarih.AddYears(5);
                        break;

                    default:
                        break;
                }

                pro.NEXTFILLING = tarih;

                if (JID == 0)
                {

                    db.CHECKLISTs.Add(check);
                    db.SaveChanges();
                }

                pro = db.PRODUCTs.Where(x => x.ID == check.PID).FirstOrDefault();
                pro.CARE = 1;
                db.SaveChangesAsync();

            }

            return RedirectToAction("ChasingPeriodicTable", "Chasing");
        }

        public ActionResult ChasingPeriodicList(Int32 id)
        {
            if (Session["User"] == null)
                return RedirectToAction("Login");

            CHECKLIST check = new CHECKLIST();
            var _check = db.CHECKLISTs.ToList();
            PRODUCT proc = new PRODUCT();
            proc = db.PRODUCTs.Find(id);

            if (proc.CARE == 0)
            {
                return RedirectToAction("ChasingPeriodicTable", "Chasing");
            }

            if (id != 0)
            {
                try
                {


                    check = db.CHECKLISTs.Where(x => x.PID == id).FirstOrDefault();
                    ViewBag.TCUSTOMER = proc.TCUSTOMER;
                    ViewBag.PTYPE = proc.PTYPE;
                    ViewBag.PID = check.PID;
                    ViewBag.JID = check.JID;
                    ViewBag.CID = check.CID;
                    ViewBag.SSTATUS = check.SSTATUS;
                    ViewBag.VNU = check.VNU;
                    ViewBag.SNU = check.SNU;
                    ViewBag.ACTION = check.ACTION;
                    ViewBag.WPLACE = check.WPLACE;
                    ViewBag.WDATE = check.WDATE;
                    ViewBag.JDESC = check.JDESC;
                    ViewBag.PRESSURE = check.PRESSURE;
                    ViewBag.SEAL = check.SEAL;
                    ViewBag.SVALVE = check.SVALVE;
                    ViewBag.MANOMETER = check.MANOMETER;
                    ViewBag.VALVE = check.VALVE;
                    ViewBag.FUNCTIONALITY = check.FUNCTIONALITY;
                    ViewBag.RESET = check.RESET;
                    ViewBag.EPUNCH = check.EPUNCH;
                    ViewBag.MEMBRANE = check.MEMBRANE;
                    ViewBag.PCHANGE = check.PCHANGE;
                    ViewBag.PCONTROL = check.PCONTROL;
                    ViewBag.DAMAGE = check.DAMAGE;
                    ViewBag.SIGNAL = check.SIGNAL;
                    ViewBag.PROTECT = check.PROTECT;
                    ViewBag.FNEEDLE = check.FNEEDLE;

                }
                catch (Exception)
                {
                    return RedirectToAction("PageNull", "Error");
                    throw;
                }
            }
            else
            {
                return RedirectToAction("ChasingPeriodicTable", "Chasing");
            }


            return View(_check);

        }


    }
}