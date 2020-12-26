using Business.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using ShoppingMarket.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CartManager : ICartService
    {
        private ICartDal _cartDal;
        public CartManager(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }
        public void Add(Cart cart)
        {
            _cartDal.Add(cart);
        }

        public void Delete(Cart cart)
        {
            _cartDal.Delete(cart);
        }

        public List<Cart> GetAll()
        {
            return _cartDal.GetList();
        }

        public List<Cart> GetByTime(DateTime dateTime)
        {
            return _cartDal.GetList(p => p.SellBy == dateTime);
        }

        public Cart GetCart(int id)
        {
            return _cartDal.Get(c => c.CartId == id);
        }

        public void Update(Cart cart)
        {
            _cartDal.Update(cart);
        }
    }
}
