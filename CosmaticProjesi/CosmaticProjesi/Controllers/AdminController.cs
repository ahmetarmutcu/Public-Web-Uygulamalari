using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using FluentValidation.Results;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using PagedList;

namespace CosmaticProjesi.Controllers
{
    public class AdminController : Controller
    {
        SettingManager sm = new SettingManager(new EfSettingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        ProductManager pm = new ProductManager(new EfProductDal());
        ContactManger com = new ContactManger(new EfContactDal());
        UserManager um = new UserManager(new EfUserDal());
        [Authorize]
        public  ActionResult Profile()
        {
            string username = (string)Session["Username"];
            var user=um.GetList().Where(x => x.Username == username).FirstOrDefault();
            return View(user);
        }
        #region Setting
        [Authorize]
        [HttpGet]
        public ActionResult EditSetting()
        {
            var settingValue = sm.GetByID(1);
            return View(settingValue);
        }
        [Authorize]
        [HttpPost]
        public ActionResult EditSetting(Setting setting)
        {
            setting.ID = 1;
            sm.SettingUpdate(setting);
            return RedirectToAction("EditSetting");
        }
        #endregion

        #region Category
        [Authorize]
        public ActionResult Category()
        {
            var categoryValues = cm.GetList();
            return View(categoryValues);
        }
        [Authorize]
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(p);
            if (result.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction("Category");
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
        [Authorize]
        public ActionResult DeleteCategory(int id)
        {
            var categoryValue = cm.GetByID(id);
            cm.CategoryDelete(categoryValue);
            return RedirectToAction("Category");
        }
        [Authorize]
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryValue = cm.GetByID(id);
            return View(categoryValue);
        }
        [Authorize]
        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
            cm.CategoryUpdate(p);
            return RedirectToAction("Category");
        }
        #endregion

        #region Product
        public ActionResult Product(int page = 1)
        {
            var productValues = pm.GetList().ToPagedList(page, 10);
            return View(productValues);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.ID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product p)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Content/image/" + fileName;
                if (System.IO.File.Exists(Server.MapPath(path)))
                    System.IO.File.Delete(Server.MapPath(path));

