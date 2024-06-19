using GameStore.Domain.Enum;

namespace GameStore.Domain.Entities;

public record Game
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public GameGenre Genre { get; set; }

    public int PublisherId { get; set; }
    public Publisher Publisher { get; set; } = null!;
}