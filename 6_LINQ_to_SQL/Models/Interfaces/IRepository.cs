using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IteaLinqToSql.Models.Interfaces
{
    public interface IRepository<T>
    {
        void Create(T item);
        T FindById(string id);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        void Remove(T item);
        void Update(T item);
    }
}
