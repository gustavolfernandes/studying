using Microsoft.AspNetCore.Mvc;
using Storebook.Domain.Entities;
using Storebook.Domain.Interfaces.Repositories;
using Storebook.Domain.Interfaces.UnitOfWork;
using System.ComponentModel.DataAnnotations;
using static Storebook.Endpoint;

namespace Storebook.Api.Endpoints.Livros.AtualizarLivroEndpoint;

public class RemoverLivroEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
     => app.MapDelete("/{id}", HandleAsync)
        .WithName("Orders: Delete by id")
        .WithSummary("Remove um livro.")
        .WithDescription("Remover um livro pelo id");

    private static async Task<IResult> HandleAsync(
       [FromServices] ILivrosRepository livrosRepository,
       [FromServices] IUnitOfWork unitOfWork,
       [FromRoute, Required] Guid id)
    {
        try
        {
            var livro = await livrosRepository.GetByIdAsync(new LivroId(id));

            if (livro is null)
                return TypedResults.BadRequest(new Response<Livro>(livro) { Message = "Livro não encontrado." });
            else
            {
                livro.Remover();

                await unitOfWork.SaveChangesAsync();

                return TypedResults.Ok(new Response<Livro>(livro) { Message = "Removido com sucesso."});
            }
        }
        catch
        {
            return TypedResults.InternalServerError(new Response<Livro>(null) { Message = "Não foi possível remover o livro." });
        }
    }
}
