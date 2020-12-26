using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMarket.WebUI.Models.DTOModels
{
    public class Districts
    {
        public Districts()
        {
            Users = new HashSet<Users>();
        }

        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string CustomDisctName { get; set; }
        public int? ProvId { get; set; }

        public virtual Provinces Prov { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
