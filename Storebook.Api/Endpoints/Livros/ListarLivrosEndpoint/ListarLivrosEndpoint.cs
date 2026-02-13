using Microsoft.AspNetCore.Mvc;
using Storebook.Api;
using Storebook.Domain.Entities;
using Storebook.Domain.Interfaces.Repositories;
using System.ComponentModel.DataAnnotations;
using static Storebook.Endpoint;

namespace Storebook.Application.Livros.ListarLivrosEndpoint;

public class ListarLivrosEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
     => app.MapGet("/", HandleAsync)
        .WithName("Orders: Get All")
        .WithSummary("Lista todos os livros paginado.")
        .WithDescription("Lista todos os livros com a paginação solicitada.")
        .Produces<PagedResponse<Livro>>();

    private static async Task<IResult> HandleAsync(
       [FromServices] ILivrosRepository livrosRepository,
       [FromQuery, Required, Range(10, 100)] int pageSize,
       [FromQuery, Required] int pageNumber)
    {
        var request = new ListarLivrosRequest(pageSize, pageNumber);

        try
        {
            var livros = await livrosRepository.GetAllPaginatedAsync(request.PageSize * (request.PageNumber - 1), request.PageSize);

            var response = new PagedResponse<Livro[]>(livros)
            {
                CurrentPage = request.PageNumber,
                PageSize = request.PageSize,
                TotalCount = await livrosRepository.CountAllLivros()
            };
            return TypedResults.Ok(response);
        }
        catch
        {
            return TypedResults.InternalServerError(new PagedResponse<Livro[]>(null) { Message = "Não foi possível pesquisar livros."});
        }
    }
}
