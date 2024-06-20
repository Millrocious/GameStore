using GameStore.Domain.Entities;

namespace GameStore.Domain.Interfaces.Repositories;

public interface IPublisherRepository
{
    ValueTask<Publisher?> GetPublisherByIdAsync(int id);
    Task<List<Publisher>> GetAllPublishersAsync();
    Task<Publisher> AddPublisherAsync(Publisher publisher);
    Task UpdatePublisherAsync(Publisher publisher);
    Task DeletePublisherAsync(Publisher publisher);
}