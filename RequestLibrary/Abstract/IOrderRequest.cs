using Presentation.RequestLibrary.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RequestLibrary.Abstract
{
   public interface IOrderRequest
    {
        List<Orders> GetAll();
        List<Orders> GetByCustomer(int customerId);
        List<Orders> GetByTime(DateTime dateTime);
        Orders GetOrder(int id);
        void Add(Orders order);
        void Update(Orders order);
        void Delete(Orders order);
    }
}
