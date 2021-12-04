using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        MessageManager mm = new MessageManager(new EfMessageDal());
        ContactValidator cv = new ContactValidator();
        public ActionResult Index()
        {
            var contactValues = cm.GetList();
            return View(contactValues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactValues = cm.GetByID(id);
            return View(contactValues);
        }
        public PartialViewResult ContactPartialLeftMenu()
        {
            StaticModel model = new StaticModel();
            //model.InboxCount = mm.GetListInbox().Count();
            //model.SendboxCount = mm.GetListSendbox().Count();
            model.ReadSendboxCount = mm.GetListInbox(true,"admin@gmail.com").Count();
            model.UnreadableSendboxCount = mm.GetListInbox(false, "admin@gmail.com").Count();
            return PartialView(model);
        }
    }
}