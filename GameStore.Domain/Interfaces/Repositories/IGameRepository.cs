using GameStore.Domain.Entities;

namespace GameStore.Domain.Interfaces.Repositories;

public interface IGameRepository
{
    ValueTask<Game?> GetGameByIdAsync(int id);
    Task<List<Game>> GetAllGamesAsync();
    Task<Game> AddGameAsync(Game game);
    Task UpdateGameAsync(Game game);
    Task DeleteGameAsync(Game game);
}