using Microsoft.EntityFrameworkCore;
using Storebook.Domain.Entities;

namespace Storebook.Infra;

public sealed partial class StorebookContext : DbContext
{
    public DbSet<Book> Books { get; set; } = default!;
    private static void MapBooks(ModelBuilder model)
    {
        model.Entity<Book>(map =>
        {
            map.Property(l => l.Id).HasStronglyTypedIdConversion().ValueGeneratedOnAdd();
            map.Property(l => l.Title)
                   .HasMaxLength(200)
                   .IsRequired();

            map.Property(l => l.Author)
                   .HasMaxLength(150)
                   .IsRequired();

            map.Property(l => l.Publisher)
                   .HasMaxLength(100)
                   .IsRequired();

            map.Property(l => l.PublicationYear)
                   .IsRequired();

            map.Property(l => l.PageCount)
                   .IsRequired();

            map.Property(l => l.StockQuantity)
                   .IsRequired();

            map.Property(l => l.CreatedOn)
                   .IsRequired();

            map.Property(l => l.Active)
                   .IsRequired();

            map.HasIndex(l => l.Title).IsUnique();
            map.HasIndex(l => l.Author);
        });
    }
}