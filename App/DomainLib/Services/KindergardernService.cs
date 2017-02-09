using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLib.Repository;

namespace DomainLib.Services
{
    public class KindergardernService : IKindergardenService
    {
        private readonly IRepository<Kindergarden> _kindernRepository;
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
            throw new NotImplementedException();
        }

        public Kindergarden GetKindergardenById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateKindergarden(Kindergarden kindergarden)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Kindergarden> GetKindergardens(int id, string address)
        {
            throw new NotImplementedException();
        }
    }
}
