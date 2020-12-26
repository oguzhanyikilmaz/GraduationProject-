using Presentation.RequestLibrary.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RequestLibrary.Abstract
{
  public  interface ICategoryRequest
    {
        List<Categories> GetAll();
        Categories GetCategory(int id);
        void Add(Categories category);
        void Update(Categories category);
        void Delete(Categories category);
    }
}
