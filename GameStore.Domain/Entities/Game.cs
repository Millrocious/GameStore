using GameStore.Domain.Enum;

namespace GameStore.Domain.Entities;

public class Game
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public GameGenre Genre { get; set; }

    public int PublisherId { get; set; }
    public Publisher Publisher { get; set; } = default!;
}