using DomainLib.Domain.Models;

namespace DomainLib.Domain.Services
{
    public interface IAnnouncemenService
    {
        Announcemen CreateAnnouncemen(string message);

    }
}