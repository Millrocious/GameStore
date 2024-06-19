using GameStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data.Repositories;

public class PublisherRepository : IPublisherRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PublisherRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Publisher?> GetPublisherByIdAsync(Guid id)
    {
        return await _dbContext.Publishers.FindAsync(id);
    }

    public async Task<IList<Publisher>> GetAllPublishersAsync()
    {
        return await _dbContext.Publishers.ToListAsync();
    }

    public async Task AddPublisherAsync(Publisher publisher)
    {
        await _dbContext.Publishers.AddAsync(publisher);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdatePublisherAsync(Publisher publisher)
    {
        _dbContext.Publishers.Update(publisher);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeletePublisherAsync(Publisher publisher)
    {
        _dbContext.Publishers.Remove(publisher);
        await _dbContext.SaveChangesAsync();
    }
}