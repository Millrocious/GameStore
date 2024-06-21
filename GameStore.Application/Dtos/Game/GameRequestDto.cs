using System.Text.Json.Serialization;
using GameStore.Domain.Enums;

namespace GameStore.Application.Dtos.Game;

public class GameRequestDto
{
    public required string Title { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public GameGenre Genre { get; set; }
    public int PublisherId { get; set; }
}