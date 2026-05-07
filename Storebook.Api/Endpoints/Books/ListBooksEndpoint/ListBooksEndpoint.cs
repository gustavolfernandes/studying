using Microsoft.AspNetCore.Mvc;
using Storebook.Api;
using Storebook.Domain.Entities;
using Storebook.Domain.Interfaces.Repositories;
using System.ComponentModel.DataAnnotations;
using static Storebook.Endpoint;

namespace Storebook.Application.Books.ListBooksEndpoint;

public class ListBooksEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
     => app.MapGet("/", HandleAsync)
        .WithName("Orders: Get All")
        .WithSummary("List all books paginated.")
        .WithDescription("List all books with the requested page")
        .Produces<PagedResponse<Book>>();

    private static async Task<IResult> HandleAsync(
       [FromServices] IBooksRepository booksRepository,
       [FromQuery, Required, Range(10, 100)] int pageSize,
       [FromQuery, Required] int pageNumber)
    {
        var request = new ListBooksRequest(pageSize, pageNumber);

        try
        {
            var books = await booksRepository.GetAllPaginatedAsync(request.PageSize * (request.PageNumber - 1), request.PageSize);

            var response = new PagedResponse<Book[]>(books)
            {
                CurrentPage = request.PageNumber,
                PageSize = request.PageSize,
                TotalCount = await booksRepository.CountAllBooks()
            };
            return TypedResults.Ok(response);
        }
        catch
        {
            return TypedResults.InternalServerError(new PagedResponse<Book[]>(null) { Message = "Books not found."});
        }
    }
}
