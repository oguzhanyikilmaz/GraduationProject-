using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrderService
    {
        List<Orders> GetAll();
        List<Orders> GetByCustomer(string customerId);
        List<Orders> GetByTime(DateTime dateTime);
        Orders GetOrder(int id);
        void Add(Orders order);
        void Update(Orders order);
        void Delete(Orders order);
        
    }
}
