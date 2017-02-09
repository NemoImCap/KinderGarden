﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DomainLib.Context;

namespace DomainLib.Repository
{
    public class Repository <T>: IDisposable, IRepository<T> where T : class
    {
        private EfContext Context { get; set; }


        public Repository(EfContext context)
        {
            Context = context;
        }

        void IDisposable.Dispose()
        {
            if (Context != null) Context.Dispose();
        }

        void IRepository<T>.Add(T entity)
        {
            Context.Set<T>().Add(entity);
            Context.Entry(entity).State = System.Data.Entity.EntityState.Added;

            Context.SaveChanges();
        }


        void IRepository<T>.AddOrUpdate(T entity)
        {
            var current = Context.Set<T>().Find(entity);
            if (current == null)
            {
                Context.Set<T>().Add(entity);
                Context.Entry(entity).State = System.Data.Entity.EntityState.Added;
            }
            else
            {
                Context.Set<T>().Attach(entity);
                Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }

            Context.SaveChanges();
        }

        void IRepository<T>.Update(T entity)
        {
            Context.Set<T>().Attach(entity);
            Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;

            Context.SaveChanges();
        }

        void IRepository<T>.Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
            Context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;

            Context.SaveChanges();
        }

        void IRepository<T>.Remove(IEnumerable<T> entities)
        {
            var context = Context.Set<T>();
            foreach (var item in entities)
            {
                context.Remove(item);
                Context.Entry(item).State = System.Data.Entity.EntityState.Deleted;
            }

            Context.SaveChanges();
        }

        public T AddEntity(T Entity)
        {
            throw new NotImplementedException();
        }

        T IRepository<T>.Find(T entity)
        {
            return Context.Set<T>().Find(entity);
        }

        IEnumerable<T> IRepository<T>.GetAll()
        {
            return Context.Set<T>();
        }

        IEnumerable<T> IRepository<T>.Where(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }

        bool IRepository<T>.Any(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Any(predicate);
        }

        T IRepository<T>.FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().FirstOrDefault(predicate);
        }

        int IRepository<T>.Count(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Count(predicate);
        }

        IQueryable<T> IRepository<T>.Include(string field)
        {
            return Context.Set<T>().Include(field);
        }

        IQueryable<T> IRepository<T>.Take(int count)
        {
            return Context.Set<T>().Take(count);
        }
    }
}
