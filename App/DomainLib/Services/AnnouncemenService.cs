using System;
using DomainLib.Domain.Models;
using DomainLib.Domain.Services;
using DomainLib.Repository;

namespace DomainLib.Services
{
    public class AnnouncemenService : IAnnouncemenService
    {
        private readonly IRepository<Announcemen> _repository;

        public AnnouncemenService(IRepository<Announcemen> repository)
        {
            _repository = repository;
        }

        public Announcemen CreateAnnouncemen(string message)
        {
            var announcement = new Announcemen
            {
                Announcementunification = Guid.NewGuid(),
                NewsMessage = message
            };
           _repository.Add(announcement);
            return announcement;
        }
    }
}