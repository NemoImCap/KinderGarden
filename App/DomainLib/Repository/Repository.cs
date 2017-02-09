using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DomainLib.Repository
{
    public class Repository <T>: IDisposable, IRepository<T> where T : class
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void AddOrUpdate(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public T AddEntity(T entity)
        {
            throw new NotImplementedException();
        }

        public T Find(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Include(string field)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Take(int count)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
