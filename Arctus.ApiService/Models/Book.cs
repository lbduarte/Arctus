using Arctus.ApiService.DTOs;

namespace Arctus.ApiService.Models;

public class Book
{
    public long Id { get; set; }
    public required string Title { get; set; }

    public BookResponse ToBookResponse() => new BookResponse
    {
        Id = Id,
        Title = Title
    };
}
