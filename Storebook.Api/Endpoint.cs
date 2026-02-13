using Storebook.Api.Endpoints.Livros.AtualizarLivroEndpoint;
using Storebook.Api.Endpoints.Livros.ObterLivroEndpoint;
using Storebook.Application.Livros.ListarLivrosEndpoint;

namespace Storebook;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app
            .MapGroup("/livros")
            .WithTags("Livros")
            .MapEndpoint<AdicionarLivroEndpoint>()
            .MapEndpoint<ObterLivroEndpoint>()
            .MapEndpoint<RemoverLivroEndpoint>()
            .MapEndpoint<ListarLivrosEndpoint>()
            .MapEndpoint<AtualizarLivroEndpoint>();
    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
            where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }

    public interface IEndpoint
    {
        static abstract void Map(IEndpointRouteBuilder app);
    }
}
