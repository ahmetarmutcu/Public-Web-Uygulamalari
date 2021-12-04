using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace CosmaticProjesi.Controllers
{
    public class HomeController : Controller
    {
        SettingManager sm = new SettingManager(new EfSettingDal());
        ContactManger cm = new ContactManger(new EfContactDal());
        CategoryManager catM = new CategoryManager(new EfCategoryDal());
        ProductManager pm = new ProductManager(new EfProductDal());
        public ActionResult Index()
        {
            var settingValues = sm.GetByID(1);
            return View(settingValues);
        }
        public PartialViewResult RecentlyAddedProducts() //Son 6 Ürün
        {
            var products = pm.GetList();
            var values = products.OrderByDescending(x => x.ID).Take(6).ToList();
            return PartialView(values);
        }
        public PartialViewResult CustomProducts() //Özel Ürünler
        {
            var products = pm.GetCustomProductsList();
            var values = products.OrderByDescending(x => x.ID).Take(6).ToList();
            return PartialView(values);
        }

        public PartialViewResult FeaturedProduct() //Öne Çıkan Ürünler
        {
            var products = pm.GetFeaturedProductsList();
            var values = products.OrderByDescending(x => x.ID).Take(6).ToList();
            return PartialView(values);
        }

        public ActionResult About()
        {
            var settingValues = sm.GetByID(1);
            return View(settingValues);
        }
        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(Contact contact)
        {
            ContactValidator categoryValidator = new ContactValidator();
            ValidationResult result = categoryValidator.Validate(contact);
            if (result.IsValid)
            {
                
                cm.ContactAdd(contact);
                TempData["ContactMessage"]= "Mesaj başarıyla iletildi.";
                return RedirectToAction("Contact");
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

        public PartialViewResult LeftProductCategory() //Default gelen
        {
            var categoryValues = catM.GetList();
            return PartialView(categoryValues);
        }
        public ActionResult ProductByCategoryID(int id=3,int page=1)
        {
            var productValues = pm.GetListByCategoryID(id).ToPagedList(page, 16);
            return View(productValues);
        }
        public ActionResult ProductDetailByCategoryID(int id)
        {
            var productValues = pm.GetByID(id);
            return View(productValues);
        }



        #region  Layout Partial
        public PartialViewResult TitlePartial()
        {
            var settingValues = sm.GetByID(1);
            return PartialView(settingValues);
        }
        public PartialViewResult LeftHeaderPartial()
        {
            var settingValues = sm.GetByID(1);
            return PartialView(settingValues);
        }
        public PartialViewResult FooterAddressPartial()
        {
            var settingValues = sm.GetByID(1);
            return PartialView(settingValues);
        }
        public PartialViewResult SocialMediaPartial()
        {
            var settingValues = sm.GetByID(1);
            return PartialView(settingValues);
        }
        #endregion

    }
}