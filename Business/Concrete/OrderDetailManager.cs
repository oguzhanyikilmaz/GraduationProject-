using Business.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class OrderDetailManager : IOrderDetailService
    {
        private IOrderDetailDal _orderDetailDal;
        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }
        public void Add(OrderDetails orderDetail)
        {
            _orderDetailDal.Add(orderDetail);
        }

        public void Delete(OrderDetails orderDetail)
        {
            _orderDetailDal.Delete(orderDetail);
        }

        public List<OrderDetails> GetAll()
        {
            return _orderDetailDal.GetListInclude(x=>x.OrderDetailsId>=0,x=>x.Product);
        }

       

        public List<OrderDetails> GetByProduct(int productId)
        {
            return _orderDetailDal.GetList(p => p.OrderId == productId);
        }

        public List<OrderDetails> GetOrderDetail(int id)
        {
            return _orderDetailDal.GetListInclude(o => o.OrderId == id,x=>x.Product);
        }

       

        public void Update(OrderDetails orderDetail)
        {
            _orderDetailDal.Update(orderDetail);
        }
    }
}
