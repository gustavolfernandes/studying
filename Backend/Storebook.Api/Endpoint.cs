using Storebook.Api.Endpoints.Books.RemoveBookEndpoint;
using Storebook.Api.Endpoints.Books.GetBookEndpoint;
using Storebook.Application.Books.ListBooksEndpoint;
using Storebook.Api.Endpoints.Books.AddBookEndpoint;

namespace Storebook;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app
            .MapGroup("/books")
            .WithTags("Books")
            .MapEndpoint<AddBookEndpoint>()
            .MapEndpoint<GetBookEndpoint>()
            .MapEndpoint<RemoveBookEndpoint>()
            .MapEndpoint<ListBooksEndpoint>()
            .MapEndpoint<UpdateBookEndpoint>();
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
