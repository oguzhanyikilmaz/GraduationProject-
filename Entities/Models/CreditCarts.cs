using ShoppingMarket.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class CreditCarts : IEntity
    {
        public int CartNumber { get; set; }
        public string CartPassword { get; set; }
        public decimal? CardBalance { get; set; }
    }
}
