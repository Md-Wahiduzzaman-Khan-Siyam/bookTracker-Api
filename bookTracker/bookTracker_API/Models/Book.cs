namespace bookTracker_API.Models;

public class Book
{
    public int Id { get; set; }
    
    public required string Title { get; set; }
    
    public required string Author { get; set; }
    
    public int? ReleaseYear { get; set; }
    
    public required string Genre { get; set; }
    
    public bool IsRead { get; set; }
}