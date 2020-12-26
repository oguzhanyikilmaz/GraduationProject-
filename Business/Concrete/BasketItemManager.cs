using Business.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Business.Concrete
{
    public class BasketItemManager : IBasketItemService
    {
        IBasketItemDal _basketItemDal;
        public BasketItemManager(IBasketItemDal basketItemDal)
        {
            _basketItemDal = basketItemDal;
        }

        public void Add(BasketItem basketItem)
        {
            _basketItemDal.Add(basketItem);
        }

        public void DeleteId(int id, int productId)
        {
            var basket = GetById(id, productId);
            foreach (var item in basket)
            {
                _basketItemDal.Delete(item);
            }
           
        }

        public void Delete(BasketItem basketItem)
        {
            _basketItemDal.Delete(basketItem);
        }

        public List<BasketItem> GetAll()
        {
            return _basketItemDal.GetList();
        }

        public List<BasketItem> GetByBasket(int id)
        {
            return _basketItemDal.GetListInclude(p => p.BasketId == id,x=>x.Product);
        }

        public List<BasketItem> GetById(int id, int productId)
        {
            return _basketItemDal.GetListInclude(b => b.BasketId == id && b.ProductId == productId,x=>x.Product);
        }

        public void Update(BasketItem basketItem)
        {

            _basketItemDal.Update(basketItem);
        }

    }
}
