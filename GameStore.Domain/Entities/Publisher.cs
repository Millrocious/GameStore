namespace GameStore.Domain.Entities;

public record Publisher
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Country { get; set; }
    public IList<Game> Games { get; set; } = new List<Game>();

    public DateTime CreatedOn { get; set; } = DateTime.Now;
}