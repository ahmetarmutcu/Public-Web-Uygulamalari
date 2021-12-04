using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    [AllowAnonymous]
    public class GalleryController : Controller
    {
        ImageFileManager ifm = new ImageFileManager(new EfImageFileDal());
        public ActionResult Index()
        {
            var files = ifm.GetList();
            return View(files);
        }

        [HttpGet]
        public ActionResult AddImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddImage(ImageFile image)
        {
            if (Request.Files.Count > 0)
            {
                string fileName=Path.GetFileName(Request.Files[0].FileName);
                string expansion=Path.GetExtension(Request.Files[0].FileName);
                string path="/Content/img/" + fileName + expansion;
                Request.Files[0].SaveAs(Server.MapPath(path));
                image.ImagePath="/Content/img/" + fileName + expansion;
                ifm.AddImageFile(image);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}