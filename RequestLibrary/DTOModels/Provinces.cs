using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.RequestLibrary.DTOModels
{
    public class Provinces
    {
        public Provinces()
        {
            District = new HashSet<Districts>();
        }

        public int ProvinceId { get; set; }
        public string ProvName { get; set; }
        public int? ContId { get; set; }

        public virtual Countries Cont { get; set; }
        public virtual ICollection<Districts> District { get; set; }
    }
}
