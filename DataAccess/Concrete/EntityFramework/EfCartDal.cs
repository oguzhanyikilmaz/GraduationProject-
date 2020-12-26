using DataAccess.Abstract;
using Entities;
using Entities.Models;
using ShoppingMarket.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCartDal : EfEntityRepositoryBase<Cart, ShoppingMarkettContext>, ICartDal
    {
    }
}
