using Microsoft.AspNetCore.Mvc;
using Storebook.Domain.Entities;
using Storebook.Domain.Interfaces.Repositories;
using System.ComponentModel.DataAnnotations;
using static Storebook.Endpoint;

namespace Storebook.Api.Endpoints.Books.GetBookEndpoint;

public class GetBookEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
     => app.MapGet("/{id}", HandleAsync)
        .WithName("Orders: Get by id")
        .WithSummary("Get book.")
        .WithDescription("Get book by id.")
        .Produces<Response<Book>>();

    private static async Task<IResult> HandleAsync(
       [FromServices] IBooksRepository booksRepository,
       [FromRoute, Required] Guid id)
    {
        var errorMessage = "Book not found.";
        try
        {
            var book = await booksRepository.GetByIdAsync(new BookId(id));

            if(book is null)
                return TypedResults.BadRequest(new Response<Book>(book) { Message = errorMessage});
            else
                return TypedResults.Ok(new Response<Book>(book));
        }
        catch
        {
            return TypedResults.InternalServerError(new Response<Book>(null) { Message = errorMessage});
        }
    }
}
