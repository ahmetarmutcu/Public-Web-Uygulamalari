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
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult MyContent()
        {
            string p = (string)Session["WriterMail"];
            var writerIDInfo = wm.GetList().Where(x => x.WriterMail == p).Select(y=>y.WriterID).FirstOrDefault();
            var contentValues = cm.GetListByWriter(writerIDInfo);
            return View(contentValues);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            string w = (string)Session["WriterMail"];
            var writerIDInfo = wm.GetList().Where(x => x.WriterMail == w).Select(y => y.WriterID).FirstOrDefault();
            p.WriterID = writerIDInfo;
            p.ContentStatus = true;
            cm.ContentAdd(p);
            return RedirectToAction("MyContent");
        }
    }
}