using Microsoft.AspNetCore.Mvc;
using Storebook.Domain.Entities;
using Storebook.Domain.Interfaces.Repositories;
using Storebook.Domain.Interfaces.UnitOfWork;
using System.ComponentModel.DataAnnotations;
using static Storebook.Endpoint;

namespace Storebook.Api.Endpoints.Books.RemoveBookEndpoint;

public class UpdateBookEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
     => app.MapPut("/{id}", HandleAsync)
        .WithName("Orders: Update by id")
        .WithSummary("Update a book by id.")
        .WithDescription("Update a book sending only the information that needs to be changed");

    private static async Task<IResult> HandleAsync(
       [FromServices] IBooksRepository booksRepository,
       [FromServices] IUnitOfWork unitOfWork,
       [FromRoute, Required] Guid id,
       [FromBody] BookDto bookDto)
    {
        var errorMessage = "Book not found";
        try
        {
            var book = await booksRepository.GetByIdAsync(new BookId(id));

            if (book is null)
                return TypedResults.BadRequest(new Response<Book>(book) { Message = errorMessage });
            else
            {
                book.EditBook(bookDto.Title,
                                  bookDto.Author,
                                  bookDto.Publisher,
                                  bookDto.PublicationYear,
                                  bookDto.PageCount,
                                  bookDto.StockQuantity);

                await unitOfWork.SaveChangesAsync();

                return TypedResults.Ok(new Response<Book>(book) { Message = "Successfully updated." });
            }
        }
        catch
        {
            return TypedResults.InternalServerError(new Response<Book>(null) { Message = errorMessage });
        }
    }
}
