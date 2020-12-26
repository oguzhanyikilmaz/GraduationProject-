using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICartDetailService
    {
        List<CartDetails> GetAll();
        List<CartDetails> GetByProduct(int product);
        CartDetails GetCartDetail(int id);
        void Add(CartDetails cartDetail);
        void Update(CartDetails cartDetail);
        void Delete(CartDetails cartDetail);
    }
}
