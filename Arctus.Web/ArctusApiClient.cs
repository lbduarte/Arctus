using Arctus.Web.Models;

namespace Arctus.Web;

public class ArctusApiClient(HttpClient httpClient)
{
    public async Task<Book[]> GetBooksAsync(int maxItems = 10, CancellationToken cancellationToken = default)
    {
        List<Book>? books = null;

        await foreach (var book in httpClient.GetFromJsonAsAsyncEnumerable<Book>("/api/books", cancellationToken))
        {
            if (books?.Count >= maxItems)
            {
                break;
            }
            if (book is not null)
            {
                books ??= [];
                books.Add(book);
            }
        }

        return books?.ToArray() ?? [];
    }
}
