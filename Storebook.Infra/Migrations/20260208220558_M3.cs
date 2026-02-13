using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Storebook.Infra.Migrations
{
    /// <inheritdoc />
    public partial class M3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuantidadeEstoque",
                table: "Livros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "QuantidadeEstoque",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "QuantidadeEstoque",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "QuantidadeEstoque",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                column: "QuantidadeEstoque",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                column: "QuantidadeEstoque",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"),
                column: "QuantidadeEstoque",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"),
                column: "QuantidadeEstoque",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                column: "QuantidadeEstoque",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                column: "QuantidadeEstoque",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                column: "QuantidadeEstoque",
                value: 10);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantidadeEstoque",
                table: "Livros");
        }
    }
}
