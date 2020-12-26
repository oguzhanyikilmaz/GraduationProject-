using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IBasketService
    {
        Basket GetByUser(string id);
        List<Basket> GetAll();
        void InitializeCart(string userId);
        void Add(Basket basket);
        void Update(Basket basket);
        void Delete(Basket basket);
        
    }
}
