using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCVoorbeeld3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            this.Session["aantalBezoeken"] = (int)this.Session["aantalBezoeken"] + 1;
            System.Web.HttpContext.Current.Application.Lock();
            System.Web.HttpContext.Current.Application["aantalBezoeken"] = (int)System.Web.HttpContext.Current.Application["aantalBezoeken"] + 1;
            System.Web.HttpContext.Current.Application.UnLock();

            return View();      
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Wissen()
        {
            this.Session["aantalBezoeken"] = 0;
            System.Web.HttpContext.Current.Application.Lock();
            System.Web.HttpContext.Current.Application["aantalBezoeken"] = 0;
            System.Web.HttpContext.Current.Application.UnLock();
            return View();
        }
    }
}