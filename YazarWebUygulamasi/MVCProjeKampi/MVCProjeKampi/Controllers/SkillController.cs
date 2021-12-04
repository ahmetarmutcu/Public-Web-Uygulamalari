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
    public class SkillController : Controller
    {
        SkillManager sm = new SkillManager(new EfSkillDal());
        public ActionResult Index()
        {
            var meSkill = sm.GetByID(1);
            return View(meSkill);
        }
        [HttpGet]
        public ActionResult EditSkill()
        {
            var skillValue = sm.GetByID(1);
            return View(skillValue);
        }
        [HttpPost]
        public ActionResult EditSkill(Skill skill)
        {
            sm.UpdateSkill(skill);
            return RedirectToAction("Index");
        }
    }
}