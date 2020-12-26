using Presentation.RequestLibrary.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RequestLibrary.Abstract
{
   public interface ICartRequest
    {
        List<Cart> GetAll();
        List<Cart> GetByTime(DateTime dateTime);
        Cart GetCart(int id);
        void Add(Cart cart);
        void Update(Cart cart);
        void Delete(Cart cart);
    }
}
