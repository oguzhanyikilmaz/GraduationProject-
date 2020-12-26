using Business.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Products product)
        {
            _productDal.Add(product);
        }

        public void Delete(Products product)
        {
            _productDal.Delete(product);
        }

        public List<Products> GetAll()
        {
            return _productDal.GetList();
        }

        

        public List<Products> GetByBarcode(string barcode)
        {
            return _productDal.GetList(p => p.Barcode == barcode);
        }

        public List<Products> GetByCategory(int categoryId)
        {
            return _productDal.GetList(p => p.CategoryId == categoryId);
        }

        public Products GetProduct(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }

        public Products GetProductBarode(string barcode)
        {
            return _productDal.Get(p => p.Barcode == barcode);
        }

        public void Update(Products product)
        {
            _productDal.Update(product);
        }
    }
}
