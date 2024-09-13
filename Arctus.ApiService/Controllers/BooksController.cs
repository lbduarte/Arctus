using Arctus.ApiService.DbContexts;
using Arctus.ApiService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    public IAsyncEnumerable<Book> GetBooks()
    {
        return _context.Books.AsAsyncEnumerable();
    }

    [HttpGet("{id}")]
    public async Task<Book?> GetBook(long id)
    {
        return await _context.Books.FindAsync(id);
    }

    [HttpPost]
    public async Task SaveBook([FromBody] Book book)
    {
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
    }
}
