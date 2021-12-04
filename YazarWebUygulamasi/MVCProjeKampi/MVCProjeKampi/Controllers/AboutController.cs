using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var aboutValue = abm.GetList();
            return View(aboutValue);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            abm.AboutAddBL(p);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
        public ActionResult UpdateStatus(int id)
        {
            var aboutValue = abm.GetByID(id);
            if (aboutValue.AboutStatus)
                aboutValue.AboutStatus = false;
            else
                aboutValue.AboutStatus = true;
            abm.AboutUpdate(aboutValue);
            return RedirectToAction("Index");
        }

    }
}