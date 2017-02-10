using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCVoorbeeld3.Services;

namespace MVCVoorbeeld3.Controllers
{
    public class FiliaalController : Controller
    {
        private FiliaalService filiaalService = new FiliaalService();
        private HoofdZetelService hoofdZetelService = new HoofdZetelService();
        // GET: Filiaal
        public ActionResult Index()
        {
            var hoofdZetel = hoofdZetelService.Read();
            ViewBag.hoofdZetel = hoofdZetel;
            var filialen = filiaalService.FindAll();
            return View(filialen);
        }
    }
}