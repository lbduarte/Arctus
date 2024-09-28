using Arctus.ApiService.DbContexts;
using Arctus.ApiService.DTOs;
using Arctus.ApiService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Arctus.ApiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly ArctusContext _context;

    public BooksController(ArctusContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IAsyncEnumerable<BookResponse> GetBooks()
    {
        return _context.Books.Select(x => x.ToBookResponse()).AsAsyncEnumerable();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBook(long id)
    {
        Book? book = await _context.Books.FindAsync(id);

        if (book == null)
            return NotFound();

        return Ok(book.ToBookResponse());
    }

    [HttpPost]
    public async Task<IActionResult> PostBook(CreateBookRequest request)
    {
        Book book = request.ToBook();
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        BookResponse response = book.ToBookResponse();

        return CreatedAtAction(nameof(GetBook), new { id = response.Id }, response);
    }

    [HttpPut]
    public async Task<IActionResult> PutBook(UpdateBookRequest request)
    {
        Book updatedBook = request.ToBook();
        _context.Update(book);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(long id)
    {
        _context.Books.Remove(new Book()
        {
            Id = id,
            Title = string.Empty
        });

        await _context.SaveChangesAsync();

        return NoContent();
    }
}
