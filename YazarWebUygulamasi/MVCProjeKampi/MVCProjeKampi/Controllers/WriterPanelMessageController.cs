using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityLayer.Concrete;

namespace MVCProjeKampi.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();

        public ActionResult Inbox() //Gelen  kutusu
        {
            string writerMail = (string)Session["WriterMail"];
            var messageList = mm.GetListInbox(writerMail);
            return View(messageList);
        }
        public ActionResult Sendbox() //Gönderilen Kutusu
        {
            string writerMail = (string)Session["WriterMail"];
            var messageList = mm.GetListSendbox(writerMail);
            return View(messageList);
        }
        public ActionResult GetInBoxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult result = messageValidator.Validate(p);
            if (result.IsValid)
            {
                p.SenderMail = (string)Session["WriterMail"];
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(p);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public PartialViewResult MessageListMenu()
        {
            //StaticModel model = new StaticModel();
            //model.InboxCount = mm.GetListInbox().Count();
            //model.SendboxCount = mm.GetListSendbox().Count();
            //model.ReadSendboxCount = mm.GetListInbox(true, "admin@gmail.com").Count();
            //model.UnreadableSendboxCount = mm.GetListInbox(false, "admin@gmail.com").Count();
            return PartialView();
        }
    }
}