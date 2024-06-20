using GameStore.Domain.Entities;
using GameStore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data.Repositories;

public class GameRepository : IGameRepository
{
    private readonly ApplicationDbContext _dbContext;

    public GameRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ValueTask<Game?> GetGameByIdAsync(Guid id) => _dbContext.Games.FindAsync(id);
    
    public Task<List<Game>> GetAllGamesAsync() => _dbContext.Games.ToListAsync();
    
    public async Task AddGameAsync(Game game)
    {
        await _dbContext.Games.AddAsync(game);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateGameAsync(Game game)
    {
        _dbContext.Games.Update(game);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteGameAsync(Game game)
    {
        _dbContext.Games.Remove(game);
        await _dbContext.SaveChangesAsync();
    }
}