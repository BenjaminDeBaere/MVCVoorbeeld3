using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCVoorbeeld3.Services;
using MVCVoorbeeld3.Models;

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
            return View("filialen",filialen);
        }
        public ActionResult Verwijderen(int id)
        {
            var filiaal = filiaalService.Read(id);
            return View(filiaal);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var filiaal = filiaalService.Read(id);
            this.TempData["filiaal"] = filiaal;
            filiaalService.Delete(id);
            return Redirect("~/filiaal/Verwijderd");
        }

        public ActionResult Verwijderd()
        {
            var filiaal = (Filiaal)this.TempData["filiaal"];
            return View(filiaal);
        }
    }
}