using bookTracker_API.Data;
using bookTracker_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace bookTracker_API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly BookTrackerDbContext _context;

    public BooksController(BookTrackerDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAllBooks()
    {
        var books = _context.Books.ToList();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public IActionResult GetBookById(int id)
    {
        var book = _context.Books.Find(id);
        if (book == null)
        {
            return NotFound();
        }
        return Ok(book);
    }

    [HttpPost]
    public IActionResult AddBook(Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();
        return Ok(book);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, Book book)
    {
        var updatedBook = _context.Books.Find(id);
        if (updatedBook == null)
        {
            return NotFound();
        }
        updatedBook.Title = book.Title;
        updatedBook.Author = book.Author;
        updatedBook.ReleaseYear = book.ReleaseYear;
        updatedBook.Genre = book.Genre;
        updatedBook.IsRead = book.IsRead;
        _context.Books.Update(updatedBook);
        _context.SaveChanges();
        return Ok(updatedBook);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        var book = _context.Books.Find(id);
        if (book == null)
        {
            return NotFound();
        }
        _context.Remove(book);
        _context.SaveChanges();
        return Ok(book);
    }
    
    
}