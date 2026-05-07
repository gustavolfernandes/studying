using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Storebook.Infra.Migrations
{
    /// <inheritdoc />
    public partial class M6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livros");

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PublicationYear = table.Column<int>(type: "int", nullable: false),
                    PageCount = table.Column<int>(type: "int", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Active", "Author", "CreatedOn", "PageCount", "PublicationYear", "Publisher", "StockQuantity", "Title" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), true, "Robert C. Martin", new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 464, 2008, "Prentice Hall", 1, "Clean Code" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), true, "Eric Evans", new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 560, 2003, "Addison-Wesley", 2, "Domain-Driven Design" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), true, "Martin Fowler", new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 448, 1999, "Addison-Wesley", 3, "Refactoring" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), true, "Andrew Hunt", new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 352, 1999, "Addison-Wesley", 4, "The Pragmatic Programmer" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), true, "GoF", new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 395, 1994, "Addison-Wesley", 5, "Design Patterns" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), true, "Robert C. Martin", new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 432, 2017, "Pearson", 6, "Clean Architecture" },
                    { new Guid("77777777-7777-7777-7777-777777777777"), true, "Michael Feathers", new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 456, 2004, "Prentice Hall", 7, "Working Effectively with Legacy Code" },
                    { new Guid("88888888-8888-8888-8888-888888888888"), true, "Martin Fowler", new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 533, 2002, "Addison-Wesley", 8, "Patterns of Enterprise Application Architecture" },
                    { new Guid("99999999-9999-9999-9999-999999999999"), true, "Eric Freeman", new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 694, 2004, "O'Reilly", 9, "Head First Design Patterns" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), true, "Kyle Simpson", new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 278, 2015, "O'Reilly", 10, "You Don’t Know JS" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_Author",
                table: "Books",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Title",
                table: "Books",
                column: "Title",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnoPublicacao = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DataCadastro = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Editora = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    QuantidadeEstoque = table.Column<int>(type: "int", nullable: false),
                    QuantidadePaginas = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Livros",
                columns: new[] { "Id", "AnoPublicacao", "Ativo", "Autor", "DataCadastro", "Editora", "QuantidadeEstoque", "QuantidadePaginas", "Titulo" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), 2008, true, "Robert C. Martin", new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Prentice Hall", 1, 464, "Clean Code" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), 2003, true, "Eric Evans", new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Addison-Wesley", 2, 560, "Domain-Driven Design" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), 1999, true, "Martin Fowler", new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Addison-Wesley", 3, 448, "Refactoring" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), 1999, true, "Andrew Hunt", new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Addison-Wesley", 4, 352, "The Pragmatic Programmer" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), 1994, true, "GoF", new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Addison-Wesley", 5, 395, "Design Patterns" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), 2017, true, "Robert C. Martin", new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Pearson", 6, 432, "Clean Architecture" },
                    { new Guid("77777777-7777-7777-7777-777777777777"), 2004, true, "Michael Feathers", new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Prentice Hall", 7, 456, "Working Effectively with Legacy Code" },
                    { new Guid("88888888-8888-8888-8888-888888888888"), 2002, true, "Martin Fowler", new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Addison-Wesley", 8, 533, "Patterns of Enterprise Application Architecture" },
                    { new Guid("99999999-9999-9999-9999-999999999999"), 2004, true, "Eric Freeman", new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "O'Reilly", 9, 694, "Head First Design Patterns" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), 2015, true, "Kyle Simpson", new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "O'Reilly", 10, 278, "You Don’t Know JS" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livros_Autor",
                table: "Livros",
                column: "Autor");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_Titulo",
                table: "Livros",
                column: "Titulo",
                unique: true);
        }
    }
}
