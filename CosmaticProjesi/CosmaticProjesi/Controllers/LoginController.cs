using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CosmaticProjesi.Controllers
{
    public class LoginController : Controller
    {
        UserManager um = new UserManager(new EfUserDal());
        [HttpGet]
        public ActionResult UserLogin()
        {

            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(User u)
        {
            var users = um.GetList();
            if (users != null)
            {
                foreach(var us in users)
                {
                    if(us.Username==u.Username && us.Password == u.Password)
                    {
                        FormsAuthentication.SetAuthCookie(us.Username,false);
                        Session["Username"] = us.Username;
                        return RedirectToAction("Profile", "Admin");
                    }
                }
            }
            return RedirectToAction("UserLogin");
        }
        public ActionResult UserLoginClose()
        {
            Session["Username"] = null;
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("UserLogin", "Login");
        }
    }
}