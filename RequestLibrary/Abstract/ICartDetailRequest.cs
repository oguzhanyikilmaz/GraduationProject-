using Presentation.RequestLibrary.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RequestLibrary.Abstract
{
  public  interface ICartDetailRequest
    {
        List<CartDetails> GetAll();
        List<CartDetails> GetByProduct(int product);
        CartDetails GetCartDetail(int id);
        void Add(CartDetails cartDetail);
        void Update(CartDetails cartDetail);
        void Delete(CartDetails cartDetail);
    }
}
