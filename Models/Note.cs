namespace Notes.Api.Models;

public class Note 
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime TimeCreated { get; set; }
}