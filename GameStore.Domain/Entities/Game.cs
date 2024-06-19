using GameStore.Domain.Enum;

namespace GameStore.Domain.Entities;

public record Game
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public GameGenre Genre { get; set; }

    public required Publisher Publisher { get; set; }
}