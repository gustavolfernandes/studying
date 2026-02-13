using Microsoft.EntityFrameworkCore;
using Storebook.Domain.Entities;

namespace Storebook.Infra;

public sealed partial class StorebookContext : DbContext
{
    public DbSet<Livro> Livros { get; set; } = default!;
    private static void MapLivros(ModelBuilder model)
    {
        model.Entity<Livro>(map =>
        {
            map.Property(l => l.Id).HasStronglyTypedIdConversion().ValueGeneratedOnAdd();
            map.Property(l => l.Titulo)
                   .HasMaxLength(200)
                   .IsRequired();

            map.Property(l => l.Autor)
                   .HasMaxLength(150)
                   .IsRequired();

            map.Property(l => l.Editora)
                   .HasMaxLength(100)
                   .IsRequired();

            map.Property(l => l.AnoPublicacao)
                   .IsRequired();

            map.Property(l => l.QuantidadePaginas)
                   .IsRequired();

            map.Property(l => l.QuantidadeEstoque)
                   .IsRequired();

            map.Property(l => l.DataCadastro)
                   .IsRequired();

            map.Property(l => l.Ativo)
                   .IsRequired();

            map.HasIndex(l => l.Titulo).IsUnique();
            map.HasIndex(l => l.Autor);
        });
    }
}