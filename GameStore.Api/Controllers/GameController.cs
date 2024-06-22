using GameStore.Application.Dtos.Game;
using GameStore.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers;

[ApiController]
[Route("api/games")]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService;

    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }

    [HttpGet]
    public async Task<ActionResult<IList<GameResponseDto>>> GetAll()
    {
        var games = await _gameService.GetAllGamesAsync();
        
        return Ok(games);
    }
    
    [HttpGet("{id:int:min(1)}")]
    public async Task<ActionResult<GameResponseDto>> GetById([FromRoute] int id)
    {
        var game = await _gameService.GetGameByIdAsync(id);

        return Ok(game);
    }
    
    [HttpPost]
    public async Task<ActionResult<GameResponseDto>> Add([FromBody] GameRequestDto gameDto)
    {
        var game = await _gameService.AddGameAsync(gameDto);

        return Created(nameof(Add), game);
    }
    
    [HttpPut("{id:int:min(1)}")]
    public async Task<ActionResult> Update([FromRoute] int id, [FromBody] GameRequestDto gameDto)
    {
        await _gameService.UpdateGameAsync(id, gameDto);
        
        return NoContent();
    }
    
    [HttpDelete("{id:int:min(1)}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        await _gameService.DeleteGameAsync(id);

        return NoContent();
    }
}