using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Products> GetAll();
        List<Products> GetByCategory(int categoryId);
        List<Products> GetByBarcode(string barcode);
        Products GetProduct(int id);
        Products GetProductBarode(string barcode);
        void Add(Products product);
        void Update(Products product);
        void Delete(Products product);
        
    }
}
