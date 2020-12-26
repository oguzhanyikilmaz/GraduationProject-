using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICreditCartService
    {
        List<CreditCarts> GetAll();
        CreditCarts GetCreditCart(int id);
        void Add(CreditCarts creditCart);
        void Update(CreditCarts creditCart);
        void Delete(CreditCarts creditCart);
    }
}