                Request.Files[0].SaveAs(Server.MapPath(path));
                p.Img1Path = "/Content/image/" + fileName;
            }
            pm.ProductAdd(p);
            TempData["Message"] = "Ürün başarıyla eklendi";
            return RedirectToAction("Product");

        }
        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.ID.ToString()
                                                  }).ToList();

            ViewBag.vlc = valueCategory;
            var productValue = pm.GetByID(id);
            return View(productValue);
        }
        [HttpPost]
        public ActionResult EditProduct(Product p)
        {
            var product = pm.GetByID(p.ID);
            product.Name = p.Name;
            product.Category = p.Category;
            product.CategoryID = p.CategoryID;
            product.Price = p.Price;
            product.Content = p.Content;
            pm.ProductUpdate(product);
            TempData["Message"] = "Ürün başarıyla güncellendi";
            return RedirectToAction("Product");
        }

        [HttpGet]
        public  ActionResult DeleteProduct (int id)
        {
            var value = pm.GetByID(id);
            pm.ProductDelete(value);
            TempData["Message"] = "Ürün başarıyla silindi";
            return RedirectToAction("Product");
        }

        [HttpGet]
        public  ActionResult UploadProductImage(int id)
        {
            var values = pm.GetByID(id);
            return View(values);
        }

        [Route("ImageOperation")]
        public ActionResult UploadImage(int id,int imageID)
        {
            var product = pm.GetByID(id);
            if (imageID == 1)
            {
                if (Request.Files.Count > 0)
                {
                    if (System.IO.File.Exists(Server.MapPath(product.Img1Path)))
                        System.IO.File.Delete(Server.MapPath(product.Img1Path));

                    string fileName = Path.GetFileName(Request.Files[0].FileName);
                    string extension = Path.GetExtension(Request.Files[0].FileName);
                    string path = "~/Content/image/" + fileName;
                    Request.Files[0].SaveAs(Server.MapPath(path));
                    product.Img1Path = "/Content/image/" + fileName;
                }
            }
            if (imageID == 2)
            {
                if (Request.Files.Count > 0)
                {
                    if (System.IO.File.Exists(Server.MapPath(product.Img2Path)))
                        System.IO.File.Delete(Server.MapPath(product.Img2Path));

                    string fileName = Path.GetFileName(Request.Files[0].FileName);
                    string extension = Path.GetExtension(Request.Files[0].FileName);
                    string path = "~/Content/image/" + fileName;
                    Request.Files[0].SaveAs(Server.MapPath(path));
                    product.Img2Path = "/Content/image/" + fileName;
                }
            }
            if (imageID == 3)
            {
                if (Request.Files.Count > 0)
                {
                    if (System.IO.File.Exists(Server.MapPath(product.Img3Path)))
                        System.IO.File.Delete(Server.MapPath(product.Img3Path));

                    string fileName = Path.GetFileName(Request.Files[0].FileName);
                    string extension = Path.GetExtension(Request.Files[0].FileName);
                    string path = "~/Content/image/" + fileName;
                    Request.Files[0].SaveAs(Server.MapPath(path));
                    product.Img3Path = "/Content/image/" + fileName;
                }
            }
            if (imageID == 4)
            {
                if (Request.Files.Count > 0)
                {
                    if (System.IO.File.Exists(Server.MapPath(product.Img4Path)))
                        System.IO.File.Delete(Server.MapPath(product.Img4Path));

                    string fileName = Path.GetFileName(Request.Files[0].FileName);
                    string extension = Path.GetExtension(Request.Files[0].FileName);
                    string path = "~/Content/image/" + fileName;
                    Request.Files[0].SaveAs(Server.MapPath(path));
                    product.Img4Path = "/Content/image/" + fileName;
                }
            }
            if (imageID == 5)
            {
                if (Request.Files.Count > 0)
                {

                    if (System.IO.File.Exists(Server.MapPath(product.Img5Path)))
                        System.IO.File.Delete(Server.MapPath(product.Img5Path));

                    string fileName = Path.GetFileName(Request.Files[0].FileName);
                    string extension = Path.GetExtension(Request.Files[0].FileName);
                    string path = "~/Content/image/" + fileName;
                    Request.Files[0].SaveAs(Server.MapPath(path));
                    product.Img5Path = "/Content/image/" + fileName;
                }
            }
            pm.ProductUpdate(product);
            return RedirectToAction("UploadProductImage", new { id = product.ID });
        }
        [Route("ImageOperation")]
        public ActionResult DeleteImage(int id, int imageID)
        {
            var product = pm.GetByID(id);
            if (imageID == 1)
            {
                if (System.IO.File.Exists(Server.MapPath(product.Img1Path)))
                {
                    System.IO.File.Delete(Server.MapPath(product.Img1Path));
                    product.Img1Path = "";
                    pm.ProductUpdate(product);
                }
            }
            if (imageID == 1)
            {
                if (System.IO.File.Exists(Server.MapPath(product.Img1Path)))
                {
                    System.IO.File.Delete(Server.MapPath(product.Img1Path));
                    product.Img2Path = "";
                    pm.ProductUpdate(product);
                }
            }
            if (imageID == 2)
            {
                if (System.IO.File.Exists(Server.MapPath(product.Img2Path)))
                {
                    System.IO.File.Delete(Server.MapPath(product.Img2Path));
                    product.Img3Path = "";
                    pm.ProductUpdate(product);
                }
            }
            if (imageID == 3)
            {
                if (System.IO.File.Exists(Server.MapPath(product.Img3Path)))
                {
                    System.IO.File.Delete(Server.MapPath(product.Img3Path));
                    product.Img4Path = "";
                    pm.ProductUpdate(product);
                }
            }
            if (imageID == 4)
            {
                if (System.IO.File.Exists(Server.MapPath(product.Img4Path)))
                {
                    System.IO.File.Delete(Server.MapPath(product.Img4Path));
                    product.Img5Path = "";
                    pm.ProductUpdate(product);
                }
            }
            if (imageID == 5)
            {
                if (System.IO.File.Exists(Server.MapPath(product.Img5Path)))
                {
                    System.IO.File.Delete(Server.MapPath(product.Img5Path));
                    product.Img5Path = "";
                    pm.ProductUpdate(product);
                }
            }
            return RedirectToAction("UploadProductImage", new {id=product.ID});
        }
        #endregion

        #region
        public ActionResult ContactIndex()
        {
            var values = com.GetList();
            return View(values);
        }
        public PartialViewResult ContactPartialLeftMenu()
        {
            return PartialView();
        }
        public ActionResult GetContactDetail(int id)
        {
            var values = com.GetByID(id);
            return View(values);
        }

        #endregion

    }
}