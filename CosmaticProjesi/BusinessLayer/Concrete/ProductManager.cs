using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public Product GetByID(int id)
        {
           return _productDal.Get(x => x.ID == id);
        }

        public List<Product> GetCustomProductsList()
        {
            return _productDal.List(x => x.CustomProduct==true);
        }

        public List<Product> GetFeaturedProductsList()
        {
            return _productDal.List(x => x.FeaturedProduct == true);
        }

        public List<Product> GetList()
        {
            return _productDal.List();
        }

        public List<Product> GetListByCategoryID(int ID=3)
        {
            return _productDal.List(x => x.CategoryID == ID);
        }

        public void ProductAdd(Product product)
        {
            _productDal.Insert(product);
        }

        public void ProductDelete(Product product)
        {
            _productDal.Delete(product);
        }

        public void ProductUpdate(Product product)
        {
            _productDal.Update(product);
        }
    }
}
