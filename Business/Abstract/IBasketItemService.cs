using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
  public  interface IBasketItemService
    {
        List<BasketItem> GetByBasket(int id);
        List<BasketItem> GetAll();
        List<BasketItem> GetById(int id,int productId);
        void Add(BasketItem basketItem);
        void Update(BasketItem basketItem);
        void Delete(BasketItem basketItem);
        void DeleteId(int id,int productId);

    }
}
