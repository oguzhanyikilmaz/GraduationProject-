using Business.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CreditCartManager : ICreditCartService
    {
        private ICreditCartDal _creditCartDal;
        public CreditCartManager(ICreditCartDal creditCartDal)
        {
            _creditCartDal = creditCartDal;
        }
        public void Add(CreditCarts creditCart)
        {
            _creditCartDal.Add(creditCart);
        }

        public void Delete(CreditCarts creditCart)
        {
            _creditCartDal.Delete(creditCart);
        }

        public List<CreditCarts> GetAll()
        {
            return _creditCartDal.GetList();
        }

        public CreditCarts GetCreditCart(int id)
        {
           return _creditCartDal.Get(c => c.CartNumber == id);
        }

        public void Update(CreditCarts creditCart)
        {
            _creditCartDal.Update(creditCart);
        }
    }
}
