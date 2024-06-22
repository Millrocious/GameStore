using GameStore.Application.Dtos.Game;

namespace GameStore.Application.Dtos.Publisher;

public class PublisherResponseDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Country { get; set; }
    public IList<GameResponseDto> Games { get; set; } = default!;
}