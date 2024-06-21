using GameStore.Domain.Entities;
using GameStore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data.Repositories;

public class PublisherRepository : IPublisherRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PublisherRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ValueTask<Publisher?> GetPublisherByIdAsync(int id) => _dbContext.Publishers.FindAsync(id);
    
    public Task<List<Publisher>> GetAllPublishersAsync() => _dbContext.Publishers.Include(p => p.Games).ToListAsync();

    public async Task<Publisher> AddPublisherAsync(Publisher publisher)
    {
        var entity = await _dbContext.Publishers.AddAsync(publisher);
        await _dbContext.SaveChangesAsync();

        return entity.Entity;
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