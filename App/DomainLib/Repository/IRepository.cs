using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DomainLib.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> Table();
        void Add(T entity);
        void AddOrUpdate(T entity);
        void Update(T entity);
        void Remove(T entity);
        void Remove(IEnumerable<T> entities);
        void RemoveRange(IEnumerable<T> entities);
        T Find(T entity);
        IEnumerable<T> GetAll();
        IQueryable<T> Include(string property);
        IQueryable<T> Take(int count);
        IEnumerable<T> Where(Expression<Func<T, bool>> predicate);
        T FirstOrDefault(Expression<Func<T, bool>> predicate);
        bool Any(Expression<Func<T, bool>> predicate);
        int Count(Expression<Func<T, bool>> predicate);
    }
}