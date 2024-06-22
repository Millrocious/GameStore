using AutoMapper;
using GameStore.Application.Dtos.Game;
using GameStore.Application.Services.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Domain.Exceptions;
using GameStore.Domain.Interfaces.Repositories;

namespace GameStore.Application.Services.Implementations;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;
    private readonly IMapper _mapper;

    public GameService(IGameRepository gameRepository, IMapper mapper)
    {
        _gameRepository = gameRepository;
        _mapper = mapper;
    }

    public async Task<GameResponseDto> GetGameByIdAsync(int id)
    {
        var game = await GetGameOrThrowAsync(id);
        
        return _mapper.Map<GameResponseDto>(game);
    }

    public async Task<IList<GameResponseDto>> GetAllGamesAsync()
    {
        var games = await _gameRepository.GetAllGamesAsync();
        
        return _mapper.Map<IList<GameResponseDto>>(games);
    }

    public async Task<GameResponseDto> AddGameAsync(GameRequestDto newGame)
    {
        var addedGame = await _gameRepository.AddGameAsync(_mapper.Map<Game>(newGame));
        
        return _mapper.Map<GameResponseDto>(addedGame);
    }

    public async Task UpdateGameAsync(int id, GameRequestDto updatedGame)
    {
        var game = await GetGameOrThrowAsync(id);

        _mapper.Map(updatedGame, game);
        
        await _gameRepository.UpdateGameAsync(game);
    }

    public async Task DeleteGameAsync(int id)
    {
        var game = await GetGameOrThrowAsync(id);

        await _gameRepository.DeleteGameAsync(game);
    }

    private async Task<Game> GetGameOrThrowAsync(int id)
    {
        var game = await _gameRepository.GetGameByIdAsync(id);

        if (game is null)
        {
            throw new NotFoundException("Game not found");
        }

        return game;
    }
}