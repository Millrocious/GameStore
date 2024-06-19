using GameStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data.Repositories;

// GameRepository.cs
public class GameRepository : IGameRepository
{
    private readonly ApplicationDbContext _dbContext;

    public GameRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Game?> GetGameByIdAsync(Guid id)
    {
        return await _dbContext.Games.FindAsync(id);
    }

    public async Task<IList<Game>> GetAllGamesAsync()
    {
        return await _dbContext.Games.ToListAsync();
    }

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