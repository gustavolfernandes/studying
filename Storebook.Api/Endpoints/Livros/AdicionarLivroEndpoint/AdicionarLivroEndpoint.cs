using Microsoft.AspNetCore.Mvc;
using Storebook.Domain.Entities;
using Storebook.Domain.Interfaces.Repositories;
using Storebook.Domain.Interfaces.UnitOfWork;
using System.ComponentModel.DataAnnotations;
using static Storebook.Endpoint;

namespace Storebook.Api.Endpoints.Livros.AtualizarLivroEndpoint;

public class AdicionarLivroEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
     => app.MapPost("/", HandleAsync)
        .WithName("Orders: Adicionar")
        .WithSummary("Adiciona um livro.")
        .WithDescription("Adicionar um livro com todas as suas características.");

    private static async Task<IResult> HandleAsync(
       [FromServices] ILivrosRepository livrosRepository,
       [FromServices] IUnitOfWork unitOfWork,
       [FromBody, Required] AdicionarLivroRequest request)
    {
        try
        {
            var livro = Livro.CadastrarLivro(request.Titulo,
                                             request.Autor,
                                             request.Editora,
                                             request.AnoPublicacao,
                                             request.QuantidadePaginas,
                                             request.QuantidadeEstoque);

            livrosRepository.Add(livro);

            await unitOfWork.SaveChangesAsync();

            return TypedResults.Ok(new Response<Livro>(livro) { Message = "Adicionado com sucesso." });
        }
        catch
        {
            return TypedResults.InternalServerError(new Response<Livro>(null) { Message = "Não foi possível adicionar o livro." });
        }
    }
}
