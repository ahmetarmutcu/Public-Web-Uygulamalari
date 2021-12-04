using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class IstatistikController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            Istatistik i = new Istatistik();
            i.TotalCategoryCount = cm.GetList().ToList().Count();
            i.SoftwareCategoryCount = hm.GetList().Where(b => b.CategoryID == cm.GetList().Where(x => x.CategoryName == "yazılım").FirstOrDefault().CategoryID).Count();
            i.WriterCount = wm.GetList().Where(x => x.WriterName.ToLower().Contains("a")).ToList().Count();
            i.MaximumCategoryCountName=cm.GetList().Where(b => b.CategoryID == hm.GetList().GroupBy(x => x.CategoryID).ToList().OrderBy(c => c.Count()).Last().Key).FirstOrDefault().CategoryName;
            i.DifCategoryStatus=cm.GetList().Where(x => x.CategoryStatus == true).Count() - cm.GetList().Where(y => y.CategoryStatus == false).Count();
            return View(i);
        }
    }
}