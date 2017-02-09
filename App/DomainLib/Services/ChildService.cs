using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLib.Repository;

namespace DomainLib.Services
{
    public class ChildService : IChildService
    {
        private readonly IRepository<Child> _childRepository;

        public ChildService(IRepository<Child> childRepository)
        {
            _childRepository = childRepository;
        }

        public void AddChild(Child child)
        {
            throw new NotImplementedException();
        }

        public void UpdteChild(Child child)
        {
            throw new NotImplementedException();
        }

        public void DeleteChild(Child child)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Child> GetChildren(string name, string surname, int age)
        {
            throw new NotImplementedException();
        }

        public Child GetChildById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
