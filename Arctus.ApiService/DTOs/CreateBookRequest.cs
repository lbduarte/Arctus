using Arctus.ApiService.Models;

namespace Arctus.ApiService.DTOs;

public class CreateBookRequest
{
    public required string Title { get; set; }

    public Book ToBook() => new Book { Title = Title };
}
