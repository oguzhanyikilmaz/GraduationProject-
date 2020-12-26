using Business.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CartDetailManager : ICartDetailService
    {
        private ICartDetailsDal _cartDetailsDal;
        public CartDetailManager(ICartDetailsDal cartDetailsDal)
        {
            _cartDetailsDal = cartDetailsDal;
        }
        public void Add(CartDetails cartDetail)
        {
            _cartDetailsDal.Add(cartDetail);
        }

        public void Delete(CartDetails cartDetail)
        {
            _cartDetailsDal.Delete(cartDetail);
        }

        public List<CartDetails> GetAll()
        {
            return _cartDetailsDal.GetList();
        }

        public List<CartDetails> GetByProduct(int product)
        {
            return _cartDetailsDal.GetList(p => p.ProductId == product);
        }

        public CartDetails GetCartDetail(int id)
        {
           return _cartDetailsDal.Get(c => c.CartId == id);
        }

        public void Update(CartDetails cartDetail)
        {
            _cartDetailsDal.Update(cartDetail);
        }
    }
}
