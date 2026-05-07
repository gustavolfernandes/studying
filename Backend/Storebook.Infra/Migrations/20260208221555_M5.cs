using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Storebook.Infra.Migrations
{
    /// <inheritdoc />
    public partial class M5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Livros_Titulo",
                table: "Livros");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_Titulo",
                table: "Livros",
                column: "Titulo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Livros_Titulo",
                table: "Livros");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_Titulo",
                table: "Livros",
                column: "Titulo");
        }
    }
}
