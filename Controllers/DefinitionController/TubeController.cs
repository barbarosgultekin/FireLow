using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FireLow.Controllers.Definition
{
   
    public class TubeController : Controller
    {
        FLEntities db = new FLEntities();
        // GET: TubeDefinition

        public ActionResult TubeDefinition()
        {
            var customer = db.CUSTOMERs.ToList();
            var tube = db.PRODUCTs.ToList();

            return View(Tuple.Create(customer, tube));
        }

        public ActionResult TubeDelete(Int32 ID)
        {
            if (Session["User"] == null)
                return RedirectToAction("Login");

            PRODUCT _pruduct = new PRODUCT();

            if (ID != 0)
            {
                _pruduct = db.PRODUCTs.Where(x => x.ID == ID).SingleOrDefault();

                _pruduct.TSTATUS = 1;

                //db.PRODUCTs.Remove(_tube);

                db.SaveChangesAsync();
                return RedirectToAction("TubeTable", "Tube");

            }


            return RedirectToAction("TubeTable", "Tube");


        }

        public ActionResult TubeSave(Int32 ID)
        {
            if (Session["User"] == null)
                return RedirectToAction("Login");

            PRODUCT _product = new PRODUCT();
            CUSTOMER _customer = new CUSTOMER();

            DateTime tarih;

            if (ID != 0)
            {
                _product = db.PRODUCTs.Where(x => x.ID == ID).SingleOrDefault();
                
                _product.PTYPE = Request.Form["PTYPE"];
                _product.SERIAL = Request.Form["SERIAL"];
                _product.CAPACITY = Request.Form["CAPACITY"];
                _product.DETAIL = Request.Form["DETAIL"];
                _product.TCONTENT = Request.Form["TCONTENT"];
                _product.TCUSTOMER = Request.Form["TCUSTOMER"];
                _product.TAREA = Request.Form["TAREA"];
                _product.PTYPE = Request.Form["PTYPE"];
                _product.LOCATION = Request.Form["LOCATION"];
                _product.FIRSTFILLING = Convert.ToDateTime(Request.Form["FIRSTFILLING"]);
                _product.PCLASS = Request.Form["PCLASS"];
                _product.TPERIOD = Convert.ToInt32(Request.Form["TPERIOD"]);
                _product.MANUFACTURER = Request.Form["MANUFACTURER"];


                if (Request.Form["TSTATUS"] == "OK")
                {
                    ViewBag.TSTATUS = _product.TSTATUS;
                    _product.TSTATUS = 0;
                }
                else
                {
                    ViewBag.TSTATUS = _product.TSTATUS;
                    _product.TSTATUS = 1;
                }

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

                //db.TUBEs.Remove(_tube);

                db.SaveChangesAsync();
                return RedirectToAction("TubeTable", "Tube");

            }

            _product.PCLASS = Request.Form["PCLASS"];
            _product.LOCATION = Request.Form["LOCATION"];
            _product.SERIAL = Request.Form["TSERIAL"];
            _product.CAPACITY = Request.Form["CAPACITY"];
            _product.DETAIL = Request.Form["DETAIL"];
            _product.MANUFACTURER = Request.Form["MANUFACTURER"];
            _product.FIRSTFILLING = Convert.ToDateTime(Request.Form["FIRSTFILLING"]);
            _product.TCONTENT = Request.Form["TCONTENT"];
            _product.TPERIOD = Convert.ToInt32(Request.Form["TPERIOD"]);
            _product.TSTATUS = Convert.ToInt32(Request.Form["TSTATUS"]);
            _product.TCUSTOMER = Request.Form["TCUSTOMER"];
            _product.TAREA = Request.Form["TAREA"];
            _product.PTYPE = Request.Form["PTYPE"];
            _product.PCLASS = Request.Form["PCLASS"];


            string APPELLATION = "";
            APPELLATION = _product.TCUSTOMER;
            _customer = db.CUSTOMERs.Where(x => x.APPELLATION == APPELLATION).SingleOrDefault();
            _product.CID = _customer.REFID;

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
            _product.FILL = 0;
            _product.FILLDATE = Convert.ToDateTime("01-01-0001 00:00:00");
            _product.CARE = 0;

            if (ID == 0)
            {

                db.PRODUCTs.Add(_product);
                db.SaveChangesAsync();

            }

            return RedirectToAction("TubeTable", "Tube");

        }

        public ActionResult TubeTable()
        {
            var model = db.PRODUCTs.ToList();

            return View(model);
        }

        public ActionResult Notification(Int32 ID)
        {
            PRODUCT _tube = new PRODUCT();

            _tube = db.PRODUCTs.Where(x => x.ID == ID).SingleOrDefault();

            //_tube.TSERIAL = ViewBag.TSERIAL;
            ViewBag.TSERIAL = _tube.SERIAL;
            ViewBag.ID = ID;

            return View();
        }

        public ActionResult TubeEdit(Int32 id)
        {

            var product = db.PRODUCTs.ToList();
            PRODUCT _product;
            var customer = db.CUSTOMERs.ToList();
            CUSTOMER _customer;

            if (id != 0)
            {
                _product = db.PRODUCTs.Find(id);

                ViewBag.REFID = _product.ID;
                ViewBag.PTYPE = _product.PTYPE;
                ViewBag.SERIAL = _product.SERIAL;
                ViewBag.DETAIL = _product.DETAIL;
                ViewBag.MANUFACTURER = _product.MANUFACTURER;
                ViewBag.TCONTENT = _product.TCONTENT;
                ViewBag.TCUSTOMER = _product.TCUSTOMER;
                ViewBag.TAREA = _product.TAREA;
                ViewBag.LOCATION = _product.LOCATION;
                ViewBag.FIRSTFILLING = _product.FIRSTFILLING;
                ViewBag.PCLASS = _product.PCLASS;
                ViewBag.CAPACITY = _product.CAPACITY;
                ViewBag.TPERIOD = _product.TPERIOD;

            }
            else
            {
                _customer = db.CUSTOMERs.Where(x => x.REFID == -1).FirstOrDefault();
            }

            return View(Tuple.Create(customer, product));
        }


    }
}
