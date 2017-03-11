using System;
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
    public class KindergardernService : IKindergardenService
    {
        private readonly IRepository<Kindergarden> _kindernRepository;
        private readonly IChildService _childService;
         
        private const int PageSize = 8;
        public KindergardernService(IRepository<Kindergarden> kindeRepository, IChildService childService)
        {
            _kindernRepository = kindeRepository;
            _childService = childService;
        }


        public void AddKindergarden(Kindergarden kindergarden)
        {
           _kindernRepository.Add(kindergarden);
        }

        public void DeleteKindergarden(Kindergarden kindergarden)
        {
            var item = this.GetKindergardenById(kindergarden.Id);
           _childService.RemoveKinderGarten(item.Children.ToArray());
           _kindernRepository.Remove(item);
        }

        public Kindergarden GetKindergardenById(int id)
        {
            var item = _kindernRepository.Table().Include(x=>x.Children).FirstOrDefault(x => x.Id == id);
            return item;
        }

        public void UpdateKindergarden(Kindergarden kindergarden)
        {
           _kindernRepository.Update(kindergarden);
        }

        public IEnumerable<Kindergarden> GetKindergardens(string address = "", int number = 0, int page = 1)
        {
            IQueryable<Kindergarden> queryable;
            Expression<Func<Kindergarden, bool>> selector = PredicateBuilder.True<Kindergarden>();
            if (!string.IsNullOrEmpty(address))
            {
                selector = selector.And(x => x.Address.Contains(address));
            }
            if (number > 0)
            {
                selector = selector.And(x => x.Number == number);
            }

            queryable = _kindernRepository.Table().Where(selector)
                    .OrderBy(x => x.Id)
                    .Skip((page - 1)*PageSize)
                    .Take(PageSize);
            var list = queryable.ToList();
            return list;

        }
    }
}
