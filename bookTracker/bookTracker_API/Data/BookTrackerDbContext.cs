using bookTracker_API.Models;
using Microsoft.EntityFrameworkCore;

namespace bookTracker_API.Data;

public class BookTrackerDbContext: DbContext
{
    public BookTrackerDbContext(DbContextOptions<BookTrackerDbContext> options ) : base(options)
    {
        
    }
    
    public DbSet<Book> Books { get; set; }
}