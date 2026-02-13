using Microsoft.AspNetCore.Mvc;
using Storebook.Domain.Entities;
using Storebook.Domain.Interfaces.Repositories;
using System.ComponentModel.DataAnnotations;
using static Storebook.Endpoint;

namespace Storebook.Api.Endpoints.Livros.ObterLivroEndpoint;

public class ObterLivroEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
     => app.MapGet("/{id}", HandleAsync)
        .WithName("Orders: Get by id")
        .WithSummary("Obter livro.")
        .WithDescription("Obter livro pelo id.")
        .Produces<Response<Livro>>();

    private static async Task<IResult> HandleAsync(
       [FromServices] ILivrosRepository livrosRepository,
       [FromRoute, Required] Guid id)
    {
        try
        {
            var livro = await livrosRepository.GetByIdAsync(new LivroId(id));

            if(livro is null)
                return TypedResults.BadRequest(new Response<Livro>(livro) { Message = "Livro não encontrado."});
            else
                return TypedResults.Ok(new Response<Livro>(livro));
        }
        catch
        {
            return TypedResults.InternalServerError(new Response<Livro>(null) { Message = "Não foi possível encontrar o livro." });
        }
    }
}
