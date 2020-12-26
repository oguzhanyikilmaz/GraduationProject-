using Presentation.RequestLibrary.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RequestLibrary.Abstract
{
    public interface ICreditCartRequest
    {
        List<CreditCarts> GetAll();
        CreditCarts GetCreditCart(int id);
        void Add(CreditCarts creditCart);
        void Update(CreditCarts creditCart);
        void Delete(CreditCarts creditCart);
    }
}
