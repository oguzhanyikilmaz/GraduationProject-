using Business.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Business.Concrete
{
    public class BasketManager : IBasketService
    {
        IBasketDal _basketDal;
       
        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
           
        }

        public void Add(Basket basket)
        {
            _basketDal.Add(basket);
        }

        public void Delete(Basket basket)
        {
            _basketDal.Delete(basket);
        }

        public List<Basket> GetAll()
        {
            return _basketDal.GetList();
        }


        public Basket GetByUser(string id)
        {
            return _basketDal.GetInclude(b=>b.UserId==id,x=>x.BasketItem);
        }

        public void InitializeCart(string userId)
        {
           var basket= new Basket() { UserId = userId };
            _basketDal.Add(basket);
        }

        public void Update(Basket basket)
        {
            _basketDal.Update(basket);
        }
    }
}
