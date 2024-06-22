using GameStore.Application.Dtos.Game;

namespace GameStore.Application.Services.Interfaces;

public interface IGameService
{
    Task<GameResponseDto> GetGameByIdAsync(int id);
    Task<IList<GameResponseDto>> GetAllGamesAsync();
    Task<GameResponseDto> AddGameAsync(GameRequestDto newGame);
    Task UpdateGameAsync(int id, GameRequestDto updatedGame);
    Task DeleteGameAsync(int id);
}