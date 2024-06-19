using GameStore.Domain.Entities;

namespace GameStore.Data.Repositories;

public interface IGameRepository
{
    Task<Game?> GetGameByIdAsync(Guid id);
    Task<IList<Game>> GetAllGamesAsync();
    Task AddGameAsync(Game game);
    Task UpdateGameAsync(Game game);
    Task DeleteGameAsync(Game game);
}