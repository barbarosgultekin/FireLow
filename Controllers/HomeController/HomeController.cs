using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FireLow.Controllers
{
    public class HomeController : Controller
    {
        FLEntities DB = new FLEntities();
       
        public ActionResult Index()
        {
            if (Session["User"] == null)
                return RedirectToAction("Login");

            var x = DB.sp_datemonth().ToList();
            var y = DB.sp_dateyear().ToList();
            var z = DB.sp_datenow().ToList();

            
            //foreach (var xx in x)
            //{
            //    PRODUCT _product;

            //    var id = xx.ID;
            //    _product = DB.PRODUCTs.Find(id);

            //    xx.ID = _product.ID;
            //    xx.TCUSTOMER = _product.TCUSTOMER;
            //    xx.LOCATION = _product.LOCATION;
            //    xx.PTYPE = _product.PTYPE;
            //    xx.NEXTFILLING = _product.NEXTFILLING;

            //}


            return View(Tuple.Create(x,y,z));
        }

        public ActionResult Date()
        {
            var model = DB.PRODUCTs.ToList();
            PRODUCT _tube = new PRODUCT();

            foreach (var item in model)
            {
                ViewBag.msq = item.NEXTFILLING;
                var date2 = System.DateTime.Now.Date;
                var date1 = Convert.ToDateTime(item.NEXTFILLING);
                var sayici = date1.Subtract(date2);

                if (sayici.Days == 15)
                {

                }

                if (item.NEXTFILLING == date2)
                {
                    var ID = item.ID;
                    _tube = DB.PRODUCTs.Where(x => x.ID == ID).SingleOrDefault();
                    ViewBag.adi = _tube.TCUSTOMER;
                    ViewBag.id = _tube.ID;
                    ViewBag.n = _tube.NEXTFILLING;


                }

            }

            return View(model);
        }

        public ActionResult Info()
        {
            if (Session["User"] == null)
                return RedirectToAction("Login");
            return View();
        }

        public ActionResult Settings()
        {
            if (Session["User"] == null)
                return RedirectToAction("Login");
            return View();


        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Login", "Home");
        }

        [AllowAnonymous]
        public ActionResult Login(FireLow.Models.UserModel user)
        {

            if (user.Username != null)
            {
                USER _user = DB.USERS.Where(x => x.USERNAME == user.Username && x.PASSWORD == user.Password).FirstOrDefault();

                FormsAuthentication.SetAuthCookie(user.Username, false);
               
                Session.Add("User", _user);

                return RedirectToAction("Index", "Home");

            }
            else
            {
                return View();
            }
        }
    }
}