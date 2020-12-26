using System;
using System.Collections.Generic;
using System.Text;

namespace RequestLibrary.Abstract
{
   public interface IDistrictRequest
    {
        List<District> GetAll();
        List<District> GetById(int districtId);
        District GetDistrict(int id);
        void Add(District district);
        void Update(District district);
        void Delete(District district);
    }
}
