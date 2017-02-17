using MVCVoorbeeld3.Models;
using MVCVoorbeeld3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCVoorbeeld3.Controllers
{
    public class PersoonController : Controller
    {
        PersoonService persoonservice = new PersoonService();
        // GET: Persoon
        public ActionResult Index()
        {
            return View(persoonservice.FindAll());
        }

        [HttpGet]
        public ActionResult VerwijderForm(int id)
        {
            return View(persoonservice.FindById(id));
        }
        [HttpPost]
        public ActionResult Verwijderen(int id)
        {
            persoonservice.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Opslag()
        {
            OpslagViewModel opslagViewModel = new OpslagViewModel();
            opslagViewModel.Percentage = 10;
            return View(opslagViewModel);
        }
        [HttpPost]
        public ActionResult Opslag(OpslagViewModel opslagViewModel)
        {
            if (this.ModelState.IsValid)
            {
                persoonservice.Opslag(opslagViewModel.VanWedde.Value, opslagViewModel.TotWedde.Value, opslagViewModel.Percentage);
                return RedirectToAction("Index");
            }
            else
            {
                return View(opslagViewModel);
            }
        }
        [HttpGet]
        public ActionResult VanTotWedde()
        {
            var form = new VanTotWeddeViewModel();
            return View(form);
        }
        [HttpGet]
        public ActionResult VanTotWeddeResultaat(VanTotWeddeViewModel form)
        {
            if(this.ModelState.IsValid)
            {
                form.Personen = persoonservice.VanTotWedde(form.VanWedde.Value, form.TotWedde.Value);
            }
            return View("VanTotWedde", form);
        }

        
        
    }
}