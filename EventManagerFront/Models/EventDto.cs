namespace EventManagerFront.Models;
using System.Text.Json.Serialization;


public class EventDto
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    public string Type { get; set; } = "";
    public DateTime Date { get; set; }
    public string Loc { get; set; } = "";
    public string Es { get; set; } = "";
    public int Duration { get; set; }
    public List<ContactDto> Contacts { get; set; } = new();
}