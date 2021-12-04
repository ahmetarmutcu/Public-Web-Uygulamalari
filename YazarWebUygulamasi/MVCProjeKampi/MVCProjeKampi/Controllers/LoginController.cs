using BusinessLayer.Concrete;
using DataAccessLayer;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using EntityLayer.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
namespace MVCProjeKampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        AdminManager adM = new AdminManager(new EfAdminDal());
        WriterLoginManager wm = new WriterLoginManager(new EfWriterDal());
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var response = Request["g-recaptcha-response"];
            string secretKey = "6LcSs38bAAAAAAsBPZxcUHgReTYJwnfdw-TjDtx-";
            var client = new WebClient();
            var reply =
            client.DownloadString(
            string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);
            if (!captchaResponse.Success)
                TempData["Message"] = "Lütfen güvenliği doğrulayınız.";
            else
            {
                string encUsername = StaticFunctions.Encrypt(p.AdminUsername);
                string encPassword = StaticFunctions.Encrypt(p.AdminPassword);
                var admin = adM.GetAdmin(encUsername, encPassword);
                if (admin != null)
                {
                    FormsAuthentication.SetAuthCookie(admin.AdminUsername, false);
                    Session["AdminUsername"] = admin.AdminUsername;
                    return RedirectToAction("Index", "AdminCategory");
                }
            }
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer w)
        {
            string encUsername = StaticFunctions.Encrypt(w.WriterMail);
            string encPassword = StaticFunctions.Encrypt(w.WriterPassword);
            var writerUser = wm.GetWriter(encUsername, encPassword);
            if (writerUser != null)
            {
                FormsAuthentication.SetAuthCookie(writerUser.WriterMail, false);
                Session["WriterMail"] = writerUser.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
    }
}