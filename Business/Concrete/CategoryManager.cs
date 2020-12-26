using Business.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public void Add(Categories category)
        {
            _categoryDal.Add(category);
        }

        public void Delete(Categories category)
        {
            _categoryDal.Delete(category);
        }

        public List<Categories> GetAll()
        {
            return _categoryDal.GetList();
        }

        public Categories GetCategory(int id)
        {
            return _categoryDal.Get(c=> c.CategoryId==id);
        }

        public void Update(Categories category)
        {
            _categoryDal.Update(category);
        }
    }
}
