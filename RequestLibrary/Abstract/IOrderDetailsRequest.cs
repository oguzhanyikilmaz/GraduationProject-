using Presentation.RequestLibrary.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RequestLibrary.Abstract
{
  public  interface IOrderDetailsRequest
    {
        List<OrderDetails> GetAll();
        List<OrderDetails> GetByProduct(int productId);
        OrderDetails GetOrderDetail(int id);
        void Add(OrderDetails orderDetail);
        void Update(OrderDetails orderDetail);
        void Delete(OrderDetails orderDetail);
    }
}
