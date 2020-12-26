﻿using Entities.Models;
using ShoppingMarket.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IBasketItemDal : IEntityRepository<BasketItem>
    {
    }
}
