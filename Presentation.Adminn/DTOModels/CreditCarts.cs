using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Adminn.Models
{
    public class CreditCarts
    {
        public int CartNumber { get; set; }
        public string CartPassword { get; set; }
        public decimal? CardBalance { get; set; }
    }
}
