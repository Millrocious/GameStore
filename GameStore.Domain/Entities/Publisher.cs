namespace GameStore.Domain.Entities;

public class Publisher
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Country { get; set; }
    
    public IList<Game> Games { get; set; } = [];
}