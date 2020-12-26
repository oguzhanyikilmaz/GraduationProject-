using Business.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public void Add(Orders order)
        {
            _orderDal.Add(order);
        }

        public void Delete(Orders order)
        {
            _orderDal.Delete(order);
        }

        public List<Orders> GetAll()
        {
            return _orderDal.GetListInclude(x=>x.OrderId>=0,x=>x.OrderDetails);
        }

        public List<Orders> GetAllInclude()
        {
            return _orderDal.GetList();
        }

        public List<Orders> GetByCustomer(string customerId)
        {
            return _orderDal.GetListInclude(p => p.UserId == customerId,x=>x.OrderDetails);

        }

        public List<Orders> GetByTime(DateTime dateTime)
        {
            return _orderDal.GetList(p => p.OrderDate == dateTime);
        }

        public Orders GetOrder(int id)
        {
            return _orderDal.Get(o => o.OrderId == id);
        }

        public void Update(Orders order)
        {
            _orderDal.Update(order);
        }
    }
}
