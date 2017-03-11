﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DomainLib.Repository;
using DomainLib.Utils;

namespace DomainLib.Services
{
    public class ChildService : IChildService
    {
        private readonly IRepository<Child> _childRepository;
        private const int PageSize = 8;

        public ChildService(IRepository<Child> childRepository)
        {
            _childRepository = childRepository;
        }

        public void AddChild(Child child)
        {
            _childRepository.Add(child);
        }

        public void UpdteChild(Child child)
        {
          _childRepository.Update(child);
        }

        public void DeleteChild(Child child)
        {
           _childRepository.Remove(child);
        }

        public IEnumerable<Child> GetChildren(int? gartenId, int? gartenNumber, int? age, string search = "", int page = 1)
        {
            Expression<Func<Child, bool>> selector = PredicateBuilder.True<Child>();
            if (!string.IsNullOrEmpty(search))
            {
               selector = selector.And(x => x.FirstName.Contains(search) || x.LastName.Contains(search));
            }
            if (age > 0)
            {
                selector = selector.And(x => x.Age == age);
            }
            if (gartenNumber > 0)
            {
                selector = selector.And(x => x.Kindergarden.Number == gartenNumber);
            }
            if (gartenId > 0)
            {
                selector = selector.And(x => x.Kindergarden.Id == gartenId);
            }
            IQueryable<Child> queryable = _childRepository.Table().Include(x => x.Kindergarden).Where(selector).OrderBy(x => x.Id).Skip((page - 1) * PageSize).Take(PageSize);
            var items = queryable.ToList();
            return items;
        }

        public Child GetChildById(int id)
        {
            var entity = _childRepository.FirstOrDefault(x => x.Id == id);
            return entity;
        }

        public void RemoveKinderGarten(IEnumerable<Child> children)
        {

            foreach (var child in children)
            {
                child.Kindergarden = null;
                _childRepository.Update(child);
            }
        }
    }
}
