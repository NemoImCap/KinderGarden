using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DomainLib.Context;
using LinqKit;

namespace DomainLib.Repository
{
    public class Repository<T> : IDisposable, IRepository<T> where T : class
    {
        private IDbSet<T> _entities;


        public Repository(EfContext context)
        {
            Context = context;
        }

        private EfContext Context { get; set; }


        protected IDbSet<T> Entities
        {
            get { return _entities ?? (_entities = Context.Set<T>()); }
        }

        public IQueryable<T> Table
        {
            get { return Entities.AsExpandable(); }
        }

        void IDisposable.Dispose()
        {
            if (Context != null) Context.Dispose();
        }

        IQueryable<T> IRepository<T>.Table()
        {
            return Table;
        }

        void IRepository<T>.Add(T entity)
        {
            Entities.Add(entity);
            Context.Entry(entity).State = EntityState.Added;

            Context.SaveChanges();
        }


        void IRepository<T>.AddOrUpdate(T entity)
        {
            var current = Entities.Find(entity);
            if (current == null)
            {
                Entities.Add(entity);
                Context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                Entities.Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;
            }

            Context.SaveChanges();
        }


        void IRepository<T>.Update(T entity)
        {
            Entities.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;

            Context.SaveChanges();
        }

        void IRepository<T>.RemoveRange(IEnumerable<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);
            foreach (var entity in entities)
                Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }

        void IRepository<T>.Remove(T entity)
        {
            try
            {
                Entities.Remove(entity);
                Context.Entry(entity).State = EntityState.Deleted;

                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                var e = ex;
            }
        }

        void IRepository<T>.Remove(IEnumerable<T> entities)
        {
            var context = Entities;
            foreach (var item in entities)
            {
                context.Remove(item);
                Context.Entry(item).State = EntityState.Deleted;
            }

            Context.SaveChanges();
        }


        T IRepository<T>.Find(T entity)
        {
            return Entities.Find(entity);
        }

        IEnumerable<T> IRepository<T>.GetAll()
        {
            return Entities;
        }

        IEnumerable<T> IRepository<T>.Where(Expression<Func<T, bool>> predicate)
        {
            return Entities.Where(predicate);
        }

        bool IRepository<T>.Any(Expression<Func<T, bool>> predicate)
        {
            return Entities.Any(predicate);
        }

        T IRepository<T>.FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return Entities.FirstOrDefault(predicate);
        }

        int IRepository<T>.Count(Expression<Func<T, bool>> predicate)
        {
            return Entities.Count(predicate);
        }

        IQueryable<T> IRepository<T>.Include(string property)
        {
            return Entities.Include(property);
        }

        IQueryable<T> IRepository<T>.Take(int count)
        {
            return Entities.Take(count);
        }
    }
}