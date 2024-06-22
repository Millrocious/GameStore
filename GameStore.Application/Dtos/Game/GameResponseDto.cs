using GameStore.Domain.Enums;

namespace GameStore.Application.Dtos.Game;

public class GameResponseDto
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public GameGenre Genre { get; set; }
    public int PublisherId { get; set; }
}