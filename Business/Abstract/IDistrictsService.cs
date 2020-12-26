using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IDistrictsService
    {
        List<District> GetAll();
        List<District> GetById(int districtId);
        District GetDistrict(int id);
        void Add(District district);
        void Update(District district);
        void Delete(District district);
    }
}
