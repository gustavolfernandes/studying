using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Storebook.Domain.Extensions;

namespace Storebook.Infra;

public sealed partial class StorebookContext : DbContext
{
    private IConfiguration Configuration { get; }

    public StorebookContext(DbContextOptions<StorebookContext> options, IConfiguration configuration) : base(options)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Prevenir ações em cascata para Migrações
        modelBuilder.Model.GetEntityTypes().Where(e => !e.IsOwned())
            .SelectMany(e => e.GetForeignKeys())
            .ForEach(PreventCascade);

        MapLivros(modelBuilder);

        modelBuilder.SeedLivros();
    }

    private void PreventCascade(IMutableForeignKey fk)
    {
        fk.DeleteBehavior = DeleteBehavior.Restrict;
    }
}
