using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Storebook.Infra.Migrations
{
    /// <inheritdoc />
    public partial class M1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Autor = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Editora = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AnoPublicacao = table.Column<int>(type: "int", nullable: false),
                    QuantidadePaginas = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livros_Autor",
                table: "Livros",
                column: "Autor");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_Titulo",
                table: "Livros",
                column: "Titulo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livros");
        }
    }
}
