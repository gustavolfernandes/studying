using Microsoft.AspNetCore.Mvc;
using Storebook.Domain.Entities;
using Storebook.Domain.Interfaces.Repositories;
using Storebook.Domain.Interfaces.UnitOfWork;
using System.ComponentModel.DataAnnotations;
using static Storebook.Endpoint;

namespace Storebook.Api.Endpoints.Livros.AtualizarLivroEndpoint;

public class AtualizarLivroEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
     => app.MapPut("/{id}", HandleAsync)
        .WithName("Orders: Update by id")
        .WithSummary("Atualize um livro pelo id.")
        .WithDescription("Atualize um livro enviando apenas as informações a serem atualizadas.");

    private static async Task<IResult> HandleAsync(
       [FromServices] ILivrosRepository livrosRepository,
       [FromServices] IUnitOfWork unitOfWork,
       [FromRoute, Required] Guid id,
       [FromBody] AtualizarLivroRequest atualizarLivroRequest)
    {
        try
        {
            var livro = await livrosRepository.GetByIdAsync(new LivroId(id));

            if (livro is null)
                return TypedResults.BadRequest(new Response<Livro>(livro) { Message = "Livro não encontrado." });
            else
            {
                livro.EditarLivro(atualizarLivroRequest.Titulo,
                                  atualizarLivroRequest.Autor,
                                  atualizarLivroRequest.Editora,
                                  atualizarLivroRequest.AnoPublicacao,
                                  atualizarLivroRequest.QuantidadePaginas,
                                  atualizarLivroRequest.QuantidadeEstoque);

                await unitOfWork.SaveChangesAsync();

                return TypedResults.Ok(new Response<Livro>(livro) { Message = "Atualizado com sucesso."});
            }
        }
        catch
        {
            return TypedResults.InternalServerError(new Response<Livro>(null) { Message = "Não foi possível atualizar o livro." });
        }
    }
}
