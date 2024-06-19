using GameStore.Domain.Entities;

namespace GameStore.Data.Repositories;

public interface IPublisherRepository
{
    Task<Publisher?> GetPublisherByIdAsync(Guid id);
    Task<IList<Publisher>> GetAllPublishersAsync();
    Task AddPublisherAsync(Publisher publisher);
    Task UpdatePublisherAsync(Publisher publisher);
    Task DeletePublisherAsync(Publisher publisher);
}