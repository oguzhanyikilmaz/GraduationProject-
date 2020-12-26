using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        List<Categories> GetAll();
        Categories GetCategory(int id);
        void Add(Categories category);
        void Update(Categories category);
        void Delete(Categories category);
    }
}
