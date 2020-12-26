using ShoppingMarket.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ShoppingMarket.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter = null);
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        List<T> GetListInclude(Expression<Func<T, bool>> filterr = null, Expression<Func<T, object>> filter = null);
        T GetInclude(Expression<Func<T, bool>> filterr = null, Expression<Func<T, object>> filter = null);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
