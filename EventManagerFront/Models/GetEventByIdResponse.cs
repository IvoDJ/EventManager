namespace EventManagerFront.Models;
using System.Text.Json.Serialization;

public class GetEventByIdResponse
{
    [JsonPropertyName("e")]
    public EventDto E { get; set; } = new();
}