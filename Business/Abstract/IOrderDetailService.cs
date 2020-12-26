using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrderDetailService
    {
        List<OrderDetails> GetAll();
        List<OrderDetails> GetByProduct(int productId);
        List<OrderDetails> GetOrderDetail(int id);
        void Add(OrderDetails orderDetail);
        void Update(OrderDetails orderDetail);
        void Delete(OrderDetails orderDetail);
        

    }
}
