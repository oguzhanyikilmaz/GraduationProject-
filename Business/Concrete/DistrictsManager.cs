using Business.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class DistrictsManager : IDistrictsService
    {
        private IDistrictsDal _districtsDal;
        public DistrictsManager(IDistrictsDal districtsDal)
        {
            _districtsDal = districtsDal;
        }

        public void Add(District district)
        {
            _districtsDal.Add(district);
        }

        public void Delete(District district)
        {
            _districtsDal.Delete(district);
        }

        public List<District> GetAll()
        {
            return _districtsDal.GetList();
        }

        public List<District> GetById(int districtId)
        {
            return _districtsDal.GetList(d=>d.DistrictId==districtId);
        }

        public District GetDistrict(int id)
        {
            return _districtsDal.Get(d=>d.DistrictId==id);
        }

        public void Update(District district)
        {
            _districtsDal.Update(district);
        }
    }
}
