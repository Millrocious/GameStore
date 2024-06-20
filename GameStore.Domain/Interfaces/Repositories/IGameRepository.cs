using GameStore.Domain.Entities;

namespace GameStore.Domain.Interfaces.Repositories;

public interface IGameRepository
{
    ValueTask<Game?> GetGameByIdAsync(Guid id);
    Task<List<Game>> GetAllGamesAsync();
    Task AddGameAsync(Game game);
    Task UpdateGameAsync(Game game);
    Task DeleteGameAsync(Game game);
}