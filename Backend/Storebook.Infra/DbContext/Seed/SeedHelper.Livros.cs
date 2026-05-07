using Microsoft.EntityFrameworkCore;
using Storebook.Domain.Entities;

namespace Storebook.Infra;
public static partial class SeedHelper
{
    public static ModelBuilder SeedBooks(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasData(
            Book.Seed(new BookId(Guid.Parse("11111111-1111-1111-1111-111111111111")), "Clean Code", "Robert C. Martin", "Prentice Hall", 2008, 464, 1),
            Book.Seed(new BookId(Guid.Parse("22222222-2222-2222-2222-222222222222")), "Domain-Driven Design", "Eric Evans", "Addison-Wesley", 2003, 560, 2),
            Book.Seed(new BookId(Guid.Parse("33333333-3333-3333-3333-333333333333")), "Refactoring", "Martin Fowler", "Addison-Wesley", 1999, 448, 3),
            Book.Seed(new BookId(Guid.Parse("44444444-4444-4444-4444-444444444444")), "The Pragmatic Programmer", "Andrew Hunt", "Addison-Wesley", 1999, 352, 4),
            Book.Seed(new BookId(Guid.Parse("55555555-5555-5555-5555-555555555555")), "Design Patterns", "GoF", "Addison-Wesley", 1994, 395, 5),
            Book.Seed(new BookId(Guid.Parse("66666666-6666-6666-6666-666666666666")), "Clean Architecture", "Robert C. Martin", "Pearson", 2017, 432, 6),
            Book.Seed(new BookId(Guid.Parse("77777777-7777-7777-7777-777777777777")), "Working Effectively with Legacy Code", "Michael Feathers", "Prentice Hall", 2004, 456, 7),
            Book.Seed(new BookId(Guid.Parse("88888888-8888-8888-8888-888888888888")), "Patterns of Enterprise Application Architecture", "Martin Fowler", "Addison-Wesley", 2002, 533, 8),
            Book.Seed(new BookId(Guid.Parse("99999999-9999-9999-9999-999999999999")), "Head First Design Patterns", "Eric Freeman", "O'Reilly", 2004, 694, 9),
            Book.Seed(new BookId(Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa")), "You Don’t Know JS", "Kyle Simpson", "O'Reilly", 2015, 278, 10)
        );

        return modelBuilder;
    }
}
