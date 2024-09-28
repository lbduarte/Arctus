using Arctus.ApiService.Models;

namespace Arctus.ApiService.DTOs;

public class UpdateBookRequest
{
    public long Id { get; set; }
    public required string Title { get; set; }

    public Book ToBook() => new Book
    {
        Id = Id,
        Title = Title
    };
}
