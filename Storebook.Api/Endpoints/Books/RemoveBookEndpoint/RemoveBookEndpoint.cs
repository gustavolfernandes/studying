using Microsoft.AspNetCore.Mvc;
using Storebook.Domain.Entities;
using Storebook.Domain.Interfaces.Repositories;
using Storebook.Domain.Interfaces.UnitOfWork;
using System.ComponentModel.DataAnnotations;
using static Storebook.Endpoint;

namespace Storebook.Api.Endpoints.Books.RemoveBookEndpoint;

public class RemoveBookEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
     => app.MapDelete("/{id}", HandleAsync)
        .WithName("Orders: Delete by id")
        .WithSummary("Remove a book.")
        .WithDescription("Remove a book by id");

    private static async Task<IResult> HandleAsync(
       [FromServices] IBooksRepository bookRepository,
       [FromServices] IUnitOfWork unitOfWork,
       [FromRoute, Required] Guid id)
    {
        var errorMessage = "Book not found.";
        try
        {
            var book = await bookRepository.GetByIdAsync(new BookId(id));

            if (book is null)
                return TypedResults.BadRequest(new Response<Book>(book) { Message = errorMessage });
            else
            {
                book.Remove();

                await unitOfWork.SaveChangesAsync();

                return TypedResults.Ok(new Response<Book>(book) { Message = "Removido com sucesso."});
            }
        }
        catch
        {
            return TypedResults.InternalServerError(new Response<Book>(null) { Message = errorMessage });
        }
    }
}
