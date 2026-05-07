using Microsoft.AspNetCore.Mvc;
using Storebook.Domain.Entities;
using Storebook.Domain.Interfaces.Repositories;
using Storebook.Domain.Interfaces.UnitOfWork;
using System.ComponentModel.DataAnnotations;
using static Storebook.Endpoint;

namespace Storebook.Api.Endpoints.Books.AddBookEndpoint;

public class AddBookEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
     => app.MapPost("/", HandleAsync)
        .WithName("Orders: Add")
        .WithSummary("Add a book.")
        .WithDescription("Add a book with all features");

    private static async Task<IResult> HandleAsync(
       [FromServices] IBooksRepository booksRepository,
       [FromServices] IUnitOfWork unitOfWork,
       [FromBody, Required] BookDto request)
    {
        try
        {
            var book = Book.CreateBook(request.Title,
                                             request.Author,
                                             request.Publisher,
                                             request.PublicationYear,
                                             request.PageCount,
                                             request.StockQuantity);

            booksRepository.Add(book);

            await unitOfWork.SaveChangesAsync();

            return TypedResults.Ok(new Response<Book>(book) { Message = "Successfully added." });
        }
        catch
        {
            return TypedResults.InternalServerError(new Response<Book>(null) { Message = "Not possible add a book." });
        }
    }
}
