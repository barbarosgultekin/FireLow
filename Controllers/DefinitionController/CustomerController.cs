using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FireLow.Controllers.Definition
{
    public class CustomerController : Controller
    {
        FLEntities db = new FLEntities();


        public ActionResult CustomerDefinition()
        {
            if (Session["User"] == null)
                return RedirectToAction("Login");

            var customer = db.CUSTOMERs.ToList();

            return View(customer);
        }
        public ActionResult CustomerDetail(Int32 id)
        {

            var product = db.PRODUCTs.ToList();
            PRODUCT _product = new PRODUCT();

            var customer = db.CUSTOMERs.ToList();
            CUSTOMER _customer = new CUSTOMER();

            _product.CID = id;

            List<PRODUCT> model = db.PRODUCTs.Where(x => x.CID == id).ToList();

            if (id != 0)
            {

                _customer = db.CUSTOMERs.Find(id);

                ViewBag.REFID = _customer.REFID;

                ViewBag.APPELLATION = _customer.APPELLATION;

                ViewBag.CNAME = _customer.CNAME;

                ViewBag.CADRESS = _customer.CADRESS;

                ViewBag.CTAXNO = _customer.CTAXNO;

                ViewBag.CTAXOFFICE = _customer.CTAXOFFICE;

                ViewBag.CGSM = _customer.CGSM;

                ViewBag.CMAIL = _customer.CMAIL;

                ViewBag.CPROVINCE = _customer.CPROVINCE;

                ViewBag.CDISTRICT = _customer.CDISTRICT;

                ViewBag.CAREA = _customer.CAREA;

                ViewBag.CSTATUS = _customer.CSTATUS;
            }
            else
            {
                _customer = db.CUSTOMERs.Where(x => x.REFID == -1).FirstOrDefault();
            }



            return View(model);
        }
        public ActionResult CustomerSave()
        {
            if (Session["User"] == null)
                return RedirectToAction("Login");

            if (Request.Form.Count > 0)
            {
                CUSTOMER _customer = new CUSTOMER();


                int REFID = Convert.ToInt32(Request.Form["REFID"]);


                if (REFID != 0)
                {
                    _customer = db.CUSTOMERs.Where(x => x.REFID == REFID).FirstOrDefault();

                    _customer.REFID = Convert.ToInt32(Request.Form["REFID"]);
                    ViewBag.REFID = _customer.REFID;

                    _customer.APPELLATION = Request.Form["APPELLATION"];
                    ViewBag.APPELLATION = _customer.APPELLATION;

                    _customer.CNAME = Request.Form["CNAME"];
                    ViewBag.CNAME = _customer.CNAME;

                    _customer.CTAXNO = Request.Form["CTAXNO"];
                    ViewBag.CTAXNO = _customer.CTAXNO;

                    _customer.CTAXOFFICE = Request.Form["CTAXOFFICE"];
                    ViewBag.CTAXOFFICE = _customer.CTAXOFFICE;

                    _customer.CGSM = Request.Form["CGSM"];
                    ViewBag.CGSM = _customer.CGSM;

                    _customer.CMAIL = Request.Form["CMAIL"];
                    ViewBag.CMAIL = _customer.CMAIL;

                    _customer.CPROVINCE = Request.Form["CPROVINCE"];
                    ViewBag.CPROVINCE = _customer.CPROVINCE;

                    _customer.CDISTRICT = Request.Form["CDISTRICT"];
                    ViewBag.CDISTRICT = _customer.CDISTRICT;

                    _customer.CADRESS = Request.Form["CADRESS"];
                    ViewBag.CADRESS = _customer.CADRESS;

                    _customer.CAREA = Request.Form["CAREA"];
                    ViewBag.CAREA = _customer.CAREA;


                    if (Request.Form["CSTATUS"] == "OK")
                    {
                       
                        _customer.CSTATUS = 1;
                    }
                    else
                    {
                      
                        _customer.CSTATUS = 0;
                    }

                    db.SaveChangesAsync();
                    return RedirectToAction("CustomerTable", "Customer");

                }

                _customer.REFID = Convert.ToInt32(Request.Form["REFID"]);
                ViewBag.REFID = _customer.REFID;

                _customer.APPELLATION = Request.Form["APPELLATION"];
                ViewBag.APPELLATION = _customer.APPELLATION;

                _customer.CNAME = Request.Form["CNAME"];
                ViewBag.CNAME = _customer.CNAME;

                _customer.CTAXNO = Request.Form["CTAXNO"];
                ViewBag.CTAXNO = _customer.CTAXNO;

                _customer.CTAXOFFICE = Request.Form["CTAXOFFICE"];
                ViewBag.CTAXOFFICE = _customer.CTAXOFFICE;

                _customer.CGSM = Request.Form["CGSM"];
                ViewBag.CGSM = _customer.CGSM;

                _customer.CMAIL = Request.Form["CMAIL"];
                ViewBag.CMAIL = _customer.CMAIL;

                _customer.CPROVINCE = Request.Form["CPROVINCE"];
                ViewBag.CPROVINCE = _customer.CPROVINCE;

                _customer.CDISTRICT = Request.Form["CDISTRICT"];
                ViewBag.CDISTRICT = _customer.CDISTRICT;

                _customer.CADRESS = Request.Form["CADRESS"];
                ViewBag.CADRESS = _customer.CADRESS;

                _customer.CAREA = Request.Form["CAREA"];
                ViewBag.CAREA = _customer.CAREA;

                if (Request.Form["CSTATUS"] == "OK")
                {
                    _customer.CSTATUS = 1;
                  
                }
                else
                {
                    _customer.CSTATUS = 0;
                  
                }

                //if (User.IsInRole("1"))
                //{
                //    _customer.CUSTOMERID = 1;
                //}


                if (REFID == 0)
                {

                    db.CUSTOMERs.Add(_customer);

                    db.SaveChanges();
                }

                return RedirectToAction("CustomerTable", "Customer");
            }

            return View("CustomerTable", "Customer");
            //var model = db.CUSTOMERs.ToList();


        }
        public ActionResult CustomerTable()
        {
            if (Session["User"] == null)
                return RedirectToAction("Login");

            var model = db.CUSTOMERs.ToList();


            return View(model);
        }
        public ActionResult CustomerEdit(Int32 id)
        {

            var customer = db.CUSTOMERs.ToList();
            CUSTOMER _customer;

            if (id != 0)
            {
                _customer = db.CUSTOMERs.Find(id);

                ViewBag.REFID = _customer.REFID;

                ViewBag.APPELLATION = _customer.APPELLATION;

                ViewBag.CNAME = _customer.CNAME;

                ViewBag.CADRESS = _customer.CADRESS;

                ViewBag.CTAXNO = _customer.CTAXNO;

                ViewBag.CTAXOFFICE = _customer.CTAXOFFICE;

                ViewBag.CGSM = _customer.CGSM;

                ViewBag.CMAIL = _customer.CMAIL;

                ViewBag.CPROVINCE = _customer.CPROVINCE;

                ViewBag.CDISTRICT = _customer.CDISTRICT;

                ViewBag.CAREA = _customer.CAREA;

                ViewBag.CSTATUS = _customer.CSTATUS;
            }
            else
            {
                _customer = db.CUSTOMERs.Where(x => x.REFID == -1).FirstOrDefault();
            }

            return View(customer);
        }
    }
}
