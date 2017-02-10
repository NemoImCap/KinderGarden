using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DomainLib.Repository;
using DomainLib.Utils;

namespace DomainLib.Services
{
    public class KindergardernService : IKindergardenService
    {
        private readonly IRepository<Kindergarden> _kindernRepository;
        private const int PageSize = 8;
        public KindergardernService(IRepository<Kindergarden> kindeRepository)
        {
            _kindernRepository = kindeRepository;
        }

      
        public void AddKindergarden(Kindergarden kindergarden)
        {
           _kindernRepository.Add(kindergarden);
        }

        public void DeleteKindergarden(Kindergarden kindergarden)
        {
           _kindernRepository.Remove(kindergarden);
        }

        public Kindergarden GetKindergardenById(int id)
        {
            var item = _kindernRepository.FirstOrDefault(x => x.Id == id);
            return item;
        }

        public void UpdateKindergarden(Kindergarden kindergarden)
        {
           _kindernRepository.Update(kindergarden);
        }

        public IEnumerable<Kindergarden> GetKindergardens(string address = "", int number = 0, int page = 1)
        {
            IQueryable<Kindergarden> queryable = _kindernRepository.GetAll().AsQueryable();
            Expression<Func<Kindergarden, bool>> selector = PredicateBuilder.True<Kindergarden>();
            if (!string.IsNullOrEmpty(address))
            {
                selector = selector.And(x => x.Address.Contains(address));
            }
            if (number > 0)
            {
                selector = selector.And(x => x.Number == number);
            }

            var items = queryable.Where(selector).ToList();
            var list = items.Skip((page - 1)*PageSize).Take(PageSize);
            return list;

        }
    }
}
