using CarRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CarRental.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);   // Expression Filtre vermemizi sağlayan yapı 
        List<T> GetAll(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes); 
        T Get(Expression<Func<T, bool>> filter);
        T Get(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);
        bool Any(Expression<Func<T, bool>> filter = null);
        int Count(Expression<Func<T, bool>> filter = null);
    }
}
